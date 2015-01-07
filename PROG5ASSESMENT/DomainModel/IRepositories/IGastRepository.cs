using DomainModel.Models;
using System.Collections.Generic;

namespace DomainModel.IRepositories {
    
    public interface IGastRepository {

        Gast        Get(int gastId);
        List<Gast>  GetAll();
        Gast        Create(Gast gast);
        Gast        Update(Gast gast);
        void        Delete(Gast gast);

    }

}
