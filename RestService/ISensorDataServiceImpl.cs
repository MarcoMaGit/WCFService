using System.IO;
using System.Xml.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace SensorDataService
{
    [ServiceContract]
    public interface ISensorDataServiceImpl
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "storesensordata")]
        Stream StoreSensorData(Stream request);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getsensordata")]
        XElement GetSensorData();
    }
}