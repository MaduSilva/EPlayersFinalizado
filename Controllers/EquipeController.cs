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

namespace Eplayers.Controllers {
    public class EquipeController : Controller {

        ///mapeamento
        Equipe equipemodel = new Equipe ();

        public IActionResult Index () {
            ViewBag.Equipes = equipemodel.ReadAll ();
            return View ();
        }

        public IActionResult Cadastrar (IFormCollection form) {

            Equipe equipe = new Equipe ();
            equipe.IdEquipe = Int32.Parse (form["IdEquipe"]);
            equipe.Nome = form["Nome"];

            //upload da imagem
           equipe.Imagem = form["Imagem"];

            var file = form.Files[0];

            //path combine - combina caminhos ex: pastaA/pastaB/pastaC/arquivo.png
            //verifica o diretório
            var folder = Path.Combine (Directory.GetCurrentDirectory (), "wwwroot/img/Equipes");

            //se o arquivo existir, mas o diretório não, ele cria o diretorio
            //se o arquivo não existir, ele cria
            if (file != null) {
                if (!Directory.Exists (folder)) {
                    Directory.CreateDirectory (folder);
                }
                //GetCurrentDirectory captura o diretório atual
                var path = Path.Combine (Directory.GetCurrentDirectory (), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream (path, FileMode.Create)) {
                    file.CopyTo (stream);
                }
                equipe.Imagem = file.FileName;
            } else {
                equipe.Imagem = "padrao.png";
            }
            // fim da imagem
            
            equipemodel.Create (equipe);
            ViewBag.Equipes = equipemodel.ReadAll ();

            return LocalRedirect ("~/Equipe");
        }
    }
}

