using DomainModel.Models;
using System.Collections.Generic;

namespace DomainModel.IRepositories {

    public interface IKortingRepository {

        Korting         Get(int kortingId);
        List<Korting>   GetAll();
        Korting         Create(Korting korting);
        Korting         Update(Korting korting);
        void            Delete(Korting korting);

    }

}
