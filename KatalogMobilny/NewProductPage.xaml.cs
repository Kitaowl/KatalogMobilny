namespace KatalogMobilny;

public partial class NewProductPage : ContentPage
{
    int licznik = 0;

    public NewProductPage()
    {
        InitializeComponent();
    }

    private void DodajProdukty_Clicked(object sender, EventArgs e)
    {
        licznik++;
        KliknietoLabel.Text = $"Kliknięto {licznik} razy";
    }

    private void ResetujProdukty_Clicked(object sender, EventArgs e)
    {
        licznik = 0;
        KliknietoLabel.Text = "Kliknięto 0 razy";
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

    private void KategoriaPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        if (picker.SelectedItem != null)
        {
            // Берем выбранную категорию и подставляем в текст
            string wybranaKategoria = picker.SelectedItem.ToString();
            EtykietaWyniku.Text = $"Kategoria: {wybranaKategoria}";
        }
    }

    private void NazwaEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        int dlugosc = e.NewTextValue?.Length ?? 0;

        EtykietaWyniku.Text = $"Nazwa ma {dlugosc} znaków";
    }
}