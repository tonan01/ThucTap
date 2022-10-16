using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT.ASC.DATA
{
    public class CoSo : BaseDoiTuong
    {
        private string ten;
        public string Ten { get => ten; set => ten = value; }
        public CoSo()
        {

        }
        public CoSo(string ten)
        {
            Ten = ten;
        }
    }
}
