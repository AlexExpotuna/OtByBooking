using OtByBooking.Models.Entities;
using OtByBooking.Repository.Interfaces;
using OtByBooking.Services.Interfaces;

namespace OtByBooking.Services;

public class DataGridViewOTView(
    //IOtRepository otRepository,
    string booking) : IViewBuilder<DataGridViewRow, OT>
{
    private readonly string Booking = booking;
    private IOtRepository? _repository { get; set; }

    public void AddRepository(IOtRepository repository)
    {
        _repository = repository;
    }

    public List<DataGridViewRow> Build(List<OT> otList)
    {
        List<DataGridViewRow> results = [];
        foreach (OT ot in otList)
        {
            DataGridViewRow row = new();
            row.Cells.AddRange([
                new DataGridViewTextBoxCell(){
                        Value = ot.Code
                    },
                    new DataGridViewTextBoxCell(){
                        Value = ot.State
                    },
                    new DataGridViewButtonCell()
                    {
                        Value = "Click",
                    }
            ]);
            results.Add(row);
        }
        return results;
    }

    public List<OT> GetModels()
    {
        return _repository?.GetOTsByBookingCode(Booking) ?? throw new Exception("View must have repository");
    }
}
