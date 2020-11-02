using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        int legajo;

        #region Constructores
        public Universitario()
        {
        }

        public Universitario(int legajo, string nombre, string apellido, ENacionalidad nacionalidad, string dni)
            :base(nombre, apellido, nacionalidad, dni)
        {

            this.legajo = legajo;

        }
        #endregion

        #region Metodos

        protected virtual string MostrarDatos()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{base.ToString()}");
            sb.AppendLine($"Legajo: {this.legajo}");

            return sb.ToString();

        }

        protected abstract string ParticiparEnClase();

        #endregion

        #region Operadores
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {

            return pg1.Equals(pg2);

        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }


        public override bool Equals(object obj)
        {
            bool sonIguales = false;
            if (obj is Universitario)
            {
                if (((Universitario)obj).legajo == this.legajo || ((Universitario)obj).DNI == this.DNI)
                    sonIguales = true;
            }
            return sonIguales;
        }

        #endregion

    }
}
