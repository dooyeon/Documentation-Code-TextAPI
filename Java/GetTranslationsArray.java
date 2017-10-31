import java.io.*;
import java.net.*;
import java.util.*;
import javax.net.ssl.HttpsURLConnection;

public class GetTranslationsArray {

// **********************************************
// *** Update or verify the following values. ***
// **********************************************

// Replace the key string value with your valid subscription key.
	static String key = "ENTER KEY HERE";

	static String host = "https://api.microsofttranslator.com";
	static String path = "/V2/Http.svc/GetTranslationsArray";

	public static String post (URL url, String content) throws Exception {
		HttpsURLConnection connection = (HttpsURLConnection) url.openConnection();
		connection.setRequestMethod("POST");
		connection.setRequestProperty("Content-Type", "text/xml");
		connection.setRequestProperty("Ocp-Apim-Subscription-Key", key);
		connection.setDoOutput(true);

        DataOutputStream wr = new DataOutputStream(connection.getOutputStream());
		byte[] encoded_content = content.getBytes("UTF-8");
		wr.write(encoded_content, 0, encoded_content.length);
		wr.flush();
		wr.close();

		StringBuilder response = new StringBuilder ();
		BufferedReader in = new BufferedReader(
		new InputStreamReader(connection.getInputStream()));
		String line;
		while ((line = in.readLine()) != null) {
			response.append(line);
		}
		in.close();

		return response.toString();
	}

	public static String GetTranslationsArray () throws Exception {
		URL url = new URL (host + path);

		String from = "en-us";
		String to = "fr-fr";

		String ns = "http://schemas.microsoft.com/2003/10/Serialization/Arrays";
		String xml =
			"<GetTranslationsArrayRequest>" +
			"  <AppId />" +
			"  <From>" + from + "</From>" +
			"  <Texts>" +
			"    <string xmlns=\"" + ns + "\">Hello</string>" +
			"    <string xmlns=\"" + ns + "\">Goodbye</string>" +
			"  </Texts>" +
			"  <To>" + to + "</To>" +
			"  <MaxTranslations>10</MaxTranslations>" +
			"</GetTranslationsArrayRequest>";
		return post (url, xml);
    }

	public static void main(String[] args) {
		try {
			String response = GetTranslationsArray ();
			System.out.println (response);
		}
		catch (Exception e) {
			System.out.println (e);
		}
	}
}
