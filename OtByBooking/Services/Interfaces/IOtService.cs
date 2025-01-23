using OtByBooking.Models.DTOs;
namespace OtByBooking.Services.Interfaces;

public interface IOtService
{    
    MessageInfoDTO<List<TResult>> GetOtsByBookingCodeV3<TResult>(IViewBuilder<TResult, OtDTO> viewBuilder);
    MessageInfoDTO<string> GetDetailsByOtCode(string code);
}
