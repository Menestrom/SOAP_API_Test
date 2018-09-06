using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace Promotion_API_tests
{
    class XMLCreate
    {
        //public static XmlDocument XML()
        //{
        //    GetPromotionPlanRequest MethodBody = new GetPromotionPlanRequest();
        //    XmlSerializer method = new XmlSerializer(typeof(GetPromotionPlanRequest));
        //    // TextWriter txtWriter = new StreamWriter(@"C:\Users\yevhenta\Serialization.xml");
        //    method.Serialize(txtWriter, MethodBody);
        //    // txtWriter.Close();
        //}
        public static XmlDocument XML(object lol)
        {
            XmlSerializer ser = new XmlSerializer(lol.GetType());
            string result = string.Empty;
            using (MemoryStream memStm = new MemoryStream())
            { 
                ser.Serialize(memStm, lol);

                memStm.Position = 0;
                result = new StreamReader(memStm).ReadToEnd();
            }
            XmlDocument xd = new XmlDocument();

            return xd.LoadXml(result);
        }
    }
    public class GlobalBody
    {
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
