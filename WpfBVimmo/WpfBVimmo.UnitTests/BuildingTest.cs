using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WpfBVimmo.Models;

namespace WpfBVimmo.UnitTests
{
    [TestClass]
    public class BuildingTest
    {
        [TestMethod]
        public void SetGoodPropertyOn_Apartment_IsApartment()
        {
            //Arrange
            Apartment apart = new Apartment();
            //Act
            Boolean result = apart.IsApartment;
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SetGoodPropertyOn_Apartment_IsHouse()
        {
            //Arrange
            Apartment apart = new Apartment();
            //Act
            Boolean result = apart.IsHouse;
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SetGoodPropertyOn_House_IsApartment()
        {
            //Arrange
            House house = new House();
            //Act
            Boolean result = house.IsApartment;
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SetGoodPropertyOn_House_IsHouse()
        {
            //Arrange
            House house = new House();
            //Act
            Boolean result = house.IsHouse;
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckStringEntry_EntryWithOneSpaceOrHyphenInside()
        {
            //Arrange
            //Act
            Boolean result = Building.CheckStringEntry("Amerique Du Nord") && Building.CheckStringEntry("Pays-Bas");
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckStringEntry_EntryWhoStartWithSpaceOrHyphen()
        {
            //Arrange
            //Act
            Boolean result = Building.CheckStringEntry(" Belgique") || Building.CheckStringEntry("-Belgique");
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckStringEntry_EntryWithMoreThanOneSpace()
        {
            //Arrange
            //Act
            Boolean result = Building.CheckStringEntry("Belgique  ") || Building.CheckStringEntry("Amerique  du Nord") 
                            || Building.CheckStringEntry("  Belgique");
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckStringEntry_EntryWithMoreThanOneHyphen()
        {
            //Arrange
            //Act
            Boolean result = Building.CheckStringEntry("Belgique--") || Building.CheckStringEntry("Pays--Bas")
                            || Building.CheckStringEntry("--Belgique");
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckStringEntry_NameWithNotAllowedChar()
        {
            //Arrange
            //Act
            Boolean result = Building.CheckStringEntry("@mérique") || Building.CheckStringEntry("Belgique15")
           || Building.CheckStringEntry("Bel&gique");
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckStringEntry_EntryWhoDontStartWithUppercase()
        {
            //Arrange
            //Act
            Boolean result = Building.CheckStringEntry("belgique");
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckStringEntry_EntryWithPartWhoDontStartWithUppercase()
        {
            //Arrange
            //Act
            Boolean result = Building.CheckStringEntry("rue De Belgique") || Building.CheckStringEntry("Rue de Belgique") || Building.CheckStringEntry("Rue De belgique");
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckNumberEntry_MinLimit()
        {
            //Arrange
            //Act
            Boolean result = Building.CheckNumberEntry(0, 0, 10);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckNumberEntry_MaxLimit()
        {
            //Arrange
            //Act
            Boolean result = Building.CheckNumberEntry(10, 0, 10);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckNumberEntry_InTheMiddle()
        {
            //Arrange
            //Act
            Boolean result = Building.CheckNumberEntry(5, 0, 10);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckNumberEntry_ToSmall()
        {
            //Arrange
            //Act
            Boolean result = Building.CheckNumberEntry(-1, 0, 10);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckNumberEntry_ToBig()
        {
            //Arrange
            //Act
            Boolean result = Building.CheckNumberEntry(11, 0, 10);
            //Assert
            Assert.IsFalse(result);
        }

    }//end class BuildingTest
}//end namespace
