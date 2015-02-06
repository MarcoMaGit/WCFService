using System.ServiceModel;
using System.ServiceModel.Web;

namespace RestService
{
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;

    [ServiceContract]
    public interface IRestServiceImpl
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "xml/{id}")]
        string XMLData(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "json/{id}")]
        string JSONData(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Xml, RequestFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "auth")]
        ResponseData Auth(RequestData rData);

        [OperationContract]
        [WebInvoke(UriTemplate = "storesensordata")]
        Stream StoreSensorData(Stream request);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getsensordata")]
        XElement GetSensorData();
    }
}