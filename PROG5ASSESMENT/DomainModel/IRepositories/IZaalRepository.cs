using DomainModel.Models;
using System.Collections.Generic;

namespace DomainModel.IRepositories {

    public interface IZaalRepository {

        Zaal        Get(int zaalId);
        List<Zaal>  GetAll();
        Zaal        Create(Zaal zaal);
        Zaal        Update(Zaal zaal);
        void        Delete(Zaal zaal);

    }

}
