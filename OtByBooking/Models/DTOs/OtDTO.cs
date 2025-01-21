using OtByBooking.Models.Entities;

namespace OtByBooking.Models.DTOs;

public class OtDTO
{
    public string Description { get; set; } = string.Empty;
    public void SetToDto(OT oT)
    {
        Description = oT.Code;
    }
}
