using System.Configuration;
using System.Diagnostics;

namespace Recaptcha.Models.Recaptcha
{

    public class ReCaptcha : IReCaptcha
    {
        public string SiteKey { get; set; }
        public string SiteSecret { get; set; }
        public string ScriptUrl { get; set; }
        public string VerifyUrl { get; set; }

        public ReCaptcha(bool useTestKey = false)
        {
            if (useTestKey)
            {
                SiteKey = ConfigurationManager.AppSettings["Google.ReCaptcha.Test.Site.Key"];
                SiteSecret = ConfigurationManager.AppSettings["Google.ReCaptcha.Test.Secret"];
            }
            else
            {
                SiteKey = ConfigurationManager.AppSettings["Google.ReCaptcha.Site.Key"];
                SiteSecret = ConfigurationManager.AppSettings["Google.ReCaptcha.Secret"];
            }
            ScriptUrl = ConfigurationManager.AppSettings["Google.ReCaptcha.Script.Url"];
            VerifyUrl = ConfigurationManager.AppSettings["Google.ReCaptcha.Verify.Url"];
        }

        public ReCaptchaVerifyResponse Validate(string encodedResponse, string clientIp)
        {
            if (string.IsNullOrEmpty(encodedResponse) || string.IsNullOrEmpty(SiteSecret))
            {
                return new ReCaptchaVerifyResponse();
            }

            var client = new System.Net.WebClient();
            var googleReply = client.DownloadString(string.Format(VerifyUrl, SiteSecret, encodedResponse, clientIp));
            googleReply = googleReply.Replace("error-codes", "errorcodes");
            Debug.WriteLine(googleReply);

            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

            var reCaptchaVerifyResponse = serializer.Deserialize<ReCaptchaVerifyResponse>(googleReply);

            return reCaptchaVerifyResponse;
        }
    }
}
