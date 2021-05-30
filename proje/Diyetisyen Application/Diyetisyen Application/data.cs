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
			Kullanicilar.Add(hasta);
		}
		public List<User> GetKullanicilar()
        {
			return this.Kullanicilar;
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

		public returnValue AddDiyetisyen(Diyetisyen diyetisyen)
        {
			returnValue temp = new returnValue();
            try
			{
				if (diyetisyen != null)
				{
					this.Kullanicilar.Add(diyetisyen);
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