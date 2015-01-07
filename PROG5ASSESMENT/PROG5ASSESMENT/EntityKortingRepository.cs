using DomainModel.IRepositories;
using DomainModel.Models;
using System.Collections.Generic;
using System.Linq;

namespace PROG5ASSESMENT {

    public class EntityKortingRepository : IKortingRepository {

        private EntityContext dbContext;

        public EntityKortingRepository() {
            dbContext = new EntityContext();
        }

        public Korting Get(int kortingId) {
            return (dbContext.Kortingen.First(k => k.KortingId == kortingId));
        }

        public List<Korting> GetAll() {
            return dbContext.Kortingen.ToList();
        }

        public Korting Create(Korting korting) {
            dbContext.Kortingen.Add(korting);
            dbContext.SaveChanges();
            return korting;
        }

        public Korting Update(Korting korting) {
            dbContext.Kortingen.Remove(dbContext.Kortingen.First(k => k.KortingId == korting.KortingId));
            dbContext.Kortingen.Add(korting);
            dbContext.SaveChanges();
            return korting;
        }

        public void Delete(Korting korting) {
            dbContext.Kortingen.Remove(dbContext.Kortingen.First(k => k.KortingId == korting.KortingId));
            dbContext.SaveChanges();
        }

    }

}