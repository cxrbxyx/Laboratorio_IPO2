﻿#pragma checksum "C:\Users\pca_p\Documents\GitHub\Laboratorio_IPO2\IPO2_EntregaGrupal\PokedexPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "970DBAF898B08CC325D438A3DED5683B21B6B5879DE556B07ED4E529A9FD8354"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IPO2_EntregaGrupal
{
    partial class PokedexPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // PokedexPage.xaml line 38
                {
                    this.lvPokedex = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.lvPokedex).ItemClick += this.lvPokedex_ItemClick;
                }
                break;
            case 4: // PokedexPage.xaml line 81
                {
                    global::Windows.UI.Xaml.Controls.Button element4 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element4).Click += this.Info_Click;
                }
                break;
            case 6: // PokedexPage.xaml line 28
                {
                    this.txtBuscar = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.txtBuscar).TextChanged += this.txtBuscar_TextChanged;
                }
                break;
            case 7: // PokedexPage.xaml line 31
                {
                    this.cbTipos = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.cbTipos).SelectionChanged += this.cbTipos_SelectionChanged;
                }
                break;
            case 8: // PokedexPage.xaml line 34
                {
                    this.btnLimpiar = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnLimpiar).Click += this.btnLimpiar_Click;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

