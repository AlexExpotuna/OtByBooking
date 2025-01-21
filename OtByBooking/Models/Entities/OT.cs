namespace OtByBooking.Models.Entities;

public class OT
{
    public string Code { get; set; } = string.Empty;
    public string State {  get; set; } = string.Empty;
    public List<OtDetail> Details { get; set; } = [];
}
