using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TT.ASC.DATA
{
    public static class Library2
    {
        #region Xác định được trong chuỗi có bao nhiêu ký tự được tìm và ở vị trí bao nhiêu
        public static string SoLuongVaViTriKyTu(string pInput1,string pTimKyTu)
        {
            string dSachViTri = "";
            List<string> ViTri = new List<string>();
            int dem = 0;
            for (int i = 0; i < pInput1.Length; i++)
            {
                string s = pInput1.Substring(i, 1);
                if (s==pTimKyTu)//tìm ra
                {
                    dem++;//số lượng
                    ViTri.Add(i.ToString());//lưu vị trí  
                }    
            }
            if(dem==0)//không trùng ký tự nào hết
            {
                return "Không có ký tự giống: " + pTimKyTu;
            }    
            //danh sách vị trí
            dSachViTri = String.Join(", ", ViTri);
            return "Số lượng: "+ dem.ToString() +"; Vị trí thứ "+dSachViTri;
        }
        #endregion

        #region Viết hàm random họ tên theo danh sách 3 mảng các từ có sẵn (Họ, Đệm, Tên)
        public static string RanDomHoDemTen()
        {
            string fullName = "";
            string[] Ho = new string[] { "Nguyễn", "Trần", "Lê", "Hồ" };
            string[] Dem = new string[] { "Văn", "Thanh", "Hoàng", "Thị", "Kim", "Ngọc" };
            string[] Ten = new string[] { "Nhân", "Hậu", "Nghĩa", "Lễ", "Trí", "Tín", "Trang", "Thúy", "Phương", "Hiếu" };
            Random random = new Random();
            fullName= Ho[random.Next(Ho.Length)] + " " + Dem[random.Next(Dem.Length)] + " " + Ten[random.Next(Ten.Length)];
            return fullName;
        }
        #endregion Tách họ và tên

        #region Bài 3 tạo cơ sở, tạo lớp, tạo sinh viên
        //tạo cở sở
        public static List<CoSo> TaoListCoSo(int pSoLuongBatDau,int pSoLuongCoSo)
        {
            List<CoSo> lsCoSo = new List<CoSo>();
            for(int i= pSoLuongBatDau; i<pSoLuongCoSo;i++)
            {
                CoSo coSo = new CoSo();
                coSo.ID= i;
                coSo.GuidID=i.ToString()+"CS";
                coSo.Ten = "Cơ sở " + i.ToString();
                lsCoSo.Add(coSo);
            }
            return lsCoSo;
        }
        //tạo lớp
        public static List<LopHoc> TaoListLopHoc(int pSoLuongBatDau,int psoLuongLopHoc,int pSoLuong, int pNamMoLop, int pID,bool pHienThi)
        {
            List<LopHoc> lsLopHoc = new List<LopHoc>();
            for (int i = pSoLuongBatDau; i < psoLuongLopHoc; i++)
            {
                LopHoc lopHoc = new LopHoc();
                lopHoc.ID = i;
                lopHoc.GuidID = i.ToString() + "LH";
                lopHoc.TenLop = "Lớp " + i.ToString();
                lopHoc.SoLuong = pSoLuong;
                lopHoc.NamMoLop = pNamMoLop;
                lopHoc.CoSoDaoTao = pID;
                lopHoc.HienThi = pHienThi;
                lsLopHoc.Add(lopHoc);
            }
            return lsLopHoc;
        }
        //tạo sinh viên
        public static List<SinhVien> TaoListSinhVien(int pSoLuongBatDau, int pSoLuongSinhVien,List<int> pGioiTinh, int pIDLopHoc)
        {
            List<SinhVien> lsSinhVien = new List<SinhVien>();
            List<int> dsGioiTinh = new List<int>();
            dsGioiTinh = pGioiTinh.ToList();
            string[] Ho = new string[] { "Nguyễn", "Trần", "Lê", "Hồ" };
            string[] Dem = new string[] { "Văn", "Thanh", "Hoàng", "Thị", "Kim", "Ngọc" };
            string[] Ten = new string[] { "Nhân", "Hậu", "Nghĩa", "Lễ", "Trí", "Tín", "Trang", "Thúy", "Phương", "Hiếu" };
            Random random = new Random();
            for (int i = pSoLuongBatDau; i < pSoLuongSinhVien; i++)
            {
                string HoVaTen = "";
                HoVaTen = Ho[random.Next(Ho.Length)] + " " + Dem[random.Next(Dem.Length)] + " " + Ten[random.Next(Ten.Length)];
                string hoDem = HoVaTen.Substring(0, HoVaTen.LastIndexOf(' '));
                string ten = HoVaTen.Substring(HoVaTen.LastIndexOf(' ')+1);
                SinhVien sinhVien = new SinhVien();
                sinhVien.ID = i;
                sinhVien.GuidID = i.ToString() + "SV";
                sinhVien.HoDem = hoDem;
                sinhVien.Ten = ten;
                sinhVien.GioiTinh = dsGioiTinh[i-pSoLuongBatDau];
                sinhVien.LopHoc = pIDLopHoc;
                lsSinhVien.Add(sinhVien);
            }
            return lsSinhVien;
        }
        //ramdom nam nữ theo số lượng
        public static List<int> RanDomNamNu(int pSLNam,int pSLNu,int pSoLuongSinhVien)
        {
            List<int> list = new List<int>();
            int sLNam=pSLNam;
            int sLNu=pSLNu;
            Random rand = new Random();
            for(int i = 0; i < pSoLuongSinhVien; i++)
            {
                int s = 0;
                s = rand.Next(1, 3);

                if (sLNam != 0 && s == 1)//random ra nam
                {
                    list.Add(s);
                    sLNam--;
                }
                else if (sLNam == 0 && s == 1 && sLNu != 0)//hết nam còn nữ
                {
                    s = 2;
                }
                if (sLNu != 0 && s == 2)//random ra nữ
                {
                    list.Add(s);
                    sLNu--;
                }
                else if (sLNu == 0 && s == 2 && sLNam > 0)// hết nữ còn nam
                {
                    list.Add(s - 1);
                    sLNam--;
                }
            }
            return list;
        }
        #endregion
    }
}
