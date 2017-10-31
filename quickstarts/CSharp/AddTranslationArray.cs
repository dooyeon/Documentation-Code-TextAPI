using System;
using System.Net.Http;
using System.Text;
using System.Xml.Linq;

namespace TranslateTextQuickStart
{
    class Program
    {
        static string host = "https://api.microsofttranslator.com";
        static string path = "/V2/Http.svc/AddTranslationArray";

        // NOTE: Replace this example key with a valid subscription key.
        static string key = "ENTER KEY HERE";

        async static void AddTranslationArray()
        {
            string uri = host + path;

            XNamespace ns = @"http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2";
            XDocument doc = new XDocument(
                new XElement("AddtranslationsRequest",
                    // NOTE: AppId is required, but it can be empty because we are sending the Ocp-Apim-Subscription-Key header.
                    new XElement("AppId"),
                    new XElement("From", "en-US"),
                    new XElement("Options",
                        new XElement(ns + "User", "JohnDoe")
                    ),
                    new XElement("To", "fr-fr"),
                    new XElement("Translations",
                        new XElement(ns + "Translation",
                            new XElement(ns + "OriginalText", "Hi there"),
                            new XElement(ns + "Rating", 1),
                            new XElement(ns + "TranslatedText", "Salut")
                        )
                    )
                )
            );
            var requestBody = doc.ToString();

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(uri);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "text/xml");
                request.Headers.Add("Ocp-Apim-Subscription-Key", key);
                var response = await client.SendAsync(request);
                Console.WriteLine(response.ToString());
            }
        }

        static void Main(string[] args)
        {
            AddTranslationArray();
            Console.ReadLine();
        }
    }
}
