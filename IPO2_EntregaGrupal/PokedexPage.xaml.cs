using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using IPO2_EntregaGrupal.PokemonControls;

namespace IPO2_EntregaGrupal
{
    public sealed partial class PokedexPage : Page
    {
        private List<iPokemon> todos;
        private List<iPokemon> filtrados;

        public PokedexPage()
        {
            this.InitializeComponent();
            CargarPokemon();
        }

        private void CargarPokemon()
        {
            todos = new List<iPokemon>
            {
            new PokemonControls.BulbasaurRH(),
            new PokemonControls.DunsparcePCA(),
            new PokemonControls.GengarJMC(),
            new PokemonControls.SwabluSCP(),
            new PokemonControls.VictiniLDM()
            };

            filtrados = new List<iPokemon>(todos);
            lvPokedex.ItemsSource = null; // Limpiar primero
            lvPokedex.ItemsSource = filtrados;

            if (todos.Any())
            {
                var tipos = todos
                    .Where(p => p.Tipo != null)
                    .SelectMany(p => p.Tipo.Split('/'))
                    .Select(t => t.Trim())
                    .Distinct()
                    .OrderBy(t => t)
                    .ToList();

                tipos.Insert(0, "Todos");
                cbTipos.ItemsSource = tipos;
                if (cbTipos.Items.Count > 0)
                {
                    cbTipos.SelectedIndex = 0;
                }
            }
            else
            {
                cbTipos.ItemsSource = new List<string> { "Todos" };
                cbTipos.SelectedIndex = 0;
            }
        }

        private void AplicarFiltros()
        {
            string texto = txtBuscar.Text?.Trim().ToLower() ?? "";
            string tipoSeleccionado = cbTipos.SelectedItem as string;

            if (todos == null) return;

            filtrados = todos
                .Where(p =>
                    (string.IsNullOrEmpty(texto) || (p.Nombre?.ToLower().Contains(texto) ?? false)) &&
                    (string.IsNullOrEmpty(tipoSeleccionado) || tipoSeleccionado == "Todos" || (p.Tipo?.Contains(tipoSeleccionado, StringComparison.OrdinalIgnoreCase) ?? false))
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
            if (boton?.Tag is iPokemon pokemon)
            {
                Frame.Navigate(typeof(InfoPokemon), pokemon);
            }
        }

        private void lvPokedex_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is iPokemon pokemon)
            {
                Frame.Navigate(typeof(InfoPokemon), pokemon);
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtBuscar.Text = string.Empty;
            if (cbTipos.Items.Count > 0)
            {
                cbTipos.SelectedIndex = 0;
            }
            AplicarFiltros();
        }
    }
}
