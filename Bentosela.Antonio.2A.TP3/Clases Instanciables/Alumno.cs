using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        #region Constructores

        public Alumno()
        {
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
             : base(id, nombre, apellido, nacionalidad, dni)
        {
            this.claseQueToma = claseQueToma;
        }

     
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        #endregion

        #region Metodos

        protected override string MostrarDatos()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine($"{this.ParticiparEnClase()}");
            sb.AppendLine($"Estado de Cuenta: { this.estadoCuenta}");

            return sb.ToString();

        }

        protected override string ParticiparEnClase()
        {

            return "Clase que toma: " + this.claseQueToma;

        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Operadores

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {

            if(a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {

            return a.claseQueToma == clase;

        }

        #endregion

    }
}
