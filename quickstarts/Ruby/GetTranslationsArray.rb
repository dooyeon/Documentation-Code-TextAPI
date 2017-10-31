require 'net/https'
require 'uri'
require 'cgi'

# **********************************************
# *** Update or verify the following values. ***
# **********************************************

# Replace the key string value with your valid subscription key.
key = 'ENTER KEY HERE'

host = 'https://api.microsofttranslator.com'
path = '/V2/Http.svc/GetTranslationsArray'

params = ''

from = "en-us";
to = "fr-fr";

ns = "http://schemas.microsoft.com/2003/10/Serialization/Arrays";
body =
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

uri = URI (host + path + params)

request = Net::HTTP::Post.new(uri)
request['Content-type'] = 'text/xml'
request['Ocp-Apim-Subscription-Key'] = key
request.body = body

response = Net::HTTP.start(uri.host, uri.port, :use_ssl => uri.scheme == 'https') do |http|
    http.request (request)
end

puts response.body
