using System;
using System.Collections.Generic;
using Xunit;

namespace OrgInfoStats.Tests
{
    public class ActivityTests
    {
        // Невозможность установить пустые значения в поля name и place
        [Fact]
        public void CanNotSetNullOrEmptyValueToPlaceAndName()
        {
            // Arrange
            Activity activity;
            Activity activity1;
            RestType restType; 

            // Act
            restType = new RestType(3);
            activity1 = new Activity("Test", "Test", 0m, restType);


            // Assert
            Assert.Throws<Exception>(() => activity = new Activity("", "Test", 290m, restType));
            Assert.Throws<Exception>(() => activity = new Activity("Test1", "", 290m, restType));
            Assert.Throws<Exception>(() => activity = new Activity("Test2", "Test", -30.4m, restType));

            Assert.Throws<Exception>(() => activity1.Name = "");
            Assert.Throws<Exception>(() => activity1.Place = "");
        }

        // Невозможность установить отрицательные значения в поле price
        [Fact]
        public void CanNotSetNegativeValueToPrice()
        {
            // Arrange
            Activity activity;
            Activity activity1;
            RestType restType;

            // Act
            restType = new RestType(3);
            activity1 = new Activity("Test", "Test", 0m, restType);


            // Assert
            Assert.Throws<Exception>(() => activity = new Activity("Test2", "Test", -30.4m, restType));
            Assert.Throws<Exception>(() => activity1.Price = -49m);
        }



    }
}
