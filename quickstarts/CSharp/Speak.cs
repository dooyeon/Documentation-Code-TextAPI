using System;
using System.IO;
using System.Net;

namespace TranslateTextQuickStart
{
    class Program
    {
        static string host = "https://api.microsofttranslator.com";
        static string path = "/V2/Http.svc/Speak";

        // NOTE: Replace this example key with a valid subscription key.
        static string key = "ENTER KEY HERE";

        static void Speak()
        {
            string text = "Hello world";
            string language = "en-US";
            string output_path = "speak.wav";

            string uri = host + path + "?text=" + System.Net.WebUtility.UrlEncode(text) + "&language=" + language;

            WebRequest webRequest = WebRequest.Create(uri);
            webRequest.Headers.Add("Ocp-Apim-Subscription-Key", key);

            using (WebResponse response = webRequest.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (var fileStream = File.Create(output_path))
            {
                stream.CopyTo(fileStream);
                Console.WriteLine("File written.");
            }
        }

        static void Main(string[] args)
        {
            Speak();
            Console.ReadLine();
        }
    }
}
