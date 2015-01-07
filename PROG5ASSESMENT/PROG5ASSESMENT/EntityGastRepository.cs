using DomainModel.IRepositories;
using DomainModel.Models;
using System.Collections.Generic;
using System.Linq;

namespace PROG5ASSESMENT {
    
    public class EntityGastRepository : IGastRepository {

        private EntityContext dbContext;

        public EntityGastRepository() {
            dbContext = new EntityContext();
        }

        public Gast Get(int gastId) {
            return (dbContext.Gasten.First(g => g.GastId == gastId));
        }

        public List<Gast> GetAll() {
            return dbContext.Gasten.ToList();
        }

        public Gast Create(Gast gast) {
            dbContext.Gasten.Add(gast);
            dbContext.SaveChanges();
            return gast;
        }

        public Gast Update(Gast gast) {
            dbContext.Gasten.Remove(dbContext.Gasten.First(g => g.GastId == gast.GastId));
            dbContext.Gasten.Add(gast);
            dbContext.SaveChanges();
            return gast;
        }

        public void Delete(Gast gast) {
            dbContext.Gasten.Remove(dbContext.Gasten.First(g => g.GastId == gast.GastId));
            dbContext.SaveChanges();
        }

    }

}