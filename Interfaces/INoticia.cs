using System.Collections.Generic;
using Eplayers.Models;

namespace Eplayers.Interfaces {

    public interface INoticia {

        void Create (Noticia n);

        List<Noticia> ReadAll();

        void Update(Noticia n);

        void Delete(int IdNoticia);
    }
}