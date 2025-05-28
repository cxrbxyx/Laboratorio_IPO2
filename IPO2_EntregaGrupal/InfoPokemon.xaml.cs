using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace IPO2_EntregaGrupal
{
    public sealed partial class InfoPokemon : Page
    {
        private iPokemon pokemon; // Mantenemos iPokemonAdapter si los UserControls lo implementan

        // Mapa para relacionar nombre de Pokémon con su UserControl correspondiente
        private Dictionary<string, Type> mapaUserControls = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase)
        {
            // Aquí agregaremos los Pokémon que tienen UserControl
            { "Bulbasaur", typeof(PokemonControls.BulbasaurRH) },
            { "Dunsparce", typeof(PokemonControls.DunsparcePCA) },
            { "Gengar", typeof(PokemonControls.GengarJMC) },
            { "Swablu", typeof(PokemonControls.SwabluSCP) },
            { "Victini", typeof(PokemonControls.VictiniLDM) }
            // Añade más Pokémon según los UserControls disponibles
        };

        public InfoPokemon()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is iPokemon pokemonParam) // Asumimos que el parámetro sigue siendo iPokemonAdapter
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

            // Mostramos el UserControl del Pokémon
            MostrarUserControlPokemon();

            // Mostramos los iconos de tipo
            if (pokemon.IconosTipo != null && pokemon.IconosTipo.Count > 0)
            {
                icTipos.ItemsSource = pokemon.IconosTipo;
            }
        }

        private void MostrarUserControlPokemon()
        {
            // Verificamos si existe un UserControl para este Pokémon
            if (mapaUserControls.TryGetValue(pokemon.Nombre, out Type tipoUserControl))
            {
                try
                {
                    // Creamos una instancia del UserControl
                    var userControl = Activator.CreateInstance(tipoUserControl) as UserControl;

                    // Si implementa iPokemon, configuramos las propiedades básicas
                    if (userControl is iPokemon pokemonControl)
                    {
                        // Activamos la animación idle
                        pokemonControl.activarAniIdle(true);

                        // Configuramos opciones de visualización
                        pokemonControl.verFondo(true);
                        pokemonControl.verFilaVida(true);
                        pokemonControl.verFilaEnergia(true);
                        pokemonControl.verNombre(true);
                    }

                    // Asignamos el control al contenedor
                    pokemonUserControlContainer.Content = userControl;
                }
                catch (Exception)
                {
                    // Si falla, mostramos la imagen estática como fallback
                    MostrarImagenPokemon();
                }
            }
            else
            {
                // Si no hay UserControl para este Pokémon, mostramos la imagen
                MostrarImagenPokemon();
            }
        }

        private void MostrarImagenPokemon()
        {
            // Creamos una imagen y la configuramos
            var imgPokemon = new Image
            {
                Stretch = Windows.UI.Xaml.Media.Stretch.Uniform
            };

            // Mostramos la imagen del Pokémon si tiene URL de imagen
            if (!string.IsNullOrEmpty(pokemon.Imagen))
            {
                imgPokemon.Source = new BitmapImage(new Uri(pokemon.Imagen));
            }

            // Añadimos la imagen al contenedor
            pokemonUserControlContainer.Content = imgPokemon;
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
