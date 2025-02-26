using OtByBooking.Models.DTOs;
using OtByBooking.Services;
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
    private void SearchBooking()
    {
        button1.Enabled = false;
        button1.Focus();
        IViewBuilder<DataGridViewRow, OtDTO> windowsForm = new DataGridViewOTView(bookingTextField.Text.Trim());
        var newOts = _service.GetOtsByBookingCodeV3(windowsForm);
        otDataGridView.Rows.Clear();
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

    private void searchOT_Click(object sender, EventArgs e)
    {
        SearchBooking();
    }
    private void otDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex > -1 && e.ColumnIndex == 3)
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

    private void bookingTextField_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            SearchBooking();
        }
    }
}