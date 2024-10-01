using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Context;

namespace WebApplication1.Controllers
{
    public class AppointmentController : Controller
    {
        ProjectDBContext _dbContext;
        public AppointmentController()
        {
            this._dbContext = new ProjectDBContext();
        }
        public JsonResult GetAvailableTimes(int chamberId)
        {
            var availableTimes = _dbContext.TimeSlot.Where(t => t.ChamberId == chamberId).Select(t => new { Time = t.Time}).ToList();

            return Json(new { success = true, data = availableTimes }, JsonRequestBehavior.AllowGet);
        }
    }
}