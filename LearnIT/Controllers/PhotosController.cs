﻿using LearnIT.Domain;
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
                var generated = GenerateFileName(image.FileName);
                var foto = GetFileName(generated,
                    User.Identity.GetUserId());

                image.SaveAs(foto);

                var photo = new Photo()
                {
                    Description = model.Description,
                    Tags = model.Tags,
                    UserId = User.Identity.GetUserId(),
                    Name = image.FileName,
                    FileName = generated,
                    MimeType = image.ContentType
                };
                _context.Photos.Add(photo);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();
            var fotos = _context.Photos.Where(x => x.UserId == id).ToList();
            return View(fotos);
        }

        public ActionResult Download(long id)
        {
            var userId = User.Identity.GetUserId();
            var foto = _context.Photos
                .FirstOrDefault(x => x.Id == id && x.UserId == userId);
            if (foto == null) return HttpNotFound();

            var physic = GetFileName(foto.FileName, userId);

            return File(physic, foto.MimeType, foto.Name);
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

        private string GenerateFileName(string name)
        {
            var filename = Guid.NewGuid().ToString();
            var ext = Path.GetExtension(name);
            return filename + ext;
        }
    }
}