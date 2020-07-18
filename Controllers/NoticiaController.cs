using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Eplayers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EplayersFinalizado.Controllers {
    public class NoticiaController : Controller {

        ///mapeamento
        Noticia noticiamodel = new Noticia ();

        public IActionResult Index () {
            ViewBag.Noticias = noticiamodel.ReadAll ();
            return View ();

        }

        public IActionResult Cadastrar (IFormCollection form) {

            Noticia noticia = new Noticia ();
            noticia.IdNoticia = Int32.Parse (form["IdNoticia"]);
            noticia.Titulo = form["Titulo"];

           
            var file = form.Files[0];
            var folder = Path.Combine (Directory.GetCurrentDirectory (), "wwwroot/img/Noticias");
            if (file != null) {
                if (!Directory.Exists (folder)) {
                    Directory.CreateDirectory (folder);
                }
                var path = Path.Combine (Directory.GetCurrentDirectory (), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream (path, FileMode.Create)) {
                    file.CopyTo (stream);
                }
                noticia.Imagem = file.FileName;
            } else {
                noticia.Imagem = "padrao.png";
            }
          

            noticiamodel.Create (noticia);
            return LocalRedirect ("~/Noticia");
        }

        [Route ("[controller]/{id}")]

        public IActionResult Excluir (int id) {
            noticiamodel.Delete (id);
            return LocalRedirect ("~/Noticia");
        }
    }
}