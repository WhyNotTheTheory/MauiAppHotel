using MauiAppHotel.Models;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    private App PropriedadesApp;

    public ContratacaoHospedagem()
    {
        InitializeComponent();

        // Instância global do app
        PropriedadesApp = (App)Application.Current;

        // Define a lista de quartos
        pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;

        // Define os limites das datas
        dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkin.MaximumDate = DateTime.Now.AddMonths(1);

        dtpck_checkout.MinimumDate = dtpck_checkin.Date.AddDays(1);
        dtpck_checkout.MaximumDate = dtpck_checkin.Date.AddMonths(6);

        // Adiciona uma leve animação ao entrar
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
            if (pck_quarto.SelectedItem == null)
            {
                await DisplayAlert("Atenção", "Selecione uma suíte antes de continuar.", "OK");
                return;
            }

            if (dtpck_checkout.Date <= dtpck_checkin.Date)
            {
                await DisplayAlert("Atenção", "A data de check-out deve ser posterior ao check-in.", "OK");
                return;
            }

            Hospedagem hospedagem = new Hospedagem
            {
                QuartoSelecionado = (Quarto)pck_quarto.SelectedItem,
                QntAdultos = (int)stp_adultos.Value,
                QntCriancas = (int)stp_criancas.Value,
                DataCheckIn = dtpck_checkin.Date,
                DataCheckOut = dtpck_checkout.Date
            };

            // Animação no botão antes de navegar
            var btn = sender as Button;
            await btn.ScaleTo(0.95, 100);
            await btn.ScaleTo(1, 100);

            await Navigation.PushAsync(new HospedagemContratada()
            {
                BindingContext = hospedagem
            });
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops!", $"Ocorreu um erro: {ex.Message}", "OK");
        }
    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DateTime dataSelecionada = e.NewDate;

        dtpck_checkout.MinimumDate = dataSelecionada.AddDays(1);
        dtpck_checkout.MaximumDate = dataSelecionada.AddMonths(6);
    }

    private async void AbrirSobre_Clicked(object sender, EventArgs e)
    {
        var btn = sender as Button;
        await btn.ScaleTo(0.95, 100);
        await btn.ScaleTo(1, 100);

        await Navigation.PushAsync(new Sobre());
    }
}
