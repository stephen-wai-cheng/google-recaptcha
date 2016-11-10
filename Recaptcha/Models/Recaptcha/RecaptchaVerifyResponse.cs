using System.Collections.Generic;

namespace Recaptcha.Models.Recaptcha
{
    public class ReCaptchaVerifyResponse
    {
        public bool Success { get; set; }
        public List<string> ErrorCodes { get; set; }
        public string Hostname { get; set; }
    }
}