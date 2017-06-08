using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace BookStore3
{
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


        internal async static Task<List<clsAuthor>> GetAuthorsAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<clsAuthor>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/book/GetAuthors/"));
        }

        internal async static Task<string> InsertBookAsync(clsAllBooks prBook)
        {
            return await InsertOrUpdateAsync(prBook, "http://localhost:60064/api/book/PostBook", "POST");
        }

        internal async static Task<string> UpdateBookAsync(clsAllBooks prBook)
        {
            return await InsertOrUpdateAsync(prBook, "http://localhost:60064/api/book/PutBook", "PUT");
        }

        private async static Task<string> InsertOrUpdateAsync<TItem>(TItem prItem, string prUrl, string prRequest)
        {
            using (HttpRequestMessage lcReqMessage = new HttpRequestMessage(new HttpMethod(prRequest), prUrl))
            using (lcReqMessage.Content =
                new StringContent(JsonConvert.SerializeObject(prItem), Encoding.Default, "application/json"))
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.SendAsync(lcReqMessage);
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }
    }
}
