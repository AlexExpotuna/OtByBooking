using OtByBooking.Repository.Interfaces;
namespace OtByBooking;

public partial class OtByBooking : Form
{
    private readonly IOtRepository _repository;
    public OtByBooking(IOtRepository repository)
    {
        InitializeComponent();
        _repository = repository;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        
        otTextField.Text = string.Empty;
        message.Text = string.Empty;
    }
    private void buttonCopy_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(otTextField.Text))
        {
            buttonCopy.Text = "Copiado";
            message.Text = "La OT ya está en tu portapapeles, presiona ctrl + v";
            SwapClipboardHtmlText(otTextField.Text);
        }
    }
    private void searchOT_Click(object sender, EventArgs e)
    {
        buttonCopy.Text = "Copiado";
        button1.Enabled = false;
        button1.Focus();

        var ot = _repository.GetOTByBookingCode(bookingTextField.Text.Trim());
        if (ot.Success)
        {
            otTextField.Text = ot.Result;
            message.Text = "La OT ya está en tu portapapeles, presiona ctrl + v";
            SwapClipboardHtmlText(otTextField.Text);
        }
        else
        {
            MessageBox.Show(ot.Message);
            buttonCopy.Text = "Copiar";
        }
        button1.Enabled = true;
        bookingTextField.Focus();
    }
    public static string SwapClipboardHtmlText(string replacementHtmlText)
    {
        string returnHtmlText = string.Empty;
        if (Clipboard.ContainsText(TextDataFormat.Text) && !string.IsNullOrEmpty(replacementHtmlText))
        {
            Clipboard.SetText(replacementHtmlText, TextDataFormat.Text);
        }
        return returnHtmlText;
    }
}
