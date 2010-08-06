﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using FacebookSharp.Extensions;
using FacebookSharp.Schemas.Graph;

namespace FacebookSharp.Samples.CanvasIFrameApplication.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var far = FacebookAuthenticationResult.Parse(
                Request.Url.ToString(), new FacebookSettings { ApplicationSecret = "" });

            if (!string.IsNullOrEmpty(far.AccessToken))
            {
                var facebook = new Facebook(far.AccessToken);
                ViewData["name"] = facebook.Get<User>("/me").Name;
            }

            return View();
        }
    }
}
