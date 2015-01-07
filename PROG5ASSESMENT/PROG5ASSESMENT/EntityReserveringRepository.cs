using DomainModel.IRepositories;
using DomainModel.Models;
using System.Collections.Generic;
using System.Linq;

namespace PROG5ASSESMENT {
    
    public class EntityReserveringRepository : IReserveringRepository {

        private EntityContext dbContext;

        public EntityReserveringRepository() {
            dbContext = new EntityContext();
        }

        public Reservering Get(int reserveringId) {
            return (dbContext.Reserveringen.First(r => r.ReserveringId == reserveringId));
        }

        public List<Reservering> GetAll() {
            return dbContext.Reserveringen.ToList();
        }

        public Reservering Create(Reservering reservering) {
            dbContext.Reserveringen.Add(reservering);
            dbContext.SaveChanges();
            return reservering;
        }

        public Reservering Update(Reservering reservering) {
            dbContext.Reserveringen.Remove(dbContext.Reserveringen.First(r => r.ReserveringId == reservering.ReserveringId));
            dbContext.Reserveringen.Add(reservering);
            dbContext.SaveChanges();
            return reservering;
        }

        public void Delete(Reservering reservering) {
            dbContext.Reserveringen.Remove(dbContext.Reserveringen.First(r => r.ReserveringId == reservering.ReserveringId));
            dbContext.SaveChanges();
        }

        public Film GetFilm(int filmId) {
            return (dbContext.Films.First(f => f.FilmId == filmId));
        }

        public List<Film> GetAllFilms() {
            return dbContext.Films.ToList();
        }

        public List<Korting> GetAllKortingen() {
            return dbContext.Kortingen.ToList();
        }
    }

}