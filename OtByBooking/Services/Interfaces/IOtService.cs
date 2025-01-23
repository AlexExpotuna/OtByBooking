using OtByBooking.Models.DTOs;
using OtByBooking.Models.Entities;
namespace OtByBooking.Services.Interfaces;

public interface IOtService
{
    MessageInfoDTO<List<DataGridViewRow>> GetOtsByBookingCodeV2(string booking);
    MessageInfoDTO<List<TResult>> GetOtsByBookingCodeV3<TResult>(IViewBuilder<TResult, OT> viewBuilder);
    MessageInfoDTO<string> GetDetailsByOtCode(string code);
}
