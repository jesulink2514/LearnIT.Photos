using LearnIT.Domain;
using LearnIT.Infraestructure.Database;
using LearnIT.Models.Photos;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnIT.Controllers
{
    [Authorize]
    public class PhotosController : Controller
    {
        private readonly LearnITContext _context; 
        public PhotosController()
        {
            _context = new LearnITContext();
        }

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
            if (image == null)
                ModelState.AddModelError("image",
                    "La imagen es requerida.");

            if (ModelState.IsValid)
            {
                var photo = new Photo()
                {
                    Description = model.Description,
                    Tags = model.Tags,
                    UserId = User.Identity.GetUserId(),
                    Name = image.FileName,
                    MimeType = image.ContentType
                };
                _context.Photos.Add(photo);
                _context.SaveChanges();
                image.SaveAs(
                    GetFileName(image.FileName,
                    User.Identity.GetUserId()));

                return RedirectToAction("Index");
            }
            return View(model);
        }

        private string GetFileName(string name,string userId)
        {
            var format = "~/images/{0}";
            var file = String.Format(format, userId);
            var folder = Server.MapPath(file);

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            return Path.Combine(folder, name);
        }
    }
}