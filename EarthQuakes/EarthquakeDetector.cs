namespace EarthQuakes;

internal class EarthquakeDetector
{
    private readonly Form1 _form;
    private readonly MapConfig _mapConfig;

    public EarthquakeDetector(Form1 form, MapConfig mapConfig)
    {
        _form = form;
        _mapConfig = mapConfig;
    }

    public async Task DetectEarthquakes(string period = "Important")
        => (await new EarthquakesData()
            .DownloadAndExtractData(period))
            .CalculateLocation(_form, _mapConfig)
            .DrawEarthquakesOnMap(period);
}

