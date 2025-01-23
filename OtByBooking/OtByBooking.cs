using OtByBooking.Services.Interfaces;
namespace OtByBooking;

public partial class OtByBooking : Form
{
    private readonly IOtService _service;
    //private readonly IClipboardService _clipboardService;
    public OtByBooking(IOtService service)
    {
        InitializeComponent();
        _service = service;
        //_clipboardService = clipboardService;
    }
    private void searchOT_Click(object sender, EventArgs e)
    {
        button1.Enabled = false;
        button1.Focus();
        var newOts = _service.GetOtsByBookingCodeV2(bookingTextField.Text.Trim());
        if (newOts.Success)
        {
            otDataGridView.Rows.AddRange([.. newOts.Result!]);
            otDataGridView.Refresh();
        }
        else
        {
            MessageBox.Show(newOts.Message);
        }
        button1.Enabled = true;
        bookingTextField.Focus();
    }
    private void otDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if(e.RowIndex > -1 && e.ColumnIndex == 2)
        {
            var otCode = otDataGridView.Rows[e.RowIndex].Cells[0];
            var otDetails = _service.GetDetailsByOtCode(otCode.Value.ToString()!);
            if (otDetails.Success)
            {
                MessageBox.Show(otDetails.Result!);
            }
            else
            {
                MessageBox.Show(otDetails.Message);
            }
            bookingTextField.Focus();
        }
    }
}