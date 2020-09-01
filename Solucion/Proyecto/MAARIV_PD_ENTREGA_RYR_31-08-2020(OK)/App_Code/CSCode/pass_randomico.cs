/*
 *******************************************************************************************
  PROGRAMA				: pass_randomico.cs
  FECHA DE CREACION	    : Julio 13 de 2012
  FECHA DE MODIFICACION : Marzo 21 de 2017
  VERSION               : 1.1
  AUTOR                 : Gustavo Adolfo Caicedo Viveros

 *******************************************************************************************

  CLASE			        : pass_randomico
  RESPONSABILIDAD	    : Se encarga se encarga de crear una contraseña aleatoria
  COLABORACION		    : JULIAN A. BOCANEGRA M.
********************************************************************************************
*/

using System;
using System.Text;

namespace com.GACV.lgb.modelo.pass_randomico
{

    class pass_randomico
    {
        static int semilla;
        static Random rnd;

        protected static pass_randomico instancia_c;

        public pass_randomico() { }

        // Metodo generador de la única instancia de la clase retorna instancia de la clase        
        public static pass_randomico getInstancia_c()
        {
            if (instancia_c == null)
                instancia_c = new pass_randomico();
            return instancia_c;
        }
            
        public string contraseña_randomica()
	    {
		    semilla = (int)DateTime.Now.Ticks;
            rnd = new Random(semilla);

            string s = "";
            int alto = 10;
            int ancho = 10;
            //Console.WriteLine("Milisegundos: {0:#,#}", DateTime.Now.Ticks);
        
            for(int i = 1; i <= alto - 5; i++)
            {
                //s = cadenaAleatoria(ancho - 4);
                s = cadenaAleatoria(ancho - 5);
                //Console.WriteLine("{0:00} {1}", i, s);
            }

            return s;
	    }

        static string cadenaAleatoria(int longitud)
        {
            // Un objeto StrngBuilder para mejorar el rendimiento
            // del manejo de cadenas, además indicando la longitud
            // el rendimiento es mejor todavía
            StringBuilder s = new StringBuilder(longitud);

            // El objeto Random para generar los caracteres
            // con una semilla basada en los milisegundos actuales

            // Si se genera aquí, y se hacen varias llamadas seguidas
            // casi todas las cadenas serán iguales

            // Prueba 2:
            // Quita estos dos comentarios
            //semilla = DateTime.Now.Millisecond;
            //rnd = new Random(semilla);

            // desde la letra A Mayúscula (65)
            // hasta la letra Z en Mayúsculas (90)
            char c = (char)(rnd.Next(65, 91));
            // lo añadimos a la cadena
            s.Append(c);

            // Un bucle para cada uno de los caracteres
            for(int i = 1; i <= longitud; i++)
            {
                // Si se genera la semilla y el objeto random
                // dentro del bucle... ¡tu mismo!

                // Prueba 1:
                // Quita estos dos comentarios
                //semilla = DateTime.Now.Millisecond;
                //rnd = new Random(semilla);

                // El valor debe ser un carácter válido,
                // desde la letra a minúscula (97)
                // hasta la letra z en minúsculas (122)
                //char c = (char)(rnd.Next(97, 123));
                c = (char)(rnd.Next(97, 123));
                // lo añadimos a la cadena
                s.Append(c);
            }

            // desde el número 1 al 9 (1-9)
            int num = rnd.Next(1, 10);
            //c = Convert.ToChar(num);
            // lo añadimos a la cadena
            s.Append(num);

            // genera caracteres especiales (33-47)
            c = (char)(rnd.Next(33, 48));
            // lo añadimos a la cadena
            s.Append(c);

            // Devolvemos la cadena generada
            return s.ToString();
        }

     }

}
