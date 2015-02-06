using System;

namespace SensorDataService
{
    using System.Xml.Linq;

    public class SensorDataRepository
    {
        private readonly XDocument sensorDatas;

        public SensorDataRepository()
        {
            sensorDatas = new XDocument();
            sensorDatas.Add(new XElement("SensorDatas"));
        }

        public void InsertSensorData(string parameterValue)
        {
            var parameter = new XElement("SensorData") { Value = parameterValue };
            parameter.SetAttributeValue("TimeStamp", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            var root = this.sensorDatas.Root;
            if (root != null)
            {
                root.Add(parameter);
            }
        }

        public XElement GetSensorData()
        {
            var xDocument = this.sensorDatas.Document;
            if (xDocument != null)
            {
                return xDocument.Element("SensorDatas");
            }

            return null;
        }
    }
}