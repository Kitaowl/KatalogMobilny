using System;
using System.Collections.Generic;
using System.Text;
//to trzeba dostosować do namespace projektu, w którym będziecie tworzyć klasę Produkt
namespace KatalogMobilny
{
    internal class Produkt
    {
        private string _nazwa;
        public string Nazwa
        {
            get { return _nazwa; }
            set
            {
                if (value == String.Empty || value == null)
                {
                    _nazwa = "Brak nazwy";
                    throw new ArgumentException("Nazwa nie może być pusta.");
                }
                else
                {
                    _nazwa = value;
                }
            }
        }
        private double _cena;
        public double Cena
        {
            get { return _cena; }
            set
            {
                if (value < 0)
                {
                    _cena = 0;
                    throw new ArgumentException("Cena nie może być ujemna.");
                }
                else
                {
                    _cena = value;
                }
            }
        }
        public int MinimalnyStan { get; set; }

        public string Kategoria { get; set; }
        public int Ilosc { get; private set; }

        public double WartoscMagazynu
        {
            get { return Cena * Ilosc; }
        }

        public Produkt(string nazwa, double cena, string kategoria, int ilosc)
        {
            Nazwa = nazwa;
            Cena = cena;
            Kategoria = kategoria;
            Ilosc = ilosc;
            MinimalnyStan = 1;
        }
        public Produkt(string nazwa)
        {
            Nazwa = nazwa;
            Cena = 0;
            Kategoria = "Brak kategorii";
            Ilosc = 0;
            MinimalnyStan = 1;
        }
        public void WypiszProdukt()
        {
            Console.WriteLine($"Nazwa: {Nazwa,-15}| Cena: {Cena,10:f2} zł | " +
                $"Kategoria: {Kategoria} | Ilość: {Ilosc,5} | Wartość magazynu: {WartoscMagazynu,10:f2} zł");
        }
        public override string ToString()
        {
            return $"Nazwa: {Nazwa,-15}| Cena: {Cena,10:f2} zł | " +
                $"Kategoria: {Kategoria} | Ilość: {Ilosc,5} | Wartość magazynu: {WartoscMagazynu,10:f2} zł";
        }
        public static double ObliczWartoscMagazynu(Produkt[] produkty)
        {
            double suma = 0; // pusty licznik na sume
            foreach (Produkt produkt in produkty)
            {
                suma += produkt.WartoscMagazynu;
            }
            return suma;
        }
        public static double ObliczWartoscMagazynu(List<Produkt> produkty)
        {
            return produkty.Sum(p => p.WartoscMagazynu);
        }
        public bool CzyMoznaZamowic()
        {
            return Ilosc > MinimalnyStan;
        }
        public void Sprzedaj()
        {
            if (CzyMoznaZamowic())
            {
                Ilosc--;
                Console.WriteLine($"Sprzedano produkt: {Nazwa}. Pozostało na stanie: {Ilosc}");
            }
            else
            {
                Console.WriteLine($"Nie można sprzedać produktu: {Nazwa}. Brak na stanie.");
            }
        }
        public static Produkt ZnajdzPoNazwie(Produkt[] produkty, string nazwa)
        {
            foreach (var produkt in produkty)
            {
                if (produkt.Nazwa == nazwa)
                {
                    return produkt;
                }
            }
            return null;
        }
        public static Produkt ZnajdzPoNazwie(List<Produkt> produkty, string nazwa)
        {
            return produkty.FirstOrDefault(p => p.Nazwa.Contains(nazwa, StringComparison.OrdinalIgnoreCase));
        }
    }
}