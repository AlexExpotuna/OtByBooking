namespace OtByBooking.Models.Entities;

public class OT
{
    public string Code { get; set; } = string.Empty;
    public string State {  get; set; } = string.Empty;
    public List<OtDetail> Details { get; set; } = [];

    public string GetOTHeaderResult(int oTsAmount)
    {
        return Code + (oTsAmount > 1 ? Environment.NewLine : string.Empty);
    }
}
