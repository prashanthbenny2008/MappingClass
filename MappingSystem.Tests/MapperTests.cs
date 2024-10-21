using System;
using Xunit;
using MappingSystem.Mappers;
using MappingSystem.DataModels;
using System.Diagnostics;

namespace MappingSystem.Tests
{
    public class MapperTests
    {
        [Fact]
        public void Should_Map_GoogleReservation_To_Reservation_Correctly()
        {
            // Arrange: Set up the source object
            var googleReservation = new GoogleReservation
            {
                Id = 1,
                GuestName = "John Doe",
                RoomType = "Deluxe",
                CheckIn = new DateTime(2024, 10, 21),
                CheckOut = new DateTime(2024, 10, 25)
            };

            // Create an instance of the Mapper class
            var mapper = new Mapper();

            // Act: Perform the mapping
            var result = mapper.Map("MappingSystem.DataModels.GoogleReservation", "MappingSystem.DataModels.Reservation", googleReservation) as Reservation;

            // Assert: Check that the mapping was performed correctly
            Assert.NotNull(result);  // Ensure the result is not null
            Assert.Equal(googleReservation.Id, result.Id);
            Assert.Equal(googleReservation.GuestName, result.GuestName);
            Assert.Equal(googleReservation.RoomType, result.RoomType);
            Assert.Equal(googleReservation.CheckIn, result.CheckIn);
            Assert.Equal(googleReservation.CheckOut, result.CheckOut);
        }

        [Fact]
        public void Should_Throw_Exception_For_Invalid_Arguments()
        {
            // Arrange
            var googleReservation = new GoogleReservation
            {
                Id = 1,
                GuestName = "John Doe",
                RoomType = "Deluxe",
                CheckIn = new DateTime(2024, 10, 21),
                CheckOut = new DateTime(2024, 10, 25)
            };

            var mapper = new Mapper();

            // Act & Assert: Expecting an exception when trying to map to an invalid type
            Assert.Throws<ArgumentException>(() =>
                mapper.Map("MappingSystem.DataModels.GoogleReservation", "MappingSystem.DataModels.NonExistentClass", googleReservation)
            );
        }
    }
}