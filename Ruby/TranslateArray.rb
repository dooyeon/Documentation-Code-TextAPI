require 'net/https'
require 'uri'
require 'cgi'

# **********************************************
# *** Update or verify the following values. ***
# **********************************************

# Replace the key string value with your valid subscription key.
key = 'ENTER KEY HERE'

host = 'https://api.microsofttranslator.com'
path = '/V2/Http.svc/TranslateArray'

params = ''

ns = "http://schemas.microsoft.com/2003/10/Serialization/Arrays"
body =
	"<TranslateArrayRequest>" +
	# NOTE: AppId is required, but it can be empty because we are sending the Ocp-Apim-Subscription-Key header.
	"	<AppId />" +
	"	<Texts>" +
	"		<string xmlns=\"" + ns + "\">Hello</string>" +
	"		<string xmlns=\"" + ns + "\">Goodbye</string>" +
	"	</Texts>" +
	"	<To>fr-fr</To>" +
	"</TranslateArrayRequest>"

uri = URI (host + path + params)

request = Net::HTTP::Post.new(uri)
request['Content-type'] = 'text/xml'
request['Ocp-Apim-Subscription-Key'] = key
request.body = body

response = Net::HTTP.start(uri.host, uri.port, :use_ssl => uri.scheme == 'https') do |http|
    http.request (request)
end

puts response.body
