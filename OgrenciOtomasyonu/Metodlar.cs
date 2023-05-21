using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciOtomasyonu
{
	public static class Metodlar
	{
		public static string GetString(string metin, int min = 1, int max = 500)
		{
			string txt = string.Empty;
			bool hata = false;
			do
			{
				Console.Write(metin);
				txt = Console.ReadLine();
				if (string.IsNullOrEmpty(txt))
				{
					Console.WriteLine("Boş bir değer giremezsiniz.");
					hata = true;
				}
				else
				{
					if (txt.Length < min || txt.Length > max)
					{
						Console.WriteLine("Lütfen min. {0}, max.{1} uzunlukta metin giriniz", min, max);
						hata = true;
					}
					else if (!IsOnlyLetters(txt))
					{
						Console.WriteLine("Lütfen sadece harf kullanın.");
						hata = true;
					}
					else
					{
						hata = false;
					}
				}
			} while (hata);
			return txt;
		}

		public static bool IsOnlyLetters(string text)
		{
			foreach (var character in text)
			{
				if (!char.IsLetter(character))
				{
					return false;
				}
			}
			return true;
		}

		internal static int GetInt(string metin, int min = int.MinValue, int max = int.MaxValue)
		{
			int sayi = 0;
			bool hata = false;
			do
			{
				Console.Write(metin);
				try
				{
					sayi = int.Parse(Console.ReadLine());
					if (sayi >= min && sayi <= max)
					{
						hata = false;
					}
					else
					{
						Console.WriteLine("Lütfen {0} ile {1} arasında bir değer giriniz", min, max);
						hata = true;
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
					hata = true;
				}
			} while (hata);
			return sayi;
		}

		public static DateTime GetDateTime(string metin, int minYear, int maxYear)
		{
			DateTime date = DateTime.Now;
			bool hata = false;
			do
			{
				Console.Write(metin);
				try
				{
					date = DateTime.Parse(Console.ReadLine());
					if (date.Year <= maxYear && date.Year >= minYear)
					{
						hata = false;
					}
					else
					{
						Console.WriteLine("Lütfen {0} ile {1} yılları arasında bir tarih giriniz", minYear, maxYear);
						hata = true;
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
					hata = true;
				}
			} while (hata);
			return date;
		}

		public static double GetDouble(string metin, double min = Double.MinValue, double max = Double.MaxValue)
		{
			double sayi = 0;
			bool hata = false;
			do
			{
				Console.Write(metin);
				try
				{
					sayi = double.Parse(Console.ReadLine());
					if (sayi >= min && sayi <= max)
					{
						hata = false;
					}
					else
					{
						Console.WriteLine("Lütfen min.{0}, max.{1} aralığında değer giriniz");
						hata = true;
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
					hata = true;
				}
			} while (hata);
			return sayi;
		}

		internal static bool ListedeEleman(List<Ogrenci> ogrenci)
		{
			if (ogrenci.Count > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

	}
}
