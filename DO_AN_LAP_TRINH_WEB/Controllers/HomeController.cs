using DO_AN_LAP_TRINH_WEB.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DO_AN_LAP_TRINH_WEB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            MyDataDataContext data = new MyDataDataContext();
            var all_sanpham = (from sp in data.SanPhams select sp).OrderBy(m => m.maSP);
            int pageSize = 6;
            int pageNum = page ?? 1;
            return View(all_sanpham.ToPagedList(pageNum, pageSize));
        }
            public ActionResult About()
            {
            ViewBag.Message = "Your application description page.";

            return View();
            }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}