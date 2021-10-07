using System;
using System.Collections.Generic;
using Xunit;

namespace OrgInfoStats.Tests
{
    public class RestTypeTests
    {
        // ��� ����������� �������� ������� ���� ������
        [Fact]
        public void CanNotCreateEmptyRestType()
        {
            // Arrange
            RestType rType;
            RestType rType2;

            // Act
            rType = new RestType();
            rType2 = new RestType();
            

            // Assert
            Assert.NotEqual(String.Empty, rType.Type);
            Assert.Throws<Exception>(() => rType2.Type = "");
        }

        // ���������� ������ ����� ������ �� ����� ���������� ������ � ���������
        [Fact]
        public void GettedListOfRestTypeAndStaticNotEqual()
        {
            // Arrange
            List<string> gettedRestType;

            // Act
            gettedRestType = RestType.ListOfRestTypes;

            // Assert
            Assert.NotSame(gettedRestType, RestType.ListOfRestTypes);
        
        }

        // ��� ����������� ���������� � �������� ���� ������, ������� �� ������� � ������
        [Fact]
        public void CanNotChangeBadRestType()
        {
            // Arrange
            RestType rType;
            RestType rType2;

            // Act
            rType = new RestType();

            // Assert
            Assert.Throws<Exception>(() => rType.Type = "else");
            Assert.Throws<Exception>(() => rType2 = new RestType("else"));
        }

        // ��� ����������� �������� ���� ���������� � �� ������������ ���������� �������
        [Fact]
        public void CanNotSetBadSerialNumber()
        {
            // Arrange
            RestType restType;

            // Act


            // Assert
            Assert.Throws<Exception>(() => restType = new RestType(-2));
        }
    }
}
