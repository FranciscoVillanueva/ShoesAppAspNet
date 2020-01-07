using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shoes__App.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult FileUpload(HttpPostedFileBase file)
        //{
        //    string pic = System.IO.Path.GetFileName(file.FileName);
        //    if (file != null)
        //    {
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            file.InputStream.CopyTo(ms);
        //            byte[] array = ms.GetBuffer();
        //        }

        //    }
        //    after successfully uploading redirect the user
        //    return base.File(file.FileName, "image/jpeg");
        //    return RedirectToAction("Index", "Home");
        //    return RedirectToAction("Create");
        //    return PartialView("_Image");

        //}

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}