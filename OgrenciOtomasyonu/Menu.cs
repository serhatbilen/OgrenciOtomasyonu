using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciOtomasyonu
{
	public static class Menu
	{
		static List<Ogrenci> ogrenciler = new List<Ogrenci>();
		public static void Islemler(ConsoleKey key)
		{
			bool varMi = Metodlar.ListedeEleman(ogrenciler);
			Console.Clear();
			if (varMi || key == ConsoleKey.D1 || key == ConsoleKey.NumPad1 || key == ConsoleKey.D0 || key == ConsoleKey.NumPad0)
			{
				switch (key)
				{
					case ConsoleKey.NumPad1:
					case ConsoleKey.D1:
						Ekle("ÖĞRENCİ EKLE");
						break;
					case ConsoleKey.NumPad2:
					case ConsoleKey.D2:
						Listele("ÖĞRENCİ LİSTELE");
						break;
					case ConsoleKey.NumPad3:
					case ConsoleKey.D3:
						Sil("ÖĞRENCİ SİL");
						break;
					case ConsoleKey.NumPad4:
					case ConsoleKey.D4:
						Ortalama("ÖĞRENCİLERİN GENEL NOT ORTALAMASI");
						break;
					case ConsoleKey.NumPad5:
					case ConsoleKey.D5:
						YasOrtalamasi("ÖĞRENCİLERİN YAŞ ORTALAMASI");
						break;
					case ConsoleKey.NumPad6:
					case ConsoleKey.D6:
						BaslikYazdir("TOPLAM ÖĞRENCİ SAYISI");
						AnaMenuyeDon(string.Format("Toplam {0} adet öğrenci kayıtlıdır", ogrenciler.Count));
						break;
				}
			}
			else
			{
				AnaMenuyeDon("Listenizde öğrenci mevcut değil");
			}
		}

		private static void YasOrtalamasi(string v)
		{
			BaslikYazdir(v);

			int toplamYas = 0;
			foreach (var ogrenci in ogrenciler)
			{
				toplamYas += ogrenci.Yas;
			}
			double yasOrtalamasi = (double)toplamYas / ogrenciler.Count;

			AnaMenuyeDon(string.Format("Toplam {0} öğrencinin yaş ortalaması: {1}", ogrenciler.Count, yasOrtalamasi));
		}

		private static void Ortalama(string v)
		{
			BaslikYazdir(v);

			double genelToplam = 0;
			foreach (var ogrenci in ogrenciler)
			{
				genelToplam += ogrenci.Ortalama;
			}
			double genelOrtalama = genelToplam / ogrenciler.Count;
			AnaMenuyeDon(string.Format("Toplam {0} Öğrencinin genel not ortalaması {1}", ogrenciler.Count, genelOrtalama));
		}

		private static void Sil(string v)
		{
			BaslikYazdir(v);
			for (int i = 0; i < ogrenciler.Count; i++)
			{
				ogrenciler[i].Yazdir(i + 1);
			}
			Console.WriteLine();
			int siraNo = Metodlar.GetInt("Silmek istediğiniz öğrencinin sıra numarasını giriniz.\nAna menüye dönmek için 0' a basınız: ", 0, ogrenciler.Count);
			if (siraNo == 0)
			{
				AnaMenuyeDon("Silme işlemi iptal edildi");
			}
			else
			{
				int indexNo = siraNo - 1;
				Console.Write(ogrenciler[indexNo].TamAd + " öğrencisini silmek istediğinize emin misiniz?(e): ");
				if (Console.ReadKey().Key == ConsoleKey.E)
				{
					string silinen = ogrenciler[indexNo].TamAd;
					ogrenciler.RemoveAt(indexNo);
					AnaMenuyeDon(string.Format("{0} isimli öğrenci silinmiştir", silinen));
				}
				else
				{
					AnaMenuyeDon("Silme işlemi iptal edildi");
				}
			}


		}

		private static void Listele(string v)
		{
			BaslikYazdir(v);
			for (int i = 0; i < ogrenciler.Count; i++)
			{
				ogrenciler[i].Yazdir(i + 1);
			}
			AnaMenuyeDon(string.Format("Toplam {0} adet öğrenci listelenmiştir", ogrenciler.Count));
		}

		private static void Ekle(string v)
		{
			BaslikYazdir(v);
			Ogrenci o = new Ogrenci();
			o.Ad = Metodlar.GetString("Adı Giriniz: ", 2, 20);
			o.Soyad = Metodlar.GetString("Soyadı Giriniz: ", 2, 15);
			o.N1 = Metodlar.GetDouble("1. Not: ", 0, 100);
			o.N2 = Metodlar.GetDouble("2. Not: ", 0, 100);
			o.DogumTarihi = Metodlar.GetDateTime("Doğum Tarihi: ", 1998, 2014);
			ogrenciler.Add(o);
			AnaMenuyeDon(string.Format("{0} öğrencisi listeye başarı ile eklendi", o.TamAd));
		}

		private static void AnaMenuyeDon(string v)
		{
			Console.WriteLine();
			Console.WriteLine(v);
			Console.WriteLine("Ana menüye dönmek için bir tuşa basınız");
			Console.ReadKey();
		}

		private static void BaslikYazdir(string v)
		{
			Console.WriteLine(v);
			Console.WriteLine("------------------------");
			Console.WriteLine();
		}
	}
}
