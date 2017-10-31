<?php

// NOTE: Be sure to uncomment the following line in your php.ini file.
// ;extension=php_openssl.dll

// **********************************************
// *** Update or verify the following values. ***
// **********************************************

// Replace the subscriptionKey string value with your valid subscription key.
$key = 'ENTER KEY HERE';

$host = "https://api.microsofttranslator.com";
$path = "/V2/Http.svc/Translate";

$target = "fr-fr";
$text = "Hello";

$params = '?to=' . $target . '&text=' . urlencode($text);

$content = '';

function Translate ($host, $path, $key, $params, $content) {

	$headers = "Content-type: text/xml\r\n" .
		"Ocp-Apim-Subscription-Key: $key\r\n";

	// NOTE: Use the key 'http' even if you are making an HTTPS request. See:
	// http://php.net/manual/en/function.stream-context-create.php
	$options = array (
		'http' => array (
			'header' => $headers,
			'method' => 'GET'
		)
	);
	$context  = stream_context_create ($options);
	$result = file_get_contents ($host . $path . $params, false, $context);
	return $result;
}

$result = Translate ($host, $path, $key, $params, $content);

echo $result;
?>
