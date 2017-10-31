require 'net/https'
require 'uri'
require 'cgi'

# **********************************************
# *** Update or verify the following values. ***
# **********************************************

# Replace the key string value with your valid subscription key.
key = 'ENTER KEY HERE'

host = 'https://api.microsofttranslator.com'
path = '/V2/Http.svc/AddTranslation'

originalText = "Hi there"
translatedText = "Salut"
from = "en-US"
to = "fr-fr"
user = "JohnDoe"

params =
	"?originalText=" + CGI.escape(originalText) +
	"&translatedText=" + CGI.escape(translatedText) +
	"&from=" + from +
	"&to=" + to +
	"&user=" + CGI.escape(user);

uri = URI (host + path + params)

request = Net::HTTP::Get.new(uri)
request['Ocp-Apim-Subscription-Key'] = key

response = Net::HTTP.start(uri.host, uri.port, :use_ssl => uri.scheme == 'https') do |http|
    http.request (request)
end

puts response.body
