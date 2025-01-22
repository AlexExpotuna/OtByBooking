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
            return messageInfoDTO;
        }
        catch(Exception ex)
        {
            messageInfoDTO.Message = ex.Message;
            return messageInfoDTO;
        }
    }

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
                result += ot.GetOTHeaderResult(otList.Count);
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
    //public MessageInfoDTO<DataRowCollection> GetOtsByBookingCodeV2(string booking)
    //{
    //    MessageInfoDTO<DataRowCollection> messageInfoDTO = new();
    //    try
    //    {
    //        List<DataRow> result = [];
    //        List<OT> otList = _repository.GetOTsByBookingCode(booking);
    //        if (otList.Count <= 0)
    //        {
    //            messageInfoDTO.Message = "No hay OTs registradas";
    //            return messageInfoDTO;
    //        }
    //        foreach (OT ot in otList)
    //        {
    //            result.Rows.Add(
    //            [
    //                ot.Code, ot.State, string.Empty
    //            ]);
    //        }
    //        messageInfoDTO.Success = true;
    //        messageInfoDTO.Result = result.Rows;
    //        return messageInfoDTO;
    //    }
    //    catch (Exception ex)
    //    {
    //        messageInfoDTO.Message = ex.Message;
    //        return messageInfoDTO;
    //    }
    //}
}
