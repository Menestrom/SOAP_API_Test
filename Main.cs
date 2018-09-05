using System;
using System.Net;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Threading;

namespace Promotion_API_tests
{
    class Program
    {
        static void Main(string[] args)
        {
            FormatXML(CallWebService());
        }
        public static string CallWebService()
        {
            XmlDocument soapBodyXml = CreateSoapBody();
            HttpWebRequest webRequest = CreateWebRequest(Configurations.PromotionService.URL, 
                                                         Configurations.PromotionService.GetPromotionPlanRequest);
            InsertSoapBodyIntoWebRequest(soapBodyXml, webRequest);

            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);
            asyncResult.AsyncWaitHandle.WaitOne();
            string soapResult;
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }
                return soapResult;
            }
        }
        private static HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=UTF-8";
            webRequest.Method = "POST";
            webRequest.Accept = "text/xml";
            return webRequest;
        }
        private static XmlDocument CreateSoapBody()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\yevhenta\Documents\Visual Studio 2015\Projects\Promotion_API_tests\Promotion_API_tests\RequestBody.txt");
            return doc;
        }
        private static void InsertSoapBodyIntoWebRequest(XmlDocument soapBodyXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapBodyXml.Save(stream);
            }
        }
        public static void FormatXML (string result)
        {
            XDocument doc = XDocument.Parse(result);
            Console.Write(doc.ToString());
            Thread.Sleep(3000);
        }

    }
}

