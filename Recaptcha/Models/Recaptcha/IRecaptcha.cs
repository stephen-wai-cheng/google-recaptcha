using System.Collections.Generic;
using System.Diagnostics;

namespace Recaptcha.Models.Recaptcha
{
    public interface IReCaptcha
    {
        string SiteKey { get; set; }
        string SiteSecret { get; set; }
        string ScriptUrl { get; set; }
        string VerifyUrl { get; set; }
        ReCaptchaVerifyResponse Validate(string encodedResponse, string clientIp);
    }
}
