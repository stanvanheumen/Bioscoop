using DomainModel.Models;
using System.Collections.Generic;

namespace DomainModel.IRepositories {

    public interface IFilmRepository {

        Film        Get(int filmId);
        List<Film>  GetAll();
        Film        Create(Film film);
        Film        Update(Film film);
        void        Delete(Film film);

        Zaal        GetZaal(int zaalId);
        List<Zaal>  GetAllZalen();

    }

}
