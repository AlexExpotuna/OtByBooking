using OtByBooking.Services.Interfaces;

namespace OtByBooking.Models.DTOs;

public class OtDTO: IDto
{
    public string Code { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;

    public TModel ToModel<TModel>()
    {
        throw new NotImplementedException();
    }

    //public void SetToDto(OT oT)
    //{
    //    Description = oT.Code;
    //}
}
