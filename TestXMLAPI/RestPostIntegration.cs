using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TestXMLAPI
{
   public  class RestPostIntegration
    {
        private static string className = "RestPostIntegration";

        
        public static T GetIntegration<T>(object request, string requestId, string appId, string appKey, string endpoint, string countryId)
        {

            string methodName = "GetIntegration";

            try
            {
                string param = JsonConvert.SerializeObject(request);
                var client = new RestClient(endpoint);
                var webRequest = new RestRequest();
                //webRequest.AddHeader("content-type", "application/json");
                webRequest.AddHeader("Content-Type", "application/xml");
                webRequest.AddParameter("application/json", param, ParameterType.RequestBody);
                webRequest.RequestFormat = DataFormat.Xml;               
                var webResponse = client.Execute(webRequest);

                if (webResponse.StatusCode != HttpStatusCode.OK)
                {
                    //LogService.LogInfo(requestId, countryId, className, "FI client.Execute Request", JsonConvert.SerializeObject(webResponse));
                    return default(T);
                }

                if (string.IsNullOrEmpty(webResponse.Content))
                {
                    //LogService.LogInfo(requestId, countryId, className, methodName, $"FI Response Details \r\n {webResponse}");
                }              

                //LogService.LogInfo(requestId, countryId, className, methodName, "Response Object " + webResponse?.Content);

                return JsonConvert.DeserializeObject<T>(webResponse?.Content);
            }
            catch (Exception ex)
            {
                //LogService.LogExceptionError(countryId, className, methodName, ex);
                return default(T);
            }

        }

        public static T PostIntegration<T>(object request, string endpoint)
        {

            string methodName = "PostIntegration";

            try
            {
                //string param = JsonConvert.SerializeObject(request);
                //var client = new RestClient(endpoint);
                //var webRequest = new RestRequest();
                //webRequest.AddHeader("content-type", "application/json");
                //webRequest.AddParameter("application/json", param, ParameterType.RequestBody);
                //webRequest.RequestFormat = DataFormat.Json;
                   
                  
                var client = new RestClient("https://localhost:7237/api/WeatherForecast/post.xml");
                var webRequest = new RestRequest();
                webRequest.AddHeader("cache-control", "no-cache");
                webRequest.AddHeader("Content-Type", "application/xml");

                var serializer = Serializer(request);
                var serialize = Serialize(request);




                //webRequest.AddParameter("application/xml", "<CreatePostRequest xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://schemas.datacontract.org/2004/07/RestXMLAPI\">\r\n  <Name>javes</Name>\r\n  <Tag>madden</Tag>\r\n</CreatePostRequest>", ParameterType.RequestBody);
                webRequest.AddParameter("application/xml", serialize, ParameterType.RequestBody);
                //webRequest.AddParameter("{\r\n    \"name\": \"javes\",\r\n    \"tag\": \"madden\"\r\n}", ParameterType.RequestBody);
                


                
                var webResponse = client.ExecutePost(webRequest);

                if (webResponse.StatusCode != HttpStatusCode.OK)
                {
                    //LogService.LogInfo(requestId,countryId, className, "FI client.Execute Request", JsonConvert.SerializeObject(webResponse));
                    return default(T);
                }

                if (string.IsNullOrEmpty(webResponse.Content))
                {
                    //LogService.LogInfo(requestId,countryId, className, methodName, $"FI Response Details \r\n {webResponse}");
                }

                //LogService.LogInfo(requestId,countryId, className, methodName, "Response Object " + webResponse?.Content);

                return JsonConvert.DeserializeObject<T>(webResponse?.Content);
            }
            catch (Exception ex)
            {
                //LogService.LogExceptionError(countryId, className, methodName, ex);
                return default(T);
            }
        }

        public static string Serialize(object dataToSerialize)
        {
            if (dataToSerialize == null) return null;

            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = false,
                Encoding = Encoding.UTF8
            };



            using (StringWriter stringwriter = new System.IO.StringWriter())
            {
                var serializer = new XmlSerializer(dataToSerialize.GetType());
                serializer.Serialize(stringwriter, dataToSerialize);
                return stringwriter.ToString();
            }
        }


        public static string Serializer(object data)
        {
            MemoryStream ms = new MemoryStream();
            StreamWriter sw = new StreamWriter(ms, Encoding.UTF8);
            XmlSerializer xz = new XmlSerializer(data.GetType());
            xz.Serialize(sw, data);
            return Encoding.UTF8.GetString(ms.ToArray());
        }

        public static T Deserialize<T>(string xmlText)
        {
            if (String.IsNullOrWhiteSpace(xmlText)) return default(T);

            using (StringReader stringReader = new System.IO.StringReader(xmlText))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stringReader);
            }
        }


    }
}
