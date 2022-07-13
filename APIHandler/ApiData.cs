using RealTimeAPIReader.Models;
using Newtonsoft.Json;
using System.Net.Http;



namespace RealTimeAPIReader.APIHandler
{
    public class ApiData
    {
        static async System.Threading.Tasks.Task<List<Root>> qweqwe()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://api.nbp.pl/api/exchangerates/tables/a/");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();

            var resultee = JsonConvert.DeserializeObject<List<Root>>(responseBody);
            return resultee;
        }
        public async static Task<List<ApiModel>> GetApiData()
        {
            var t = await Task.Run(() => qweqwe());
            List<ApiModel> partss = new List<ApiModel>();

            foreach (var x in t)
            {
                //Console.WriteLine("Table: " + x.table);
                //Console.WriteLine("PrintId: " + x.no);
                //Console.WriteLine("EffectiveDate: " + x.effectiveDate);
                foreach (var c in x.rates)
                {
                   // Console.WriteLine(c.currency);
                    new ApiModel { ApiData = new List<double> { c.mid }, Label = c.currency, DateAPI = x.effectiveDate };
                }
            }
            return partss;
        }
    }
}

