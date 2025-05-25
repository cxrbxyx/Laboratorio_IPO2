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
            // Si tienes una página de inicio diferente, navega a ella.
            // Si MainPage es la raíz, puedes limpiar el frame:
            while (fmMain.CanGoBack)
                fmMain.GoBack();
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
