using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;

namespace TranslateTextQuickStart
{
    class Program
    {
        static string host = "https://api.microsofttranslator.com";
        static string path = "/V2/Http.svc/DetectArray";

        // NOTE: Replace this example key with a valid subscription key.
        static string key = "ENTER KEY HERE";

        static void DetectArray()
        {
            string uri = host + path;

            string[] texts = { "Hello", "Bonjour", "Guten tag" };

            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "POST";
            request.ContentType = "text/xml";
            request.Headers.Add("Ocp-Apim-Subscription-Key", key);

            // NOTE: The following code serializes texts as follows.
            /*
            <ArrayOfstring xmlns:i="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://schemas.microsoft.com/2003/10/Serialization/Arrays">
                <string>Hello</string>
                <string>Bonjour</string>
                <string>Guten tag</string>
            </ArrayOfstring>
            */
            DataContractSerializer dcs = new DataContractSerializer(Type.GetType("System.String[]"));
            using (Stream stream = request.GetRequestStream())
            {
                dcs.WriteObject(stream, texts);
            }

            using (WebResponse response = request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    String line = sr.ReadToEnd();
                    Console.WriteLine(line);
                }

                // NOTE: Use the following code to deserialize the stream contents.
                /*
                string[] languageNames = (string[])dcs.ReadObject(stream);
                foreach (var i in languageNames)
                {
                    Console.WriteLine(i);
                }
                */
            }
        }

        static void Main(string[] args)
        {
            DetectArray();
            Console.ReadLine();
        }
    }
}
