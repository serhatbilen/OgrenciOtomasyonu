using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciOtomasyonu
{
	internal class Program
	{
		static void Main(string[] args)
		{
			ConsoleKey cevap;
			do
			{
				Console.Clear();
				Console.WriteLine("ÖĞRENCİ KAYIT PROGRAMI");
				Console.WriteLine("----------------------");
				Console.WriteLine("1- Öğrenci Ekle");
				Console.WriteLine("2- Öğrencileri Listele");
				Console.WriteLine("3- Öğrenci Sil");
				Console.WriteLine("4- Öğrencilerin Genel Not Ortalaması");
				Console.WriteLine("5- Öğrencilerin Yaş Ortalaması");
				Console.WriteLine("6- Toplam Öğrenci Sayısı");
				Console.WriteLine("0- Çıkış");

				Console.WriteLine();
				Console.Write("Hangi işlemi yapmak istersiniz? ");
				cevap = Console.ReadKey().Key;
				Menu.Islemler(cevap);
			} while (cevap != ConsoleKey.NumPad0 && cevap != ConsoleKey.D0);

			Console.WriteLine();
			Console.WriteLine("Programı kullandığınız için teşekkür ederiz");
			Console.WriteLine("Programı Kapatmak için bir tuşa basınız");

			Console.ReadKey();
		}
	}
}
