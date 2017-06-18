using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace BookStoreWindows
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

        internal async static Task<string> InsertAuthorAsync(clsAuthor prAuthor)
        {
            return await InsertOrUpdateAsync(prAuthor, "http://localhost:60064/api/book/PutAuthor", "PUT");
        }

        internal async static Task<string> DeleteBookAsync(clsAllBooks prBook)
        {
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.DeleteAsync
                    ($"http://localhost:60064/api/book/DeleteBook?BookTitle={prBook.BookTitle}&AuthorName={prBook.AuthorName}");
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }

        // ******************* for order *****************

        internal async static Task<List<clsOrder>> GetOrderListAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<clsOrder>>
                    (await lcHttpClient.GetStringAsync
                    ("http://localhost:60064/api/book/GetOrderList/"));
        }

        internal async static Task<clsOrder> GetOrderAsync(int prOrderID)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsOrder>
                    (await lcHttpClient.GetStringAsync
                    ("http://localhost:60064/api/book/GetOrder?orderId=" + prOrderID));
        }

        internal async static Task<clsOrder> GetOrdersAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsOrder>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/book/GetOrders"));
        }

        internal static async Task<string> InsertOrderAsync(clsOrder prOrder)
        {
            return await InsertOrUpdateAsync(prOrder, "http://localhost:60064/api/book/PostBook", "POST");
        }

        internal static async Task<string> UpdateOrderAsync(clsOrder prOrder)
        {
            return await InsertOrUpdateAsync(prOrder, "http://localhost:60064/api/book/PutBook", "PUT");
        }

        internal static async Task<string> DeleteOrderAsync(clsOrder prOrder)
        {
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.DeleteAsync
                    ($"http://localhost:60064/api/Book/DeleteOrder?OrderID={prOrder.OrderID}");
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }

        internal async static Task<long> GetBookISBNAsync(long prISBN)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<long>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/book/GetBookISBN?ISBN=" + prISBN));
        }
    }
}
