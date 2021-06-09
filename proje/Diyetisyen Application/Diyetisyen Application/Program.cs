using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diyetisyen_Application
{
    class Program
    {
        static User myUser;
        static void Main(string[] args)
        {
            kimsiniz();
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
            Console.WriteLine("SİSTEM GİRİŞİ");
            myUser = girisYap();
            if (myUser.ToString()=="Diyetisyen_Application.Admin")
            {
            gecerliDegerGirAdmin:
                Console.Write("1-Kullanıcıları Listele\n2-Diyetisyen Ekle\n3-Hasta Ata\n4-Ust Menu\n5-Cikis\nSeçim: ");
                adminKontrol = Console.ReadLine();
                if (adminKontrol == "1")
                {
                    KullaniciListele(kullaniciTipleri.Diyetisyen);
                    KullaniciListele(kullaniciTipleri.Hasta);
                }
                else if (adminKontrol == "2")
                {
                    diyetisyenEkle();
                }
                else if (adminKontrol == "3")
                {
                    KullaniciListele(kullaniciTipleri.Diyetisyen);
                    HastaAta();
                }
                else if (adminKontrol == "4")
                {

                }
                else if (adminKontrol == "5")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Lutfen Gecerli Bir Deger Giriniz!!!\a\n");
                }
                    goto gecerliDegerGirAdmin;
            }
            else if (myUser.ToString() == "Diyetisyen_Application.Diyetisyen")
            {
            gecerliDegerGirD:
                string secim = "";
                Console.Write("1-Hastaları Listele\n2-Hasta Ekle \n3-Hastaların Diyetini Değistir\n4-Hasta Raporu\n5-Üst Menu\n6-Çıkış\nSeçim: ");
                secim = Console.ReadLine();

                if (secim == "1")
                {
                    KullaniciListele();
                }
                else if (secim == "2")
                {
                    hastaEkle();
                }
                else if (secim == "3")
                {
                    KullaniciListele();
                    hastaDiyetDegistir();
                }
                else if (secim == "4")
                {
                    KullaniciListele();
                    Raporlama();
                }
                else if (secim == "5")
                {

                } else if (secim == "6")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Lutfen Gecerli Bir Deger Giriniz!!!\a\n");
                }
                goto gecerliDegerGirD;
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
            Console.Write("Hastanın TC Kimlik Numarası: ");
            tcNo = Console.ReadLine();
            Console.Write("Hastanın Adı: ");
            isim = Console.ReadLine();
            Console.Write("Hastanın Soyadı: ");
            soyisim = Console.ReadLine();
            Hasta hasta = new Hasta(tcNo, isim, soyisim);
            TipListele();
            Console.Write("Hastalık Seç (No):");
            int index = int.Parse(Console.ReadLine())-1;
            SingletonDB.GetInstance.HastalikAtamaIslemi((Hastaliklar)(Enum.GetValues(typeof(Hastaliklar)).GetValue(index)), hasta);
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
            else if(tip=="hastalik")
            {
                Console.WriteLine("\nHASTALIK ÇEŞİTLERİ:\n");
                listeleme = Enum.GetNames(typeof(Hastaliklar));
            }
            else
            {
                Console.WriteLine("\nHASTALIK ÇEŞİTLERİ:\n");
                listeleme = Enum.GetNames(typeof(raporTip));
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

                Console.Write("Hastalık Seç (No):");
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
            try
            {
                Console.Write("Hasta Seç (No):");
                int index = Convert.ToInt32(Console.ReadLine()) - 1;
                Hasta hastam = (Hasta)SingletonDB.GetInstance.GetKullanicilar(kullaniciTipleri.Hasta).ToArray()[index];
                TipListele("rapor");

                Console.Write("Rapor Tipi Seç (No):");
                index = Convert.ToInt32(Console.ReadLine()) - 1;
                raporTip tip = index == 1 ? raporTip.HTML : raporTip.Json;


                Console.Write("Format Seç (1/2):");
                index = Convert.ToInt32(Console.ReadLine());
                RaporlamaInfo info = new RaporlamaInfo();
                info.HastaTc = hastam.KisiBilgi()[0];
                info.HastaAdi = hastam.KisiBilgi()[1];
                info.HastaSoyadi = hastam.KisiBilgi()[2];
                info.Hastalik = hastam.HastalikBilgisi();
                info.Diyet = hastam.DiyetBilgisi();

                RaporlamaBuilderBase builder;
                switch (tip)
                {
                    case raporTip.Json:builder= new JsonBasedRaporlamaBuilder(info); 
                        break;
                    case raporTip.HTML:
                        builder = new HTMLBasedRaporlamaBuilder(info);
                        break;
                    default:
                        builder = new JsonBasedRaporlamaBuilder(info);
                        break;
                }
                
                RaporlamaManager raporlamaManager = new RaporlamaManager(builder);
                string str="";
                if (index==1)
                {
                    str= raporlamaManager.Build();
                }
                else
                {
                    str=raporlamaManager.BuildUpsideDown();
                }
                 
                Console.WriteLine(str+"\n");
                returnValue temp= SingletonDB.GetInstance.RaporOlustur(tip,str);
                if (!temp.state)
                {
                    Console.WriteLine("\nBaşarısız İşlem : \n" + temp.message);
                }
                else
                {
                    Console.WriteLine("\nRapor Dosyası Oluşturuldu (D:/rapor) \n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nBaşarısız İşlem : \n" + e.Message);
            }

        }
    }
}