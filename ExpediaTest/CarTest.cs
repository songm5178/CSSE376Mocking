using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Expedia;
using Rhino.Mocks;

namespace ExpediaTest
{
	[TestClass]
	public class CarTest
	{	
		private Car targetCar;
		private MockRepository mocks;
		
		[TestInitialize]
		public void TestInitialize()
		{
			targetCar = new Car(5);
			mocks = new MockRepository();
		}
		
		[TestMethod]
		public void TestThatCarInitializes()
		{
			Assert.IsNotNull(targetCar);
		}	
		
		[TestMethod]
		public void TestThatCarHasCorrectBasePriceForFiveDays()
		{
			Assert.AreEqual(50, targetCar.getBasePrice()	);
		}
		
		[TestMethod]
		public void TestThatCarHasCorrectBasePriceForTenDays()
		{
            var target = new Car(10);
			Assert.AreEqual(80, target.getBasePrice());	
		}
		
		[TestMethod]
		public void TestThatCarHasCorrectBasePriceForSevenDays()
		{
			var target = new Car(7);
			Assert.AreEqual(10*7*.8, target.getBasePrice());
		}
		
		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void TestThatCarThrowsOnBadLength()
		{
			new Car(-5);
		}
     //   public String getCarLocation(int carNumber)
     //   {
     //       return Database.getCarLocation(carNumber);
     //   }
        [TestMethod()]
        public void TestThatGetCarLocationWorks()
        {
            IDatabase mockDB = mocks.StrictMock<IDatabase>();
            Int32 carNum = 3003;
            String carLoc = "Indiana";
            Int32 anotherCarNum = 21;
            String anotherCarLoc = "Portland";

            Expect.Call(mockDB.getCarLocation(carNum)).Return(carLoc);
            Expect.Call(mockDB.getCarLocation(anotherCarNum)).Return(anotherCarLoc);

            mocks.ReplayAll();

            Car car = new Car(10);

            car.Database = mockDB;

            String result;

            result = car.getCarLocation(carNum);
            Assert.AreEqual(carLoc, result);

            result = car.getCarLocation(anotherCarNum);
            Assert.AreEqual(anotherCarLoc, result);
        }
	}
}
