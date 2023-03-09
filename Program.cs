using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTelefonRehberiUygulamasi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            İslemler islem = new İslemler();
            bool durum = true;

            while (durum)
            {
                Console.WriteLine("TELEFON REHBERİ");
                Console.WriteLine("1 - Telefon Numarası Kaydet");
                Console.WriteLine("2 - Telefon Numarası Sil");
                Console.WriteLine("3 - Telefon Numarası Güncelle");
                Console.WriteLine("4 - Rehberi Listele");
                Console.WriteLine("5 - Rehberde Arama Yap");
                Console.WriteLine("6 - Çıkış");


                int secim = Convert.ToInt32(Console.ReadLine());
                switch (secim)
                {
                    case 1:
                        islem.Ekle();
                        Console.WriteLine("----------------------");
                        break;
                    case 2:
                        islem.Sil();
                        Console.WriteLine("----------------------");
                        break;
                    case 3:
                        islem.güncelle();
                        Console.WriteLine("----------------------");
                        break;
                    case 4:
                        islem.listele();
                        Console.WriteLine("----------------------");
                        break;
                    case 5:
                        islem.aramaYapma();
                        Console.WriteLine("----------------------");
                        break;
                    case 6:
                        durum = false;
                        break;

                }
            }
        }
    }

    public class Rehber
    {
        public string ad;
        public string soyad;
        public string numara;

        public Rehber() { }
        public Rehber(string ad, string soyad, string numara)
        {
            this.ad = ad;
            this.soyad = soyad;
            this.numara = numara;
        }

        /*public string getAd() { return ad;}
        public void setAd(string ad) { this.ad = ad;}

        public string getSoyad() { return soyad; }
        public void setSoyad(string soyad) { this.soyad = soyad; }

        public string getNumara() { return numara; }
        public void setNumara(string numara) { this.numara = numara; }*/

    }

    public class İslemler
    {
        List<Rehber> kisiler = new List<Rehber>();
        
        public İslemler()
        {
            kisiler.Add(new Rehber("A1", "A2", "0536897415"));
            kisiler.Add(new Rehber("B1", "B2", "0789451425"));
            kisiler.Add(new Rehber("C1", "C2", "0589471475"));
            kisiler.Add(new Rehber("D1", "D2", "0536147258"));
            kisiler.Add(new Rehber("E1", "E2", "0478253673"));
           
        }

        public void Ekle()
        {
            Console.Write("Ad:"); string name = Console.ReadLine();
            Console.Write("Soyad:"); string surName = Console.ReadLine();
            Console.Write("Numara:"); string number = Console.ReadLine();


            Rehber yeniKisi = new Rehber(name, surName, number);
            kisiler.Add(yeniKisi);
            Console.WriteLine(name + surName + "kişisi rehbere eklenmiştir.");
        }

        public void Sil()
        {
            Console.WriteLine("Ad ve Soyad Giriniz:"); 
            string silinecek = Console.ReadLine();

            for(int i=0; i<kisiler.Count; i++)
            {
                if (kisiler[i].ad.Equals(silinecek) || kisiler[i].soyad.Equals(silinecek))
                {
                    Console.WriteLine(kisiler[i].ad + "adlı kişi rehberinizden silinmiştir.");
                    kisiler.RemoveAt(i);
                    break;
                }

                if(i == kisiler.Count - 1)
                {
                    Console.WriteLine("Rehberde böyle kişi kayıt yoktur.");
                }
            }

        }

        public void güncelle()
        {
            Console.WriteLine("Ad ve Soyad Giriniz:");
            string güncellenecek = Console.ReadLine();

            for(int i=0; i<kisiler.Count; i++)
            {
                if (kisiler[i].ad.Equals(güncellenecek) || kisiler[i].soyad.Equals(güncellenecek))
                {
                    Console.WriteLine("1 - Adı Güncelle\n 2 - Soyadı Güncelle\n 3 - Numarayı Güncelle");
                    int secim = Convert.ToInt32(Console.ReadLine());

                    if(secim == 1)
                    {
                        Console.Write("Değiştirmek istediğiniz adı giriniz:");
                        string yeniAd = Console.ReadLine();
                        kisiler[i].ad = yeniAd;
                        break;
                    }
                    else if(secim == 2)
                    {
                        Console.Write("Değiştirmek istediğiniz soyadı giriniz:");
                        string yeniSoyad = Console.ReadLine();
                        kisiler[i].soyad = yeniSoyad;
                        break;
                    }
                    else if(secim == 3)
                    {
                        Console.Write("Değiştirmek istediğiniz numarayı giriniz:");
                        string yeniNumara = Console.ReadLine();
                        kisiler[i].numara = yeniNumara;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Lütfen doğru bir seçim yapınız.");
                        break;
                    }
                }
                if(i== kisiler.Count - 1)
                {
                    Console.WriteLine("Aranan kişi kayıtlı değil.");
                }
            }
        }

        public void aramaYapma()
        {
            Console.WriteLine("Lütfen aramak istediğiniz kişinin adını, soyadını ya da numarasını giriniz:");
            string aranan = Console.ReadLine();

            for(int i=0; i<kisiler.Count; i++)
            {
                if (kisiler[i].ad.Equals(aranan) || kisiler[i].soyad.Equals(aranan) || kisiler[i].numara.Equals(aranan))
                {
                    Console.WriteLine("Girilen ad/soyad/numara rehberde mevcut.");
                }
                if(i == kisiler.Count - 1)
                {
                    Console.WriteLine("Girilen ad/soyad/numara rehberde mevcut değil.");

                }
            }
        }

        public void listele()
        {
            Console.WriteLine("1 - A'dan Z'ye listelem\n 2 - Z'den A'ya listeleme");
            int secim = Convert.ToInt32(Console.ReadLine());

            if(secim == 1)
            {
                var az = kisiler.OrderBy(value => value.ad); //az = a'dan z'ye
                foreach(var rehber in az)
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("Kişi adı:" + rehber.ad);
                    Console.WriteLine("Kişi soyadı: " + rehber.soyad);
                    Console.WriteLine("Kişi numarası: " + rehber.numara);
                    Console.WriteLine("---------------------------------");
                }
            }
            else if(secim == 2)
            { 
                var za = kisiler.OrderBy(value => value.ad).Reverse(); //za = z'Den a'ya
                foreach (var rehber in za)
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("Kişi adı:" + rehber.ad);
                    Console.WriteLine("Kişi soyadı: " + rehber.soyad);
                    Console.WriteLine("Kişi numarası: " + rehber.numara);
                    Console.WriteLine("---------------------------------");
                }
            }
        }
    }
  
}
