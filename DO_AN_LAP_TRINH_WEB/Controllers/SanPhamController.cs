using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DO_AN_LAP_TRINH_WEB.Models;
using PagedList;

namespace DO_AN_LAP_TRINH_WEB.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        MyDataDataContext data = new MyDataDataContext();
        public ActionResult ListSanPham()
        {
            var all_sanpham = from ss in data.SanPhams select ss;
            return View(all_sanpham);
        }
        public ActionResult Details(int id)
        {
            var D_sanpham = data.SanPhams.Where(m => m.maSP == id).First();
            return View(D_sanpham);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SanPham s)
        {
            var E_ten = collection["tenSP"];
            var E_mota = collection["mota"];
            var E_gia = Convert.ToDecimal(collection["giaban"]);
            var E_hinh = collection["hinh"];
            var E_ngaycapnhat = Convert.ToDateTime(collection["ngaycapnhat"]);
            var E_soluongton = Convert.ToInt32(collection["soluongton"]);
            if (string.IsNullOrEmpty(E_ten))
            {
                ViewData["Error"] = "Don't empty!";
            }

            else
            { 
                s.tenSP = E_ten.ToString();
                s.hinh = E_hinh.ToString();
                s.giaban = E_gia;
                s.ngaycapnhat = E_ngaycapnhat;
                s.soluongton = E_soluongton;
                data.SanPhams.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("ListSanPham");
            }
            return this.Create();
        }

        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
            return "/Content/images/" + file.FileName;
        }

        public ActionResult Edit(int id)
        {
            var E_sach = data.SanPhams.First(m => m.maSP == id);
            return View(E_sach);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var E_sach = data.SanPhams.First(m => m.maSP == id);
            var E_ten = collection["tenSP"];
            var E_mota = collection["mota"];
            var E_gia = Convert.ToDecimal(collection["giaban"]);
            var E_hinh = collection["hinh"];
            var E_ngaycapnhat = Convert.ToDateTime(collection["ngaycapnhat"]);
            var E_soluongton = Convert.ToInt32(collection[" soluongton"]);
            if (string.IsNullOrEmpty(E_ten))
            {
                ViewData["Error"] = "Don 't empty!";
            }
            else
            {
                E_sach.tenSP = E_ten;
                E_sach.hinh = E_hinh;
                E_sach.giaban = E_gia;
                E_sach.ngaycapnhat = E_ngaycapnhat;
                E_sach.soluongton = E_soluongton;
                UpdateModel(E_sach);
                data.SubmitChanges();
                return RedirectToAction("ListSanPham");
            }
            return this.Edit(id);
        }
        public ActionResult Delete(int id)
        {
            var D_sach = data.SanPhams.First(m => m.maSP == id);
            return View(D_sach);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_sach = data.SanPhams.Where(m => m.maSP == id).First();
            data.SanPhams.DeleteOnSubmit(D_sach);
            data.SubmitChanges();
            return RedirectToAction("ListSanPham");
        }
    }
}
