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
            string kimsin;
            gecerliDegerGir:
            Console.WriteLine("Kim Giris Yapiyor(Admin-A, Diyetisyen-D)");
            kimsin = Console.ReadLine();
            if (kimsin == "A" || kimsin == "a")
            {
                Console.WriteLine("Yeni Diyetisyen Ekle");

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
    }

}
