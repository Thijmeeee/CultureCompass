using System.Diagnostics;
using CultureCompass.Navigation;
using Newtonsoft.Json;

namespace CultureCompass.API
{
    internal class APIManager
    {
        public async Task<APIResponse> WriteData(string origin, string destination)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                Data data = new Data(origin, destination);
                var fullUrl = "https://maps.googleapis.com/maps/api/directions/json" + data.GetData();

                HttpResponseMessage response = await httpClient.GetAsync(fullUrl);
                response.EnsureSuccessStatusCode();

                string jsonContent = await response.Content.ReadAsStringAsync();
                APIResponse responseData = JsonConvert.DeserializeObject<APIResponse>(jsonContent);

                Trace.WriteLine(jsonContent);
                return responseData;
            }
        }
    }

    internal class Data(string origin, string destination)
    {
        const string apiKey = "AIzaSyBXG_XrA3JRTL58osjxd0DbqH563e2t84o";

        public string GetData()
        {
            return $"?destination={destination}&origin={origin}&key={apiKey}&mode=bicycling";
        }
    }
}
