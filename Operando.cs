using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public class Operando
    {
        #region ATRIBUTOS

        private double numero;

        #endregion 

        #region PROPIEDADES
        private string Numero
        {
            //La propiedad Numero asignará un valor al atributo numero, previa validación.
            //En este lugar será el único en todo el código que llame al método ValidarOperando

            set
            {
                
                this.numero = this.ValidarOperando(value);
            }
        }
        #endregion

        #region CONSTRUCTORES
        public Operando()
        {
            this.numero = 0;
        }
        public Operando(double numero)
        {
            this.numero = numero;
        }
        public Operando(string strNumero)
        {
           this.Numero = strNumero;//asigna el stringNumero a la propiedad setNumero
        }
        #endregion

        #region METODOS

        private bool EsBinario(string binario)
        {
            bool esValido = true;
            int i = 0;
            while((i < binario.Length) && (esValido))
            {
                string digito = "";
                digito = binario[i].ToString();
                if ((digito != "0") && (digito != "1"))
                {
                    esValido= false;
                }
                i++;
            }
            return esValido;
        }

        public string BinarioDecimal(string binario)
        {
            string  retorno= "Valor invalido";

            double acum = 0;
            double numero = 0;
            double potencia = 0;
            potencia = binario.Length;

            if (EsBinario(binario))
            {
                for (int i = 0; i < binario.Length; i++)
                {
                    string digito = "";
                    potencia = (potencia - 1);

                    digito = binario[i].ToString();
                    if (double.TryParse(digito, out numero))
                    {
                        acum = acum + numero * (Math.Pow(2, potencia));
                    }
                }
                retorno = (Math.Abs((int)acum)).ToString();
            }
           
            return retorno;
        }

        public string DecimalBinario(double numero)
        {
            string cadena = "";


            int cociente = 0;
            int resto = 0;

            do
            {
                cociente = Math.Abs((int)numero / 2);
                resto = Math.Abs((int)numero % 2);

                numero = cociente;

                cadena = resto + cadena;

            }
            while (cociente != 0);

            return cadena;
        }
    
        public string DecimalBinario(string binario)
        {
        string cadena = "Valor invalido ";

        double numeroValidado = 0;
        if (double.TryParse(binario, out numeroValidado))
        {
            cadena = this.DecimalBinario(numeroValidado);

            return cadena;
        }
        return cadena;
    }

        private double ValidarOperando(string strNumero)
        {// ValidarNumero comprobará que el valor recibido sea numérico, y lo retornará en      
         // double. Caso contrario, retornará 0.
            
            double numeroValidado = 0;
            if(double.TryParse(strNumero,out numeroValidado))
            {
                return numeroValidado;
            }
            return numeroValidado;
        }
        #endregion

        #region SOBRECARGA DE OPERADORES
        //Los operadores realizarán las operaciones correspondientes entre dos números.
        public static double operator +(Operando n1,Operando n2)
        {
            double resultado = 0;
            resultado = n1.numero + n2.numero;
            return resultado;
        }

        public static double operator -(Operando n1, Operando n2)
        {
            double resultado = 0;
            resultado = n1.numero - n2.numero;
            return resultado;
        }

        public static double operator *(Operando n1, Operando n2)
        {
            double resultado = 0;
            resultado = n1.numero * n2.numero;
            return resultado;
        }

        public static double operator /(Operando n1, Operando n2)
        {

            double resultado = 0;
            if (n2.numero == 0)
            {
                return double.MinValue;//resultado;
            }
            else 
                { 
                resultado = n1.numero / n2.numero;
                return resultado;
                } 
        }
        #endregion
    }
}
