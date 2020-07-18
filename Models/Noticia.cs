using System;
using System.Collections.Generic;
using System.IO;
using Eplayers.Interfaces;
using EplayersFinalizado.Models;

namespace Eplayers.Models {
    public class Noticia : EplayersBase , INoticia {

        public int IdNoticia { get; set; }

        public string Titulo { get; set; }

        public string Texto { get; set; }

        public string Imagem { get; set; }

        private const string PATH = "Database/noticia.csv";

        /// <summary>
        /// Cria Folder e File Noticia
        /// </summary>
        public Noticia () {
            CreateFolderAndFile (PATH);
        }

        /// <summary>
        /// Criar Noticia
        /// </summary>
        /// <param name="n">Noticia</param>
        public void Create (Noticia n) {
            string[] linha = { Prepare (n) }; 
            File.AppendAllLines (PATH, linha);
        }

        /// <summary>
        /// Preparar estrutura id;titulo;texto;imagem
        /// </summary>
        /// <param name="n">Noticia</param>
        private string Prepare (Noticia n) {
            return $"{n.IdNoticia};{n.Titulo};{n.Texto};{n.Imagem}";
        }



        /// <summary>
        /// Deleta a Noticia
        /// </summary>
        /// <param name="IdNoticia">Id da Noticia</param>
        public void Delete (int IdNoticia) {
            List<string> linhas = ReadAllLinesCSV (PATH);
            linhas.RemoveAll (y => y.Split (";") [0] == IdNoticia.ToString ());
            RewriteCSV (PATH, linhas);
        }


        /// <summary>
        /// Ler Noticias
        /// </summary>
        /// <returns>Return Noticias</returns>
        public List<Noticia> ReadAll () {
            List<Noticia> noticias = new List<Noticia> ();
            string[] linhas = File.ReadAllLines (PATH);
            foreach (var item in linhas) {
                string[] linha = item.Split (";");
                Noticia noticia = new Noticia ();
                noticia.IdNoticia = Int32.Parse (linha[0]);
                noticia.Titulo = linha[1];
                noticia.Texto = linha[2];
                noticia.Imagem = linha[3];

                noticias.Add (noticia);
            }
            return noticias;
        }

        /// <summary>
        /// Update Noticias
        /// </summary>
        /// <param name="n">Noticia</param>
        public void Update (Noticia n) {
            List<string> linhas = ReadAllLinesCSV (PATH);
            linhas.RemoveAll (y => y.Split (";") [0] == n.IdNoticia.ToString ());
            linhas.Add (Prepare (n));
            RewriteCSV (PATH, linhas);
            //update equipe
        }
    }
}

