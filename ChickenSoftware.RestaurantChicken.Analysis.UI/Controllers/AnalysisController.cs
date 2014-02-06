using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChickenSoftware.RestraurantChicken.Analysis;


namespace ChickenSoftware.RestaurantChicken.Analysis.UI.Controllers
{
    public class AnalysisController : Controller
    {
        //
        // GET: /Analysis/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChineseIndex()
        {
            return View();
        }

        public JsonResult AverageScoreByMonth()
        {
            var analysis = new RestaurantAnalysis();
            var scores = analysis.GetAverageScoreByMonth();
            return Json(scores,JsonRequestBehavior.AllowGet);
        }

        public JsonResult AverageScoreByDay()
        {
            var analysis = new RestaurantAnalysis();
            var scores = analysis.AverageScoreByDay();
            return Json(scores, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AverageScoreByDayOfWeek()
        {
            var analysis = new RestaurantAnalysis();
            var scores = analysis.AverageScoreByDayOfWeek();
            return Json(scores, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AverageScoreByInspector()
        {
            var analysis = new RestaurantAnalysis();
            var scores = analysis.AverageScoreByInspector();
            return Json(scores, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AverageScoreByEstablishmentType()
        {
            var analysis = new RestaurantAnalysis();
            var scores = analysis.AverageScoreByEstablishmentType();
            return Json(scores, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AverageScoreOfChineseAndNonChineseByInspector()
        {
            var analysis = new RestaurantAnalysis();
            var scores = analysis.AverageScoresOfChineseAndNonChineseByInspector();
            return Json(scores, JsonRequestBehavior.AllowGet);

        }




	}
}