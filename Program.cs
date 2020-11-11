using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
namespace COVID19PROJECT
{
    class Program
    {
        
        public static async Task Main(string[] args)
        {

            string province_name;
            dynamic response1 = (JObject)await Program.MakeRequest("http://api.weatherstack.com/current?access_key=--------------------------------&query=Toronto");
            dynamic response = (JObject) await Program.MakeRequest("https://services9.arcgis.com/pJENMVYPQqZZe20v/arcgis/rest/services/" +
                "Join_Features_to_Enriched_Population_Case_Data_By_Province_Polygon/FeatureServer/0/query?where=1%3D1&outFields=NAME," +
                "Abbreviation,Recovered,Tests,Last_Updated,ActiveCases,Hospitalized,ICU,ICUVent,Deaths,Case_Total&returnGeometry=false&outSR=4326&f=json");
            
            var loc = response1.location;
            Console.WriteLine("\n\t\t\t\tTODAY'S WEATHER");
            Console.WriteLine("\t-------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"\n\tLocation-> {loc.name} \t\tLocal Time-> {loc.localtime}");
            var curr = response1.current;
            Console.WriteLine($"\tTemperature-> {curr.temperature} \t\tHumidity-> {curr.humidity} \n\tWind Speed-> {curr.wind_speed} \t\tWeather Description-> {curr.weather_descriptions[0]}");
            Console.WriteLine($"\tCloud Cover-> {curr.cloudcover} \t\tUV index-> {curr.uv_index} ");
            Console.WriteLine("\t-------------------------------------------------------------------------------------------------------------");

            Console.Write("\n\n\tEnter the Province Name or Abbreviation for COVID 19 UPDATE");
            province_name = Console.ReadLine();
            try
            {


                for (int i = 0; i < response.features.Count; i++)
                {
                    var fea = response.features[i].attributes;
                    if (fea.NAME.ToString().Equals(province_name, StringComparison.OrdinalIgnoreCase) || fea.Abbreviation.ToString().Equals(province_name, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("\n\n\t\t\t\t COVID UPDATES");
                        Console.WriteLine("\t-------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine($"\n\t{fea.NAME} ({fea.Abbreviation}) \t\t\tTotal Cases->{fea.Case_Total}");
                        Console.Write("\t");
                        for (int j = 0; j < fea.NAME.ToString().Length + 5; j++)
                            Console.Write("-");
                        Console.WriteLine($"\n\tRecovered-> {fea.Recovered} \t\tTests-> {fea.Tests} \n\tICU-> {fea.ICU} \t\t\tICU Vent-> {fea.ICUVent}");
                        Console.WriteLine($"\tHospitalized-> {fea.Hospitalized} \t\tActive Cases-> {fea.ActiveCases} ");
                        Console.WriteLine($"\tDeaths-> {fea.Deaths}");
                    }
                    else
                        continue;
                }
            }
            catch (Exception) { }
            finally
            {
                Console.WriteLine("\t-------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("\n\t\t\t\tHAVE A SAFE DAY");
            }
        
        }

        public static async Task<dynamic> MakeRequest(string url)
        {
            using var client = new HttpClient();
            var result = await client.GetStringAsync(url);
            dynamic json = JsonConvert.DeserializeObject(result);
            return json;
        }

      
    }
}

