<?php

// NOTE: Be sure to uncomment the following line in your php.ini file.
// ;extension=php_openssl.dll

// **********************************************
// *** Update or verify the following values. ***
// **********************************************

// Replace the subscriptionKey string value with your valid subscription key.
$key = 'ENTER KEY HERE';

$host = "https://api.microsofttranslator.com";
$path = "/V2/Http.svc/Speak";

$text = "Hello world";
$language = "en-US";
$output_path = "speak.wav";

$params = "?text=" . urlencode ($text) . "&language=$language";

function Speak ($host, $path, $key, $params) {

	$headers =
		"Content-type: text/xml\r\n" .
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

$result = Speak ($host, $path, $key, $params);

$out = fopen($output_path, 'w');
// NOTE: fwrite is binary-safe. See: http://php.net/manual/en/function.fwrite.php
fwrite($out, $result);

echo "File written.";
?>
