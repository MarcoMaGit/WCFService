namespace RestService
{
    using System;
    using System.ComponentModel.Design;
    using System.IO;
    using System.ServiceModel.Web;
    using System.Web;
    using System.Xml;
    using System.Xml.Linq;

    public class RestServiceImpl : IRestServiceImpl
    {
        #region IRestServiceImpl Members

        public string XMLData(string id)
        {
            return "You requested product " + id;
        }

        public string JSONData(string id)
        {
            return "You requested product " + id;
        }

        public ResponseData Auth(RequestData rData)
        {
            // Call BLL here
            var data = rData.details.Split('|');
            var response = new ResponseData
                               {
                                   Name = data[0],
                                   Age = data[1],
                                   Exp = data[2],
                                   Technology = data[3]
                               };

            return response;
        }

        public Stream StoreSensorData(Stream request)
        {
            var reader = new StreamReader(request);
            string data = reader.ReadToEnd();
            string text = "Sensor Data Stored: " + data;
            SensorDataRepositoryFactory.Instance.InsertSensorData(data);
            // SaveDataToXMLFile(data);
            var encoding = new System.Text.ASCIIEncoding();
            var ms = new MemoryStream(encoding.GetBytes(text));
            if (WebOperationContext.Current != null)
            {
                WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
            }
            return ms;
        }

        private void SaveDataToXMLFile(string value)
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"\SensorData.xml";
                XDocument doc = XDocument.Load(path);
                XElement ele = new XElement("SensorData", value);
                ele.SetAttributeValue("TimeStamp",DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                doc.Root.Add(ele);
                doc.Save(path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public XElement GetSensorData()
        {
            return SensorDataRepositoryFactory.Instance.GetSensorData();
            // var doc = new XmlDocument();
            // doc.Load(AppDomain.CurrentDomain.BaseDirectory + @"\SensorData.xml");
            // return doc.DocumentElement;
        }

        #endregion      
    }
}