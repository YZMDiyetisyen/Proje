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
            kimsiniz();
               //User MyUser=girisYap();//kullanici girisi alma

            //Console.WriteLine(MyUser.GetType().Name);//kullanıcı tipini alma

            //MyUser.BilgiYazdir();
            //hasta olduğunu varsayarsak {
            //Console.WriteLine(((Hasta)MyUser).DiyetBilgisi());// kullanıcı tipine göre işlen yapacağımız şekil , di
            //SingletonDB.GetInstance.DiyetAtamaIslemi(DiyetTipleri.Akdeniz,(Hasta)MyUser);//giris yapan hastaya diyet atama
            //Console.WriteLine(((Hasta)MyUser).HastalikBilgisi());
            // }

            ///////////////////////////
             

            //Console.Read();
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
                    goto gecerliDegerGirAdmin;
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
            gecerliDegerGirD:
                string secim = "";
                Console.WriteLine("1-Hasta Ekle\n2-Hastalarin Diyetini Degistir\n3-Ust Menu\n4-Cikis");
                secim = Console.ReadLine();

                if (secim == "1")
                {
                    hastaEkle();
                    goto gecerliDegerGirD;
                }
                else if (secim == "2")
                {
                    hastaListele();
                    hastaDiyetDegistir();
                    goto gecerliDegerGirD;
                }
                else if (secim == "3")
                {
                    goto gecerliDegerGir;
                }
                else if (secim == "4")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Lutfen Gecerli Bir Deger Giriniz!!!\a\n");
                    goto gecerliDegerGirD;
                }

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
            SingletonDB.GetInstance.AddUser(diyetisyen);
            Console.WriteLine("Diyetisyen Eklendi");

        }

        static public void hastaEkle()
        {
            string tcNo, isim, soyisim, sifre;
            Console.WriteLine("Hastanin TC Kimlik Numarasi: ");
            tcNo = Console.ReadLine();
            Console.WriteLine("Hastanin Adi: ");
            isim = Console.ReadLine();
            Console.WriteLine("Hastanin Soyadi: ");
            soyisim = Console.ReadLine();
            Console.WriteLine("Hastanin Sifresi: ");
            sifre = Console.ReadLine();
            Hasta hasta = new Hasta(tcNo, isim, soyisim,sifre);
            SingletonDB.GetInstance.AddUser(hasta);
            Console.WriteLine("Hasta Eklendi");
        }
        static public void hastaListele()
        {
            Console.WriteLine("\nHastalar");
            foreach (User item in SingletonDB.GetInstance.GetKullanicilar(kullaniciTipleri.Hasta))
            {
                item.BilgiYazdir();
            }
        }

        static public void hastaDiyetDegistir()
        {
            
        }

    }

}