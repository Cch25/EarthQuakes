using System.Globalization;

namespace EarthQuakes;

internal record EarthquakeDataModel(
    string Place,
    float Magnitude,
    float Latitude,
    float Longitude,
    string Updated,
    string Type,
    string Id);

internal class EarthquakesDataParser
{ 
    private readonly Dictionary<string, string> dataPaths = new()
    {
        ["Important"] = "significant_month.csv",
        ["Last day"] = "all_day.csv",
        ["Last week"] = "all_week.csv",
        ["Last month"] = "all_month.csv",

    };

    public async Task<IEnumerable<EarthquakeDataModel>> 
        DownloadAndExtractData(string period) => 
        await new EarthquakeExtractor()
            .Extract($"https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/{dataPaths[period]}");
    

    internal class EarthquakeExtractor
    {
        public async Task<IEnumerable<EarthquakeDataModel>> Extract(string path)
        {
            var earthquakesInfos = new List<EarthquakeDataModel>();
            var result = await DownloadData(path);
            string[] lineItems = result.Split('\n');
            for (int i = 1; i < lineItems.Length - 1; i++)
            {
                try
                {
                    string[] tempItems = lineItems[i].SplitWithQualifier(',', '"', true);
                    earthquakesInfos.Add(
                        new EarthquakeDataModel(
                            Convert.ToString(tempItems[13]),
                            float.Parse(tempItems[4], CultureInfo.InvariantCulture),
                            float.Parse(tempItems[1], CultureInfo.InvariantCulture),
                            float.Parse(tempItems[2], CultureInfo.InvariantCulture),
                            Convert.ToString(tempItems[12]),
                            Convert.ToString(tempItems[14]),
                            Convert.ToString(tempItems[11]))
                        );
                }
                catch (Exception)
                {
                    //throw;
                }
            }
            return earthquakesInfos;
        }

        private async Task<string> DownloadData(string url)
        {
            string result = "404";
            try
            {
                var client = new HttpClient();
                return await client.GetStringAsync(url);
            }
            catch (Exception)
            {
                Console.WriteLine("Timeout");
            }

            return result;
        }
    }
}

