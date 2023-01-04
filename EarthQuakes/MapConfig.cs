namespace EarthQuakes;
internal class MapConfig
{
    private const int _width = 1024;
    private const int _height = 512;

    public int CLat { get; } = 0;
    public int CLon { get; } = 0;
    public int Zoom { get; } = 1;


    public string MapUrl() => $"https://api.mapbox.com/styles/v1/mapbox/dark-v9/static/" +
        $"{CLat},{CLon},{Zoom}/{_width}x{_height}" +
        $"?access_token=pk.eyJ1IjoiZHJlYW13b3JsZDI1IiwiYSI6ImNqNGp0a3FwMzBvZGIzMm83M3BtM3B5MWUifQ.J-hyod7cC4aafNzi5mIymQ";
}

