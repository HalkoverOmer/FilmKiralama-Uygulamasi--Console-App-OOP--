using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using static FilmKiralamaYazilimi.Program;

namespace FilmKiralamaYazilimi
{
    internal class Program
    {

        static void SonSatirSil()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write("                                                                                                              ");
            Console.SetCursorPosition(0, Console.CursorTop - 0);
        }

        static DateTime TarihSaatSilici(DateTime date)
        {
            string temp = date.ToString().TrimEnd('0', ':', ' ');
            return DateTime.Parse(temp);
        }

        static List<Musteri> FakeData()
        {
            List<Musteri> musteriler = new List<Musteri>();
            string[] adlar = { "Ali", "Suat", "Kerim", "Sedef", "Banu" };
            string[] soyadlar = { "Duran", "Keser", "Okur", "Yılmaz", "Ateş" };
            long[] telefonlar = { 05511231212, 05451478956, 05324793218, 05384613259, 05449613248 };
            int[] gunVeAy = { 12, 01, 09, 11, 04 };
            int[] yillar = { 1997, 1987, 2002, 1976, 2001 };

            for (int i = 0; i < adlar.Length; i++)
            {
                Musteri musteri = new Musteri
                {
                    Ad = adlar[i],
                    Soyad = soyadlar[i],
                    Telefon = telefonlar[i],
                    DogumTarihi = new DateTime(yillar[i], gunVeAy[i], gunVeAy[i])
                };

                musteriler.Add(musteri);
            }

            return musteriler;
        }

        static List<Film> FakeDataFilmler()
        {
            List<Film> filmler = new List<Film>();
            string[] filmAdlari = { "Savaşçı", "Av", "Kraliyet", "Scarface", "GodFather", "Fight Club", "It", "Conjuring" };
            string[] kategoriler = { "Aksiyon", "Macera", "Dram", "Mafia", "Mafia", "Gerilim", "Korku", "Korku" };
            int[] sure = { 121, 110, 102, 150, 154, 168, 114, 118 };
            int[] gunlukKira = { 5, 10, 7, 15, 24, 18, 4, 9 };
            int[] gunVeAy = { 12, 01, 09, 11, 04, 07, 10, 02 };
            int[] yillar = { 1997, 1987, 2002, 1976, 2001, 1978, 1964, 1981 };

            for (int i = 0; i < filmAdlari.Length; i++)
            {
                Film film = new Film
                {
                    FilmAd = filmAdlari[i],
                    Kategori = kategoriler[i],
                    Sure = sure[i],
                    GunlukKiraBedeli = gunlukKira[i],
                    CikisTarihi = new DateTime(yillar[i], gunVeAy.Length - i, gunVeAy[i]),
                    VizyondaMi = true
                };
                filmler.Add(film);
            }
            return filmler;
        }


        static int gunKira;
        static int ciro;

        static void Main(string[] args)
        {
            int kontrol, secim;
            bool fakeDataKontrol = true;
            List<string> logs = new List<string>();
            List<Musteri> musteriler = new List<Musteri>();
            List<Film> filmler = new List<Film>();

            do
            {
                Console.Clear();
                Console.Write("---- Film Kiralama Programı ----\n\n" +
                          "[1] - Yeni Müşteri Tanımlama\n" +
                          "[2] - Yeni Film Tanımlama\n" +
                          "[3] - Film Kiralama\n" +
                          "[4] - Kiralama Kayıtları\n" +
                          "[5] - Genel Kiralama Kazancı\n" +
                          "[6] - Doğum Günü Yaklaşanlar\n" +
                          "[7] - Örnek Veri Yükle\n" +
                          "[0] - Çıkış\n\n" +
                          "(-) - Seçiminizi giriniz : ");
                secim = int.Parse(Console.ReadLine());

                
                if (secim == 1)
                {
                    Console.Clear();
                    Console.Write("---- Film Kiralama Programı ----\n\n");

                    Musteri musteri = new Musteri();

                    Console.Write("Müşteri adı : ");
                    musteri.Ad = Console.ReadLine();
                    Console.Write("Müşteri soyadı : ");
                    musteri.Soyad = Console.ReadLine();

                    Console.Write("Müşteri telefon No : ");
                    musteri.Telefon = long.Parse(Console.ReadLine());

                    for (int i = 0; i < musteriler.Count; i++)
                    {
                        if (musteri.Telefon == musteriler[i].Telefon)
                        {
                            SonSatirSil();
                            Console.Write("Telefon numarası mevcut !!, farklı bir numara giriniz : ");
                            musteri.Telefon = long.Parse(Console.ReadLine());
                            i--;
                        }

                        else
                        {
                            SonSatirSil();
                            Console.Write($"Müşteri telefon no : {musteri.Telefon}\n");
                        }
                    }

                    Console.Write("Müşteri doğum tarihi (Örnek : 01.01.1990) : ");
                    musteri.DogumTarihi = TarihSaatSilici(DateTime.Parse(Console.ReadLine()));

                    musteriler.Add(musteri);

                    Console.WriteLine("Müşteri ekleme işlemi başaryıla tamamlandı, menüye dönmek için herhangi bir tuşa basın...");
                    Console.ReadKey();

                }

                else if (secim == 2)
                {

                    do
                    {
                        Console.Clear();
                        Console.Write("---- Film Kiralama Programı ----\n\n");

                        Film film = new Film();

                        Console.Write("Film adı : ");
                        film.FilmAd = Console.ReadLine();

                        if (filmler.Count > 0)
                        {
                            for (int i = 0; i < musteriler.Count; i++)
                            {
                                if (film.FilmAd.ToString() == filmler[i].FilmAd)
                                {
                                    SonSatirSil();
                                    Console.Write("\nFilm zaten mevcut !!, ekleme işlemi iptal edildi");
                                    film = new Film();
                                    break;
                                }
                            }
                        }

                        Console.Write("Filmin kategorisi : ");
                        film.Kategori = Console.ReadLine();
                        Console.Write("Filmin süresi : ");
                        film.Sure = int.Parse(Console.ReadLine());
                        Console.Write("Filmin çıkış tarihi (Örnek : 01.01.1990) : ");
                        film.CikisTarihi = TarihSaatSilici(DateTime.Parse(Console.ReadLine()));

                        Console.Write("Film vizyonda mı [E/H] : ");
                        string vizyon = Console.ReadLine();

                        if (vizyon.ToLower() == "e")
                        {
                            film.VizyondaMi = true;
                        }
                        else
                        {
                            film.VizyondaMi = false;
                        }

                        Console.Write("Günlük kiralama bedeli : ");
                        film.GunlukKiraBedeli = decimal.Parse(Console.ReadLine());

                        filmler.Add(film);

                        Console.WriteLine("Film ekleme işlemi başaryıla tamamlandı, menüye dönmek için herhangi bir tuşa basın...");
                        Console.ReadKey();

                    } while (false);

                }

                else if (secim == 3)
                {
                    Console.Clear();
                    Console.Write("---- Film Kiralama Programı ----\n\n");

                    if (musteriler.Count <= 0)
                    {
                        Console.Write("Kayıtlı müşteri yok, ana menüye dönmek bir tuşa basın...");
                        Console.ReadKey();
                    }

                    else if (filmler.Count <= 0)
                    {
                        Console.Write("Kayıtlı film yok, ana menüye dönmek bir tuşa basın...");
                        Console.ReadKey();
                    }

                    else
                    {
                        for (int j = 0; j < musteriler.Count; j++)
                        {
                            Console.WriteLine($"[{j}] - {musteriler[j].Ad} {musteriler[j].Soyad} - {musteriler[j].Telefon}");
                        }

                        Console.WriteLine();

                        for (int k = 0; k < filmler.Count; k++)
                        {
                            Console.WriteLine($"[{k}] - {filmler[k].FilmAd} {filmler[k].GunlukKiraBedeli} TL / gün");
                        }

                        Console.Write("\nMüşteri numarasını giriniz : ");
                        int musteriNo = int.Parse(Console.ReadLine());
                        Console.Write("Film numarasını giriniz : ");
                        int filmNo = int.Parse(Console.ReadLine());
                        Console.Write("Kaç gün kiralanacak : ");
                        gunKira = int.Parse(Console.ReadLine());

                        Console.Write("\nKiramala Bilgileri ::\n");
                        string log = $"Müşteri : {musteriler[musteriNo].Ad} {musteriler[musteriNo].Soyad} - Film : {filmler[filmNo].FilmAd} - {gunKira * filmler[filmNo].GunlukKiraBedeli}";
                        logs.Add(log);
                        Console.WriteLine();
                        Console.WriteLine($"{log} TL");

                        Console.Write("\nKiralama işlemi tamamlandı, menüye dönmek için herhangi bir tuşa basınız...");
                        Console.ReadKey();
                    }

                }

                else if (secim == 4)
                {
                    Console.Clear();
                    Console.Write("---- Film Kiralama Programı ----\n\n" +
                                  "Kiralama kayıtları ::\n\n");

                    if (musteriler.Count <= 0)
                    {
                        Console.Write("Kayıtlı müşteri yok, ana menüye dönmek bir tuşa basın...");
                        Console.ReadKey();
                    }

                    else if (logs.Count > 0)
                    {
                        for (int l = 0; l < logs.Count; l++)
                        {
                            Console.WriteLine($"{logs[l]} TL - Teslim Tarihi : {DateTime.Now.AddDays(gunKira)}");
                        }
                        Console.WriteLine("Menüye dönmek için herhangi bir tuşa basın...");
                        Console.ReadKey();
                    }
                }

                else if (secim == 5)
                {
                    Console.Clear();
                    Console.Write("---- Film Kiralama Programı ----\n\n");

                    if (logs.Count > 0)
                    {
                        foreach (string logSplit in logs)
                        {
                            string[] kayitParcali = logSplit.Split('-');
                            ciro += int.Parse(kayitParcali[2]);
                        }

                        Console.Write($"Toplam kiralama cirosu : {ciro} TL");
                        Console.Write("\nAna menüye dönmek için bir tuşa basınız...");
                        Console.ReadKey();
                    }

                    else
                    {
                        Console.Write("Henüz kiralanan film yok, ana menüye dönmek için bir tuşa basınız...");
                        Console.ReadKey();
                    }


                }

                else if (secim == 6)
                {
                    Console.Clear();
                    Console.Write("---- Film Kiralama Programı ----\n\n");

                    if (musteriler.Count > 0)
                    {
                        DateTime bugun = DateTime.Now;

                        foreach (Musteri musteri in musteriler)
                        {
                            if ((musteri.DogumTarihi.Month == bugun.Month) && ((int)(bugun.Day - musteri.DogumTarihi.Day) > 0 && (int)(bugun.Day - musteri.DogumTarihi.Day) <= 10))
                            {
                                Console.WriteLine($"- {musteri.Ad} {musteri.Soyad} {musteri.DogumTarihi} Kalan gün : {(int)(bugun.Day - musteri.DogumTarihi.Day)}");
                            }
                        }
                        Console.WriteLine("Ana menüye dönmek için herhangi bir tuşa basın...");
                        Console.ReadKey();
                    }

                    else
                    {
                        Console.WriteLine("Henüz kayıtlı bir müşteri yok, ana menüye dönmek için herhangi bir tuşa basınız...");
                        Console.ReadKey();
                    }
                }

                else if (secim == 7)
                {
                    if (fakeDataKontrol)
                    {
                        List<Musteri> fakeMusteriler = FakeData();
                        List<Film> fakeFilmler = FakeDataFilmler();

                        for (int z = 0; z < fakeMusteriler.Count; z++)
                        {
                            musteriler.Add(fakeMusteriler[z]);

                            if (z == 0)
                            {
                                for (int i = 0; i < fakeFilmler.Count; i++)
                                {
                                    filmler.Add(fakeFilmler[i]);
                                }
                            }
                        }
                        fakeDataKontrol = false;
                    }
                    Console.Clear();
                    Console.WriteLine("Örnek veriler başarıyla üretildi, ana menüye dönmek için bir tuşa basın...");
                    Console.ReadKey();

                }

            } while (secim != 0);


        }

        public class Musteri
        {
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public long Telefon { get; set; }
            public DateTime DogumTarihi { get; set; }

        }

        public class Film
        {
            public string FilmAd { get; set; }
            public string Kategori { get; set; }
            public int Sure { get; set; }
            public DateTime CikisTarihi { get; set; }
            public bool VizyondaMi { get; set; }
            public decimal GunlukKiraBedeli { get; set; }

        }
    }
}