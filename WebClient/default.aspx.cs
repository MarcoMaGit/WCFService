using System;
using System.IO;
using System.Net;
using System.Web.UI;
using System.Xml;

namespace WebClient
{
    using System.Text;

    public partial class _default : Page
    {
        private string wcfUrl = @"http://localhost:35798/RestServiceImpl.svc/";
        // private string wcfUrl = @"http://marcoweb.chinacloudsites.cn/RestServiceImpl.svc/";

        protected void Page_Load(object sender, EventArgs e)
        {
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
                    string str = "Temperature: 20";
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
                    var streamReader = new StreamReader(responseStream);

                    this.SensorDataList.Text = streamReader.ReadToEnd();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpWebRequest req = null;
            HttpWebResponse res = null;
            try
            {
                string url = wcfUrl + "/auth";
                req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "POST";
                req.ContentType = "application/xml; charset=utf-8";
                req.Timeout = 30000;
                req.Headers.Add("SOAPAction", url);

                var xmlDoc = new XmlDocument { XmlResolver = null };
                xmlDoc.Load(Server.MapPath("PostData.xml"));
                string sXml = xmlDoc.InnerXml;
                req.ContentLength = sXml.Length;
                var sw = new StreamWriter(req.GetRequestStream());
                sw.Write(sXml);
                sw.Close();

                res = (HttpWebResponse)req.GetResponse();
                Stream responseStream = res.GetResponseStream();
                var streamReader = new StreamReader(responseStream);

                //Read the response into an xml document
                var soapResonseXmlDocument = new XmlDocument();
                soapResonseXmlDocument.LoadXml(streamReader.ReadToEnd());

                //return only the xml representing the response details (inner request)
                //TextBox1.Text = soapResonseXmlDocument.InnerXml;
                //Response.Write(soapResonseXMLDocument.InnerXml);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}