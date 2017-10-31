'use strict';

let https = require ('https');

// **********************************************
// *** Update or verify the following values. ***
// **********************************************

// Replace the subscriptionKey string value with your valid subscription key.
let subscriptionKey = 'ENTER KEY HERE';

let host = 'api.microsofttranslator.com';
let path = '/V2/Http.svc/AddTranslationArray';

let params = '';

let from = "en-us";
let to = "fr-fr";
let original = "Hi there";
let translation = "Salut";
let user = "JohnDoe";

let ns = "http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2";
let content =
	"<AddtranslationsRequest>" +
	"  <AppId />" +
	"  <From>" + from + "</From>" +
	"  <Options>" +
	"    <User xmlns=\"" + ns + "\">" + user + "</User>" +
	"  </Options>" +
	"  <To>" + to + "</To>" +
	"  <Translations>" +
	"    <Translation xmlns=\"" + ns + "\">" +
	"      <OriginalText>" + original + "</OriginalText>" +
	"      <Rating>1</Rating>" +
	"      <TranslatedText>" + translation + "</TranslatedText>" +
	"    </Translation>" +
	"  </Translations>" +
	"</AddtranslationsRequest>";

let response_handler = function (response) {
    let body = '';
    response.on ('data', function (d) {
        body += d;
    });
    response.on ('end', function () {
		console.log (body);
    });
    response.on ('error', function (e) {
        console.log ('Error: ' + e.message);
    });
};

let AddTranslationArray = function () {
	let request_params = {
		method : 'POST',
		hostname : host,
		path : path + params,
		headers : {
			'Content-Type' : 'text/xml',
			'Ocp-Apim-Subscription-Key' : subscriptionKey,
		}
	};

	let req = https.request (request_params, response_handler);
	req.write (content);
	req.end ();
}

AddTranslationArray ();
