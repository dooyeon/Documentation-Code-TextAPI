using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;

namespace TranslateTextQuickStart
{
    class Program
    {
        static string locale = "en";
        static string host = "https://api.microsofttranslator.com";
        static string path = "/V2/Http.svc/GetLanguageNames?locale=" + locale;

        // NOTE: Replace this example key with a valid subscription key.
        static string key = "ENTER KEY HERE";

        static void GetLanguageNames()
        {
            string uri = host + path;

            string[] languageCodes = { "en", "fr", "uk" };

            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "POST";
            request.ContentType = "text/xml";
            request.Headers.Add("Ocp-Apim-Subscription-Key", key);

            // NOTE: The following code serializes languageCodes as follows.
            /*
            <ArrayOfstring xmlns:i="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://schemas.microsoft.com/2003/10/Serialization/Arrays">
                <string>en</string>
                <string>fr</string>
                <string>uk</string>
            </ArrayOfstring>
            */
            DataContractSerializer dcs = new DataContractSerializer(Type.GetType("System.String[]"));
            using (Stream stream = request.GetRequestStream())
            {
                dcs.WriteObject(stream, languageCodes);
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
            GetLanguageNames();
            Console.ReadLine();
        }
    }
}
