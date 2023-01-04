namespace EarthQuakes;
internal class MapConfig
{
    private const int _cLat = 0;
    private const int _cLon = 0;
    private const int _zoom = 1;
    private const int _width = 1024;
    private const int _height = 512;

    public string MapUrl { get; } = $"https://api.mapbox.com/styles/v1/mapbox/dark-v9/static/" +
        $"{_cLat},{_cLon},{_zoom}/{_width}x{_height}" +
        $"?access_token=pk.eyJ1IjoiZHJlYW13b3JsZDI1IiwiYSI6ImNqNGp0a3FwMzBvZGIzMm83M3BtM3B5MWUifQ.J-hyod7cC4aafNzi5mIymQ";
}

