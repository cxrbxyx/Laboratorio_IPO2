using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPO2_EntregaGrupal
{
    public interface iPokemon    {
        // Existing properties and methods...
        double Vida { get; set; }
        double Energia { get; set; }
        string Nombre { get; set; }
        string Categoria { get; set; }
        string Tipo { get; set; }
        double Altura { get; set; }
        double Peso { get; set; }
        string Evolucion { get; set; }
        string Descripcion { get; set; }
        string Imagen { get; set; }
        List<string> IconosTipo { get; set; }

        void verFondo(bool ver);
        void verFilaVida(bool ver);
        void verFilaEnergia(bool ver);
        void verPocionVida(bool ver);
        void verPocionEnergia(bool ver);
        void verNombre(bool ver);
        void activarAniIdle(bool activar);
        void animacionAtaqueFuerte();
        void animacionDefensa();
        void animacionDescasar();

        void animacionCansado();
        void animacionNoCansado();
        void animacionHerido();
        void animacionNoHerido();
        void animacionDerrota();
    }

}
