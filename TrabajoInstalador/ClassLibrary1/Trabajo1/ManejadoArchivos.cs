using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo1
{
    public class ManejadoArchivos
    {
        public string Archivo { get; set; }
        public ManejadoArchivos(string archivo)
        {
            Archivo = archivo;
        }
        public string LeerA()
        {
            try
            {
                StreamReader file = new StreamReader(Archivo);
                string datos = file.ReadToEnd();
                file.Close();
                return datos;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
