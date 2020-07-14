using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            equipe.Imagem = form["Imagem"];

            equipemodel.Create (equipe);
            ViewBag.Equipes = equipemodel.ReadAll ();
            return LocalRedirect ("~/Equipe");

        }
    }
}