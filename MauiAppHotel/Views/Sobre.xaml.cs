namespace MauiAppHotel.Views;

public partial class Sobre : ContentPage
{
    public Sobre()
    {
        InitializeComponent(); // ⚠️ sem isso, a tela fica em branco
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // Volta pra tela anterior
    }
}
