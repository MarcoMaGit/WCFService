using System;
using System.IO;
using System.Net;
using System.Web.UI;

namespace WebClient
{
    using System.Xml;
    using System.Xml.Linq;

    public partial class _default : Page
    {
        // private string wcfUrl = @"http://localhost:35798/SensorDataServiceImpl.svc/";
        private string wcfUrl = @"http://marcoweb.chinacloudsites.cn/SensorDataServiceImpl.svc/";

        protected void Page_Load(object sender, EventArgs e)
        {
            ServicePointManager.Expect100Continue = false;
        }

        protected void BtnInsertSensorDataClick(object sender, EventArgs e)
        {
            try
            {
                string url = wcfUrl + "storesensordata";

                var webRequest = WebRequest.Create(url) as HttpWebRequest;
                if (webRequest != null)
                {
                    webRequest.Method = "POST";
                    webRequest.ContentType = "application/x-www-form-urlencoded";
                    string str = "Temperature: " + SensorValue.Text;
                    webRequest.ContentLength = str.Length;
                    var sw = new StreamWriter(webRequest.GetRequestStream());
                    sw.Write(str);
                    sw.Close();

                    WebResponse webResponse = webRequest.GetResponse();
                    Stream responseStream = webResponse.GetResponseStream();
                    if (responseStream != null)
                    {
                        var streamReader = new StreamReader(responseStream);

                        this.txtInsertSensorData.Text = streamReader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void BtnShowSensorDataClick(object sender, EventArgs e)
        {
            string url = wcfUrl + "getsensordata";
            var webRequest = WebRequest.Create(url) as HttpWebRequest;
            if (webRequest != null)
            {
                webRequest.Method = "GET";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                WebResponse webResponse = webRequest.GetResponse();
                Stream responseStream = webResponse.GetResponseStream();

                if (responseStream != null)
                {
                    //var streamReader = new StreamReader(responseStream);
                    XElement xElement = XElement.Load(responseStream);

                    this.SensorDataList.Text = "";
                    foreach (XElement sensorData in xElement.Elements())
                    {
                        this.SensorDataList.Text += "TimeStamp :" + sensorData.Attribute("TimeStamp").Value + " "
                                                    + sensorData.Value + "\n";
                    }
                }
            }
        }
    }
}