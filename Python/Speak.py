# -*- coding: utf-8 -*-

import http.client, urllib.parse

# **********************************************
# *** Update or verify the following values. ***
# **********************************************

# Replace the subscriptionKey string value with your valid subscription key.
subscriptionKey = 'ENTER KEY HERE'

host = 'api.microsofttranslator.com'
path = '/V2/Http.svc/Speak'

text = "Hello world"
language = "en-US"
output_path = "speak.wav"
params = "?text=" + urllib.parse.quote (text) + "&language=" + language

def Speak ():

	headers = { 'Ocp-Apim-Subscription-Key': subscriptionKey }
	conn = http.client.HTTPSConnection(host)
	conn.request ("GET", path + params, None, headers)
	response = conn.getresponse ()
	return response.read ()

result = Speak ()

f = open(output_path, 'wb')
f.write (result)
f.close

print ('File written.')
