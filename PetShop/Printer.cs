using Pet.Menu.Core.ApplicationService;
using Pet.Menu.Core.Entity;
using System;
using System.Collections.Generic;

namespace PetShop
{
    public class Printer: IPrinter
    {
        readonly IPetService _petService;

        public Printer(IPetService petService)
        {
            _petService = petService;
            
        }

            public void StartUI()
            {
                //Tekst der kommer frem, lige når applikationen starter 
                string[] mainMenuItems =
                {
                    "List of all Pets",
                    "Search Pets by Type",
                    "Create a new Pet",
                    "Delete a Pet",
                    "Update a Pet",
                    "Sort Pets by Price",
                    "Get 5 cheapest avaiable Pets",
                    "Exit"
                    };

                Console.WriteLine("Pet Menu! ");
                //Switch der gør sådan, at man kan vælge, om man vil se listen af dyr,
                //Add et dyr, Delete et dyr, edit et dyr, og lukke programmet
                var selection = ShowMenu(mainMenuItems);

                while (selection != 8)
                {
                    switch (selection)
                    {
                        case 1:
                            var Pets = _petService.GetAllPets();
                            ListPets(Pets);
                            break;

                        case 2:
                            var searchByType = PrintFindPetByType();
                        var result = _petService.FindPetByType(searchByType);
                        foreach (var searchPet in result)
                        {
                            Console.WriteLine($"Id: {searchPet.Id} Name: {searchPet.Name} | Type: {searchPet.Type}" +
                                $" | Color: {searchPet.Color} | Birthdate: {searchPet.Birthdate}" +
                                $" | Solddate: {searchPet.Solddate} | Previous owner: {searchPet.PreviousOwner}" +
                                $" | Price: {searchPet.Price:N}");
                        }
                        Console.WriteLine("  ");                 
                            break;

                        case 3:
                            var name = AboutThePet("Name: ");
                            var type = AboutThePet("Type: ");
                            var color = AboutThePet("Color: ");
                            var birthDate = AboutThePet("Birthdate: ");
                            var soldDate = AboutThePet("Solddate: ");
                            var previousOwner = AboutThePet("Previous owner: ");
                            var price = AboutThePet("Price: ");
                            var pet = _petService.NewPet(name, type, color,
                                Convert.ToDateTime(birthDate), Convert.ToDateTime(soldDate),
                                previousOwner, Convert.ToDouble(price));
                            _petService.CreatePets(pet);
                        Console.WriteLine(" ");
                            break;

                        case 4:
                            var idForDeletePet = PrintFindPetById();
                            _petService.DeletePet(idForDeletePet);
                            Console.WriteLine(" ");
                            break;

                        case 5:
                            var idForEdit = PrintFindPetById();
                            var petToEdit = _petService.FindPetById(idForEdit);
                            Console.WriteLine("Update the information about the pet: ");
                            Console.WriteLine(petToEdit.Name);
                            var newName = AboutThePet("Name: ");
                            var newType = AboutThePet("Type: ");
                            var newColor = AboutThePet("Color: ");
                            var newBirthDate = AboutThePet("Birthdate: ");
                            var newSoldDate = AboutThePet("Solddate: ");
                            var newPreviousOwner = AboutThePet("Previous owner: ");
                            var newPrice = AboutThePet("Price: ");
                            _petService.UpdatePet(new PetEntity()
                            {
                                Id = idForEdit,
                                Name = newName,
                                Type = newType,
                                Color = newColor,
                                Birthdate = Convert.ToDateTime(newBirthDate),
                                Solddate = Convert.ToDateTime(newSoldDate),
                                PreviousOwner = newPreviousOwner,
                                Price = Convert.ToDouble(newPrice)
                            });
                            Console.WriteLine(" ");
                            break;

                        case 6:
                        Console.WriteLine("Sort the Pets from low to high price");
                        var sortResult = _petService.SortByPrice();
                        foreach (var sortPet in sortResult)
                        {
                            Console.WriteLine($"Id: {sortPet.Id} Name: {sortPet.Name} | Type: {sortPet.Type}" +
                                $" | Color: {sortPet.Color} | Birthdate: {sortPet.Birthdate}" +
                                $" | Solddate: {sortPet.Solddate} | Previous owner: {sortPet.PreviousOwner}" +
                                $" | Price: {sortPet.Price:N}");
                        }
                        Console.WriteLine(" ");
                            break;

                        case 7:
                        Console.WriteLine("Get 5 cheapest available pets");
                        CheapestPets();
                        Console.WriteLine("  ");
                            break;

                        default:
                            break;
                    }
                    selection = ShowMenu(mainMenuItems);
                }
                Console.WriteLine("Exit");

                Console.ReadLine();
            }
        
       //Fem billigste dyr
        private void CheapestPets()
        {
            var list = _petService.GetFiveCheapestPets();
            foreach (var PetEntity in list)
            {
                Console.WriteLine($"Id: {PetEntity.Id} Name: { PetEntity.Name} | Type: { PetEntity.Type}" +
                                $" | Color: {PetEntity.Color} | Birthdate: {PetEntity.Birthdate}" +
                                $" | Solddate: {PetEntity.Solddate} | Previous owner: {PetEntity.PreviousOwner}" +
                                $" | Price: {PetEntity.Price:N}");
            }
        }

        //Viser en liste af dyr
        private void ListPets(List<PetEntity> Pets)
        {
            Console.WriteLine("List of Pets");
            foreach (var PetEntity in Pets)
            {
                Console.WriteLine($" id: {PetEntity.Id} Name: { PetEntity.Name} | Type: { PetEntity.Type}" +
                                $" | Color: {PetEntity.Color} | Birthdate: {PetEntity.Birthdate}" +
                                $" | Solddate: {PetEntity.Solddate} | Previous owner: {PetEntity.PreviousOwner}" +
                                $" | Price: {PetEntity.Price:N}");
            }
                Console.WriteLine(" ");
        }

        //Id
        int PrintFindPetById()
        {
            Console.WriteLine("Insert Pet Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number - the ID have to be a number");
            }
            return id;
        }

        //Type
        string PrintFindPetByType()
        {
            Console.WriteLine("Write the Type of the Pet you are searching for: ");
            string type = Console.ReadLine();
            return type;
        }
        
        //Questions
        string AboutThePet(string About)
            {
                Console.WriteLine(About);
                return Console.ReadLine();
            }
        

        //Viser menuen, hvis man ikke har trykket på et
        //tal mellem 1-8, så skriver den, at man skal vælge
        int ShowMenu(string[] mainMenuItems)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Select what you want to do: ");
            Console.WriteLine("");

            for (int i = 0; i < mainMenuItems.Length; i++)
            {
                Console.WriteLine($"{(i + 1)} : {mainMenuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1
                || selection > 8)
            {
                Console.WriteLine("Select a number between 1-8");
            }
            return selection;
        }
    }
}

