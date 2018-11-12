using System;
using System.IO;
using System.Net;
using HurCoreProj.Core;

namespace HurCoreProj.Web.Helper
{
    public class WebServiceHelper
    {
        public T GetServiceData<T>(string serviceUrl)
        {
            if(string.IsNullOrEmpty(serviceUrl))
                throw  new ArgumentNullException($"{nameof(serviceUrl)} parametresi boş geçilemez.");

            string jsonString = GetRestService(serviceUrl);

            return JsonSerializer.ActiveInstance.DeserializeObject<T>(jsonString);
        }

        private string GetRestService(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }
    }
}
