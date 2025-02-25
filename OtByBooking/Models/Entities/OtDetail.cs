namespace OtByBooking.Models.Entities;

public class OtDetail
{
    //public string OtCode { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Amount { get; set; } = string.Empty;
    public string? IsPending { get; internal set; }
    //public OT OT { get; set; } = null!;
}
