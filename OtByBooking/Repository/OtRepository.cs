using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OtByBooking.Models.DTOs;
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
}
