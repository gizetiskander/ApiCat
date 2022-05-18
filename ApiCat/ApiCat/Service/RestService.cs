using ApiCat.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiCat.Service
{
    public class RestService : IRestService
    {
        HttpClient client;
        JsonSerializerOptions serializerOptions;

        public List<CatModel> catModels { get; set; }
        public RestService()
        {
            client = new HttpClient();
            serializerOptions = new JsonSerializerOptions
            {

            };
        }

        public async Task<List<CatModel>> GetDataAsync()
        {
            catModels = new List<CatModel>();

            Uri uri = new Uri(string.Format(Constants.CatUri, string.Empty));

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    catModels = JsonSerializer.Deserialize<List<CatModel>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return catModels;
        }
        public async Task SaveTodoItemAsync(CatModel item, bool isNewItem)
        {
            Uri uri = new Uri(string.Format(Constants.CatUri, string.Empty));
            try
            {
                string json = JsonSerializer.Serialize(item, serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uri, content);
                }

                else
                {
                    response = await client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("@@@Success");
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public async Task DeleteTodoItemAsync(CatModel item)
        {
            Uri uri = new Uri(string.Format(Constants.CatUri, item.id));

            try
            {
                HttpResponseMessage httpResponseMessage = await client.DeleteAsync(uri);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    Debug.WriteLine("@@@Success");
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine($"@@@@@@@@@@//// {ex.Message}");
            }
        }

        Task<List<CatModel>> IRestService.GetDataAsync()
        {
            throw new NotImplementedException();
        }
    }
}
