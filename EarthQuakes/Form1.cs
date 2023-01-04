namespace EarthQuakes;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    => Invoke(() =>
    {
        _ = new UIInit(this)
                        .InitializeFormComponents()
                        .DetectEarthquakes(0, 0, 1);
    });

    private void ddlPeriod_SelectedIndexChanged(object sender, EventArgs e)
    {
        var period = ((ComboBox)sender).SelectedItem.ToString() ?? "Important";
        pictureBox1.Invalidate();
        Invoke(() => _ = new EarthquakeDetector(this)
                        .DetectEarthquakes(0, 0, 1, period));
    }
}
