using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo1
{
    public class Leer
    {
        ManejadoArchivos leerArchivo;
        ManejadoArchivos leerArchivo2;
        public Leer()
        {
            leerArchivo = new ManejadoArchivos("Contrasena.txt");
            leerArchivo2 = new ManejadoArchivos("Usuario.txt");
        }
        string letras;
        public string contrasena()
        {

            string datos = leerArchivo.LeerA();
            if (datos != null)
            {
                string[] lineas = datos.Split('\n');
                for (int i = 0; i < 1; i++)
                {
                    string[] campos = lineas[i].Split(' ');
                    letras = campos[0];
                }
            }
            
            return letras;
            
        }
        string letrasUsu;
        public string usuario()
        {
            string datos = leerArchivo2.LeerA();
            if (datos != null)
            {
                string[] lineas = datos.Split('\n');
                for (int i = 0; i < 1; i++)
                {
                    string[] campos = lineas[i].Split(' ');
                    letrasUsu = campos[0];
                }
            }
            return letrasUsu;

        }
    }
}
