using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Should;
using SpecsFor;

namespace TestSol.Service.Tests.TownPlannerTests
{
    public class WhenTestingNorthSideOfStreet
    {
        public class WhenTestingWithSingleValue : SpecsFor<DoorService>
        {
            [TestCase(1, 1)]
            [TestCase(0, 2)]
            public void ShouldReturnOneHouseOnStreet(int result, int value)
            {
                DoorService.GetTotalHousesOnNorthSide(new List<int>() { value }).ShouldEqual(result);
            }
        }

        public class WhenTestingWithMultipleValues : SpecsFor<DoorService>
        {
            [TestCase(1, 1, 2)]
            [TestCase(3, 1, 3, 2, 4, 5)]
            [TestCase(2, 1, 3)]
            [TestCase(0, 2, 4, 6)]
            public void ShouldReturnCorrectHouseCountOnStreet(int result, params int[] list)
            {
                DoorService.GetTotalHousesOnNorthSide(list.ToList()).ShouldEqual(result);
            }
        }
    }
}
