using OtByBooking.Models.DTOs;

namespace OtByBooking.Repository.Interfaces;

public interface IOtRepository
{
    MessageInfoDTO<string> GetOTByBookingCode(string booking);
}
