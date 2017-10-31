# -*- coding: utf-8 -*-

import http.client, urllib.parse

# **********************************************
# *** Update or verify the following values. ***
# **********************************************

# Replace the subscriptionKey string value with your valid subscription key.
subscriptionKey = 'ENTER KEY HERE'

host = 'api.microsofttranslator.com'
path = '/V2/Http.svc/AddTranslationArray'

params = ''

from_language = "en-us"
to_language = "fr-fr"
original = "Hi there"
translation = "Salut"
user = "JohnDoe"

ns = "http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2"
# NOTE: AppId is required, but it can be empty because we are sending the Ocp-Apim-Subscription-Key header.
body = """
	<AddtranslationsRequest>
	  <AppId />
	  <From>%s</From>
	  <Options>
	    <User xmlns=\"%s\">%s</User>
	  </Options>
	  <To>%s</To>
	  <Translations>
	    <Translation xmlns=\"%s\">
	      <OriginalText>%s</OriginalText>
	      <Rating>1</Rating>
	      <TranslatedText>%s</TranslatedText>
	    </Translation>
	  </Translations>
	</AddtranslationsRequest>
""" % (from_language, ns, user, to_language, ns, original, translation)

def AddTranslationArray ():

	headers = {
		'Ocp-Apim-Subscription-Key': subscriptionKey,
		'Content-type': 'text/xml'
	}
	conn = http.client.HTTPSConnection(host)
	conn.request ("POST", path + params, body, headers)
	response = conn.getresponse ()
	return response.read ()

result = AddTranslationArray ()
print (result.decode("utf-8"))
