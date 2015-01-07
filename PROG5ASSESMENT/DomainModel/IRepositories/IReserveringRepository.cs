using DomainModel.Models;
using System.Collections.Generic;

namespace DomainModel.IRepositories {

    public interface IReserveringRepository {

        Reservering         Get(int reserveringId);
        List<Reservering>   GetAll();
        Reservering         Create(Reservering reservering);
        Reservering         Update(Reservering reservering);
        void                Delete(Reservering reservering);

        Film                GetFilm(int filmId);
        List<Film>          GetAllFilms();

        List<Korting>       GetAllKortingen();

    }

}
