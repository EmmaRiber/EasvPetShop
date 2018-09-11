using Pet.Menu.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pet.Menu.Core.DomainService
{
    public interface IOwnerRepository
    {
        //Create Data
        Owner Create(Owner owner);

        //Read Data
        Owner ReadById(int id);
        IEnumerable<Owner> ReadAll();

        //Update Data
        Owner Update(Owner OwnerUpdate);

        //Delete Data
        Owner Delete(int id);
    }
}
