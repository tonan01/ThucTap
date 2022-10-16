using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT.ASC.DATA
{
    public class BaseDoiTuong
    {
        //properties
        private int _ID;
        private string _GuidID;
        public int ID { get => _ID; set => _ID = value; }
        public string GuidID { get => _GuidID; set => _GuidID = value; }
        //defauft constructor
        public  BaseDoiTuong()
        {
            
        }
        //constructor with parameters
        public BaseDoiTuong(int iD, string guidID)
        {
            ID = iD;
            GuidID = guidID;
        }

        //methods
        #region Copy
        public void Copy()
        {
           ID=this._ID;
           GuidID = this._GuidID;
        }
        #endregion

        #region Compare
        public int SoSanh()
        {
            if (_ID< 0)//không được âm
            {
                return 1;
            }
            if (_GuidID.Length == 0)//chưa nhập tên
            {
                return 2;
            }
            return 0;
        }
        #endregion

        #region Print
        public string Print()
        {
            return this._ID.ToString() + ", " + this._GuidID;
        }
        #endregion

        #region Kiểm tra nhập mã, tên)
        public int KiemTraNhap()
        {
            if (this._ID.ToString().Length == 0)//chưa nhập mã
            {
                return 1;
            }
            if (this._GuidID.Length == 0)//chưa nhập tên
            {
                return 2;
            }
            return 0;
        }
        #endregion
    }
}
