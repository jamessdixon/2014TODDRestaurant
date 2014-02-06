using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChickenSoftware.RestraurantChicken.Analysis;
using System.Collections.Generic;

namespace ChickenSoftware.RestaurantChicken.Analysis.Tests
{
    [TestClass]
    public class RestaurantAnalysisTests
    {
        [TestMethod]
        public void GetAverageScoreByMonth_ReturnsTwelveItems()
        {
            var analysis = new RestaurantAnalysis();
            var scores = analysis.GetAverageScoreByMonth();
            Int32 expected = 12;
            Int32 actual = scores.Length;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetAverageScoreByDay_ReturnsThirtyOneItems()
        {
            var analysis = new RestaurantAnalysis();
            var scores = analysis.AverageScoreByDay();
            Int32 expected = 31;
            Int32 actual = scores.Length;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetAverageScoreByDayOfWeek_ReturnsFiveItems()
        {
            var analysis = new RestaurantAnalysis();
            var scores = analysis.AverageScoreByDayOfWeek();
            Int32 expected = 7;
            Int32 actual = scores.Length;
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void GetAverageScoreByInspector_ReturnsTwentyOneItems()
        {
            var analysis = new RestaurantAnalysis();
            var scores = analysis.AverageScoreByInspector();
            Int32 expected = 22;
            Int32 actual = scores.Length;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetAverageScoreByEstablishmentType_Returns11Items()
        {
            var analysis = new RestaurantAnalysis();
            var scores = analysis.AverageScoreByEstablishmentType();
            Int32 expected = 10;
            Int32 actual = scores.Length;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Variance_ReturnsExpected()
        {
            var analysis = new RestaurantAnalysis();
            var inputs = new List<double>();
            inputs.Add(1.0);
            inputs.Add(2.0);
            inputs.Add(3.0);

            Double expected = 2f / 3f;
            var actual = analysis.Variance(inputs);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsEstablishmentAChineseRestraurantUsingWOK_ReturnsTrue()
        {
            var analysis = new RestaurantAnalysis();
            String establishmentName = "JAMIE'S WOK";

            var expected = true;
            var actual = analysis.IsEstablishmentAChineseRestraurant(establishmentName);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsEstablishmentAChineseRestraurantUsingWok_ReturnsTrue()
        {
            var analysis = new RestaurantAnalysis();
            String establishmentName = "Jamie's Wok";

            var expected = true;
            var actual = analysis.IsEstablishmentAChineseRestraurant(establishmentName);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AverageScoreForChineseRestaurants_ReturnsExpected()
        {
            var analysis = new RestaurantAnalysis();
            var actual = analysis.AverageScoreForChineseRestaurants();
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void AverageScoresOfChineseAndNonChineseByInspector_ReturnsExpected()
        {
            var analysis = new RestaurantAnalysis();
            var scores = analysis.AverageScoresOfChineseAndNonChineseByInspector();
            Int32 expected = 21;
            Int32 actual = scores.Length;
            Assert.AreEqual(expected, actual);
        }



    
    }
}
