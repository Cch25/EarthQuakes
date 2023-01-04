namespace EarthQuakes;

public partial class Form1 : Form
{
    private readonly EarthquakeDetector _earthQuakesDetector;
    public Form1()
    {
        InitializeComponent();
        _earthQuakesDetector = new UIInit(this).InitializeFormComponents();
    }

    private void Form1_Load(object sender, EventArgs e) => 
        Invoke(() => _ = _earthQuakesDetector.DetectEarthquakes());

    private void ddlPeriod_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_earthQuakesDetector != null)
        {
            var period = ((ComboBox)sender).SelectedItem.ToString() ?? "Important";
            pictureBox1.Invalidate();
            Invoke(() => _ = _earthQuakesDetector.DetectEarthquakes(period));
        }
    }
}
