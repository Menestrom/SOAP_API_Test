using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.ServiceModel;

namespace Promotion_API_tests
{
    class XMLCreate
    {
        public static string XML()
        {
            GetPromotionPlanRequest MethodBody = new GetPromotionPlanRequest();
            XmlSerializer ser = new XmlSerializer(MethodBody.GetType());
            string result = string.Empty;
            using (MemoryStream memStm = new MemoryStream())
            { 
                ser.Serialize(memStm, MethodBody);
                memStm.Position = 0;
                result = new StreamReader(memStm).ReadToEnd();
            }
            return result;
        }
    }
    [MessageContract]
    public class GlobalBody
    {
        [MessageHeader] 
        public int NetworkID = 29;
        public int OperationSourceApplicationID = 7;
        public int SkinID = 29001;
    }
    public class GetPromotionPlanRequest: GlobalBody
    {
        public int[] CustomersList = {2024219324, 2024219325};
        public string Name = "aaa";
        public int PlatformID = 21;
        public int PromotionPlanID= 471;
    }
}
