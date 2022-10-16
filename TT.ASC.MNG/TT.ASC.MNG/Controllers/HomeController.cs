using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using TT.ASC.DATA;

namespace TT.ASC.MNG.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult TrangChu()
        {
            return View();
        }

        //Thực hành 1

        #region Định dạng
        public ActionResult DinhDangNgayThangNam()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DinhDangNgayThangNam(FormCollection formCollection)
        {
            try
            {
                DateTime dateTime = Convert.ToDateTime(formCollection["pdt"]);
                string loaiDinhDang = formCollection["pLoaiDinhDang"];
                ViewBag.DinhDang = DataThucHanh1.DinhDangNgayThangNam(dateTime, loaiDinhDang);
                
            }
            catch
            {
                ViewBag.ErrorDinhDang = "Chưa chọn thời gian";
          
            }
            return View();
        }
        #endregion

        #region Đọc dãy số bất kỳ
        public ActionResult DocSo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DocSo(FormCollection pf)
        {
            try
            {
                double daySo = Convert.ToDouble(pf["DaySo"]);
                ViewBag.DaySo = DataThucHanh1.DocSo(daySo);
            }
            catch
            {
                ViewBag.ErrorDaySo = "Lỗi chưa nhập số";
            }
            return View();
        }
        #endregion

        #region Đọc số tiền bất kỳ
        public ActionResult DocSoTien()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DocSoTien(FormCollection pf)
        {
            try
            {
                double soTien = Convert.ToDouble(pf["SoTien"]);
                ViewBag.SoTien = DataThucHanh1.DocTien(soTien);
            }
            catch
            {
                ViewBag.ErrorSoTien = "Lỗi chưa nhập số tiền";
            }
            return View();
        }
        #endregion

        #region Random ký tự
        public ActionResult RanDomKyTy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RanDomKyTy(FormCollection pf)
        {
            try
            {
                string kyTu = pf["KyTu"];
                int soLuong = Convert.ToInt32(pf["SoLuong"]);
                if(kyTu.Length==0)//chưa nhập
                {
                    ViewData["Loi1"] = "Ký tự không được để trống";
                }   
                else//nhập đủ
                {
                    ViewBag.RanDomKyTy = DataThucHanh1.RanDomKyTy(kyTu, soLuong);
                }    
            }
            catch
            {
                ViewData["Loi2"] = "Chưa nhập số";
            }
            return View();
        }
        #endregion

        #region ngày đầu tiên của tháng
        public ActionResult NgayDauTienCuaThang()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NgayDauTienCuaThang(FormCollection pf)
        {
            try
            {
                int nThang = Convert.ToInt32(pf["nThang"]);
                int nNam = Convert.ToInt32(pf["nNam"]);
                if(nThang>0 && nThang<13)//tháng hợp lệ
                {
                    ViewBag.NgayDauTienCuaThang = DataThucHanh1.NgayDauTienCuaThang(nThang, nNam);
                }
                else//tháng không hợp lệ
                {
                    ViewData["Loi1"] = "Tháng phải từ 1-12";
                }    
            }
            catch
            {
                ViewData["Loi2"] = "không được bỏ trống";
            }
            return View();
        }
        #endregion

        #region ngày cuối của tháng
        public ActionResult NgayCuoiCungCuaThang()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NgayCuoiCungCuaThang(FormCollection pf)
        {
            try
            {
                int nThang = Convert.ToInt32(pf["nThang"]);
                int nNam = Convert.ToInt32(pf["nNam"]);
                if (nThang > 0 && nThang < 13)//tháng hợp lệ
                {
                    ViewBag.NgayCuoiCungCuaThang = DataThucHanh1.NgayCuoiCungCuaThang(nThang, nNam);
                }
                else//tháng không hợp lệ
                {
                    ViewData["Loi1"] = "Tháng phải từ 1-12";
                }
            }
            catch
            {
                ViewData["Loi2"] = "không được bỏ trống";
            }
            return View();
        }
        #endregion

        #region Trả về ngày đầu tuần 
        public ActionResult NgayDauTienCuaTuan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NgayDauTienCuaTuan(FormCollection pf)
        {
            try
            {
                DateTime dateTime = Convert.ToDateTime(pf["dateTime"]);
                ViewBag.NgayDauTienCuaTuan = DataThucHanh1.NgayDauTienCuaTuan(dateTime);
            }
            catch
            {
                ViewBag.ErrorNgayDauTienCuaTuan = "Chưa chọn thời gian";

            }
            return View();
        }
        #endregion

        #region Trả về ngày cuối tuần 
        public ActionResult NgayCuoiCuaTuan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NgayCuoiCuaTuan(FormCollection pf)
        {
            try
            {
                DateTime dateTime = Convert.ToDateTime(pf["dateTime"]);
                ViewBag.NgayCuoiCuaTuan = DataThucHanh1.NgayCuoiCuaTuan(dateTime);
            }
            catch
            {
                ViewBag.ErrorNgayCuoiCuaTuan = "Chưa chọn thời gian";

            }
            return View();
        }
        #endregion

        #region Dếm số khoản trắng trong 1 chuỗi dữ liệu truyền vào.
        public ActionResult DemKhoangTrang()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DemKhoangTrang(string pChuoi)
        {
            if(pChuoi.Length!=0)//đã nhập
            {
                ViewBag.DemKhoangTrang = DataThucHanh1.DemKhoangTrang(pChuoi);
            }    
            else
            {
                ViewBag.ErrorDemKhoangTrang = "Chưa nhập chuỗi";
            }    
            return View();
        }
        #endregion

        #region Kiểm tra Tính đúng đắn của 1 địa chỉ email truyền vào.
        public ActionResult isEmail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult isEmail(string email)
        {
            if (email.Length != 0)//đã nhập
            {
                if(DataThucHanh1.isEmail(email))//là email
                {
                    ViewBag.isEmail = "Là email";

                }
                else//không phải email
                {
                    ViewBag.isEmail = "Không phải email";
                }    
            }
            else
            {
                ViewBag.ErrorisEmail = "Chưa nhập email";
            }
            return View();
        }
        #endregion

        #region Cắt chuỗi họ tên
        public ActionResult TachHoTen()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TachHoTen(string HoTen)
        {
            if (HoTen.Length != 0)//đã nhập
            {
                ViewBag.TachHoTen = DataThucHanh1.TachHoTen(HoTen);
            }
            else
            {
                ViewBag.ErrorTachHoTen = "Chưa nhập họ tên";
            }
            return View();
        }
        #endregion

        #region Làm tròn các số thập phân truyền vào theo các dạng: Floor, Truncate, Round, Ceiling
        public ActionResult LamTronThapPhan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LamTronThapPhan(FormCollection pf)
        {
            try
            {
                string pLuaChonLamTron = pf["pLuaChonLamTron"];
                double pSoThapPhan = Convert.ToDouble(pf["pSoThapPhan"]);
                ViewBag.LamTronThapPhan = DataThucHanh1.LamTronThapPhan(pSoThapPhan,pLuaChonLamTron);
            }
            catch
            {
                ViewBag.ErrorLamTronThapPhan = "Lỗi nhập số chưa đúng";
            }
            return View();
        }
        #endregion

        #region Viết hàm xử lý viết hoa đầu mỗi ký tự đâu tiên theo tên được truyền vào.
        public ActionResult VietHoaChuCaiDau()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VietHoaChuCaiDau(string Chuoi)
        {
            if (Chuoi.Length != 0)//đã nhập
            {
                ViewBag.VietHoaChuCaiDau = DataThucHanh1.VietHoaChuCaiDau(Chuoi);
            }
            else
            {
                ViewBag.ErrorVietHoaChuCaiDau = "Chưa nhập họ tên";
            }
            return View();
        }
        #endregion

        //Thực Hành 2

        #region Xác định được trong chuỗi có bao nhiêu ký tự được tìm và ở vị trí bao nhiêu
        public ActionResult SoLuongVaViTriKyTu()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SoLuongVaViTriKyTu(string pInput,string pTimKyTu)
        {
            if (pInput.Length != 0 && pTimKyTu.Length!=0)//đã nhập
            {
                ViewBag.SoLuongVaViTriKyTu = Library2.SoLuongVaViTriKyTu(pInput, pTimKyTu);
            }
            else//chưa nhập đủ
            {
                ViewBag.ErrorSoLuongVaViTriKyTu = "Chưa nhập đủ thông tin";
            }
            return View();
        }
        #endregion

        #region Viết hàm random họ tên theo danh sách 3 mảng các từ có sẵn (Họ, Đệm, Tên)
        public ActionResult RanDomHoDemTen()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RanDomHoDemTen(FormCollection pf)
        {
            try
            {
                ViewBag.RanDomHoDemTen = Library2.RanDomHoDemTen();
            }
            catch
            {
                ViewBag.ErrorRanDomHoDemTen = "Lỗi random";
            }
            return View();
        }
        #endregion

        #region Tạo cơ sở , tạo lớp ,tạo sinh viên
        //Tạo list cơ sở(theo số lượng truyền vào)
        public ActionResult TaoListCoSo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TaoListCoSo(FormCollection pf)
        {
            try
            {
                int pSoLuongCoSo = Convert.ToInt32(pf["pSoLuongCoSo"]);
                if(Session["CoSo"]==null)//chưa có mảng
                {
                    var LstCoSo = Library2.TaoListCoSo(0, pSoLuongCoSo);
                    Session["CoSo"] = LstCoSo;//lưu giá trị
                    return View(LstCoSo);
                }    
                else
                {
                    List<CoSo> coSos = new List<CoSo>();
                    coSos = (List<CoSo>)Session["CoSo"];
                    var LstCoSo2 = Library2.TaoListCoSo(coSos.Count, pSoLuongCoSo + coSos.Count);
                    List<CoSo> coSosNew = new List<CoSo>();
                    coSosNew = coSos.Concat(LstCoSo2).ToList();//nối 2 mảng cũ và mới lại
                    Session["CoSo"] = coSosNew;//lưu giá trị
                    return View(coSosNew);
                }    
            }
            catch
            {
                ViewBag.ErrorTaoListCoSo = "Lỗi chưa nhập số lượng sở sở";
            }
            return View();
        }

        //Tạo Tạo list Danh sách lớp học ngẫu nhiên theo số lượng lớp truyền vào, mỗi lớp có 20 sinh viên
        public ActionResult TaoListLopHoc(FormCollection pf)
        {
            try
            {
                int psoLuongLopHoc = Convert.ToInt32(pf["psoLuongLopHoc"]);
                int pSoLuong = Convert.ToInt32(pf["pSoLuong"]);
                int pNamMoLop = Convert.ToInt32(pf["pNamMoLop"]);
                int pID = Convert.ToInt32(pf["pID"]);
                bool pHienThi = Convert.ToBoolean(pf["pHienThi"]);
                if(Session["LopHoc"]==null)//chưa có mản
                {
                    var LstLopHoc = Library2.TaoListLopHoc(0, psoLuongLopHoc, pSoLuong, pNamMoLop, pID, true);
                    Session["LopHoc"] = LstLopHoc;//lưu giá trị
                    return RedirectToAction("TaoListCoSo", "Home");
                }   
                else
                {
                    List<LopHoc> lopHocs = new List<LopHoc>();
                    lopHocs = (List<LopHoc>)Session["LopHoc"];
                    var LstLopHoc = Library2.TaoListLopHoc(lopHocs.Count, psoLuongLopHoc + lopHocs.Count, pSoLuong, pNamMoLop, pID, true);
                    List<LopHoc> lopHocsNew = new List<LopHoc>();
                    lopHocsNew = lopHocs.Concat(LstLopHoc).ToList();//nối 2 mảng cũ và mới lại
                    Session["LopHoc"] = lopHocsNew;//lưu giá trị
                    return RedirectToAction("TaoListCoSo", "Home");
                }    
                
            }
            catch
            {
                ViewBag.ErrorTaoListLopHoc = "Lỗi chưa nhập đúng";
            }
            return RedirectToAction("TaoListCoSo", "Home");
        }

        //Tạo List Sinh viên ngẫu nhiên theo tham số truyền vào.
        public ActionResult TaoListSinhVien(FormCollection pf)
        {
           
                int pSLNam = Convert.ToInt32(pf["pSLNam"]);
                int pSLNu = Convert.ToInt32(pf["pSLNu"]);
                int pIDLopHoc = Convert.ToInt32(pf["pIDLopHoc"]);
                int pSoLuongSinhVien = Convert.ToInt32(pf["pSoLuongSinhVien"]);
                if (Session["SinhVien"] == null)//chưa có sinh viên
                {
                    var LstSinhVien = Library2.TaoListSinhVien(0, pSoLuongSinhVien, Library2.RanDomNamNu(pSLNam, pSLNu, pSoLuongSinhVien), pIDLopHoc);
                    Session["SinhVien"] = LstSinhVien;//lưu giá trị
                    return RedirectToAction("TaoListCoSo", "Home");
                }
                else
                {
                    List<SinhVien> sinhViens = new List<SinhVien>();
                    sinhViens = (List<SinhVien>)Session["SinhVien"];
                    var LstSinhVien = Library2.TaoListSinhVien(sinhViens.Count, pSoLuongSinhVien + sinhViens.Count, Library2.RanDomNamNu(pSLNam, pSLNu, pSoLuongSinhVien), pIDLopHoc);
                    List<SinhVien> sinhViensNew = new List<SinhVien>();
                    sinhViensNew = sinhViens.Concat(LstSinhVien).ToList();//nối 2 mảng cũ và mới lại
                    Session["SinhVien"] = sinhViensNew;//lưu giá trị
                    return RedirectToAction("TaoListCoSo", "Home");
                }
        }
        //Tạo List Sinh viên ngẫu nhiên theo tham số truyền vào.
        public ActionResult XemChiTietLop(int ID)
        {
            List<SinhVien> lsSinhVien = new List<SinhVien>();
            lsSinhVien = (List<SinhVien>)Session["SinhVien"];
            if (lsSinhVien.Count > 0)
            {
                var dSachSinhVien = lsSinhVien.Where(c=>c.LopHoc==ID).OrderBy(s => s.Ten).ToList();
                return View(dSachSinhVien);
            }
            else
            {
                    return RedirectToAction("TaoListCoSo", "Home");
            }       
        }
        #endregion

    }
}