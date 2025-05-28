using System;
using System.Collections.Generic;
using System.Reflection;
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
            { "Dunsparce", typeof(PokemonControls.DunsparcePCA) }
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

<<<<<<< HEAD
            // Mostramos el UserControl del Pokémon
            // Asegúrate de que el objeto 'pokemon' que se pasa a esta página 
            // sea la instancia real del UserControl y que implemente iPokemonAdapter.
            if (pokemon is UserControl pokemonControl)
            {
                pokemonUserControlContainer.Content = pokemonControl;
            }
            else if (!string.IsNullOrEmpty(pokemon.Imagen)) // Fallback si no es un UserControl (opcional)
            {
                // Si prefieres no tener un fallback a la imagen, puedes eliminar este bloque else-if.
                // Esto es en caso de que algunos Pokémon sigan usando imágenes y no UserControls.
                var image = new Image
                {
                    Source = new BitmapImage(new Uri(pokemon.Imagen)),
                    Stretch = Windows.UI.Xaml.Media.Stretch.Uniform
                };
                pokemonUserControlContainer.Content = image;
            }
=======
            // Intentamos mostrar el UserControl específico del Pokémon
            MostrarUserControlPokemon();
>>>>>>> 0a43bf69b7b224bd4f1fb92276b13ad70a37531a

            // Mostramos los iconos de tipo
            if (pokemon.IconosTipo != null && pokemon.IconosTipo.Count > 0)
            {
                icTipos.ItemsSource = pokemon.IconosTipo;
            }
        }

        private void MostrarUserControlPokemon()
        {
            // Limpiamos el contenedor
            contenedorPokemon.Children.Clear();

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

                    // Añadimos el control al contenedor
                    contenedorPokemon.Children.Add(userControl);
                }
                catch (Exception ex)
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
            contenedorPokemon.Children.Add(imgPokemon);
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
