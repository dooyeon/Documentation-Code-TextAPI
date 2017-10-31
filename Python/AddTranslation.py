# -*- coding: utf-8 -*-

import http.client, urllib.parse

# **********************************************
# *** Update or verify the following values. ***
# **********************************************

# Replace the subscriptionKey string value with your valid subscription key.
subscriptionKey = 'ENTER KEY HERE'

host = 'api.microsofttranslator.com'
path = '/V2/Http.svc/AddTranslation'

originalText = "Hi there"
translatedText = "Salut"
from_language = "en-US"
to_language = "fr-fr"
user = "JohnDoe"

params = "?originalText=" + urllib.parse.quote (originalText) + "&translatedText=" + urllib.parse.quote (translatedText) + "&from=" + from_language + "&to=" + to_language + "&user=" + urllib.parse.quote (user)

def AddTranslation ():

	headers = { 'Ocp-Apim-Subscription-Key': subscriptionKey }
	conn = http.client.HTTPSConnection(host)
	conn.request ("GET", path + params, None, headers)
	response = conn.getresponse ()
	return response.read ()

result = AddTranslation ()
print (result.decode("utf-8"))
