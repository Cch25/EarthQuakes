namespace EarthQuakes;

internal class EarthquakeManager
{
    private readonly Form1 _form;
    private readonly MapSettings _mapConfig;

    public EarthquakeManager(Form1 form, MapSettings mapConfig)
    {
        _form = form;
        _mapConfig = mapConfig;
    }

    public async Task DisplayEarthquakes(string period = "Important")
        => (await new EarthquakesDataParser()
            .DownloadAndExtractData(period))
            .CalculateLocation(_mapConfig)
            .Draw(_form, period);
}

internal static class EarthquakeLocatorExtensions
{
    public static void Draw(
        this IEnumerable<EarthQuakeLocatorModel> @this, Form1 form, string period) =>
        new EarthQuakeGraphics(form, @this).DrawEarthquakesOnMap(period);
}

