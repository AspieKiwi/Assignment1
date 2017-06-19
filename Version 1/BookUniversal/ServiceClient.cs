using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace BookStoreUniversal
{
    // Author: Rebecca Stephens
    // Date: 18/06/2017
    // Notes: This ServiceClient helps the UWP retrieve and call to the queries in the  Book Controller.
    class ServiceClient
    {
        internal async static Task<List<string>> GetAuthorNamesAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<string>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/book/GetAuthorNames/"));
        }

        internal async static Task<clsAuthor> GetAuthorAsync(string prAuthorName)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsAuthor>
                    (await lcHttpClient.GetStringAsync
                    ("http://localhost:60064/api/book/GetAuthor?Name=" + prAuthorName));
        }

        internal async static Task<string> UpdateBookAsync(clsAllBooks prBook)
        {
            return await InsertOrUpdateAsync(prBook, "http://localhost:60064/api/book/PutBook", "PUT");
        }

        private async static Task<string> InsertOrUpdateAsync<TItem>(TItem prItem, string prUrl, string prRequest)
        {
            using (HttpRequestMessage lcReqMessage = new HttpRequestMessage(new HttpMethod(prRequest), prUrl))
            using (lcReqMessage.Content =
                new StringContent(JsonConvert.SerializeObject(prItem), Encoding.UTF8, "application/json"))
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.SendAsync(lcReqMessage);
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }

        internal static async Task<string> InsertOrderAsync(clsOrder prOrder)
        {
            return await InsertOrUpdateAsync(prOrder, "http://localhost:60064/api/book/PostOrder", "POST");
        }
    }
}
