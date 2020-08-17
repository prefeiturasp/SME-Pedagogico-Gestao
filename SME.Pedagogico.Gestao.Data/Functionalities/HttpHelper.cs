using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Data.Integracao
{
    internal static class HttpHelper
    {
        private const String API_EOL_KEY_ENV = "ApiKeyEolApi";
        private const String API_EOL_KEY_HEADER = "x-api-eol-key";
        //private readonly HttpClient _httpClient;
        //private Uri BaseEndpoint { get; set; }

        //public HttpHelper(Uri baseEndpoint)
        //{ 
        //    BaseEndpoint = baseEndpoint;
        //    _httpClient = new HttpClient();
        //}

        internal static async Task<T> GetAsync<T>(string token, string url)
        {

            using (var client = new HttpClient())
            {
                try
                {
                    AddHeaders(token, client);
                    HttpResponseMessage response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(data);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

              
            }

        }

        //private static Uri CreateRequestUri(string relativePath, string queryString = "")
        //{
        //    var endpoint = new Uri(BaseEndpoint, relativePath);
        //    var uriBuilder = new UriBuilder(endpoint);
        //    uriBuilder.Query = queryString;
        //    return uriBuilder.Uri;
        //}

        //private static HttpContent CreateHttpContent<T>(T content)
        //{
        //    var json = JsonConvert.SerializeObject(content, MicrosoftDateFormatSettings);
        //    return new StringContent(json, Encoding.UTF8, "application/json");
        //}

        private static void AddHeaders(string token, HttpClient client)
        {
            var apiKey = Environment.GetEnvironmentVariable(API_EOL_KEY_ENV);
            client.DefaultRequestHeaders.Add("token", token);
            client.DefaultRequestHeaders.Add(API_EOL_KEY_HEADER, apiKey);
        }

        internal static string ConstroiURL(string baseURL, string endpoint)
        {
            var url = new StringBuilder();
            url.Append(baseURL);
            url.Append(endpoint);

            return url.ToString();
        }
    }
}


