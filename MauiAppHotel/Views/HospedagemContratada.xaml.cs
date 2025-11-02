namespace MauiAppHotel.Views;

public partial class HospedagemContratada : ContentPage
{
    public HospedagemContratada()
    {
        InitializeComponent();

        // Efeito suave de entrada da tela
        this.Appearing += async (s, e) =>
        {
            await this.FadeTo(0, 0);
            await this.FadeTo(1, 400, Easing.CubicInOut);
        };
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Efeito visual de clique no botão
            if (sender is Button btn)
            {
                await btn.ScaleTo(0.95, 80, Easing.CubicOut);
                await btn.ScaleTo(1, 80, Easing.CubicIn);
            }

            // Retorna para a tela anterior
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops!", $"Ocorreu um erro: {ex.Message}", "OK");
        }
    }
}
