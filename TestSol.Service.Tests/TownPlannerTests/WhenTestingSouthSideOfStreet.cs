using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Should;
using SpecsFor;

namespace TestSol.Service.Tests.TownPlannerTests
{
    public class WhenTestingSouthSideOfStreet
    {
        public class WhenTestingWithSingleValue : SpecsFor<DoorService>
        {
            [TestCase(0, 1)]
            [TestCase(1, 2)]
            public void ShouldReturnOneHouseOnStreet(int result, int value)
            {
                DoorService.GetTotalHousesOnSouth(new List<int>() { value }).ShouldEqual(result);
            }
        }

        public class WhenTestingWithMultipleValues : SpecsFor<DoorService>
        {
            [TestCase(1, 1, 2)]
            [TestCase(2, 1, 3, 2, 4, 5)]
            [TestCase(0, 1, 3)]
            [TestCase(3, 2, 4, 6)]
            [TestCase(6, 1, 2, 4, 3, 6, 5, 7, 8, 9, 10, 12, 11, 13, 15)]
            public void ShouldReturnCorrectHouseCountOnStreet(int result, params int[] list)
            {
                DoorService.GetTotalHousesOnSouth(list.ToList()).ShouldEqual(result);
            }
        }
    }
}
