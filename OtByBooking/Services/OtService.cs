using OtByBooking.Models.DTOs;
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
                messageInfoDTO.Result = string.Join(Environment.NewLine, details.Select(dt => $"Descripcion: {dt.Description} | Recibida: {dt.IsPending} | Costo: {dt.Amount} "));
            }
            return messageInfoDTO;
        }
        catch(Exception ex)
        {
            messageInfoDTO.Message = ex.Message;
            return messageInfoDTO;
        }
    }
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
