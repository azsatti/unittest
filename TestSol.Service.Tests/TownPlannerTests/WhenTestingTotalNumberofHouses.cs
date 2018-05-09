using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Moq;
using NUnit.Framework;
using Should;
using SpecsFor;
using TestSol.Service.Interface;

namespace TestSol.Service.Tests.TownPlannerTests
{
    public class WhenTestingTotalNumberofHouses
    {
        public class WhenTestingWithSingleValues : SpecsFor<DoorService>
        {
            [TestCase(1)]
            [TestCase(2)]
            public void ShouldReturnOneHouseOnStreet(int value)
            {
                DoorService.GetTotalHouses(new List<int>() { value }).ShouldEqual(1);
            }
        }

        public class WhenTestingWithMultipleValues : SpecsFor<DoorService>
        {
            [TestCase(2, 1, 2)]
            [TestCase(2, 1, 3)]
            [TestCase(3, 1, 3, 2)]
            [TestCase(3, 2, 4, 6)]
            [TestCase(5, 1, 2, 3, 4, 5)]
            [TestCase(15, 1, 2, 4, 3, 6, 5, 7, 8, 9, 10, 12, 11, 13, 15, 14)]
            public void ShouldReturnCorrectHouseCountOnStreet(int result, params int[] list)
            {
                DoorService.GetTotalHouses(list.ToList()).ShouldEqual(result);
            }
        }
    }
}
