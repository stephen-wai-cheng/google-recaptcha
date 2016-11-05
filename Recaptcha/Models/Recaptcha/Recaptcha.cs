using System.Collections.Generic;
using System.Configuration;

namespace Recaptcha.Models.ReCaptcha
{

    public class ReCaptcha
    {
        public bool Success { get; set; }
        public List<string> ErrorCodes { get; set; }
        public string Response { get; set; }

        public static ReCaptcha Validate(string encodedResponse, string ip)
        {
            if (string.IsNullOrEmpty(encodedResponse)) return new ReCaptcha();

            var client = new System.Net.WebClient();
            var secret = ConfigurationManager.AppSettings["Google.ReCaptcha.Secret"];

            if (string.IsNullOrEmpty(secret)) return new ReCaptcha();

            var googleReply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}&remoteip{2}", secret, encodedResponse, ip));

            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

            var reCaptcha = serializer.Deserialize<ReCaptcha>(googleReply);

            return reCaptcha;
        }
    }
}
