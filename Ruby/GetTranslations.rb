require 'net/https'
require 'uri'
require 'cgi'

# **********************************************
# *** Update or verify the following values. ***
# **********************************************

# Replace the key string value with your valid subscription key.
key = 'ENTER KEY HERE'

host = 'https://api.microsofttranslator.com'
path = '/V2/Http.svc/GetTranslations'

from = "en-us"
to = "fr-fr"
text = "Hi there"
maxTranslations = "10"
params = "?from=" + from + "&to=" + to + "&maxTranslations=" + maxTranslations + "&text=" + CGI.escape(text)

body = ''

uri = URI (host + path + params)

request = Net::HTTP::Post.new(uri)
request['Content-type'] = 'text/xml'
request['Ocp-Apim-Subscription-Key'] = key
request.body = body

response = Net::HTTP.start(uri.host, uri.port, :use_ssl => uri.scheme == 'https') do |http|
    http.request (request)
end

puts response.body
