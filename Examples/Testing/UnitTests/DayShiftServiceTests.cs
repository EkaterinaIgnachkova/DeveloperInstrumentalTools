using System;
using FluentAssertions;
using NUnit.Framework;
using UnitTestsTarget;

namespace UnitTests
{
    public class DayShiftServiceTests
    {
        private DayShiftService _instance = new DayShiftService(new DayOfWeekService());

        [Test]
        public void testGetShiftBusinessDayMinus()
        {
            _instance.GetShiftBusinessDay(new DateTime(2010, 10, 29), -365)
                .Should()
                .Be(new DateTime(2009, 10, 29));
            _instance.GetShiftBusinessDay(new DateTime(2010, 10, 29), -1)
                .Should()
                .Be(new DateTime(2010, 10, 28));
        }

        [Test]
        public void testGetShiftBusinessDayPlus()
        {
            _instance.GetShiftBusinessDay(new DateTime(2010, 11, 30), 365)
                .Should()
                .Be(new DateTime(2011, 11, 30));

            _instance.GetShiftBusinessDay(new DateTime(2010, 10, 29), 1)
                .Should()
                .Be(new DateTime(2010, 11, 01));
        }

        [Test]
        public void testGetShiftBusinessDayZero()
        {
            _instance.GetShiftBusinessDay(new DateTime(2010, 10, 29), 0)
                .Should()
                .Be(new DateTime(2010, 10, 29));
        }
    }
}