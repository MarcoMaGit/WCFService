namespace RestService
{
    using System.IO;
    using System.ServiceModel.Web;

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
            string text = "Sensor Data Stored: " + reader.ReadToEnd();
            var encoding = new System.Text.ASCIIEncoding();
            var ms = new MemoryStream(encoding.GetBytes(text));
            if (WebOperationContext.Current != null)
            {
                WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
            }
            return ms;
        }

        #endregion      
    }
}