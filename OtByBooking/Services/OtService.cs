using OtByBooking.Models.DTOs;
using OtByBooking.Models.Entities;
using OtByBooking.Repository.Interfaces;
using OtByBooking.Services.Interfaces;
namespace OtByBooking.Services;
public class OtService(IOtRepository otRepository) : IOtService
{
    private readonly IOtRepository _repository = otRepository;
    public MessageInfoDTO<string> GetDetailsByOtCode(string code)
    {
        MessageInfoDTO<string> messageInfoDTO = new();
        try
        {
            var details = _repository.GetOtDetails(code);
            if (details.Count <= 0)
            {
                return new(){
                    Message = "No se encontraron detalles"
                };
            }
            else
            {
                messageInfoDTO.Success = true;
                messageInfoDTO.Result = string.Join(Environment.NewLine, details.Select(dt => $"Factura: {dt.InvoiceNumber} Monto: {dt.Amount}"));
            }
            return messageInfoDTO;
        }
        catch(Exception ex)
        {
            messageInfoDTO.Message = ex.Message;
            return messageInfoDTO;
        }
    }
    public MessageInfoDTO<List<DataGridViewRow>> GetOtsByBookingCodeV2(string booking)
    {
        MessageInfoDTO<List<DataGridViewRow>> messageInfoDTO = new();
        try
        {
            List<DataGridViewRow> results = [];
            List<OT> otList = _repository.GetOTsByBookingCode(booking);
            if (otList.Count <= 0)
            {
                messageInfoDTO.Message = "No hay OTs registradas";
                return messageInfoDTO;
            }
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
            messageInfoDTO.Success = true;
            messageInfoDTO.Result = results;
            return messageInfoDTO;
        }
        catch (Exception ex)
        {
            messageInfoDTO.Message = ex.Message;
            return messageInfoDTO;
        }
    }

    //IViewBuilder<List<DataGridViewRow>, List<OT>>
    public MessageInfoDTO<List<TResult>> GetOtsByBookingCodeV3<TResult>(IViewBuilder<TResult, OtDTO> viewBuilder)
    {
        MessageInfoDTO<List<TResult>> messageInfoDTO = new();
        try
        {
            viewBuilder.AddRepository(_repository);
            List<TResult> results = [];
            List<OtDTO> otList = viewBuilder.GetModels();
            if (otList.Count <= 0)
            {
                messageInfoDTO.Message = "No hay OTs registradas";
                return messageInfoDTO;
            }
            messageInfoDTO.Success = true;
            messageInfoDTO.Result = viewBuilder.Build(otList);
            return messageInfoDTO;
        }
        catch (Exception ex)
        {
            messageInfoDTO.Message = ex.Message;
            return messageInfoDTO;
        }
    }

}
