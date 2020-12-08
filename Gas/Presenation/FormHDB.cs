using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gas.Entites;
using Gas.BusinessLayer;
using Gas.BusinessLayer.Interface;


namespace Gas.Presenation
{
    public class FormHDB
    {
        private IFHoaDonBanBLL hoadonban = new HoaDonBanBLL();
        public void Nhap()
        {
            Console.Clear();
            Console.WriteLine("NHAP THONG TIN HOA DON BAN");
            HoaDonBan hdb = new HoaDonBan();
            Console.Write("Nhap ma hoa don ban:"); hdb.mahdb = int.Parse(Console.ReadLine());
            Console.Write("Nhap ma nhan vien ban :"); hdb.manvban = int.Parse(Console.ReadLine());
            Console.Write("Nhap ngay ban :"); hdb.ngayban = Console.ReadLine();
            Console.Write("Nhap ma hang  :"); hdb.mahang = int.Parse(Console.ReadLine());
            Console.Write("Nhap so luong  :"); hdb.soluong = int.Parse(Console.ReadLine());
            Console.Write(" Nhap gia ban   :"); hdb.giaban = double.Parse(Console.ReadLine());
            Console.Write("Nhap don vi tinh:"); hdb.donvi = Console.ReadLine();

            hoadonban.ThemHoaDonBan(hdb);
        }
        public void Hien()
        {
            Console.Clear();
            Console.WriteLine("HIEN THI THONG TIN HOA DON BAN");
            List<HoaDonBan> list = hoadonban.XemDSHoaDonBan();
            foreach (var hdb in list)
                Console.WriteLine(hdb.mahdb + "\t" + hdb.manvban + "\t" + hdb.ngayban + "\t" + hdb.mahang + "\t" + hdb.soluong + "\t" + hdb.giaban + hdb.donvi);
        }
        public void Sua()
        {
            Console.Clear();
            Console.WriteLine("SUA THONG TIN HOA DON BAN");
            List<HoaDonBan> list = hoadonban.XemDSHoaDonBan();
            int mahdb;
            Console.Write("Nhap ma hang don can sua :");
            mahdb = int.Parse(Console.ReadLine());
            int i = 0;
            for (i = 0; i < list.Count; ++i)
                if (list[i].mahdb == mahdb) break;

            if (i < list.Count)
            {
                HoaDonBan mh = new HoaDonBan(list[i]);
                Console.Write("Nhap ten ma hang can sua:");
                string mahang = Console.ReadLine();
                if (!string.IsNullOrEmpty(mahang)) mh.mahang = mahang;
                Console.Write("So luong nhap ve:");
                int SL = int.Parse(Console.ReadLine());

            }
            else
            {
                Console.WriteLine("Khong ton tai ma hang nay");
            }
        }
        public void Menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("QUAN LY THONG TIN HOA DON");
                Console.WriteLine(" 1.Nhap Hoa don ");
                Console.WriteLine(" 2.Sua Hoa don  ");
                Console.WriteLine(" 3.Xoa hoa don  ");
                Console.WriteLine(" 4.Hien danh sach ");
                Console.WriteLine(" 5.Tim kiem ");
                Console.WriteLine(" 6.Back ");

                int n = int.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        Nhap();
                        Hien();
                        Console.WriteLine("Nhap phim bat ky de tiep tuc...");
                        Console.ReadKey();
                        break;
                    case 2:
                        Hien();
                        Console.WriteLine("Nhap phim bat ky de tiep tuc...");
                        Console.ReadKey();
                        break;
                    case 3:
                        Hien();
                        Console.WriteLine("Nhap phim bat ky de tiep tuc...");
                        Console.ReadKey();
                        break;
                    case 4:
                        Sua();
                        Hien();
                        Console.WriteLine("Nhap phim bat ky de tiep tuc...");
                        Console.ReadKey();
                        break;
                    case 6:
                        Program.Menu();
                        break;
                }
            } while (true);
        }
    }
}
