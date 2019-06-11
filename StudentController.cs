using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppPagination.Repository;

namespace WebAppPagination.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        //[OutputCache(Duration = 10)]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult JQueryDataTable()
        {
            var search = Request.Form.GetValues("search[value]")[0];
            int? draw = Convert.ToInt32(Request.Form.GetValues("draw").FirstOrDefault());
            int? start = Convert.ToInt32(Request.Form.GetValues("start").FirstOrDefault());
            int? length = Convert.ToInt32(Request.Form.GetValues("length").FirstOrDefault());
            start = start.HasValue ? start / 10 : 0;
            var data = new StudentRepository().GetPaginated(search, start.Value, length ?? 10, out int totalRecords, out int recordsFiltered);
            return Json(new { draw, recordsFiltered, totalRecords, data }, JsonRequestBehavior.AllowGet);
        }
    }
}