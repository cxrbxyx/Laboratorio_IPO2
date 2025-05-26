using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml.Media;

namespace IPO2_EntregaGrupal
{
    public sealed partial class CombatePage : Page
    {
        private Random rnd = new Random();

        public CombatePage()
        {
            this.InitializeComponent();
            TextoCombate.Text = "¡El combate ha comenzado!";
            Narrar("¡El combate ha comenzado!");
        }

        private async void Narrar(string texto)
        {
            var synth = new SpeechSynthesizer();
            SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync(texto);
            NarradorElemento.SetSource(stream, stream.ContentType);
            NarradorElemento.Play();
        }

        private void BtnAtacar_Click(object sender, RoutedEventArgs e)
        {
            int daño = rnd.Next(5, 20);
            VidaEnemigo.Value = Math.Max(0, VidaEnemigo.Value - daño);
            string texto = $"Atacaste a {NombreEnemigo.Text} e hiciste {daño} de daño.";
            TextoCombate.Text = texto;
            Narrar(texto);

            ComprobarVictoria();
        }

        private void BtnDefender_Click(object sender, RoutedEventArgs e)
        {
            string texto = $"{NombreJugador.Text} se defendió. Turno del enemigo.";
            TextoCombate.Text = texto;
            Narrar(texto);

            TurnoEnemigo();
        }

        private void TurnoEnemigo()
        {
            int daño = rnd.Next(5, 15);
            VidaJugador.Value = Math.Max(0, VidaJugador.Value - daño);
            string texto = $"{NombreEnemigo.Text} atacó y te hizo {daño} de daño.";
            TextoCombate.Text = texto;
            Narrar(texto);

            ComprobarVictoria();
        }

        private void ComprobarVictoria()
        {
            if (VidaEnemigo.Value == 0)
            {
                TextoCombate.Text = "¡Ganaste el combate!";
                Narrar("¡Ganaste el combate!");
                BtnAtacar.IsEnabled = false;
                BtnDefender.IsEnabled = false;
            }
            else if (VidaJugador.Value == 0)
            {
                TextoCombate.Text = "¡Has sido derrotado!";
                Narrar("¡Has sido derrotado!");
                BtnAtacar.IsEnabled = false;
                BtnDefender.IsEnabled = false;
            }
        }
    }
}
