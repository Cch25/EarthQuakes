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
        => await DisplayEarthquakes(
            _mapConfig.CLat,
            _mapConfig.CLon,
            _mapConfig.Zoom, period);

    private async Task DisplayEarthquakes(
        float clat,
        float clon,
        float zoom,
        string period)
    {
        var earthquakes = (await new EarthquakesData(_form)
            .DownloadAndExtractData(period))
            .CalculateLocation(clat, clon, zoom);


        foreach (var quake in earthquakes)
        {
            using var g = _form.pictureBox1.CreateGraphics();
            try
            {
                g.TranslateTransform(
                    _form.pictureBox1.ClientSize.Width / 2 - (quake.Distance / 2),
                    _form.pictureBox1.ClientSize.Height / 2 - (quake.Distance / 2));
                g.FillEllipse(
                    quake.EarthquakeDataModel.Magnitude < 5 ? Brushes.Magenta : Brushes.Red,
                    quake.XCoord,
                    quake.YCoord,
                    quake.Distance,
                    quake.Distance);
                g.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Changing the label's text in a cross thread
        _form.lblDetails.Invoke(new Action(() =>
        {
            _form.lblDetails.Text = $@"Done. We have detected {earthquakes.Count()} earthquakes in the {period} category.";
            _form.lblDetails.Location = new Point(610, 441);
        }));


        _form.pictureBox1.Click += (s, e) =>
        {
            var mea = (MouseEventArgs)e;
            var biggest = 0f;

            try
            {
                foreach (var quake in earthquakes)
                {
                    int distance = quake.CalculateDistance(mea, _form.pictureBox1);
                    if (distance <= 9)
                    {
                        float current = quake.EarthquakeDataModel.Magnitude;
                        if (current > biggest)
                            biggest = current;
                        _form.lblDetails.Location = new Point(620, 420);
                        _form.lblDetails.Text = $"Place: {quake.EarthquakeDataModel.Place} " +
                            $"\nDate: { Convert.ToDateTime(quake.EarthquakeDataModel.Updated).ToShortDateString()}" +
                            $" Time: {Convert.ToDateTime(quake.EarthquakeDataModel.Updated).ToShortTimeString()}" +
                            $"\nMagnitude: {biggest} Richter scale";
                        if (!quake.EarthquakeDataModel.Type.Equals("earthquake"))
                        {
                            _form.lblDetails.Location = new Point(620, 400);
                            _form.lblDetails.Text += $"\nType: {quake.EarthquakeDataModel.Type}";
                        }
                    }
                }
            }
            catch (Exception) { Application.Restart(); }
        };
    }

}

