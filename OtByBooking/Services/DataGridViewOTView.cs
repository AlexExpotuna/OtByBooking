using OtByBooking.Models.DTOs;
using OtByBooking.Repository.Interfaces;
using OtByBooking.Services.Interfaces;

namespace OtByBooking.Services;

public class DataGridViewOTView(
    string booking) : IViewBuilder<DataGridViewRow, OtDTO>
{
    private readonly string Booking = booking;
    private IOtRepository? _repository { get; set; }

    public void AddRepository(IOtRepository repository)
    {
        _repository = repository;
    }

    public List<DataGridViewRow> Build(List<OtDTO> otList)
    {
        List<DataGridViewRow> results = [];
        foreach (OtDTO ot in otList)
        {
            DataGridViewRow row = new();
            row.Cells.AddRange([
                new DataGridViewTextBoxCell(){
                        Value = ot.Code
                    },
                    new DataGridViewTextBoxCell(){
                        Value = ot.State
                    },
                    new DataGridViewTextBoxCell(){
                        Value = ot.Provider
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

    public List<OtDTO> GetModels()
    {
        return _repository?.GetOTsByBookingCode(Booking).Select(x => new OtDTO
        {
            Code = x.Code,
            State = x.State,
            Provider = x.Provider
        }).ToList() ?? throw new Exception("View must have repository");
    }
}
