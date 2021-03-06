require 'net/https'
require 'uri'
require 'cgi'

# **********************************************
# *** Update or verify the following values. ***
# **********************************************

# Replace the key string value with your valid subscription key.
key = 'ENTER KEY HERE'

host = 'https://api.microsofttranslator.com'
path = '/V2/Http.svc/Translate'

target = 'fr-fr'
text = 'Hello'

params = '?to=' + target + '&text=' + CGI.escape(text)
uri = URI (host + path + params)

request = Net::HTTP::Get.new(uri)
request['Ocp-Apim-Subscription-Key'] = key

response = Net::HTTP.start(uri.host, uri.port, :use_ssl => uri.scheme == 'https') do |http|
    http.request (request)
end

puts response.body
