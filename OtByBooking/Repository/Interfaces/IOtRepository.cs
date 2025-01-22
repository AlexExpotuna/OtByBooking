using OtByBooking.Models.DTOs;
using OtByBooking.Models.Entities;

namespace OtByBooking.Repository.Interfaces;

public interface IOtRepository
{
    List<OtDetail> GetOtDetails(string code);
    List<OT> GetOTsByBookingCode(string booking);
}
