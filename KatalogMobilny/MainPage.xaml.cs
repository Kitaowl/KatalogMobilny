namespace KatalogMobilny
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            //alternatywne tworzenie elementów interfejsu zamiast
            //xamla - tego nie robimy!
            //Label etykieta = new Label();
            //etykieta.Text = "Procesor";
            //etykieta.Parent = MainLayout;
        }

        private void PokazClicked(object sender, EventArgs e)
        {
            EtykietaWyniku.Text = "Wybrano procesor";
        }

        /*
        private void CounterBtn_Clicked(object sender, EventArgs e)
        {
            count++;
            EtykietaPowitania.Text = $"Kliknięto {count} razy";
        }
        */
    }
}
