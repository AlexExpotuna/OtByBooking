using OtByBooking.Services.Interfaces;
using System.Windows.Forms;
namespace OtByBooking;

public partial class OtByBooking : Form
{
    private readonly IOtService _repository;
    //private readonly IClipboardService _clipboardService;
    public OtByBooking(IOtService repository)
    {
        InitializeComponent();
        _repository = repository;
        //_clipboardService = clipboardService;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
    }
    private void searchOT_Click(object sender, EventArgs e)
    {
        button1.Enabled = false;
        button1.Focus();
        var newOts = _repository.GetOtsByBookingCodeV2(bookingTextField.Text.Trim());

        if (newOts.Success)
        {
            for (int i = 0; i < newOts.Result!.Count; i++)
            {
                var currentRow = newOts.Result[i];
                currentRow.Cells.Add(new DataGridViewButtonCell()
                {
                    Value = null
                });
            }
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
        var a = e;
        var i = sender.GetType();
        MessageBox.Show("Hola papu");
    }
}