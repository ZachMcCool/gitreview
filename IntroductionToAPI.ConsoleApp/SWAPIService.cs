using IntroductionToAPI.ConsoleApp.Models;

namespace IntroductionToAPI.ConsoleApp
{
    public class SWAPIService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        // Async Method
        public async Task<Person> GetPersonAsync(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                // Was a success
                Person person = await response.Content.ReadAsAsync<Person>();
                return person;
            }
            // Was not a success
            return null;
        }

        public async Task<Vehicle> GetVehicleAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            return response.IsSuccessStatusCode ? await response.Content.ReadAsAsync<Vehicle>() : null;
        }
    }
}