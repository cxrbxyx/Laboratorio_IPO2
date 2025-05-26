using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using IPO2_EntregaGrupal.PokemonControls;
// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace IPO2_EntregaGrupal
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private DunsparcePCA dunsparce;
        public MainPage()
        {
            this.InitializeComponent();
            fmMain.Navigated += FmMain_Navigated;
            SystemNavigationManager.GetForCurrentView().BackRequested += opcionVolver;
            ActualizarBotonAtras();
        }

        private void FmMain_Navigated(object sender, NavigationEventArgs e)
        {
            ActualizarBotonAtras();
        }

        private void ActualizarBotonAtras()
        {
            var visibility = fmMain.CanGoBack
                ? AppViewBackButtonVisibility.Visible
                : AppViewBackButtonVisibility.Collapsed;
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = visibility;
        }

        private void irMisPokemon(object sender, RoutedEventArgs e)
        {
            if (!(fmMain.Content is MisPokemonPage))
                fmMain.Navigate(typeof(MisPokemonPage));
        }
        private void irPokedex(object sender, RoutedEventArgs e)
        {
            if (!(fmMain.Content is PokedexPage))
                fmMain.Navigate(typeof(PokedexPage));
        }
        private void irCombate(object sender, RoutedEventArgs e)
        {
            if (!(fmMain.Content is CombatePage))
                fmMain.Navigate(typeof(CombatePage));
        }
        private void irInicio(object sender, RoutedEventArgs e)
        {
            // Si no hay navegación previa, recargamos el contenido visualmente
            if (fmMain.Content == null || fmMain.Content.GetType() != typeof(Grid))
            {
                fmMain.Content = null; // Borra el contenido
                Frame nuevo = new Frame();

                // Reconstruye el contenido central (imagen y texto de bienvenida)
                Grid grid = new Grid
                {
                    Background = new SolidColorBrush(Windows.UI.Colors.Black)
                };

                StackPanel stack = new StackPanel
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Spacing = 30
                };

                TextBlock titulo = new TextBlock
                {
                    Text = "Bienvenidos a IPOkemon",
                    FontSize = 60,
                    FontWeight = Windows.UI.Text.FontWeights.Bold,
                    Foreground = new SolidColorBrush(Windows.UI.Colors.White),
                    TextAlignment = TextAlignment.Center,
                    Margin = new Thickness(0, 0, 0, 10)
                };

                Image imagen = new Image
                {
                    Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri("ms-appx:///Assets/INICIO.jpg")),
                    Width = 800,
                    Stretch = Stretch.Uniform,
                    Margin = new Thickness(0, 0, 0, 10)
                };

                Border descripcion = new Border
                {
                    Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 30, 30, 30)),
                    CornerRadius = new CornerRadius(10),
                    Padding = new Thickness(20),
                    MaxWidth = 800,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Child = new TextBlock
                    {
                        Text = "Explora el mundo Pokémon desde una nueva perspectiva. Consulta tu Pokédex, entrena a tus Pokémon favoritos, participa en combates y conviértete en el mejor entrenador de IPOkemon. ¡Prepárate para una aventura inolvidable!",
                        TextWrapping = TextWrapping.Wrap,
                        FontSize = 18,
                        Foreground = new SolidColorBrush(Windows.UI.Colors.White),
                        TextAlignment = TextAlignment.Center
                    }
                };

                stack.Children.Add(titulo);
                stack.Children.Add(imagen);
                stack.Children.Add(descripcion);

                grid.Children.Add(stack);
                fmMain.Content = grid;
            }
        }

        private void irAcercade(object sender, RoutedEventArgs e)
        {
            // Implementa la navegación a la página "Acerca de" si existe
            // fmMain.Navigate(typeof(AcercaDePage));
        }

        private void opcionVolver(object sender, BackRequestedEventArgs e)
        {
            if (fmMain.CanGoBack)
            {
                e.Handled = true;
                fmMain.GoBack();
            }
        }
    }
}
