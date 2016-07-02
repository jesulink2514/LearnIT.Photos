using LearnIT.Models.Photos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnIT.Controllers
{
    [Authorize]
    public class PhotosController : Controller
    {
        // GET: Photos
        public ActionResult Upload()
        {
            return View();
        }

        //POST
        [HttpPost] 
        public ActionResult Upload(
            UploadViewModel model,
            HttpPostedFileBase image)
        {
            return View();
        }
    }
}