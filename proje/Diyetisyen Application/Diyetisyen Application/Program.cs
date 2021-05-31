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
            Diyetisyen diyetisyen = new Diyetisyen("1321321321","sezer","yıldırım","132");
            //kimsiniz();
            KullaniciListele(kullaniciTipleri.Diyetisyen);
            HastaAta();
            HastaAta();
            //Console.WriteLine("Mevcut Hastalık: " + ((Hasta)SingletonDB.GetInstance.GetKullanici("222","123")).HastalikBilgisi());
            
             //User MyUser=girisYap();//kullanici girisi alma
            //Console.WriteLine(MyUser.GetType().Name);//kullanıcı tipini alma

            //MyUser.BilgiYazdir();
            Console.Read();
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
                KullaniciListele();
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
        static public void KullaniciListele(kullaniciTipleri tip=kullaniciTipleri.Hasta)
        {
            User[] kullaniciListe;
            switch (tip)
            {
                case kullaniciTipleri.Admin:
                    Console.WriteLine("\nADMİNLER:");
                    kullaniciListe = SingletonDB.GetInstance.GetKullanicilar(kullaniciTipleri.Admin).ToArray();
                    break;
                case kullaniciTipleri.Diyetisyen:
                    Console.WriteLine("\nDİYETİSYENLER:");
                    kullaniciListe = SingletonDB.GetInstance.GetKullanicilar(kullaniciTipleri.Diyetisyen).ToArray();
                    break;
                case kullaniciTipleri.Hasta:
                    Console.WriteLine("\nHASTALAR:");
                    kullaniciListe = SingletonDB.GetInstance.GetKullanicilar(kullaniciTipleri.Hasta).ToArray();
                    break;
                default:
                    Console.WriteLine("\nADMİNLER:");
                    kullaniciListe = SingletonDB.GetInstance.GetKullanicilar(kullaniciTipleri.Admin).ToArray();
                    break;
            }
            for (int i = 0; i < kullaniciListe.Length; i++)
            {
                Console.Write((i+1) + " - ");
                kullaniciListe[i].BilgiYazdir();
            }
        }
        static public void TipListele(string tip="hastalik")
        {
            string[] listeleme;
            if (tip=="diyet")
            {
                Console.WriteLine("\nDİYET TİPLERİ:\n");
                listeleme = Enum.GetNames(typeof(DiyetTipleri));
            }
            else
            {
                Console.WriteLine("\nHASTALIK ÇEŞİTLERİ:\n");
                listeleme = Enum.GetNames(typeof(Hastaliklar));
            }
            for (int i = 0; i < listeleme.Length; i++)
            {
                Console.WriteLine((i+1).ToString()+" - "+listeleme[i]);
            }
        }

        static public void hastaDiyetDegistir()
        {
            try
            {
                Console.Write("Hasta Seç (No):");
                int index = Convert.ToInt32(Console.ReadLine()) - 1;
                Hasta hastam = (Hasta)SingletonDB.GetInstance.GetKullanicilar(kullaniciTipleri.Hasta).ToArray()[index];
                Console.WriteLine("Mevcut Diyet: " + hastam.DiyetBilgisi());
                TipListele("diyet");

                Console.Write("Diyet Seç (No):");
                index = Convert.ToInt32(Console.ReadLine()) - 1;
                SingletonDB.GetInstance.DiyetAtamaIslemi((DiyetTipleri)(Enum.GetValues(typeof(DiyetTipleri)).GetValue(index)), hastam);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nBaşarısız İşlem : \n" + e.Message);
            }
        }
        static public void HastalikBelirle()
        {
            try
            {
                int index = Convert.ToInt32(Console.ReadLine()) - 1;
                Hasta hastam = (Hasta)SingletonDB.GetInstance.GetKullanicilar(kullaniciTipleri.Hasta).ToArray()[index];
                Console.WriteLine("Mevcut Hastalık: " + hastam.HastalikBilgisi());
                TipListele();

                Console.Write("Hastalik Seç (No):");
                index = Convert.ToInt32(Console.ReadLine()) - 1;
                SingletonDB.GetInstance.HastalikAtamaIslemi((Hastaliklar)(Enum.GetValues(typeof(Hastaliklar)).GetValue(index)), hastam);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nBaşarısız İşlem : \n" + e.Message);
            }
        }
        static public void HastaAta()
        {
            try
            {
                Console.Write("Diyetisyen Seç (No):");
                int index = Convert.ToInt32(Console.ReadLine()) - 1;
                Diyetisyen diyetisyen = (Diyetisyen)SingletonDB.GetInstance.GetKullanicilar(kullaniciTipleri.Diyetisyen).ToArray()[index];
                DiyetisyenHastaLisesi(diyetisyen);
                KullaniciListele(kullaniciTipleri.Hasta);
                Console.Write("Hasta Seç (No):");
                index = Convert.ToInt32(Console.ReadLine()) - 1;
                Hasta hastam = (Hasta)SingletonDB.GetInstance.GetKullanicilar(kullaniciTipleri.Hasta).ToArray()[index];
                Console.WriteLine(diyetisyen.HastaAta(hastam).message);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nBaşarısız İşlem : \n" + e.Message);
            }
        }
        static public void DiyetisyenHastaLisesi(Diyetisyen diyetisyen)
        {
            Console.WriteLine("Diyetisyen "+diyetisyen.KisiBilgi()[1]+" " + diyetisyen.KisiBilgi()[2]+" Hasta Listesi:");
            foreach (Hasta item in diyetisyen.HastalarListesi())
            {
                item.BilgiYazdir();
            }
        }

    }

}