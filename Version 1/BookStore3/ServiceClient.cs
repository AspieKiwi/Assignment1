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
    }
}
