using System;
using Excepciones;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {

        public bool Guardar(string archivo, string datos)
        {
            bool pudoGuardar = false;

            try
            {
                if (!(archivo is null))
                {
                    using (StreamWriter sw = new StreamWriter(archivo))
                    {
                        sw.WriteLine(datos);
                        pudoGuardar = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }

            return pudoGuardar;
        }

        public bool Leer(string archivo, out string datos)
        {
            bool pudoLeer = false;
            datos = string.Empty;

            try
            {
                if (!(archivo is null))
                {
                    using (StreamReader sr = new StreamReader(archivo))
                    {
                        datos = sr.ReadToEnd();
                        pudoLeer = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }

            return pudoLeer;
        }
       
    }
}
