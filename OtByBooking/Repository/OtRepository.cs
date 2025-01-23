using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OtByBooking.Models.Entities;
using OtByBooking.Repository.Interfaces;
namespace OtByBooking.Repository;

public class OtRepository : IOtRepository
{
    private readonly IConfiguration _configuration;
    private readonly string ConnectionString;
    public OtRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        ConnectionString = _configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Key: \"DefaultConnection\" not found");
    }
    public List<OtDetail> GetOtDetails(string code)
    {
        List<OtDetail> results = [];
        const string TYPE_DOCUMENT = "ORDEN TRABAJO";
        using SqlConnection sqlConnection = new(ConnectionString);
        using SqlCommand command = new("select _ITEMDOCUMENTO, _COSTONETO from vst_orden_presupuesto_cont_report_ex where _TIPODOCUMENT = @typeDocument AND NORDEN = @otCode", sqlConnection);
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
        sqlConnection.Close();
        sqlConnection.Dispose();
        return results;
    }
    public List<OT> GetOTsByBookingCode(string booking)
    {
        List<OT> results = [];
        using SqlConnection sqlConnection = new(ConnectionString);
        using SqlCommand command = new("EXEC BuscarBooking @bk", sqlConnection);
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
                Provider = reader.GetValue(2).ToString() ?? string.Empty
            };
            results.Add(oT);
        }
        sqlConnection.Close();
        sqlConnection.Dispose();
        return results;
    }

}
