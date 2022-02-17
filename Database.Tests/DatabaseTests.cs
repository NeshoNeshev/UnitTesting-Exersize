using System;
using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private global::Database.Database database;
        private readonly int[] initialData= new int[]{1,2};
        [SetUp]
        public void Setup()
        {
          this.database= new global::Database.Database(initialData);
        }

        [Test]
        public void ThisCapacitySouldMustBeExactlySixteenIntegers()
        {
            int[] data = new int [] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17};
            Assert.Throws<InvalidOperationException>(() => this.database = new global::Database.Database(data));
        }
        [Test]
        public void TestIfConstructorWorckingCorectly()
        {
            int [] data = new int[]{1,2,3};
            this.database= new global::Database.Database(data);
            int expectedCount = data.Length;
            int actualCount = this.database.Count;
            Assert.AreEqual(expectedCount,actualCount);
        }

        //[Test]
        //public void AddShouldIncraseCountWhenAddedSucsesfouly()
        //{
        //    for (int i = 3; i <= 16; i++)
        //    {
        //        this.database.Add(i);
        //    }

        //    Assert.Throws<InvalidOperationException>(() => this.database.Add(17));
        //}

        //[Test]
        //public void RemoveShouldThrowExceptionWhenDatabaseEmoty()
        //{
        //    this.database.Remove();
        //    this.database.Remove();
        //    Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        //}

        [Test]
        [TestCase(new int[]{})]
        [TestCase(new int[]{1,2,3})]
        public void FletchShouldReturnCopyData(int[] expectedData)
        {
            this.database= new global::Database.Database(expectedData);
            int[] actualData = this.database.Fetch();
            CollectionAssert.AreEqual(expectedData,actualData);
        }
    }
}