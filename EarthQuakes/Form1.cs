namespace EarthQuakes;

public partial class Form1 : Form
{
    private readonly EarthquakeManager earthquakeManager;

    public Form1()
    {
        InitializeComponent();
        var settings = new MapSettings();
        UIInit.InitializeMap(this, settings);
        earthquakeManager = new EarthquakeManager(this, settings);
    }

    private void Form1_Load(object sender, EventArgs e) => 
        Invoke(() => _ = earthquakeManager.DisplayEarthquakes());

    private void ddlPeriod_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (earthquakeManager != null)
        {
            var period = ((ComboBox)sender).SelectedItem.ToString() ?? "Important";
            pictureBox1.Invalidate();
            Invoke(() => _ = earthquakeManager.DisplayEarthquakes(period));
        }
    }
}
