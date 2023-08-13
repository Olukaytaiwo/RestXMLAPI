# RestXMLAPI

The service accepts both JSON and XML requests.

It also outputs both JSON and XML responses.


JSON        -     JSON |
XML         -      XML |
JSON        -      XML |
XML         -     JSON |


Feel free to modify as you wish. Ofe ni igbala!


GET SAMPLE REQUEST WITH XML RESPONSE

curl -X 'GET' \
  'https://localhost:7237/api/WeatherForecast/get.xml' \
  -H 'accept: application/xml'

GET SAMPLE REQUEST WITH JSON RESPONSE
curl -X 'GET' \
  'https://localhost:7237/api/WeatherForecast/get.json' \
  -H 'accept: application/json'


SAMPLE POST JSON REQUEST AND JSON RESPONSE

curl -X 'POST' \
  'https://localhost:7237/api/WeatherForecast/post.json' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "name": "Taiwo",
  "tag": "Test"
}'

SAMPLE XML REQUEST WITH XML RESPONSE

curl -X 'POST' \
  'https://localhost:7237/api/WeatherForecast/post.XML' \
  -H 'accept: */*' \
  -H 'Content-Type: application/xml' \
  -d '<CreatePostRequest xmlns:i="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://schemas.datacontract.org/2004/07/RestXMLAPI">
  <Name>javes</Name>
  <Tag>madden</Tag>
</CreatePostRequest>'


SAMPLE POST JSON REQUEST AND XML RESPONSE

curl -X 'POST' \
  'https://localhost:7237/api/WeatherForecast/post.xml' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "name": "tAIWO",
  "tag": "Test"
}'


SAMPLE XML REQUEST WITH JSON RESPONSE

curl -X 'POST' \
  'https://localhost:7237/api/WeatherForecast/post.json' \
  -H 'accept: */*' \
  -H 'Content-Type: application/xml' \
  -d '<CreatePostRequest xmlns:i="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://schemas.datacontract.org/2004/07/RestXMLAPI">
  <Name>javes</Name>
  <Tag>madden</Tag>
</CreatePostRequest>'



