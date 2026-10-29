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
}