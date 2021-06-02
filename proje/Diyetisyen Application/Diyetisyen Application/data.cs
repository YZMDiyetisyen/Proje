using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

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

			Hasta hasta = new Hasta("222", "Ali", "Atay","123");
			Hasta hasta2 = new Hasta("222", "Mahmut", "Atay", "123");

			DiyetAtamaIslemi(DiyetTipleri.GlutenFree, hasta);
			HastalikAtamaIslemi(Hastaliklar.Colyak,hasta);

			Kullanicilar.Add(hasta);
			Kullanicilar.Add(hasta2);

			//diyetisyen.HastaAta(hasta);
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
		public returnValue DiyetAtamaIslemi(DiyetTipleri tip, Hasta hastam)
		{
			returnValue temp = new returnValue();
            try
			{
				DiyetFactory diyetFactory = new DiyetFactory();
				IDiyet diyet = diyetFactory.CreateDiyetFactory(tip);
				temp=diyet.DiyetAta(hastam);
			}
            catch (Exception e)
            {
				temp.state = false;
				temp.message = e.Message;
            }
			return temp;
		}
		public returnValue HastalikAtamaIslemi(Hastaliklar hastalikCesidi, Hasta hastam)
		{
			returnValue temp = new returnValue();
			try
			{
				HastalikFactory hastalikFactory = new HastalikFactory();
				IHastalik hastalik = hastalikFactory.CreateHastalikFactory(hastalikCesidi);
				temp = hastalik.HastalikAta(hastam);
			}
			catch (Exception e)
			{
				temp.state = false;
				temp.message = e.Message;
			}
			return temp;
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
		public returnValue AddHastaToDiyetisyen(Hasta hasta,Diyetisyen diyetisyen)
		{
			returnValue temp = new returnValue(); 
			try{
				if (diyetisyen != null&&hasta!=null)
				{
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
	}
}