using Pet.Menu.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pet.Menu.Core.ApplicationService
{
    public interface IOwnerService
    {
        //New Owner
        Owner New(string first_name, string last_name, string adress, int pets);

        //Create Owner
        Owner CreateOwner(Owner owner);

        //Read Owner
        Owner FindOwnerById(int id);
        List<Owner> GetAllOwners();

        //Update Owner
        Owner UpdateOwner(Owner ownerUpdate);

        //Delete Owner
        Owner DeleteOwner(int id);

        //CRUD
    }
}
