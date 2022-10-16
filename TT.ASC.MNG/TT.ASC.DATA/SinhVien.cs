using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT.ASC.DATA
{
    public class SinhVien : BaseDoiTuong
    {
        private string hoDem;
        private string ten;
        private int gioiTinh;
        private int lopHoc;

        public string HoDem { get => hoDem; set => hoDem = value; }
        public string Ten { get => ten; set => ten = value; }
        public int GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public int LopHoc { get => lopHoc; set => lopHoc = value; }
        public SinhVien()
        {

        }
        public SinhVien(string hoDem, string ten, int gioiTinh, int lopHoc)
        {
            HoDem = hoDem;
            Ten = ten;
            GioiTinh = gioiTinh;
            LopHoc = lopHoc;
        }
    }
}
