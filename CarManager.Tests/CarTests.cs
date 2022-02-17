using System;
using CarManager;
using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        [TestCase("VW","Golf",10,100)]
        public void CarConstructorShouldSetAllDataCorrectly(string make,string model,double fuelConsuption,double fuelCapacity)
        {
          Car car = new Car(
              make:make,
              model:model,
              fuelConsumption:fuelConsuption,
              fuelCapacity:fuelCapacity
              
              
              );
           Assert.AreEqual(car.Make,make);
           Assert.AreEqual(car.Model,model);
           Assert.AreEqual(car.FuelConsumption,fuelConsuption);
           Assert.AreEqual(car.FuelCapacity,fuelCapacity);
           Assert.AreEqual(car.FuelAmount,0);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void CarConstructorShouldThrowNullOrEmptyException(string model)
        {
            Assert.Throws<ArgumentException>(() => new Car("make", model, 10, 10));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void CarConstructorShouldMakeThrowNullOrEmptyException(string make)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, "model", 10, 10));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void CarConstructorShouldThrowExceptionIfFuelConsuptionAmountBelonwZero(double fuelConsuption)
        {
            Assert.Throws<ArgumentException>(() => new Car("make", "model", 10, fuelConsuption));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void CarConstructorShouldThrowExceptionIfFuelCapacityAmountBelonwZero(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car("make", "model", fuelCapacity, 10));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void CarConstructorShouldThrowExceptionIfFuelAmountAmountBelonwZero(double fuelAmount)
        {
            Assert.Throws<ArgumentException>(() => new Car("make", "model", 10, fuelAmount));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void RefuelShouldThrowExeptionWhenPassedValueIsBelowOrEqualsToZero(double value)
        {
            Car car = new Car("Mazda","3",10,10);
            Assert.Throws<ArgumentException>(() => car.Refuel(value));
        }
        [Test]
        [TestCase(200,50,100)]
        [TestCase(200,350,200)]
        public void RefuelShouldWorkAsExpected(double capacity, double fuel, double expectedResult)
        {
            //Arrange
            Car car = new Car("Mazda","3",10,capacity);

            //Act
            car.Refuel(fuel);

            //Assert
            var actualResult = car.FuelAmount;
            Assert.AreEqual(expectedResult,actualResult);
        }
        [Test]
        [TestCase(10,50,505)]
        [TestCase(15, 30, 201)]
        [TestCase(15, 0, 1)]
        public void DriveShouldThrowExceptionIfFuelAmoundIsNotEnough(double fuelConsuption,double refuel,double km)
        {
            //Arrange
            Car car = new Car("Mazda", "3", fuelConsuption, 100);
            car.Refuel(refuel);

            //Assert
   
            Assert.Throws<InvalidOperationException>(() => car.Drive(km));
        }
    }
}