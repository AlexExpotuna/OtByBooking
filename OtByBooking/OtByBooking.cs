using OtByBooking.Services.Interfaces;
namespace OtByBooking;

public partial class OtByBooking : Form
{
    private readonly IOtService _repository;
    private readonly IClipboardService _clipboardService;
    public OtByBooking(IOtService repository, IClipboardService clipboardService)
    {
        InitializeComponent();
        _repository = repository;
        _clipboardService = clipboardService;
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
            _clipboardService.CopyToClipboard(otTextField.Text);
        }
    }
    private void searchOT_Click(object sender, EventArgs e)
    {
        buttonCopy.Text = "Copiado";
        button1.Enabled = false;
        button1.Focus();

        var ot = _repository.GetOtsByBookingCode(bookingTextField.Text.Trim());
        if (ot.Success)
        {
            otTextField.Text = ot.Result;
            message.Text = "La OT ya está en tu portapapeles, presiona ctrl + v";
            _clipboardService.CopyToClipboard(otTextField.Text);
        }
        else
        {
            MessageBox.Show(ot.Message);
            buttonCopy.Text = "Copiar";
        }
        button1.Enabled = true;
        bookingTextField.Focus();
    }
}
