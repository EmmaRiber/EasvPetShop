using Pet.Menu.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pet.Menu.Core.DomainService
{
    public interface IPetRepository
    {
        //Create Data
        PetEntity Create(PetEntity pet);

        //Read Data
        PetEntity ReadById(int Id);
        IEnumerable<PetEntity> ReadAll();

        //Update Data
        PetEntity Update(PetEntity petUpdate);

        //Delete Data 
        PetEntity Delete(int Id);

        //CRUD
    }
}
