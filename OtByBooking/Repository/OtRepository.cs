using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OtByBooking.Models.DTOs;
using OtByBooking.Models.Entities;
using OtByBooking.Repository.Interfaces;

namespace OtByBooking.Repository;

public class OtRepository(IConfiguration configuration) : IOtRepository
{
    private readonly IConfiguration _configuration = configuration;
    public MessageInfoDTO<string> GetOTByBookingCode(string booking)
    {
        string connectionString = _configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Key: \"DefaultConnection\" not found");
        string result = $"OT no encontrado por el booking: {booking}";
        MessageInfoDTO<string> resultQuery = new();
        using SqlConnection sqlConnection = new(connectionString);
        using SqlCommand command = new("EXEC BuscarBooking @bk", sqlConnection);//sqlConnection.CreateCommand();
        try
        {
            SqlParameter parameter = new("@bk", System.Data.SqlDbType.VarChar)
            {
                Value = booking
            };
            command.Parameters.Add(parameter);
            sqlConnection.Open();
            SqlDataReader reader = command.ExecuteReader();
            
            if (reader.HasRows && reader.Read())
            {
                resultQuery.Success = true;
                resultQuery.Result = reader[0].ToString();
            }
            else
            {
                resultQuery.Success = false;
                resultQuery.Message = result;
            }
            sqlConnection.Close();
            return resultQuery;
        }
        catch (Exception ex) {
            sqlConnection.Dispose();
            return new()
            {
                Success = false,
                Message = ex.Message
            };
        }
        
    }

    public List<OtDetail> GetOtDetails(string code)
    {
        List<OtDetail> results = [];
        const string TYPE_DOCUMENT = "ORDEN TRABAJO";
        string connectionString = _configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Key: \"DefaultConnection\" not found");
        using SqlConnection sqlConnection = new(connectionString);
        using SqlCommand command = new("select _ENABLEFACTURA, _VALORTOTALFACTFAC from vst_orden_presupuesto_cont_report_ex where _TIPODOCUMENT = @typeDocument AND NORDEN = @otCode", sqlConnection);//sqlConnection.CreateCommand();
        SqlParameter parameter = new("@typeDocument", System.Data.SqlDbType.VarChar)
        {
            Value = TYPE_DOCUMENT
        };
        SqlParameter parameter2 = new("@otCode", System.Data.SqlDbType.VarChar)
        {
            Value = code
        };
        command.Parameters.AddRange([parameter, parameter2]);
        sqlConnection.Open();
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read()) 
        {
            results.Add(new OtDetail()
            {
                InvoiceNumber = reader.GetValue(0).ToString() ?? string.Empty,
                Amount = reader.GetValue(1).ToString() ?? "0",
            });
        }
        return results;
    }
    public List<OT> GetOTsByBookingCode(string booking)
    {
        List<OT> results = [];
        string connectionString = _configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Key: \"DefaultConnection\" not found");
        using SqlConnection sqlConnection = new(connectionString);
        using SqlCommand command = new("EXEC BuscarBooking @bk", sqlConnection);//sqlConnection.CreateCommand();
        SqlParameter parameter = new("@bk", System.Data.SqlDbType.VarChar)
        {
            Value = booking
        };
        command.Parameters.Add(parameter);
        sqlConnection.Open();
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            OT oT = new()
            {
                Code = reader.GetValue(0).ToString() ?? string.Empty,
                State = reader.GetValue(1).ToString() ?? string.Empty,
            };
            results.Add(oT);
        }
        sqlConnection.Close();
        sqlConnection.Dispose();
        return results;
    }

}
