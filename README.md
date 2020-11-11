# CovidRepo
In this simple C# ConsoleApp, I have tried to collect COVID 19 information and weather information from public APIs.
http://api.weatherstack.com/current?access_key=????????????????????????&query=Toronto
https://services9.arcgis.com/pJENMVYPQqZZe20v/arcgis/rest/services/
Collected the data which is send in JSON format.
Used C# JSON Object to access the values.
Install these packages Newtonsoft.Json, System.Net.Http, System.Threading.Tasks, System.Collections.Generic for successful execution
THE OUTPUT WILL BE LIKE THIS


        Location-> Toronto              Local Time-> 2020-11-11 17:32
        Temperature-> 10                Humidity-> 58
        Wind Speed-> 24                 Weather Description-> Sunny
        Cloud Cover-> 0                 UV index-> 5
        -------------------------------------------------------------------------------------------------------------


        Enter the Province Name or Abbreviation for COVID 19 UPDATEon


                                 COVID UPDATES
        -------------------------------------------------------------------------------------------------------------

        Ontario (ON)                    Total Cases->88209
        ------------
        Recovered-> 74303               Tests-> 5476811
        ICU-> 88                        ICU Vent-> 57
        Hospitalized-> 424              Active Cases-> 10631
        Deaths-> 3275
        -------------------------------------------------------------------------------------------------------------

                                HAVE A SAFE DAY
