<?php

// NOTE: Be sure to uncomment the following line in your php.ini file.
// ;extension=php_openssl.dll

// **********************************************
// *** Update or verify the following values. ***
// **********************************************

// Replace the subscriptionKey string value with your valid subscription key.
$key = 'ENTER KEY HERE';

$host = "https://api.microsofttranslator.com";
$path = "/V2/Http.svc/GetLanguageNames";

$locale = 'en';
$params = '?locale=' . $locale;

$content =
	"<ArrayOfstring xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://schemas.microsoft.com/2003/10/Serialization/Arrays\">" .
	"    <string>en</string>" .
	"    <string>fr</string>" .
	"    <string>uk</string>" .
	"</ArrayOfstring>";

function GetLanguageNames ($host, $path, $key, $params, $content) {

	$headers = "Content-type: text/xml\r\n" .
		"Ocp-Apim-Subscription-Key: $key\r\n";

	// NOTE: Use the key 'http' even if you are making an HTTPS request. See:
	// http://php.net/manual/en/function.stream-context-create.php
	$options = array (
		'http' => array (
			'header' => $headers,
			'method' => 'POST',
			'content' => $content
		)
	);
	$context  = stream_context_create ($options);
	$result = file_get_contents ($host . $path . $params, false, $context);
	return $result;
}

$result = GetLanguageNames ($host, $path, $key, $params, $content);

echo $result;
?>
