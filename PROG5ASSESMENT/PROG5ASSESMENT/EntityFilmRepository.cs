using DomainModel.IRepositories;
using DomainModel.Models;
using System.Collections.Generic;
using System.Linq;

namespace PROG5ASSESMENT {

    public class EntityFilmRepository : IFilmRepository {

        private EntityContext dbContext;

        public EntityFilmRepository() {
            dbContext = new EntityContext();
        }

        public Film Get(int filmId) {
            return (dbContext.Films.First(f => f.FilmId == filmId));
        }

        public List<Film> GetAll() {
            return dbContext.Films.ToList();
        }

        public Film Create(Film film) {
            dbContext.Films.Add(film);
            dbContext.SaveChanges();
            return film;
        }

        public Film Update(Film film) {
            dbContext.Films.Remove(dbContext.Films.First(f => f.FilmId == film.FilmId));
            dbContext.Films.Add(film);
            dbContext.SaveChanges();
            return film;
        }

        public void Delete(Film film) {
            dbContext.Films.Remove(dbContext.Films.First(f => f.FilmId == film.FilmId));
            dbContext.SaveChanges();
        }

        public Zaal GetZaal(int zaalId) {
            return (dbContext.Zalen.First(z => z.ZaalId == zaalId));
        }

        public List<Zaal> GetAllZalen() {
            return dbContext.Zalen.ToList();
        }

    }

}