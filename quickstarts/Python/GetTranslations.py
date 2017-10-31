# -*- coding: utf-8 -*-

import http.client, urllib.parse

# **********************************************
# *** Update or verify the following values. ***
# **********************************************

# Replace the subscriptionKey string value with your valid subscription key.
subscriptionKey = 'ENTER KEY HERE'

host = 'api.microsofttranslator.com'
path = '/V2/Http.svc/GetTranslations'

from_language = "en-us"
to_language = "fr-fr"
text = "Hi there"
maxTranslations = "10"
params = "?from=" + from_language + "&to=" + to_language + "&maxTranslations=" + maxTranslations + "&text=" + urllib.parse.quote (text)

body = ''

def GetTranslations ():

	headers = {
		'Ocp-Apim-Subscription-Key': subscriptionKey,
		'Content-type': 'text/xml'
	}
	conn = http.client.HTTPSConnection(host)
	conn.request ("POST", path + params, body, headers)
	response = conn.getresponse ()
	return response.read ()

result = GetTranslations ()
print (result.decode("utf-8"))
