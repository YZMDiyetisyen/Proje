using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;

namespace Diyetisyen_Application
{
	public sealed class SingletonDB
	{
		private static SingletonDB instance = null;
		private List<User> Kullanicilar { get; set; }
		public static SingletonDB GetInstance
		{
			get
			{
				if (instance == null)
					instance = new SingletonDB();
				return instance;
			}
		}
		private SingletonDB()
		{
			Kullanicilar = new List<User>();
			
			Admin admin = new Admin("123","SezerAdmin","Yıldırım","123");
			Kullanicilar.Add(admin);

			Diyetisyen diyetisyen = new Diyetisyen("111", "Sezer", "Yıldırım","123");
			Kullanicilar.Add(diyetisyen);

			Hasta hasta = new Hasta("222", "Ali", "Atay");
			Hasta hasta2 = new Hasta("223", "Mahmut", "Atay");

			DiyetAtamaIslemi(DiyetTipleri.GlutenFree, hasta);
			HastalikAtamaIslemi(Hastaliklar.Colyak,hasta);

			Kullanicilar.Add(hasta);
			Kullanicilar.Add(hasta2);

			diyetisyen.HastaAta(hasta);
			diyetisyen.HastaAta(hasta2);
		}
		public List<User> GetKullanicilar()
        {
			return this.Kullanicilar;
		}
		public List<User> GetKullanicilar(kullaniciTipleri tip)
		{
			List<User> users = new List<User>();
			try
			{
				users = this.Kullanicilar.Where(p => p.GetType().Name==Enum.GetName(typeof(kullaniciTipleri),tip)).ToList();
			}
			catch (Exception)
			{

			}
			return users;
		}
		public void DiyetAtamaIslemi(DiyetTipleri tip, Hasta hastam)
		{
			DiyetFactory diyetFactory = new DiyetFactory();
			IDiyet diyet = diyetFactory.CreateDiyetFactory(tip);
			diyet.DiyetAta(hastam);
		}
		public void HastalikAtamaIslemi(Hastaliklar hastalikCesidi, Hasta hastam)
		{
			HastalikFactory hastalikFactory = new HastalikFactory();
			IHastalik hastalik = hastalikFactory.CreateHastalikFactory(hastalikCesidi);
			hastalik.HastalikAta(hastam);
		}
		public User GetKullanici(string tc,string sifre)
        {
			User myUser = null;
            try
            {
				myUser = this.Kullanicilar.Where(p => p.UserCheck(tc, sifre) == true).ToList()[0];
			}
            catch (Exception)
            {

            }
			return myUser;
		}
		public returnValue AddUser(User kullanici)
        {
			returnValue temp = new returnValue();
            try
			{
				if (kullanici != null)
				{
					this.Kullanicilar.Add(kullanici);
				}
			}
            catch (Exception e)
            {
				temp.state = false;
				temp.message = e.Message;
            }
			return temp;
        }
		public returnValue hastaAta(Diyetisyen diyetisyen,Hasta hasta)
		{
			returnValue temp = new returnValue();
			try
			{
				foreach (Diyetisyen item in GetKullanicilar(kullaniciTipleri.Diyetisyen))
				{
					if (diyetisyen != item)
					{
						if (item.HastalarListesi().Contains(hasta))
						{
							item.hastaSevk(hasta);
						}
					}
					diyetisyen.HastaAta(hasta);
				}
			}
			catch (Exception e)
			{
				temp.state = false;
				temp.message = e.Message;
			}
			return temp;
        }
		public returnValue	RaporOlustur(raporTip tip, string RaporMetni)
		{
			returnValue temp = new returnValue();
			try
			{
				string name;
                switch (tip)
                {
                    case raporTip.Json:name = "rapor.json";RaporMetni = "{" + RaporMetni + "}";
                        break;
                    case raporTip.HTML:name = "rapor.html";
                        break;
                    default:name = "rapor.json"; RaporMetni = "{" + RaporMetni + "}";
						break;
                }
                string dosya_yolu = @"D:\"+name;
				FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
				StreamWriter sw = new StreamWriter(fs);
				sw.WriteLine(RaporMetni);
				sw.Flush();
				sw.Close();
				fs.Close();
			}
			catch (Exception e)
			{
				temp.state = false;
				temp.message = e.Message;
			}
			return temp;
		}
	}
}