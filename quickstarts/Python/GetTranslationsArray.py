# -*- coding: utf-8 -*-

import http.client, urllib.parse

# **********************************************
# *** Update or verify the following values. ***
# **********************************************

# Replace the subscriptionKey string value with your valid subscription key.
subscriptionKey = 'ENTER KEY HERE'

host = 'api.microsofttranslator.com'
path = '/V2/Http.svc/GetTranslationsArray'

params = ''

from_language = "en-us";
to_language = "fr-fr";

ns = "http://schemas.microsoft.com/2003/10/Serialization/Arrays"
# NOTE: AppId is required, but it can be empty because we are sending the Ocp-Apim-Subscription-Key header.
body = """
	<GetTranslationsArrayRequest>
	  <AppId />
	  <From>%s</From>
	  <Texts>
	    <string xmlns=\"%s\">Hello</string>
	    <string xmlns=\"%s\">Goodbye</string>
	  </Texts>
	  <To>%s</To>
      <MaxTranslations>10</MaxTranslations>
	</GetTranslationsArrayRequest>
""" % (from_language, ns, ns, to_language)

def GetTranslationsArray ():

	headers = {
		'Ocp-Apim-Subscription-Key': subscriptionKey,
		'Content-type': 'text/xml'
	}
	conn = http.client.HTTPSConnection(host)
	conn.request ("POST", path + params, body, headers)
	response = conn.getresponse ()
	return response.read ()

result = GetTranslationsArray ()
print (result.decode("utf-8"))
