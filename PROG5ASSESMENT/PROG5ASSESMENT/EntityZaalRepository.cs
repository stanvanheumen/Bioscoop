using DomainModel.IRepositories;
using DomainModel.Models;
using System.Collections.Generic;
using System.Linq;

namespace PROG5ASSESMENT {
    
    public class EntityZaalRepository : IZaalRepository {

        private EntityContext dbContext;

        public EntityZaalRepository() {
            dbContext = new EntityContext();
        }

        public Zaal Get(int zaalId) {
            return (dbContext.Zalen.First(z => z.ZaalId  == zaalId));
        }

        public List<Zaal> GetAll() {
            return dbContext.Zalen.ToList();
        }

        public Zaal Create(Zaal zaal) {
            dbContext.Zalen.Add(zaal);
            dbContext.SaveChanges();
            return zaal;
        }

        public Zaal Update(Zaal zaal) {
            dbContext.Zalen.Remove(dbContext.Zalen.First(z => z.ZaalId == zaal.ZaalId));
            dbContext.Zalen.Add(zaal);
            dbContext.SaveChanges();
            return zaal;
        }

        public void Delete(Zaal zaal) {
            dbContext.Zalen.Remove(dbContext.Zalen.First(z => z.ZaalId == zaal.ZaalId));
            dbContext.SaveChanges();
        }

    }

}