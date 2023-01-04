
namespace EarthQuakes;

internal record EarthQuakeLocatorModel(
    float XCoord,
    float YCoord,
    float Distance,
    EarthquakeDataModel EarthquakeDataModel);

internal static class EarthquakeLocator
{

    public static EarthQuakeGraphics CalculateLocation(
        this IEnumerable<EarthquakeDataModel> data,
        Form1 form,
        MapConfig mapConfig) => new(form, LocatePointsOnMap(data, mapConfig));

    private static IEnumerable<EarthQuakeLocatorModel> LocatePointsOnMap(
        IEnumerable<EarthquakeDataModel> data,
        MapConfig mapConfig)
    {
        float cx = MercX(mapConfig.CLon, mapConfig.Zoom);
        float cy = MercY(mapConfig.CLat, mapConfig.Zoom);

        foreach (var quake in data)
        {
            float x = MercX(quake.Longitude, mapConfig.Zoom) - cx;
            float y = MercY(quake.Latitude, mapConfig.Zoom) - cy;
            float mag = (float)Math.Pow(10, quake.Magnitude);
            mag = (float)Math.Sqrt(mag);
            float magmax = (float)Math.Sqrt(Math.Pow(10, 10));
            float distance = Map(mag, 0, magmax, 1, 500);
            yield return
                new EarthQuakeLocatorModel(
                    x,
                    y,
                    distance,
                    new EarthquakeDataModel(
                        quake.Place,
                        quake.Magnitude,
                        x,
                        y,
                        quake.Updated,
                        quake.Type,
                        quake.Id));
        }
    }

    public static int CalculateDistance(
      this EarthQuakeLocatorModel quake,
      MouseEventArgs eventArgs,
      PictureBox pbox)
     => (int)Distance(
                      eventArgs.X,
                      eventArgs.Y - (pbox.ClientSize.Height / 2),
                      (int)quake.EarthquakeDataModel.Latitude + (pbox.ClientSize.Width / 2),
                      (int)quake.EarthquakeDataModel.Longitude);

    private static double Distance(int x1, int y1, int x2, int y2)
        => Math.Sqrt(Math.Pow((double)x1 - x2, 2) + Math.Pow((double)y1 - y2, 2));

    private static float Map(
        float value,
        float from1,
        float to1,
        float from2,
        float to2)
        => from2 + (value - from1) * (to2 - from2) / (to1 - from1);

    private static float MercX(float lon, float zoom)
    {
        lon = (float)DegreeToRadian(lon);
        float a = (256 / (float)Math.PI) * (float)Math.Pow(2, zoom);
        float b = lon + (float)Math.PI;
        return a * b;
    }

    private static float MercY(float lat, float zoom)
    {
        lat = (float)DegreeToRadian(lat);
        var a = (256 / (float)Math.PI) * (float)Math.Pow(2, zoom);
        var b = (float)Math.Tan(Math.PI / 4 + lat / 2);
        var c = (float)Math.PI - (float)Math.Log(b);
        return a * c;
    }

    private static double DegreeToRadian(float angle)
        => Math.PI * angle / 180.0;
}

