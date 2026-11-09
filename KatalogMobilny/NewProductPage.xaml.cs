namespace KatalogMobilny;

public partial class NewProductPage : ContentPage
{
    int licznik = 0;

    public NewProductPage()
    {
        InitializeComponent();
    }

    private void NowyProdukt_Clicked(object sender, EventArgs e)
    {
        if (!double.TryParse(CenaEntry.Text, out double cena))
        {
            EtykietaWyniku.Text = "Niepoprawna cena!";
            return;
        }
        if (!int.TryParse(IloscEntry.Text, out int ilosc))
        {
            EtykietaWyniku.Text = "Niepoprawna ilość!";
            return;
        }
        if (cena < 0 || ilosc < 0)
        {
            EtykietaWyniku.Text = "Cena i ilość nie mogą być ujemne!";
            return;
        }

        double wartosc = cena * ilosc;

        string? nazwa = NazwaEntry.Text;
        if (string.IsNullOrWhiteSpace(nazwa))
        {
            EtykietaWyniku.Text = "Niepoprawna nazwa!";
            return;
        }

        if (KategoriaPicker.SelectedItem == null)
        {
            EtykietaWyniku.Text = "Nie wybrano kategorii!";
            return;
        }
        EtykietaWyniku.Text = $"Produkt: {nazwa}, cena: {cena}, ilość: {ilosc}, " +
            $"kategoria: {KategoriaPicker.SelectedItem}, wartość: {wartosc}";
    }

    private void ResetujProdukty_Clicked(object sender, EventArgs e)
    {
        licznik = 0;
        EtykietaWyniku.Text = $"Kategoria: {KategoriaPicker.SelectedItem}";
    }

    private void AvailableSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        if (e.Value)
        {
            KliknietoPrzelacznik.Text = "Produkt niedostępny";
        }
        else
        {
            KliknietoPrzelacznik.Text = "Produkt dostępny";
        }
    }

    private void NazwaEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        int dlugosc = e.NewTextValue?.Length ?? 0;
        EtykietaWyniku.Text = $"Nazwa ma {dlugosc} znaków";
    }

    private void KategoriaPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        if (picker.SelectedItem != null)
        {
            string wybranaKategoria = picker.SelectedItem?.ToString() ?? string.Empty;
            EtykietaWyniku.Text = $"Kategoria: {wybranaKategoria}";
        }
    }

    private void CenaEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        // Jeśli chcielibyście wiedzieć, który element wysłał zdarzenie
        Entry s = (Entry)sender;

        // Исправленная логика проверки на отрицательные числа и подсветку фона
        if (double.TryParse(s.Text, out double wartoscPola))
        {
            if (wartoscPola < 0)
            {
                s.BackgroundColor = Colors.Red;
            }
            else
            {
                s.BackgroundColor = Colors.Green;
            }
        }
        else
        {
            s.BackgroundColor = Colors.Transparent;
        }

        if (!double.TryParse(CenaEntry.Text, out double cena))
        {
            EtykietaWartosc.Text = "Niepoprawna cena!";
            return;
        }
        if (!int.TryParse(IloscEntry.Text, out int ilosc))
        {
            EtykietaWartosc.Text = "Niepoprawna ilość!";
            return;
        }

        EtykietaWartosc.Text = $"Wartość produktu: {cena * ilosc}";
    }
}