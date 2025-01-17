using OtByBooking.Models.DTOs;
using OtByBooking.Repository.Interfaces;

namespace OtByBooking.Services.Interfaces;

public interface IOtService
{
    MessageInfoDTO<string> GetOtsByBookingCode(string booking);
}
