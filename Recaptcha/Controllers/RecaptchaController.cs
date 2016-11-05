using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Recaptcha.Controllers
{
    public class RecaptchaController : Controller
    {
        // GET: Recaptcha
        public ActionResult Index()
        {
            return View();
        }
    }
}