using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace hubspot_integration
{
    internal class Program
    {
        static HttpClient client = new HttpClient();

        static async Task<Uri?> CreateContactAsync(ContactModel contact)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "contacts/v1/contact", contact);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("https://api.hubapi.com");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            // add the jwt token in the http request header.
            var token = "jwt token";
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            try
            {
                // Create a new contact
                var contact = ContactFactory.Create("Wael", "+31444");

                var url = await CreateContactAsync(contact);
                Console.WriteLine($"Successfully Created at {url}");

            }
            catch (HttpRequestException ex)
            {
                if(ex.StatusCode == System.Net.HttpStatusCode.Conflict)
                    Console.WriteLine($"contact already exists. {ex.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }
    }
}