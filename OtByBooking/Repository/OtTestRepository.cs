using OtByBooking.Models.Entities;
using OtByBooking.Repository.Interfaces;

namespace OtByBooking.Repository;

public class OtTestRepository : IOtRepository
{
    public List<OtDetail> GetOtDetails(string code)
    {
        return [
            new OtDetail(){
                    InvoiceNumber = "001-001-00000001",
                    Amount = "7500"
                },
            new OtDetail(){
                    InvoiceNumber = "001-002-00000001",
                    Amount = "100000"
                },
            new OtDetail(){
                    InvoiceNumber = "001-002-00000002",
                    Amount = "50000"
                }
        ];
    }

    public List<OT> GetOTsByBookingCode(string booking)
    {
        return [
            new OT(){
                Code = "OT-759684",
                State = "APROBADO",
                Provider = "PROVEEDOR A"
            },
            new OT(){
                Code = "OT-824556",
                State = "POR APROBAR",
                Provider = "PROVEEDOR B"
            }
        ];
    }
}
