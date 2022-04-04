using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DO_AN_LAP_TRINH_WEB.Models
{
    public class Giohang
    {
        MyDataDataContext data = new MyDataDataContext();
        public int maSP { get; set; }

        [Display(Name = "Tên sách")]
        public string tenSP { get; set; }

        [Display(Name = "Ảnh bìa")]
        public string hinh { get; set; }

        [Display(Name = "Giá bán")]
        public Double giaban { get; set; }

        [Display(Name = "Số lượng")]
        public int iSoLuong { get; set; }
        [Display(Name = "Thành tiền")]
        public Double dThanhtien
        {
            get
            {
                return iSoLuong * giaban;
            }
        }
        public Giohang(int id)
        {
            maSP = id;
            SanPham sach = data.SanPhams.Single(n => n.maSP == maSP);
            tenSP = sach.tenSP;
            hinh = sach.hinh;
            giaban = double.Parse(sach.giaban.ToString());
            iSoLuong = 1;
        }
    }
}