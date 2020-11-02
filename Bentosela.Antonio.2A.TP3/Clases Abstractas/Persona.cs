using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {

        private string apellido;
        private string nombre;
        private int dni;
        private ENacionalidad nacionalidad;

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #region Propiedades
        public string Nombre
        {
            get { return nombre; }
            set { nombre = ValidarNombreApellido(value); }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = ValidarNombreApellido(value); }
        }

        public int DNI
        {
            get { return dni; }
            set { dni = ValidarDni(this.Nacionalidad, value); }
        }

        public ENacionalidad Nacionalidad
        {
            get { return nacionalidad; }
            set { nacionalidad = value; }
        }

        public string DNIToString
        {
            set { dni = ValidarDniS(this.Nacionalidad, value); }
        }

        #endregion

        #region Constructores
        public Persona()
        {
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {

            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;


        }


        public Persona(string nombre, string apellido, ENacionalidad nacionalidad, int dni)
            : this(nombre, apellido, nacionalidad)
        {

            this.dni = dni;

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad, string dni) : this(nombre, apellido, nacionalidad)
        {
            DNIToString = dni;

        }
        #endregion

        #region Metodos

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int retornoDni = default(int);

            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato >= 1 && dato <= 89999999)
                        retornoDni = dato;
                    else
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI.");
                    break;

                case ENacionalidad.Extranjero:
                    if (dato >= 90000000 && dato < 99999999)
                        retornoDni = dato;
                    else
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI.");
                    break;
            }

            return retornoDni;
        }

        private int ValidarDniS(ENacionalidad nacionalidad, string dato)
        {
            int retornoDniInt = default(int);

            if (int.TryParse(dato, out retornoDniInt))
                retornoDniInt = ValidarDni(nacionalidad, retornoDniInt);
            else
                throw new DniInvalidoException();

            return retornoDniInt;
        }

        private string ValidarNombreApellido(string dato)
        {
            Regex expresionRegular = new Regex("^[a-zA-ZÁÉÍÓÚáéíóú]*$");
            string retornoStr = null;

            if (expresionRegular.IsMatch(dato))
            {

                retornoStr = dato;
            }
                    

            return retornoStr;
        }

        #endregion

        #region Override
        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Nombre: {this.nombre} Apellido: {this.apellido}");
            sb.AppendLine($"Nacionalidad: {this.nacionalidad}");
            
            return sb.ToString();


        }

        #endregion

    }


}

