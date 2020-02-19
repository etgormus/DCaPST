﻿using System;
using NUnit.Framework;
using DCAPST.Environment;

namespace ModelsTests.Environment.UnitTests
{
    [TestFixture]
    public class SolarGeometryTests
    {
        private SolarGeometryModel solar;

        [SetUp]
        public void SetUp()
        {
            solar = new SolarGeometryModel(144, 18.3);
        }

        [TestCaseSource(typeof(SolarGeometryTestData), "ConstructorTestCases")]
        public void Constructor_IfInvalidArguments_ThrowsException(double day, double lat)
        {
            Assert.Throws<Exception>(() => new SolarGeometryModel(day, lat));
        }

        [Test]
        public void SolarDeclinationTest()
        {
            var expected = 20.731383108171876;
            var actual = solar.SolarDeclination * 180 / Math.PI;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SunsetAngleTest()
        {
            var expected = 97.190868688685228;
            var actual = solar.SunsetAngle * 180 / Math.PI;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DayLengthTest()
        {
            var expected = 12.958782491824698;
            var actual = solar.DayLength;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SunriseTest()
        {
            var expected = 5.5206087540876512;
            var actual = solar.Sunrise;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SunsetTest()
        {
            var expected = 18.47939124591235;
            var actual = solar.Sunset;
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(SolarGeometryTestData), "SunAngleTestCases")]
        public void SunAngleTest(double hour, double expected)
        {
            var actual = solar.SunAngle(hour) * 180 / Math.PI;
            Assert.AreEqual(expected, actual);
        }
    }
}
