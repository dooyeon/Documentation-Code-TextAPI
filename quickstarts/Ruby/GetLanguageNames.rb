require 'net/https'
require 'uri'
require 'cgi'

# **********************************************
# *** Update or verify the following values. ***
# **********************************************

# Replace the key string value with your valid subscription key.
key = 'ENTER KEY HERE'

host = 'https://api.microsofttranslator.com'
path = '/V2/Http.svc/GetLanguageNames'

locale = 'en'
params = '?locale=' + locale

body =
	"<ArrayOfstring xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://schemas.microsoft.com/2003/10/Serialization/Arrays\">" +
	"    <string>en</string>" +
	"    <string>fr</string>" +
	"    <string>uk</string>" +
	"</ArrayOfstring>"

uri = URI (host + path + params)

request = Net::HTTP::Post.new(uri)
request['Content-type'] = 'text/xml'
request['Ocp-Apim-Subscription-Key'] = key
request.body = body

response = Net::HTTP.start(uri.host, uri.port, :use_ssl => uri.scheme == 'https') do |http|
    http.request (request)
end

puts response.body
