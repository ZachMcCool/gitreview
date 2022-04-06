using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroductionToAPI.ConsoleApp.Models;
using Newtonsoft.Json;

namespace IntroductionToAPI.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage response = httpClient.GetAsync("https://swapi.dev/api/people/1").Result;

            if (response.IsSuccessStatusCode)
            {
                // var content = response.Content.ReadAsStringAsync().Result;
                // var person = JsonConvert.DeserializeObject<Person>(content);

                Person luke = response.Content.ReadAsAsync<Person>().Result;
                Console.WriteLine(luke.Name);

                foreach (string vehiclesUrl in luke.Vehicles)
                {
                    HttpResponseMessage vehicleResponse = httpClient.GetAsync(vehiclesUrl).Result;
                    // Console.WriteLine(vehicleResponse.Content.ReadAsStringAsync().Result);

                    Vehicle vehicle = vehicleResponse.Content.ReadAsAsync<Vehicle>().Result;
                    Console.WriteLine(vehicle.Name);
                }
            }

            Console.WriteLine();

            SWAPIService service = new SWAPIService();
            Person person = service.GetPersonAsync("https://swapi.dev/api/people/11").Result;
            if (person != null)
            {
                Console.WriteLine(person.Name);

                foreach (var vehiclesUrl in person.Vehicles)
                {
                    var vehicle = service.GetVehicleAsync(vehiclesUrl).Result;
                    Console.WriteLine(vehicle.Name);
                }
            }

            Console.WriteLine();

            // var genericResponse = service.GetAsync<Vehicle>("https://swapi.dev/api/vehicles/4").Result;
            var genericResponse = service.GetAsync<Person>("https://swapi.dev/api/people/4").Result;
            if (genericResponse != null)
            {
                Console.WriteLine(genericResponse.Name);
            }
            else
            {
                Console.WriteLine("Targetted object does not exist.");
            }

            Console.WriteLine();
            var person2Response = service.GetPersonAsync("https://swapi.dev/api/people/5").Result;
            if (person2Response != null)
            {
                Console.WriteLine(person2Response.Name);
            }
            else
            {
                Console.WriteLine("Targetted object does not exist.");
            }

        }
    }
}