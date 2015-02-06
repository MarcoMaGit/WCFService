using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestService
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
            try
            {
                XElement parameter = new XElement("SensorData") { Value = parameterValue };
                parameter.SetAttributeValue("TimeStamp", DateTime.Now.ToUniversalTime());
                var root = this.sensorDatas.Root;
                if (root != null)
                {
                    root.Add(parameter);
                }
            }
            catch (Exception ex)
            {                
                throw ex;
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

    public static class SensorDataRepositoryFactory
    {

        /// <summary>
        /// This is a thread-safe, lazy singleton.  See http://www.yoda.arachsys.com/csharp/singleton.html
        /// for more details about its implementation.
        /// </summary>

        public static SensorDataRepository Instance
        {
            get { return Nested.SensorDataRepository; }
        }

        private class Nested
        {
            internal static readonly SensorDataRepository SensorDataRepository = new SensorDataRepository();
        }
    }
}