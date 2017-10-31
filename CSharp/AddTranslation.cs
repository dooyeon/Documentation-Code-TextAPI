using System;
using System.Net;
using System.Net.Http;

namespace TranslateTextQuickStart
{
    class Program
    {
        static string host = "https://api.microsofttranslator.com";
        static string path = "/V2/Http.svc/AddTranslation";

        // NOTE: Replace this example key with a valid subscription key.
        static string key = "ENTER KEY HERE";

        async static void AddTranslation()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);

            string originalText = "Hi there";
            string translatedText = "Salut";
            string from = "en-US";
            string to = "fr-fr";
            string user = "JohnDoe";

            string uri = host + path +
                "?originalText=" + WebUtility.UrlEncode(originalText) +
                "&translatedText=" + WebUtility.UrlEncode(translatedText) +
                "&from=" + from +
                "&to=" + to +
                "&user=" + WebUtility.UrlEncode(user);

            HttpResponseMessage response = await client.GetAsync(uri);
            Console.WriteLine(response.ToString());
        }

        static void Main(string[] args)
        {
            AddTranslation();
            Console.ReadLine();
        }
    }
}
