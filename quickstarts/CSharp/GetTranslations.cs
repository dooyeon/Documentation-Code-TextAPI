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
        static string path = "/V2/Http.svc/GetTranslations";

        // NOTE: Replace this example key with a valid subscription key.
        static string key = "ENTER KEY HERE";

        async static void GetTranslations()
        {
            string from = "en-us";
            string to = "fr-fr";
            string text = "Hi there";
            string maxTranslations = "10";
            string uri = host + path + "?from=" + from + "&to=" + to + "&maxTranslations=" + maxTranslations + "&text=" + System.Net.WebUtility.UrlEncode(text);

            // NOTE: Use this if you need to specify options. For more information see:
            // http://docs.microsofttranslator.com/text-translate.html#!/default/post_GetTranslations
            /*
            XNamespace ns = @"http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2";
            XDocument doc = new XDocument(
                new XElement(ns + "TranslateOptions")
            );
            var requestBody = doc.ToString();
            */
            var requestBody = "";

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
            GetTranslations();
            Console.ReadLine();
        }
    }
}
