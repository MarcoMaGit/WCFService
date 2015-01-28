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
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpWebRequest req = null;
            HttpWebResponse res = null;
            try
            {
                //const string url = "http://localhost:35798/RestServiceImpl.svc/auth";
                const string url = "http://marcoweb.chinacloudsites.cn/RestServiceImpl.svc/auth";
                req = (HttpWebRequest) WebRequest.Create(url);
                req.Method = "POST";
                req.ContentType = "application/xml; charset=utf-8";
                req.Timeout = 30000;
                req.Headers.Add("SOAPAction", url);

                var xmlDoc = new XmlDocument {XmlResolver = null};
                xmlDoc.Load(Server.MapPath("PostData.xml"));
                string sXml = xmlDoc.InnerXml;
                req.ContentLength = sXml.Length;
                var sw = new StreamWriter(req.GetRequestStream());
                sw.Write(sXml);
                sw.Close();

                res = (HttpWebResponse) req.GetResponse();
                Stream responseStream = res.GetResponseStream();
                var streamReader = new StreamReader(responseStream);

                //Read the response into an xml document
                var soapResonseXmlDocument = new XmlDocument();
                soapResonseXmlDocument.LoadXml(streamReader.ReadToEnd());

                //return only the xml representing the response details (inner request)
                // TextBox1.Text = soapResonseXmlDocument.InnerXml;
                //Response.Write(soapResonseXMLDocument.InnerXml);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                //const string url = "http://localhost:35798/RestServiceImpl.svc/echo";
                const string url = "http://marcoweb.chinacloudsites.cn/RestServiceImpl.svc/storesensordata";

                HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
                webRequest.Method = "POST";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                string str = "Temperature: 20";
                Stream os = null;
                webRequest.ContentLength = str.Length;
                var sw = new StreamWriter(webRequest.GetRequestStream());
                sw.Write(str);
                sw.Close();

                WebResponse webResponse = webRequest.GetResponse();
                Stream responseStream = webResponse.GetResponseStream();
                var streamReader = new StreamReader(responseStream);

                TextBox2.Text = streamReader.ReadToEnd();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}