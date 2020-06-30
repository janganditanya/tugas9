using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tugas9
{
    class Program
    {
        private static List<Karyawan> listKaryawan = new List<Karyawan>();
        public static void tambahKaryawan()
        {
            Console.WriteLine("Tambah Data Karyawan\n\n");
            Console.Write("Jenis Karyawan [1. Karyawan Tetap | 2. Karyawan Harian | 3. Sales]: ");
            int pil = int.Parse(Console.ReadLine());
            switch(pil)
            {
                case 1:
                    KaryawanTetap karyawanTetap = new KaryawanTetap();
                    Console.Write("NIK : ");
                    karyawanTetap.Nik = Console.ReadLine();
                    Console.Write("Nama : ");
                    karyawanTetap.Nama = Console.ReadLine();
                    Console.Write("Gaji Bulanan : ");
                    karyawanTetap.GajiBulanan = double.Parse(Console.ReadLine());
                    listKaryawan.Add(karyawanTetap);
                    break;
                case 2:
                    KaryawanHarian karyawanHarian = new KaryawanHarian();
                    Console.Write("NIK : ");
                    karyawanHarian.Nik = Console.ReadLine();
                    Console.Write("Nama : ");
                    karyawanHarian.Nama = Console.ReadLine();  
                    Console.Write("Jumlah Jam Kerja : ");
                    karyawanHarian.JumlahJamKerja =  double.Parse(Console.ReadLine());
                    Console.Write("Upah Per Jam : ");
                    karyawanHarian.UpahPerJam = double.Parse(Console.ReadLine());
                    listKaryawan.Add(karyawanHarian);
                    break;
                case 3:
                    Sales sales = new Sales();
                    Console.Write("NIK : ");
                    sales.Nik = Console.ReadLine();
                    Console.Write("Nama : ");
                    sales.Nama = Console.ReadLine(); 
                    Console.Write("Jumlah Jual : ");
                    sales.JumlahPenjualan = double.Parse(Console.ReadLine());
                    Console.Write("Komisi : ");
                    sales.Komisi = double.Parse(Console.ReadLine());
                    listKaryawan.Add(sales);
                    break;
            }
        }

        public static void hapusKaryawan()
        {
            int no = -1, hapus = -1;
            Console.WriteLine("Hapus Data Karyawan\n");
            Console.Write("NIK : ");
            string nik = Console.ReadLine();
            foreach (Karyawan karyawan in listKaryawan)
            {
                no++;
                if (karyawan.Nik == nik)
                {
                    hapus = no;
                }
            }
            if (hapus != -1)
            {
                listKaryawan.RemoveAt(hapus);
                Console.WriteLine("\nData Berhasil dihapus");
            }
            else
            {
                Console.WriteLine("\nData Nik tidak ditemukan");
            }
        }

        public static void displayKaryawan()
        {
            int noUrut = 0;
            string jenis = "";
            Console.WriteLine("Data Karyawan\n");
            foreach (Karyawan karyawan in listKaryawan)
            {
                if (karyawan is KaryawanTetap)
                {
                    jenis = "Karyawan Tetap";
                }
                else if (karyawan is KaryawanHarian)
                {
                    jenis = "Karyawan Harian";
                }
                else
                {
                    jenis = "Sales";
                }
                noUrut++;
                Console.WriteLine("{0}. Nik: {1}, Nama: {2}, Gaji: {3:N0}, {4}", noUrut, karyawan.Nik, karyawan.Nama, karyawan.Gaji(), jenis);
            }
            if (noUrut < 1)
            {
                Console.WriteLine("Data Karyawan Kosong");
            }
        }
        static void Main(string[] args)
        {
            Console.Title = "Tugas lab 9 (Pertemuan 12) - Polymorphsim, Abstraction & Collection part 2";

            bool loop = true;
            
            while (loop)
            {

                Console.Clear();
                Console.WriteLine("Pilih Menu Aplikasi\n");
                Console.WriteLine("1. Tambah Data Karyawan");
                Console.WriteLine("2. Hapus Data Karyawan");
                Console.WriteLine("3. Tampilkan Data Karyawan");
                Console.WriteLine("4. Keluar\n");
                Console.Write("Nomor Menu [1..4]: ");
                int pil = int.Parse(Console.ReadLine());

                switch (pil)
                {
                    case 1:
                        Console.Clear();
                        tambahKaryawan();
                        Console.WriteLine("\nTekan enter untuk kembali ke menu");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        hapusKaryawan();
                        Console.WriteLine("\nTekan enter untuk kembali ke menu");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        displayKaryawan();
                        Console.WriteLine("\nTekan enter untuk kembali ke menu");
                        Console.ReadKey();
                        break;
                    case 4:
                        loop = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("\nMaaf, menu yang Anda pilih tidak tersedia");
                        break;
                }
            }
        }
    }
}
