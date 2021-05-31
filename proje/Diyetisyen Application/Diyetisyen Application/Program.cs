using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diyetisyen_Application
{
    class Program
    {

        static void Main(string[] args)
        {
            User MyUser=girisYap();

            Console.WriteLine(MyUser.GetType().Name);//kullanıcı tipini alma

            MyUser.BilgiYazdir();

            Console.WriteLine(((Hasta)MyUser).DiyetBilgisi());// kullanıcı tipine göre işlen yapacağımız şekil
            SingletonDB.GetInstance.DiyetAtamaIslemi(DiyetTipleri.Akdeniz,(Hasta)MyUser);
            Console.WriteLine(((Hasta)MyUser).DiyetBilgisi());
            Console.Read();
        }
        static public User girisYap()
        {
            string tc="", sifre="";
            User myUser = null;
            while (myUser == null)
            {
                Console.Write("TC Kimlik: ");
                tc = Console.ReadLine().ToString();
                Console.Write("Sifre: ");
                sifre = Console.ReadLine().ToString();
                myUser = SingletonDB.GetInstance.GetKullanici(tc, sifre);
            }
            return myUser;
        }
        static public void kimsiniz()
        {
            string kimsin, adminKontrol;
        gecerliDegerGir:
            Console.WriteLine("Kim Giris Yapiyor(Admin-A, Diyetisyen-D)");
            kimsin = Console.ReadLine();
            if (kimsin == "A" || kimsin == "a")
            {
            gecerliDegerGirAdmin:
                Console.WriteLine("1-Diyetisyen Ekle\n2-Ust Menu\n3-Cikis");
                adminKontrol = Console.ReadLine();

                if (adminKontrol == "1")
                {
                    diyetisyenEkle();
                }
                else if (adminKontrol == "2")
                {
                    goto gecerliDegerGir;

                }
                else if (adminKontrol == "3")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Lutfen Gecerli Bir Deger Giriniz!!!\a\n");
                    goto gecerliDegerGirAdmin;
                }


            }
            else if (kimsin == "D" || kimsin == "d")
            {
                Console.WriteLine("Sen Diyetisyensin");

            }
            else
            {
                Console.WriteLine("Lutfen Gecerli Bir Deger Giriniz!!!\a\n");
                goto gecerliDegerGir;
            }
        }

        static public void diyetisyenEkle()
        {
            string tcNo, isim, soyisim,sifre;
            Console.WriteLine("Diyetisyenin TC Kimlik Numarasi: ");
            tcNo = Console.ReadLine();
            Console.WriteLine("Diyetisyenin Adi: ");
            isim = Console.ReadLine();
            Console.WriteLine("Diyetisyenin Soyadi: ");
            soyisim = Console.ReadLine();
            Console.WriteLine("Diyetisyenin Sifre: ");
            sifre = Console.ReadLine();
            Diyetisyen diyetisyen = new Diyetisyen(tcNo, isim, soyisim,sifre);
            SingletonDB.GetInstance.AddDiyetisyen(diyetisyen);
        }
       
    }

}