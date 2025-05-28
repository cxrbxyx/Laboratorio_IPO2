using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace IPO2_EntregaGrupal
{
    public sealed partial class PokedexPage : Page
    {
        // Cambiamos de Pokemon a iPokemon
        private List<iPokemonAdapter> todos;
        private List<iPokemonAdapter> filtrados;

        public PokedexPage()
        {
            this.InitializeComponent();
            CargarPokemon();
        }

        // Define a concrete implementation of the iPokemonAdapter interface  
        public class PokemonAdapter : iPokemonAdapter
        {
            public string Nombre { get; set; }
            public string Tipo { get; set; }
            public string Imagen { get; set; }
            public List<string> IconosTipo { get; set; }
            public string Descripcion { get; set; }
            public string Evolucion { get; set; }
            public string Categoria { get; set; }
            public double Altura { get; set; }
            public double Peso { get; set; }
        }

        // Replace instances of iPokemonAdapter with PokemonAdapter in the CargarPokemon method  
        private void CargarPokemon()
        {
            todos = new List<iPokemonAdapter>
           {
                new PokemonAdapter {
                    Nombre = "Azumarill",
                    Tipo = "Agua/Hada",
                    Imagen = "ms-appx:///Assets/Pokedex/azumarill.png",
                    IconosTipo = new List<string>
                    {
                        "ms-appx:///Assets/Tipo_P/Tipo_Agua.png",
                        "ms-appx:///Assets/Tipo_P/Tipo_Hada.png"
                    },
                    Descripcion = "Puede lanzar potentes chorros de agua desde su boca.",
                    Evolucion = "No tiene",
                    Categoria = "Acuático",
                    Altura = 0.8,
                    Peso = 28.5
                },
                new PokemonAdapter {
                       Nombre = "Bulbasaur",
                       Tipo = "Planta/Veneno",
                       Imagen = "ms-appx:///Assets/Pokedex/bulbasaur.png",
                       IconosTipo = new List<string>
                       {
                           "ms-appx:///Assets/Tipo_P/Tipo_Hierva.png",
                           "ms-appx:///Assets/Tipo_P/Tipo_veneno.png"
                       },
                       Descripcion = "Una semilla en su lomo crece con él desde que nace.",
                       Evolucion = "Ivysaur",
                       Categoria = "Semilla",
                       Altura = 0.7,
                       Peso = 6.9
                   },
                   new PokemonAdapter {
                       Nombre = "Corphish",
                       Tipo = "Agua",
                       Imagen = "ms-appx:///Assets/Pokedex/corphish.png",
                       IconosTipo = new List<string>
                       {
                           "ms-appx:///Assets/Tipo_P/Tipo_Agua.png"
                       },
                       Descripcion = "Siempre está listo para pelear, incluso contra oponentes más grandes.",
                       Evolucion = "Crawdaunt",
                       Categoria = "Cangrejo",
                       Altura = 0.6,
                       Peso = 11.5
                   },
                new PokemonAdapter{
                    Nombre = "Dunsparce",
                    Tipo = "Normal",
                    Imagen = "ms-appx:///Assets/Pokedex/dunsparce.png",
                    IconosTipo = new List<string>
                    {
                        "ms-appx:///Assets/Tipo_P/Tipo_normal.png"
                    },
                    Descripcion = "A pesar de tener alas, raramente vuela. Se esconde bajo tierra.",
                    Evolucion = "No tiene",
                    Categoria = "Serpiente Tierra", // Añadida categoría
                    Altura = 1.5,
                    Peso = 14.0
                },

                new PokemonAdapter
                {
                    Nombre = "Gardevoir",
                    Tipo = "Psiquico/Hada",
                    Imagen = "ms-appx:///Assets/Pokedex/gardevoir.png",
                    IconosTipo = new List<string>
                    {
                        "ms-appx:///Assets/Tipo_P/Tipo_Phsiquico.png",
                        "ms-appx:///Assets/Tipo_P/Tipo_Hada.png"
                    },
                    Descripcion = "Puede ver el futuro y proteger a su entrenador con energia psiquica.",
                    Evolucion = "Kirlia",
                    Categoria = "Sensorio", // Añadida categoría
                    Altura = 1.6,
                    Peso = 48.4
                },
                new PokemonAdapter
                {
                    Nombre = "Golbat",
                    Tipo = "Veneno/Volador",
                    Imagen = "ms-appx:///Assets/Pokedex/golbat.png",
                    IconosTipo = new List<string>
                    {
                        "ms-appx:///Assets/Tipo_P/Tipo_veneno.png",
                        "ms-appx:///Assets/Tipo_P/Tipo_aire.png"
                    },
                    Descripcion = "Drena sangre de sus victimas con sus colmillos. Le encanta volar por la noche.",
                    Evolucion = "Crobat",
                    Categoria = "Murciélago", // Añadida categoría
                    Altura = 1.6,
                    Peso = 55.0
                },

                new PokemonAdapter
                {
                    Nombre = "Gengar",
                    Tipo = "Fantasma/Veneno",
                    Imagen = "ms-appx:///Assets/Pokedex/gengar.png",
                    IconosTipo = new List<string>
                    {
                        "ms-appx:///Assets/Tipo_P/Tipo_Fantasma.png",
                        "ms-appx:///Assets/Tipo_P/Tipo_veneno.png"
                    },
                    Descripcion = "Se esconde en las sombras para acechar. Su risa puede helarte la sangre.",
                    Evolucion = "No tiene",
                    Categoria = "Sombra", // Añadida categoría
                    Altura = 1.5,
                    Peso = 40.5
                },

                new PokemonAdapter
                {
                    Nombre = "Geodude",
                    Tipo = "Roca/Tierra",
                    Imagen = "ms-appx:///Assets/Pokedex/geodude.png",
                    IconosTipo = new List<string>
                    {
                        "ms-appx:///Assets/Tipo_P/Tipo_Roca.png",
                        "ms-appx:///Assets/Tipo_P/Tipo_Tierra.png"
                    },
                    Descripcion = "Se confunde con una roca normal. Muy común en caminos de montaña.",
                    Evolucion = "Graveler",
                    Categoria = "Roca", // Añadida categoría
                    Altura = 0.4,
                    Peso = 20.0
                },

                new PokemonAdapter
                {
                    Nombre = "Horsea",
                    Tipo = "Agua",
                    Imagen = "ms-appx:///Assets/Pokedex/horsea.png",
                    IconosTipo = new List<string>
                    {
                        "ms-appx:///Assets/Tipo_P/Tipo_Agua.png"
                    },
                    Descripcion = "Nada con agilidad entre las olas. Expulsa tinta para escapar.",
                    Evolucion = "Seadra",
                    Categoria = "Dragón", // Añadida categoría
                    Altura = 0.4,
                    Peso = 8.0
                },
                new PokemonAdapter
                {
                    Nombre = "Pichu",
                    Tipo = "Eléctrico",
                    Imagen = "ms-appx:///Assets/Pokedex/pichu.png",
                    IconosTipo = new List<string>
                    {
                        "ms-appx:///Assets/Tipo_P/Tipo_Electrico.png"
                    },
                    Descripcion = "Muy tierno pero inexperto. Se electrocuta a si mismo al liberar energia.",
                    Evolucion = "Pikachu",
                    Categoria = "Ratón Pequeño", // Añadida categoría
                    Altura = 0.3,
                    Peso = 2.0
                },

                new PokemonAdapter
                {
                    Nombre = "Mimikyu",
                    Tipo = "Fantasma/Hada",
                    Imagen = "ms-appx:///Assets/Pokedex/mimikyu.png",
                    IconosTipo = new List<string>
                    {
                        "ms-appx:///Assets/Tipo_P/Tipo_Fantasma.png",
                        "ms-appx:///Assets/Tipo_P/Tipo_Hada.png"
                    },
                    Descripcion = "Se oculta bajo un disfraz de Pikachu porque desea hacer amigos.",
                    Evolucion = "No tiene",
                    Categoria = "Disfraz", // Añadida categoría
                    Altura = 0.2,
                    Peso = 0.7
                },

                new PokemonAdapter
                {
                    Nombre = "Oshawott",
                    Tipo = "Agua",
                    Imagen = "ms-appx:///Assets/Pokedex/oshawott.png",
                    IconosTipo = new List<string>
                    {
                        "ms-appx:///Assets/Tipo_P/Tipo_Agua.png"
                    },
                    Descripcion = "Usa la concha de su pecho como arma en combate.",
                    Evolucion = "Dewott",
                    Categoria = "Nutria Marina", // Añadida categoría
                    Altura = 0.5,
                    Peso = 5.9
                },

                new PokemonAdapter
                {
                    Nombre = "Pachirisu",
                    Tipo = "Eléctrico",
                    Imagen = "ms-appx:///Assets/Pokedex/pachirisu.png",
                    IconosTipo = new List<string>
                    {
                        "ms-appx:///Assets/Tipo_P/Tipo_Electrico.png"
                    },
                    Descripcion = "Almacena electricidad en sus mejillas. Le encanta correr por los árboles.",
                    Evolucion = "No tiene",
                    Categoria = "Ardilla EleSquirrel", // Añadida categoría
                    Altura = 0.4,
                    Peso = 3.9
                },

                new PokemonAdapter
                {
                    Nombre = "Regice",
                    Tipo = "Hielo",
                    Imagen = "ms-appx:///Assets/Pokedex/regice.png",
                    IconosTipo = new List<string>
                    {
                        "ms-appx:///Assets/Tipo_P/Tipo_Hielo.png"
                    },
                    Descripcion = "Su cuerpo está hecho de hielo antártico. Puede sobrevivir a cualquier temperatura.",
                    Evolucion = "No tiene",
                    Categoria = "Iceberg", // Añadida categoría
                    Altura = 1.8,
                    Peso = 175.0
                },

                new PokemonAdapter
                {
                    Nombre = "Pignite",
                    Tipo = "Fuego/Lucha",
                    Imagen = "ms-appx:///Assets/Pokedex/pignite.png",
                    IconosTipo = new List<string>
                    {
                        "ms-appx:///Assets/Tipo_P/Tipo_Fuego.png",
                        "ms-appx:///Assets/Tipo_P/Tipo_Lucha.png"
                    },
                    Descripcion = "Calienta su cuerpo antes de combatir. Su barriga incandescente es su arma.",
                    Evolucion = "Emboar",
                    Categoria = "Cerdo Fuego", // Añadida categoría
                    Altura = 1.0,
                    Peso = 55.5
                },

                new PokemonAdapter
                {
                    Nombre = "Porygon",
                    Tipo = "Normal",
                    Imagen = "ms-appx:///Assets/Pokedex/porygon.png",
                    IconosTipo = new List<string>
                    {
                        "ms-appx:///Assets/Tipo_P/Tipo_normal.png"
                    },
                    Descripcion = "Primer Pokémon completamente generado por computadora. Puede viajar por internet.",
                    Evolucion = "Porygon2",
                    Categoria = "Virtual", // Añadida categoría
                    Altura = 0.8,
                    Peso = 36.5
                },

                new PokemonAdapter
                {
                    Nombre = "Psyduck",
                    Tipo = "Agua",
                    Imagen = "ms-appx:///Assets/Pokedex/psyduck.png",
                    IconosTipo = new List<string>
                    {
                        "ms-appx:///Assets/Tipo_P/Tipo_Agua.png"
                    },
                    Descripcion = "Sufre constantes dolores de cabeza. Cuando empeoran, libera poderes psiquicos.",
                    Evolucion = "Golduck",
                    Categoria = "Pato", // Añadida categoría
                    Altura = 0.8,
                    Peso = 19.6
                },
                new PokemonAdapter
                {
                    Nombre = "Swablu",
                    Tipo = "Normal/Volador",
                    Imagen = "ms-appx:///Assets/Pokedex/swablu.png",
                    IconosTipo = new List<string>
                    {
                        "ms-appx:///Assets/Tipo_P/Tipo_normal.png",
                        "ms-appx:///Assets/Tipo_P/Tipo_aire.png"
                    },
                    Descripcion = "Le encanta posarse en las cabezas como si fuera un gorro de algodón.",
                    Evolucion = "Altaria",
                    Categoria = "Ave Algodón", // Añadida categoría
                    Altura = 0.4,
                    Peso = 1.2
                },

                new PokemonAdapter
                {
                    Nombre = "Riolu",
                    Tipo = "Lucha",
                    Imagen = "ms-appx:///Assets/Pokedex/riolu.png",
                    IconosTipo = new List<string>
                    {
                        "ms-appx:///Assets/Tipo_P/Tipo_Lucha.png"
                    },
                    Descripcion = "Percibe las emociones con sus ondas aura. Muy leal a su entrenador.",
                    Evolucion = "Lucario",
                    Categoria = "Emanación", // Añadida categoría
                    Altura = 0.7,
                    Peso = 20.2
                },

                new PokemonAdapter
                {
                    Nombre = "Rowlet",
                    Tipo = "Planta/Volador",
                    Imagen = "ms-appx:///Assets/Pokedex/rowlet.png",
                    IconosTipo = new List<string>
                    {
                        "ms-appx:///Assets/Tipo_P/Tipo_Hierva.png",
                        "ms-appx:///Assets/Tipo_P/Tipo_aire.png"
                    },
                    Descripcion = "Puede volar silenciosamente y atacar con plumas afiladas como cuchillas.",
                    Evolucion = "Dartrix",
                    Categoria = "Plumaje", // Añadida categoría
                    Altura = 0.3,
                    Peso = 1.5
                },

                new PokemonAdapter
                {
                    Nombre = "Sprigatito",
                    Tipo = "Planta",
                    Imagen = "ms-appx:///Assets/Pokedex/sprigatito.png",
                    IconosTipo = new List<string>
                    {
                        "ms-appx:///Assets/Tipo_P/Tipo_Hierva.png"
                    },
                    Descripcion = "Cuando amasa con sus patas, libera un dulce aroma que hipnotiza.",
                    Evolucion = "Floragato",
                    Categoria = "Gato Hierba", // Añadida categoría
                    Altura = 0.4,
                    Peso = 4.1
                },
                new PokemonAdapter
                {
                    Nombre = "Victini",
                    Tipo = "Psiquico/Fuego",
                    Imagen = "ms-appx:///Assets/Pokedex/victini.png",
                    IconosTipo = new List<string>
                    {
                        "ms-appx:///Assets/Tipo_P/Tipo_Phsiquico.png",
                        "ms-appx:///Assets/Tipo_P/Tipo_Fuego.png"
                    },
                    Descripcion = "Se dice que quien lo posee obtendrá la victoria. Rebosa de energia ilimitada.",
                    Evolucion = "No tiene",
                    Categoria = "Victoria", // Añadida categoría
                    Altura = 0.4,
                    Peso = 4.0
                },

                new PokemonAdapter
                {
                    Nombre = "Wartortle",
                    Tipo = "Agua",
                    Imagen = "ms-appx:///Assets/Pokedex/wartortle.png",
                    IconosTipo = new List<string>
                    {
                        "ms-appx:///Assets/Tipo_P/Tipo_Agua.png"
                    },
                    Descripcion = "Almacena aire en su peluda cola para sumergirse y descansar bajo el agua.",
                    Evolucion = "Blastoise",
                    Categoria = "Tortuga", // Añadida categoría
                    Altura = 1.0,
                    Peso = 22.5
                },

                new PokemonAdapter
                {
                    Nombre = "Zygarde",
                    Tipo = "Dragón/Tierra",
                    Imagen = "ms-appx:///Assets/Pokedex/zygarde.png",
                    IconosTipo = new List<string>
                    {
                        "ms-appx:///Assets/Tipo_P/Tipo_Dragón.png",
                        "ms-appx:///Assets/Tipo_P/Tipo_Tierra.png"
                    },
                    Descripcion = "Observa el equilibrio del ecosistema. Se activa ante amenazas al mundo.",
                    Evolucion = "No tiene",
                    Categoria = "Orden", // Añadida categoría
                    Altura = 5.0,
                    Peso = 305.0
                }
              };




            filtrados = new List<iPokemonAdapter>(todos);
            lvPokedex.ItemsSource = filtrados;

            // Extract and load unique types into the ComboBox  
            var tipos = todos
                .SelectMany(p => p.Tipo.Split('/'))
                .Select(t => t.Trim())
                .Distinct()
                .OrderBy(t => t)
                .ToList();

            tipos.Insert(0, "Todos");
            cbTipos.ItemsSource = tipos;
        }

        private void AplicarFiltros()
        {
            string texto = txtBuscar.Text?.Trim().ToLower();
            string tipoSeleccionado = cbTipos.SelectedItem as string;

            filtrados = todos
                .Where(p =>
                    (string.IsNullOrEmpty(texto) || p.Nombre.ToLower().Contains(texto)) &&
                    (string.IsNullOrEmpty(tipoSeleccionado) || tipoSeleccionado == "Todos" || p.Tipo.Contains(tipoSeleccionado, StringComparison.OrdinalIgnoreCase))
                )
                .ToList();

            lvPokedex.ItemsSource = filtrados;
        }

        private void txtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            AplicarFiltros();
        }

        private void cbTipos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AplicarFiltros();
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            var boton = sender as Button;
            var pokemon = boton.Tag as iPokemonAdapter;

            Frame.Navigate(typeof(InfoPokemon), pokemon);
        }

        private void lvPokedex_ItemClick(object sender, ItemClickEventArgs e)
        {
            var pokemon = e.ClickedItem as iPokemonAdapter;
            if (pokemon != null)
            {
                // Navegamos a la página InfoPokemon pasando el Pokémon como parámetro
                Frame.Navigate(typeof(InfoPokemon), pokemon);
            }
        }


        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtBuscar.Text = string.Empty;
            cbTipos.SelectedIndex = 0; // Selecciona "Todos"
            AplicarFiltros(); // Vuelve a aplicar los filtros
        }
    }
}
