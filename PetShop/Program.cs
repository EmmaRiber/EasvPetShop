﻿using EasvPetShopApi;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Pet.Menu.Core.ApplicationService;
using Pet.Menu.Core.ApplicationService.Services;
using Pet.Menu.Core.DomainService;
using Pet.Menu.Core.Entity;
using Pet.Menu.Infratructure.Data;
using Pet.Menu.Infratructure.Data.Repositories;
using System;
using System.Collections.Generic;


namespace PetShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //FakeDB.InitData();

            //var serviceCollection = new ServiceCollection();
            //serviceCollection.AddScoped<IPetRepository, PetRepository>();
            //serviceCollection.AddScoped<IPetService, PetService>();
            //serviceCollection.AddScoped<IPrinter, Printer>();

            //var serviceProvider = serviceCollection.BuildServiceProvider();
            //var printer = serviceProvider.GetRequiredService<IPrinter>();
            //printer.StartUI();
        }
    }
}
