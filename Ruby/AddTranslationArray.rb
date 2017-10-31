require 'net/https'
require 'uri'
require 'cgi'

# **********************************************
# *** Update or verify the following values. ***
# **********************************************

# Replace the key string value with your valid subscription key.
key = 'ENTER KEY HERE'

host = 'https://api.microsofttranslator.com'
path = '/V2/Http.svc/AddTranslationArray'

params = ''

from = "en-us";
to = "fr-fr";
original = "Hi there";
translation = "Salut";
user = "JohnDoe";

ns = "http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2"
body =
	"<AddtranslationsRequest>" +
	"  <AppId />" +
	"  <From>" + from + "</From>" +
	"  <Options>" +
	"    <User xmlns=\"" + ns + "\">" + user + "</User>" +
	"  </Options>" +
	"  <To>" + to + "</To>" +
	"  <Translations>" +
	"    <Translation xmlns=\"" + ns + "\">" +
	"      <OriginalText>" + original + "</OriginalText>" +
	"      <Rating>1</Rating>" +
	"      <TranslatedText>" + translation + "</TranslatedText>" +
	"    </Translation>" +
	"  </Translations>" +
	"</AddtranslationsRequest>";

uri = URI (host + path + params)

request = Net::HTTP::Post.new(uri)
request['Content-type'] = 'text/xml'
request['Ocp-Apim-Subscription-Key'] = key
request.body = body

response = Net::HTTP.start(uri.host, uri.port, :use_ssl => uri.scheme == 'https') do |http|
    http.request (request)
end

puts response.body
