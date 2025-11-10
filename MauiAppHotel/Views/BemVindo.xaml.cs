using MauiAppHotel.Views;

namespace MauiAppHotel.Views
{
    public partial class BemVindo : ContentPage
    {
        public BemVindo()
        {
            InitializeComponent();
        }

        private async void OnEntrarClicked(object sender, EventArgs e)
        {
            // Depois de clicar, vai pra tela principal de hospedagem
            await Navigation.PushAsync(new ContratacaoHospedagem());
        }
    }
}
