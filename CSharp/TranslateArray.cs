using System;
using System.Net.Http;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace TranslateTextQuickStart
{
    class Program
    {
        static string host = "https://api.microsofttranslator.com";
        static string path = "/V2/Http.svc/TranslateArray";

        // NOTE: Replace this example key with a valid subscription key.
        static string key = "ENTER KEY HERE";

        async static void TranslateArray()
        {
            string uri = host + path;

            XNamespace ns = @"http://schemas.microsoft.com/2003/10/Serialization/Arrays";
            XDocument doc = new XDocument(
                new XElement("TranslateArrayRequest",
                    // NOTE: AppId is required, but it can be empty because we are sending the Ocp-Apim-Subscription-Key header.
                    new XElement("AppId"),
                    new XElement("Texts",
                        new XElement(ns + "string", "Hello"),
                        new XElement(ns + "string", "Goodbye")
                    ),
                    new XElement("To", "fr-fr")
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
                var responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(PrettifyXML(responseBody));
            }
        }

        static string PrettifyXML(string xml)
        {
            var str = new StringBuilder();
            var element = XElement.Parse(xml);
            var settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true,
                Indent = true,
                NewLineOnAttributes = true
            };
            using (var writer = XmlWriter.Create(str, settings))
            {
                element.Save(writer);
            }
            return str.ToString();
        }

        static void Main(string[] args)
        {
            TranslateArray();
            Console.ReadLine();
        }
    }
}
