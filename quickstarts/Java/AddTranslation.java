import java.io.*;
import java.net.*;
import java.util.*;
import javax.net.ssl.HttpsURLConnection;

public class AddTranslation {

// **********************************************
// *** Update or verify the following values. ***
// **********************************************

// Replace the key string value with your valid subscription key.
	static String key = "ENTER KEY HERE";

	static String host = "https://api.microsofttranslator.com";
	static String path = "/V2/Http.svc/AddTranslation";

	public static String get (URL url) throws Exception {
		HttpsURLConnection connection = (HttpsURLConnection) url.openConnection();
		connection.setRequestMethod("GET");
		connection.setRequestProperty("Ocp-Apim-Subscription-Key", key);
		connection.setDoOutput(true);

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

	public static String AddTranslation () throws Exception {
		String originalText = "Hi there";
		String translatedText = "Salut";
		String from = "en-US";
		String to = "fr-fr";
		String user = "JohnDoe";

		String url = host + path +
			"?originalText=" + URLEncoder.encode (originalText, "UTF-8") +
			"&translatedText=" + URLEncoder.encode (translatedText, "UTF-8") +
			"&from=" + from +
			"&to=" + to +
			"&user=" + URLEncoder.encode (user, "UTF-8");

		URL url2 = new URL (url);
		return get (url2);
    }

	public static void main(String[] args) {
		try {
			String response = AddTranslation ();
			System.out.println (response);
		}
		catch (Exception e) {
			System.out.println (e);
		}
	}
}
