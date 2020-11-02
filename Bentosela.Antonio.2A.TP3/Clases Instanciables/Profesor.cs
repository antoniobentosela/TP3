using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public sealed class  Profesor : Universitario
    {

        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;


        #region Constructores

        static Profesor()
        {
            random = new Random();
        }

        public Profesor()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
            this._randomClases();

        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(id, nombre, apellido, nacionalidad, dni)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
            this._randomClases();

        }

        #endregion

        #region Metodos
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CLASES DEL DÍA:\n");
            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                sb.AppendFormat($"{clase}\n");
            }
            return sb.ToString();
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();

        }

        private void _randomClases()
        {
            int auxRnd = random.Next(0, 4);
            this.clasesDelDia.Enqueue((Universidad.EClases)auxRnd);
        }

        #endregion

        #region ToString
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region operator
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {

            bool rta = false;

            foreach (Universidad.EClases item in i.clasesDelDia)
            {
                if (item == clase)
                {
                    rta = true;
                }
                    
            }

            return rta;

        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        #endregion

    }
}
