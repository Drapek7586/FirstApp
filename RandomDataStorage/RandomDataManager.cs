using RealTimeAPIReader.Models;
namespace RealTimeAPIReader.RandomDataStorage
{
    public class DataManager
    {
            public static List<ChartModel> GetData()
            {
                var r = new Random();
                return new List<ChartModel>()
            {
                //Random data for simulationg charts

                new ChartModel { Data = new List<int> { r.Next(1, 40) }, Label = "Losowa dana1", BackgroundColor = "#5491DA" },
                new ChartModel { Data = new List<int> { r.Next(1, 40) }, Label = "Losowa dana 2", BackgroundColor = "#E74C3C" },
                new ChartModel { Data = new List<int> { r.Next(1, 40) }, Label = "Losowa dana 3", BackgroundColor = "#82E0AA" },
                new ChartModel { Data = new List<int> { r.Next(1, 40) }, Label = "Losowa dana 4", BackgroundColor = "#E5E7E9" }
            };
            }
        }
    }

