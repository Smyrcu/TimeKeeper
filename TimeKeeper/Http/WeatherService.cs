using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.PropertyGridInternal;
using TimeKeeper.ViewModels;

namespace TimeKeeper.Http
{
    internal class WeatherService
    {
        private readonly ApiConstants _apiConstants;
        string postalCode = "33062"; // 62-330 = 33062 !!!!
        string countryCode = "pl";
        string apiKey = "f11b0de69c8948b0965a9c0970da0647";

        public WeatherService()
        {
            _apiConstants = new ApiConstants();
        }

        public WeatherModel GetWeather()
        {
            
            using (var client = new HttpClient())
            {
                Uri uri = new Uri($"http://api.weatherbit.io/v2.0/current?postal_code={postalCode}&country={countryCode}&key={apiKey}");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(uri).Result;
                var json = response.Content.ReadAsStringAsync().Result;

            }
            return null;
        }



    }
}
