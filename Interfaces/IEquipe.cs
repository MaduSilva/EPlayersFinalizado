using System.Collections.Generic;
using Eplayers.Models;
using EplayersFinalizado.Models;

namespace EplayersFinalizado.Interfaces {

    public interface IEquipe {

        void Create (Equipe e);

        List<Equipe> ReadAll();

        void Update(Equipe e);

        void Delete(int IdEquipe);
    }
}