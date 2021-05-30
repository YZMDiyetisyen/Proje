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

            Diyetisyen diyetisyen = new Diyetisyen("11111", "Sezer", "Yıldırım");
            Hasta hasta = new Hasta("2222", "Ali", "Atay");

            diyetisyen.HastaAta(hasta);

            DiyetAtamaIslemi(DiyetTipleri.DenizUrunleri, hasta);
            kimsiniz();
            Console.Read();
        }
        static public void DiyetAtamaIslemi(DiyetTipleri tip, Hasta hastam)
        {
            DiyetFactory diyetFactory = new DiyetFactory();
            IDiyet diyet = diyetFactory.CreateDiyetFactory(tip);
            diyet.DiyetAta(hastam);
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
                else if(adminKontrol == "2") 
                {
                    goto gecerliDegerGir;

                }else if (adminKontrol == "3")
                {
                    Environment.Exit(0);
                }else
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
            string tcNo, isim, soyisim;
            Console.WriteLine("Diyetisyenin TC Kimlik Numarasi: ");
            tcNo = Console.ReadLine();
            Console.WriteLine("Diyetisyenin Adi: ");
            isim = Console.ReadLine();
            Console.WriteLine("Diyetisyenin Soyadi: ");
            soyisim = Console.ReadLine();
            Diyetisyen diyetisyen = new Diyetisyen(tcNo, isim, soyisim);
            Console.WriteLine(diyetisyen.BilgiYazdir());
        }
    }

}
