using OtByBooking.Services.Interfaces;

namespace OtByBooking.Services;

public class ClipboardService: IClipboardService
{
    public void CopyToClipboard(string replacementHtmlText)
    {
        if (Clipboard.ContainsText(TextDataFormat.Text) && !string.IsNullOrEmpty(replacementHtmlText))
        {
            Clipboard.SetText(replacementHtmlText, TextDataFormat.Text);
        }        
    }
}
