'use strict';

let https = require ('https');

// **********************************************
// *** Update or verify the following values. ***
// **********************************************

// Replace the subscriptionKey string value with your valid subscription key.
let subscriptionKey = 'ENTER KEY HERE';

let host = 'api.microsofttranslator.com';
let path = '/V2/Http.svc/AddTranslation';

let originalText = "Hi there";
let translatedText = "Salut";
let from = "en-US";
let to = "fr-fr";
let user = "JohnDoe";

let params =
	"?originalText=" + encodeURI (originalText) +
	"&translatedText=" + encodeURI (translatedText) +
	"&from=" + from +
	"&to=" + to +
	"&user=" + encodeURI (user);

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

let AddTranslation = function () {
	let request_params = {
		method : 'GET',
		hostname : host,
		path : path + params,
		headers : {
			'Ocp-Apim-Subscription-Key' : subscriptionKey,
		}
	};

	let req = https.request (request_params, response_handler);
	req.end ();
}

AddTranslation ();
