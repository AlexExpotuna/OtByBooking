using OtByBooking.Models.DTOs;
namespace OtByBooking.Services.Interfaces;

public interface IOtService
{
    MessageInfoDTO<List<DataGridViewRow>> GetOtsByBookingCodeV2(string booking);
    MessageInfoDTO<string> GetDetailsByOtCode(string code);
}
