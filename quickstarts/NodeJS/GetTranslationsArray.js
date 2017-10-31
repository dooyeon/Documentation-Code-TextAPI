'use strict';

let https = require ('https');

// **********************************************
// *** Update or verify the following values. ***
// **********************************************

// Replace the subscriptionKey string value with your valid subscription key.
let subscriptionKey = 'ENTER KEY HERE';

let host = 'api.microsofttranslator.com';
let path = '/V2/Http.svc/GetTranslationsArray';

let params = '';

let from = "en-us";
let to = "fr-fr";

let ns = "http://schemas.microsoft.com/2003/10/Serialization/Arrays";
let content =
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

let GetTranslationsArray = function () {
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

GetTranslationsArray ();
