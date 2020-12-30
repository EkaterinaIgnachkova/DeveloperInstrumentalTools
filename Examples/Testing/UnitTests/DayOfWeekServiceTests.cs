using System;
using FluentAssertions;
using NUnit.Framework;
using UnitTestsTarget;

namespace UnitTests
{
    public class DayOfWeekServiceTests
    {
        private DayOfWeekService _instance = new DayOfWeekService();

        [Test]
        public void testIsWeekendTrue()
        {
            _instance.IsWeekend(new DateTime(2015, 2, 1)).Should().BeTrue();
            _instance.IsWeekend(new DateTime(2010, 6, 6)).Should().BeTrue();
        }

        [Test]
        public void testIsWeekendFalse()
        {
            _instance.IsWeekend(new DateTime(2015, 2, 3)).Should().BeFalse();
            _instance.IsWeekend(new DateTime(2010, 6, 7)).Should().BeFalse();
        }
    }
}