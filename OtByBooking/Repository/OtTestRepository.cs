using OtByBooking.Models.DTOs;
using OtByBooking.Models.Entities;
using OtByBooking.Repository.Interfaces;

namespace OtByBooking.Repository;

public class OtTestRepository : IOtRepository
{
    public List<OT> GetOTsByBookingCode(string booking)
    {
        return [
            new OT(){
                Description = "OT-759684"
            },
            new OT(){
                Description = "OT-824556"
            }
            ];
    }
}
