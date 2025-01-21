using OtByBooking.Models.DTOs;
using OtByBooking.Models.Entities;
using OtByBooking.Repository.Interfaces;
using OtByBooking.Services.Interfaces;
namespace OtByBooking.Services;
public class OtService(IOtRepository otRepository) : IOtService
{
    private readonly IOtRepository _repository = otRepository; 
    public MessageInfoDTO<string> GetOtsByBookingCode(string booking)
    {
        MessageInfoDTO<string> messageInfoDTO = new();
        try
        {
            string result = string.Empty;
            List<OT> otList = _repository.GetOTsByBookingCode(booking);
            if(otList.Count <= 0)
            {
                messageInfoDTO.Message = "No hay OTs registradas";
                return messageInfoDTO;
            }
            foreach (OT ot in otList)
            {
                result += ot.Code + (otList.Count > 1 ? Environment.NewLine : string.Empty);
            }
            messageInfoDTO.Success = true;
            messageInfoDTO.Result = result;
            return messageInfoDTO;
        }
        catch(Exception ex) {
            messageInfoDTO.Message = ex.Message;
            return messageInfoDTO;
        }
    }
}
