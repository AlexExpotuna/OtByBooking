using OtByBooking.Models.DTOs;
using OtByBooking.Models.Entities;

namespace OtByBooking.Repository.Interfaces;

public interface IOtRepository
{
    List<OT> GetOTsByBookingCode(string booking);
}
