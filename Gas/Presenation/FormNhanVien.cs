using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gas.BusinessLayer.Interface;
using Gas.BusinessLayer;
using Gas.Entites;

namespace GAS.Presenation
{
    public class FormNhanVien
    {
        private IFNhanVienBLL nhanvien = new NhanVienBLL();
        public void Nhap()
        {
            Console.Clear();
            Console.WriteLine("NHAP THONG TIN NHAN VIEN");
            NhanVien nv = new NhanVien();
            Console.Write("Nhap ma nhan vien:"); nv.manv = int.Parse(Console.ReadLine());
            Console.Write("Nhap ten nhan vien:"); nv.tennv = Console.ReadLine();
            Console.Write("Nhap ngay sinh :"); nv.ngaysinh= (Console.ReadLine());
            Console.Write("Nhap gioi tinh :"); nv.gt = Console.ReadLine();
            Console.Write("Nhap ngay vao lam viec:"); nv.ngayvaolam = Console.ReadLine();

            nhanvien.ThemNhanVien(nv);
        }
        public void Hien()
        {
            Console.Clear();
            Console.WriteLine("HIEN THI THONG TIN NHAN VIEN ");
            List<NhanVien> list = nhanvien.XemDSNhanVien();
            foreach (var nv in list)
                Console.WriteLine(nv.manv + "\t" + nv.tennv + "\t" + nv.ngaysinh + "\t" + nv.gt + "\t" + nv.ngayvaolam);
        }
        public void Sua()
        {
            Console.Clear();
            Console.WriteLine("SUA THONG TIN NHAN VIEN");
            List<NhanVien> list = nhanvien.XemDSNhanVien();
            int manv;
            Console.Write("Nhap ma nhan vien can sua:");
            manv = int.Parse(Console.ReadLine());
            int i = 0;
            for (i = 0; i < list.Count; ++i)
                if (list[i].manv == manv) break;

            if (i < list.Count)
            {
              NhanVien nv = new NhanVien(list[i]);
                Console.Write("Nhap ten hang moi:");
                string tennv = Console.ReadLine();
                if (!string.IsNullOrEmpty(tennv)) nv.tennv = tennv;
                Console.Write("So luong nhap ve:");
                int SL = int.Parse(Console.ReadLine());

            }
            else
            {
                Console.WriteLine("Khong ton tai ma nhan vien nay");
            }
        }
        public void Menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("QUAN LY THONG TIN NHAN VIEN ");
                Console.WriteLine(" 1.Nhap nhan vien ");
                Console.WriteLine(" 2.Sua nhan vien ");
                Console.WriteLine(" 3.Xoa nhan vien  ");
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

