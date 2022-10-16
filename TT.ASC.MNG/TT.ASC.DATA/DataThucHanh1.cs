using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TT.ASC.DATA
{
    public static class DataThucHanh1
    {
        #region Định dạng ngày tháng năm, giờ phút giây
        public static string DinhDangNgayThangNam(DateTime pdt, string pLoaiDinhDang)
        {
            string NgayDinhDang = "";
            NgayDinhDang = String.Format("{0:" + pLoaiDinhDang + "}", pdt);
            return NgayDinhDang;

        }
        #endregion

        #region Đọc dãy số bất kỳ
        public static string DocSo(double DaySo, bool suffix = true)
        {
            //nếu là số không
            if (DaySo == 0)
            {
                return "Không";
            }
            string[] unitNumbers = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] placeValues = new string[] { "", "nghìn", "triệu", "tỷ" };
            // false số dương
            bool isNegative = false;

            // Chuyển đổi số thập phân thành số nguyên và đổi thành string ví dụ là 123.123 => "123"
            string sNumber = DaySo.ToString("#");
            //ép kiểu
            double number = Convert.ToDouble(sNumber);
            //Nếu là số am
            if (number < 0)
            {
                number = -number;
                sNumber = number.ToString();
                //true là số âm
                isNegative = true;
            }


            int ones, tens, hundreds;
            //vị trí
            int positionDigit = sNumber.Length;   // last -> first

            string result = " ";


            if (positionDigit == 0)
            {
                result = unitNumbers[0] + result;
            }
            else
            {
                // 0:      
                // 1: nghìn 
                // 2: triệu 
                // 3: tỷ    
                int placeValue = 0;

                while (positionDigit > 0)
                {
                    //kiểm tra trăm chục và 1 đơn vị
                    tens = hundreds = -1;
                    //Đơn vị
                    ones = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                    positionDigit--;
                    if (positionDigit > 0)
                    {
                        //Chục
                        tens = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                        positionDigit--;
                        if (positionDigit > 0)
                        {
                            //Trăm
                            hundreds = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                            positionDigit--;
                        }
                    }
                    //Thêm đơn vị "nghìn", "triệu", "tỷ"
                    if ((ones > 0) || (tens > 0) || (hundreds > 0) || (placeValue == 3))
                    {
                        result = placeValues[placeValue] + result;
                    }

                    placeValue++;//qua mỗi vòng sẽ tăng lên để lên 0: "", 1: "nghìn", 2:"triệu", 3:"tỷ"
                    if (placeValue > 3) //Vượt qua tỷ nó sẽ trở lại nghìn và tiếp tục tăng lên
                    {
                        placeValue = 1;
                    }
                    //Đọc các số đơn vị 
                    if ((ones == 1) && (tens > 1)) //Đọc số 1 khi có hàng chục > 1 vì 1 dọc là mười
                        result = "mốt " + result;
                    else
                    {
                        if ((ones == 5) && (tens > 0))//Đọc số 5 khi có hàng chục >0 vì 0 là 05 or 105 đọc là năm
                            result = "lăm " + result;
                        else if (ones > 0)//Đọc đơn vị bình thường
                            result = unitNumbers[ones] + " " + result;
                    }
                    //Đọc Hàng chục 
                    if (tens < 0)//không có hàng chục
                    {
                        break;
                    }
                    else//Có hàng chục
                    {
                        if ((tens == 0) && (ones > 0)) result = "lẻ " + result; //Hàng chục = 0
                        if (tens == 1) result = "mười " + result; //Hàng chục là 1
                        if (tens > 1) result = unitNumbers[tens] + " mươi " + result; //Hàng chục >1
                    }
                    //Đọc hàng trăm
                    if (hundreds < 0)//không có hàng trăm
                    {
                        break;
                    }
                    else//Có hàng trăm
                    {
                        if ((hundreds > 0) || (tens > 0) || (ones > 0))
                            result = unitNumbers[hundreds] + " trăm " + result;
                    }
                    result = " " + result;
                }
            }
            //Loại bỏ khoảng trắng
            result = result.Trim();
            //nếu số âm
            if (isNegative)
            {
                //Thêm Trừ phía trước
                result = "Trừ " + result;
            }
            return result;

        }
        #endregion

        #region Đọc số tiền bất kỳ
        public static string DocTien(double SoTien, bool suffix = true)
        {
            //nếu là số không
            if (SoTien == 0)
            {
                return "Không" + (suffix ? " VNĐ" : "");
            }
            string[] unitNumbers = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] placeValues = new string[] { "", "nghìn", "triệu", "tỷ" };
            // false số dương
            bool isNegative = false;

            // Chuyển đổi số thập phân thành số nguyên và đổi thành string ví dụ là 123.123 => "123"
            string sNumber = SoTien.ToString("#");
            //ép kiểu
            double number = Convert.ToDouble(sNumber);
            //Nếu là số tiền âm
            if (number < 0)
            {
                number = -number;
                sNumber = number.ToString();
                //true là số âm
                isNegative = true;
            }


            int ones, tens, hundreds;
            //vị trí
            int positionDigit = sNumber.Length;   // last -> first

            string result = " ";


            if (positionDigit == 0)
            {
                result = unitNumbers[0] + result;
            }
            else
            {
                // 0:      
                // 1: nghìn 
                // 2: triệu 
                // 3: tỷ    
                int placeValue = 0;

                while (positionDigit > 0)
                {
                    //kiểm tra trăm chục và 1 đơn vị
                    tens = hundreds = -1;
                    //Đơn vị
                    ones = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                    positionDigit--;
                    if (positionDigit > 0)
                    {
                        //Chục
                        tens = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                        positionDigit--;
                        if (positionDigit > 0)
                        {
                            //Trăm
                            hundreds = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                            positionDigit--;
                        }
                    }
                    //Thêm đơn vị "nghìn", "triệu", "tỷ"
                    if ((ones > 0) || (tens > 0) || (hundreds > 0) || (placeValue == 3))
                    {
                        result = placeValues[placeValue] + result;
                    }

                    placeValue++;//qua mỗi vòng sẽ tăng lên để lên 0: "", 1: "nghìn", 2:"triệu", 3:"tỷ"
                    if (placeValue > 3) //Vượt qua tỷ nó sẽ trở lại nghìn và tiếp tục tăng lên
                    {
                        placeValue = 1;
                    }
                    //Đọc các số đơn vị 
                    if ((ones == 1) && (tens > 1)) //Đọc số 1 khi có hàng chục > 1 vì 1 dọc là mười
                        result = "mốt " + result;
                    else
                    {
                        if ((ones == 5) && (tens > 0))//Đọc số 5 khi có hàng chục >0 vì 0 là 05 or 105 đọc là năm
                            result = "lăm " + result;
                        else if (ones > 0)//Đọc đơn vị bình thường
                            result = unitNumbers[ones] + " " + result;
                    }
                    //Đọc Hàng chục 
                    if (tens < 0)//không có hàng chục
                    {
                        break;
                    }
                    else//Có hàng chục
                    {
                        if ((tens == 0) && (ones > 0)) result = "lẻ " + result; //Hàng chục = 0
                        if (tens == 1) result = "mười " + result; //Hàng chục là 1
                        if (tens > 1) result = unitNumbers[tens] + " mươi " + result; //Hàng chục >1
                    }
                    //Đọc hàng trăm
                    if (hundreds < 0)//không có hàng trăm
                    {
                        break;
                    }
                    else//Có hàng trăm
                    {
                        if ((hundreds > 0) || (tens > 0) || (ones > 0))
                            result = unitNumbers[hundreds] + " trăm " + result;
                    }
                    result = " " + result;
                }
            }
            //Loại bỏ khoảng trắng
            result = result.Trim();
            //nếu âm tiền
            if (isNegative)
            {
                //Thêm Trừ phía trước
                result = "Âm " + result;
            }
            return result + (suffix ? " VNĐ" : "");

        }
        #endregion

        #region Random chuỗi ký tự và số có chiều dài bất kỳ    
        public static string RanDomKyTy(string KyTu, int SoLuong)
        {
            string[] s = new string[SoLuong];
            Random r = new Random();
            //random ký tự
            for (int i = 0; i < SoLuong; i++)
            {
                s[i] = KyTu[r.Next(KyTu.Length)].ToString();//lấy ra 1 ký tự bất kỳ trong mảng s
            }
            //chuyển mảng thành chuổi
            string kq = string.Join("", s);
            return kq;
        }
        #endregion

        #region Trả về ngày đầu tiên của tháng
        public static int NgayDauTienCuaThang(int nThang, int nNam)
        {
            DateTime dt = new DateTime(nNam, nThang, 1);
            return dt.Day;
        }
        #endregion

        #region Trả về ngày cuối tháng
        public static int NgayCuoiCungCuaThang(int nThang, int nNam)
        {
            DateTime dt = new DateTime(nNam, nThang, 1);
            dt = dt.AddMonths(1);//thêm 1 tháng
            dt = dt.AddDays((-dt.Day));// trừ lại 1 ngày sẽ nhận được ngày cuối tháng
            return dt.Day;
        }
        #endregion

        #region Trả về ngày đầu tuần ( thứ 2 của tuần đó)
        public static int NgayDauTienCuaTuan(DateTime dateTime)
        {
            //Ngày đầu tuần               ví đụ thứ 3 là    -2   +   1 =  -1 giảm lại 1 ngày là thứ 2
            var monday = dateTime.AddDays(-(int)dateTime.DayOfWeek + (int)DayOfWeek.Monday);
            return monday.Day;
        }
        #endregion

        #region Trả về ngày cuối tuần ( chủ nhật của tuần đó)
        public static int NgayCuoiCuaTuan(DateTime dateTime)
        {
            //Ngày cuối của tuần            ví đụ thứ 4 là    -3   +   6 =  3 Tăng thêm 3 ngày là thứ 7
            var sunday = dateTime.AddDays(-(int)dateTime.DayOfWeek + (int)DayOfWeek.Saturday);
            return sunday.Day;
        }
        #endregion

        #region Đếm số khoản trắng trong 1 chuỗi dữ liệu truyền vào
        public static int DemKhoangTrang(string Chuoi)
        {
            int dem = 0;
            string s;
            for (int i = 0; i < Chuoi.Length; i++)
            {
                s = Chuoi.Substring(i, 1);//lấy ký tự vi trí i số lượng 1
                if (s == " ")//khoảng trắng
                {
                    dem++;
                }
            }
            return dem;
        }
        #endregion

        #region Kiểm tra Tính đúng đắn của 1 địa chỉ email truyền vào.
        public static bool isEmail(string email)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(email);//nếu không phải là mail sẽ bị lỗi và chạy xuống catch
                return true;//là email
            }
            catch
            {
                return false;//không la email
            }
        }
        #endregion

        #region Cắt chuỗi họ tên ( tách ra họ và tên đệm khi một chuổi họ tên được truyền vào)
        public static string TachHoTen(string HoTen)
        {
            //split tách những ky tự có khoảng trắng
            List<string> lstTen = HoTen.Split(' ').ToList();
            string Ten = lstTen.Last();
            lstTen.RemoveAt(lstTen.Count() - 1);//xóa tên khỏi ds
            //chuyển list thành chuỗi
            string HovaTenDem = String.Join(" ", lstTen);
            return "Họ: " + HovaTenDem + "      Tên: " + Ten;
        }
        #endregion

        #region Làm tròn các số thập phân truyền vào theo các dạng: Floor, Truncate, Round, Ceiling
        public static double LamTronThapPhan(double pSoThapPhan, string pLuaChoLamTon)
        {
            double result = 0;
            switch (pLuaChoLamTon)
            {
                case "Floor"://Hàm làm tròn xuống
                    result = Math.Floor(pSoThapPhan);
                    break;
                case "Truncate": //Làm tròn lên hoặc xuống về phía không.
                    result = Math.Truncate(pSoThapPhan);
                    break;
                case "Round":
                    //Làm tròn mặc định  các số từ 0,1,2,3,4,5 sẽ làm tròn về 0 và số 6,7,8,9 làm tròn về 1
                    result = Math.Round(pSoThapPhan);
                    break;
                case "Ceiling": //Làm tròn lên 
                    result = Math.Ceiling(pSoThapPhan);
                    break;
                default:
                    break;
            }
            return result;
        }
        #endregion

        #region viết hoa đầu mỗi ký tự đâu tiên theo tên được truyền vào.
        public static string VietHoaChuCaiDau(string Chuoi)
        {
            string str = "";
            //Chuyển chuỗi thành mảng
            List<string> listVietHoa = Chuoi.Split(' ').ToList();
            for (int i = 0; i < listVietHoa.Count; i++)
            {
                string s = listVietHoa[i];
                if (s.Length > 0)
                {
                    //Viết hoa chữ cái đầu tiên và chữ cái phía sau viết thường
                    listVietHoa[i] = s.Substring(0, 1).ToUpper() + s.Substring(1).ToLower();
                }
            }
            //Chuyển mảng thành chuổi
            str = String.Join(" ", listVietHoa);
            return str;
        }
        #endregion
    }
}
