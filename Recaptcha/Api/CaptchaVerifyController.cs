using Recaptcha.Models.Recaptcha;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;

namespace Recaptcha.Api
{
    public class CaptchaVerifyController : ApiController
    {
        // GET: api/CaptchaVerify
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CaptchaVerify/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CaptchaVerify
        public ReCaptchaVerifyResponse Post([FromBody] RecaptchaResponse requestParams)
        {
            var clientIp = HttpContext.Current.Request.UserHostAddress;
            return new ReCaptcha().Validate(requestParams.Response, clientIp);
        }

        // PUT: api/CaptchaVerify/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CaptchaVerify/5
        public void Delete(int id)
        {
        }
    }
}
