using System;
using System.Net.Http;
using System.Xml.Linq;

namespace TranslateTextQuickStart
{
    class Program
    {
        static string host = "https://api.microsofttranslator.com";
        static string path = "/V2/Http.svc/Detect";

        // NOTE: Replace this example key with a valid subscription key.
        static string key = "ENTER KEY HERE";

        async static void Detect()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);

            string text = "Hello world";

            string uri = host + path + "?text=" + System.Net.WebUtility.UrlEncode(text);

            HttpResponseMessage response = await client.GetAsync(uri);

            string result = await response.Content.ReadAsStringAsync();
            // NOTE: A successful response is returned in XML. You can extract the contents of the XML as follows.
            // var content = XElement.Parse(result).Value;
            Console.WriteLine(result);
        }

        static void Main(string[] args)
        {
            Detect();
            Console.ReadLine();
        }
    }
}
