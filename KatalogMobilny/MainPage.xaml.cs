namespace KatalogMobilny
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void PokazClicked(object sender, EventArgs e)
        {
            EtykietaWyniku.Text = "Wybrano processor";
        }

        /*
        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                Clicked.Text = $"Clicked {count} time";
            else
                Clicked.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(Clicked.Text);
        }
        */
    }
}
// pierwsze 05,854 s
// drugie 05,906 s
