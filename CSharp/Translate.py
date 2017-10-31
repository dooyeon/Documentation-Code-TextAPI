using System;
using System.Collections.Generic;
using System.Net.Http;

namespace TranslateTextQuickStart
{
    class Program
    {
        static string host = "https://api.microsofttranslator.com";
        static string path = "/V2/Http.svc/Translate";

        // NOTE: Replace this example key with a valid subscription key.
        static string key = "ENTER KEY HERE";

        async static void TranslateText()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);

            List<KeyValuePair<string,string>> list = new List<KeyValuePair<string,string>>() {
                new KeyValuePair<string, string> ("Hello", "fr-fr"),
                new KeyValuePair<string, string> ("Salut", "en-us")
            };

            foreach (KeyValuePair<string, string> i in list)
            {
                string uri = host + path + "?to=" + i.Value + "&text=" + System.Net.WebUtility.UrlEncode(i.Key);

                HttpResponseMessage response = await client.GetAsync(uri);

                string result = await response.Content.ReadAsStringAsync();
                // NOTE: A successful response is returned in XML. You can extract the contents of the XML as follows.
                // var content = XElement.Parse(result).Value;
                Console.WriteLine(result);
            }
        }

        static void Main(string[] args)
        {
            TranslateText();
            Console.ReadLine();
        }
    }
}
