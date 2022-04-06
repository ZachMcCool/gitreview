using IntroductionToAPI.ConsoleApp.Models;

namespace IntroductionToAPI.ConsoleApp
{
    public class SWAPIService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        // Async Method
        public async Task<Person> GetPersonAsync(string url)
        {
            // HttpResponseMessage response = await _httpClient.GetAsync(url);

            // if (response.IsSuccessStatusCode)
            // {
            //     // Was a success
            //     Person person = await response.Content.ReadAsAsync<Person>();
            //     return person;
            // }
            // // Was not a success
            // return null;
            return await GetAsync<Person>(url);
        }

        public async Task<Vehicle> GetVehicleAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            return response.IsSuccessStatusCode ? await response.Content.ReadAsAsync<Vehicle>() : null;
        }

        public async Task<T> GetAsync<T>(string url) where T : class
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                T content = await response.Content.ReadAsAsync<T>();
                return content;
            }

            // return default;
            return null;

        }
    }
}