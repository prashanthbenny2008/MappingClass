using System;
using MappingSystem.DataModels; // Include the namespace for your data models
using MappingSystem.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace MappingSystem.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set up the Dependency Injection (DI) container
            var serviceProvider = new ServiceCollection()
                .AddTransient<Mapper>() // Register the Mapper for DI
                .BuildServiceProvider();

            // Resolve the Mapper instance
            var mapper = serviceProvider.GetService<Mapper>();

            // Create an instance of Reservation
            var reservation = new Reservation
            {
                Id = 1,
                GuestName = "Prashanth",
                RoomType = "Royal Suite",
                CheckIn = new DateTime(2024, 10, 20),
                CheckOut = new DateTime(2024, 10, 25)
            };

            // Perform the mapping
            var mappedObject = mapper.Map("MappingSystem.DataModels.Reservation", "MappingSystem.DataModels.GoogleReservation", reservation);

            // Output the mapped result
            if (mappedObject is GoogleReservation googleReservation)
            {
                Console.WriteLine($"Id: {googleReservation.Id}, GuestName: {googleReservation.GuestName}, RoomType: {googleReservation.RoomType}");
            }
            else
            {
                Console.WriteLine("Mapping failed.");
            }
        }
    }
}