using System;
using System.Collections.Generic;
using Xunit;


namespace OrgInfoStats.Tests
{
    public class OrganizationTests
    {
        // Нет возможности установить пустое значение названия организации
        [Fact]
        public void CanNotSetNullOrEmptyName()
        {
            // Arrange
            Organization org;

            // Act
            org = new Organization("Test");

            // Assert
            Assert.Throws<Exception>(() => org.Name = "");
            Assert.Throws<Exception>(() => org = new Organization(""));
        }

    }
}
