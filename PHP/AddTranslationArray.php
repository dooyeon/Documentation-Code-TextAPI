<?php

// NOTE: Be sure to uncomment the following line in your php.ini file.
// ;extension=php_openssl.dll

// **********************************************
// *** Update or verify the following values. ***
// **********************************************

// Replace the subscriptionKey string value with your valid subscription key.
$key = 'ENTER KEY HERE';

$host = "https://api.microsofttranslator.com";
$path = "/V2/Http.svc/AddTranslationArray";

$params = '';

$from = "en-us";
$to = "fr-fr";
$original = "Hi there";
$translation = "Salut";
$user = "JohnDoe";

$ns = "http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2";
$content =
	"<AddtranslationsRequest>" .
	"  <AppId />" .
	"  <From>$from</From>" .
	"  <Options>" .
	"    <User xmlns=\"$ns\">$user</User>" .
	"  </Options>" .
	"  <To>$to</To>" .
	"  <Translations>" .
	"    <Translation xmlns=\"$ns\">" .
	"      <OriginalText>$original</OriginalText>" .
	"      <Rating>1</Rating>" .
	"      <TranslatedText>$translation</TranslatedText>" .
	"    </Translation>" .
	"  </Translations>" .
	"</AddtranslationsRequest>";

function AddTranslationArray ($host, $path, $key, $params, $content) {

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

$result = AddTranslationArray ($host, $path, $key, $params, $content);

echo $result;
?>
