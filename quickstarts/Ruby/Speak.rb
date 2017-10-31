require 'net/https'
require 'uri'
require 'cgi'

# **********************************************
# *** Update or verify the following values. ***
# **********************************************

# Replace the key string value with your valid subscription key.
key = 'ENTER KEY HERE'

host = 'https://api.microsofttranslator.com'
path = '/V2/Http.svc/Speak'

text = "Hello world";
language = "en-US";
output_path = "speak.wav";

params = "?text=" + CGI.escape(text) + "&language=" + language;

uri = URI (host + path + params)

request = Net::HTTP::Get.new(uri)
request['Ocp-Apim-Subscription-Key'] = key

response = Net::HTTP.start(uri.host, uri.port, :use_ssl => uri.scheme == 'https') do |http|
    http.request (request)
end

File.open(output_path, 'wb' ) do |output|
	output.print response.body
end
