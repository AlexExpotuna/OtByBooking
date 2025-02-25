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
        using SqlConnection sqlConnection = new(ConnectionString);
        using SqlCommand command = new("select _ITEMDOCUMENTO, _COSTONETO, _RECIBIDA from vst_ot_details where NORDEN = @otCode", sqlConnection);
        SqlParameter parameter2 = new("@otCode", System.Data.SqlDbType.VarChar)
        {
            Value = code
        };
        command.Parameters.Add(parameter2);
        sqlConnection.Open();
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read()) 
        {
            string enableFactura = reader.GetValue(2).ToString()!;
            results.Add(new OtDetail()
            {
                Description = reader.GetValue(0).ToString() ?? string.Empty,
                Amount = reader.GetValue(1).ToString() ?? "0",
                IsPending = reader.GetValue(2).ToString(),
            });
        }
        reader.Close();
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
        reader.Close();
        sqlConnection.Close();
        sqlConnection.Dispose();
        return results;
    }

}
