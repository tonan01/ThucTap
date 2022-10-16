using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT.ASC.DATA
{
    public  class LopHoc : BaseDoiTuong
    {
        private string tenLop;
        private int soLuong;
        private int namMoLop;
        private int coSoDaoTao;
        private bool hienThi;

        public string TenLop { get => tenLop; set => tenLop = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public int NamMoLop { get => namMoLop; set => namMoLop = value; }
        public int CoSoDaoTao { get => coSoDaoTao; set => coSoDaoTao = value; }
        public bool HienThi { get => hienThi; set => hienThi = value; }
        public LopHoc()
        {

        }
        public LopHoc(string tenLop, int soLuong, int namMoLop, int coSoDaoTao, bool hienThi)
        {
            TenLop = tenLop;
            SoLuong = soLuong;
            NamMoLop = namMoLop;
            CoSoDaoTao = coSoDaoTao;
            HienThi = hienThi;
        }
    }
}
