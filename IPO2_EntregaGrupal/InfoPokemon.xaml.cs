using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace IPO2_EntregaGrupal
{
    public sealed partial class InfoPokemon : Page
    {
        private iPokemonAdapter pokemon;

        public InfoPokemon()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is iPokemonAdapter pokemonParam)
            {
                pokemon = pokemonParam;
                MostrarDatosPokemon();
            }
        }

        private void MostrarDatosPokemon()
        {
            // Mostramos los datos del Pokémon en los controles
            txtNombre.Text = pokemon.Nombre;
            txtCategoria.Text = pokemon.Categoria;
            txtTipo.Text = pokemon.Tipo;
            txtAltura.Text = $"{pokemon.Altura} m";
            txtPeso.Text = $"{pokemon.Peso} kg";
            txtEvolucion.Text = pokemon.Evolucion;
            txtDescripcion.Text = pokemon.Descripcion;

            // Mostramos la imagen del Pokémon
            if (!string.IsNullOrEmpty(pokemon.Imagen))
            {
                imgPokemon.Source = new BitmapImage(new Uri(pokemon.Imagen));
            }

            // Mostramos los iconos de tipo
            if (pokemon.IconosTipo != null && pokemon.IconosTipo.Count > 0)
            {
                icTipos.ItemsSource = pokemon.IconosTipo;
            }
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            // Volvemos a la página anterior
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }
    }
}
