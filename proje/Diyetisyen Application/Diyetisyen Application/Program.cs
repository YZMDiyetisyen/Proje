using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Diyetisyen_Application
{
    class Program
    {
        static User myUser;
        static void Main(string[] args)
        {
            Diyetisyen diyetisyen = new Diyetisyen("1321321321","sezer","yıldırım","132");
            //kimsiniz();
            myUser=girisYap();
            Raporlama();
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
            
            User myUser = null;
            while (myUser == null)
            {
                 string tc = "", sifre = "";
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
            string  adminKontrol;
            gecerliDegerGir:
            Console.WriteLine("Giriş Yapiniz: ");
            myUser = girisYap();
            if (myUser.ToString()=="Diyetisyen_Application.Admin")
            {
            gecerliDegerGirAdmin:
                Console.WriteLine("1-Diyetisyen Ekle\n2-Hasta Ata\n3-Ust Menu\n4-Cikis");
                adminKontrol = Console.ReadLine();

                if (adminKontrol == "1")
                {
                    diyetisyenEkle();
                    goto gecerliDegerGirAdmin;

                }else if (adminKontrol == "2")
                {
                    KullaniciListele(kullaniciTipleri.Diyetisyen);
                    HastaAta();
                    goto gecerliDegerGirAdmin;
                }
                else if (adminKontrol == "3")
                {
                    goto gecerliDegerGir;

                }
                else if (adminKontrol == "4")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Lutfen Gecerli Bir Deger Giriniz!!!\a\n");
                    goto gecerliDegerGirAdmin;
                }
            }
            else if (myUser.ToString() == "Diyetisyen_Application.Diyetisyen")
            {
            gecerliDegerGirD:
                KullaniciListele();
                string secim = "";
                Console.WriteLine("1-Hasta Ekle\n2-Hastalarin Diyetini Degistir\n3-Hasta Raporu\n4-Ust Menu\n5-Cikis");
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
                    Raporlama();
                    goto gecerliDegerGirD;
                }
                else if (secim == "4")
                {
                    goto gecerliDegerGir;

                } else if (secim == "5")
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
        static public User[] KullaniciListele(kullaniciTipleri tip=kullaniciTipleri.Hasta,bool write=true)
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
            if (write)
            {
                for (int i = 0; i < kullaniciListe.Length; i++)
                {
                    Console.Write((i + 1) + " - ");
                    kullaniciListe[i].BilgiYazdir();
                }
            }
            return kullaniciListe;
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

        static public void Raporlama()
        {
            List<object> asd = new List<object>();
            foreach (Hasta item in ((Diyetisyen)myUser).HastalarListesi().ToArray())
            {
                var myData = new {
                    TC = (item.KisiBilgi())[0],
                    Isim = (item.KisiBilgi())[1],
                    Soyisim = (item.KisiBilgi())[2],
                    Diyet = item.DiyetBilgisi(),
                    Hastalik = item.HastalikBilgisi()
                };
                asd.Add(myData);

            }
            string json = JsonConvert.SerializeObject(asd);
            Console.WriteLine(json);
            Console.WriteLine("---");


        }


    }

}