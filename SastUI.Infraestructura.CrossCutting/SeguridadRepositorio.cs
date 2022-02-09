using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SastUI.Infraestructura.CrossCutting
{
    public class SeguridadRepositorio
    {
        public class Encrypt
        {
            public static string Encriptar(string str)
            {
                SHA256 sha256 = SHA256Managed.Create();
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] stream = null;
                StringBuilder sb = new StringBuilder();
                stream = sha256.ComputeHash(encoding.GetBytes(str));
                for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
                return sb.ToString();
            }

        }

        public KeyPressEventArgs ValidarNumeros(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;

            return e;
        }

        public KeyPressEventArgs ValidarLetras(KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
                e.Handled = true;

            return e;
        }

        public bool ValidarEmail(string email)
        {
            bool validacion = false;
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                    validacion = true;
            }

            return validacion;
        }

        public bool ValidarCedula(string cedula)
        {
            int isNumeric;
            var total = 0;
            const int tamanioLongCedula = 10;
            int[] coeficientes = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            const int numeroProvincias = 24;
            const int tecerDigito = 6;
            bool retorno = false;

            if (int.TryParse(cedula, out isNumeric) && cedula.Length == tamanioLongCedula)
            {
                var provincia = Convert.ToInt32(string.Concat(cedula[0], cedula[1], string.Empty));
                var digitoTres = Convert.ToInt32(cedula[2] + string.Empty);
                if((provincia > 0 && provincia <= numeroProvincias) && digitoTres < tecerDigito)
                {
                    var digitoVerificadoRecibido = Convert.ToInt32(cedula[9] + string.Empty);
                    for(var i = 0; i < coeficientes.Length; i++)
                    {
                        var valor = Convert.ToInt32(coeficientes[i] + string.Empty) * Convert.ToInt32(cedula[i] + string.Empty);
                        total = valor >= 10 ? total + (valor - 9) : total + valor;
                    }
                    var digitoVerficadorObtenido = total >= 10 ? (total % 10) != 0 ? 10 - (total % 10) : (total % 10) : total;

                    retorno = digitoVerificadoRecibido == digitoVerficadorObtenido;
                }
            }

            return retorno;
        }

        public bool VerificarIdentificacion(string identificacion)
        {
            string tipoIdentificacion = identificacion.Substring(0, 1);

            if (tipoIdentificacion == "P" || tipoIdentificacion == "p")
                return true;
            else
            {
                bool estado = false;
                char[] valced = new char[13];
                int provincia;
                if (identificacion.Length >= 10)
                {
                    valced = identificacion.Trim().ToCharArray();
                    provincia = int.Parse((valced[0].ToString() + valced[1].ToString()));
                    if (provincia > 0 && provincia < 25)
                    {
                        if (int.Parse(valced[2].ToString()) < 6)
                        {
                            estado = VerificarCedula(valced);
                        }
                        else if (int.Parse(valced[2].ToString()) == 6)
                        {
                            estado = VerificarSectorPublico(valced);
                        }
                        else if (int.Parse(valced[2].ToString()) == 9)
                        {

                            estado = VerificarPersonaJuridica(valced);
                        }
                    }
                }
                return estado;
            }            
        }

        public bool VerificarCedula(char[] validarCedula)
        {
            int aux = 0, par = 0, impar = 0, verifi;
            for (int i = 0; i < 9; i += 2)
            {
                aux = 2 * int.Parse(validarCedula[i].ToString());
                if (aux > 9)
                    aux -= 9;
                par += aux;
            }
            for (int i = 1; i < 9; i += 2)
            {
                impar += int.Parse(validarCedula[i].ToString());
            }

            aux = par + impar;
            if (aux % 10 != 0)
            {
                verifi = 10 - (aux % 10);
            }
            else
                verifi = 0;
            if (verifi == int.Parse(validarCedula[9].ToString()))
                return true;
            else
                return false;
        }

        public bool VerificarPersonaJuridica(char[] validarCedula)
        {
            int aux = 0, prod, veri;
            veri = int.Parse(validarCedula[10].ToString()) + int.Parse(validarCedula[11].ToString()) + int.Parse(validarCedula[12].ToString());
            if (veri > 0)
            {
                int[] coeficiente = new int[9] { 4, 3, 2, 7, 6, 5, 4, 3, 2 };
                for (int i = 0; i < 9; i++)
                {
                    prod = int.Parse(validarCedula[i].ToString()) * coeficiente[i];
                    aux += prod;
                }
                if (aux % 11 == 0)
                {
                    veri = 0;
                }
                else if (aux % 11 == 1)
                {
                    return false;
                }
                else
                {
                    aux = aux % 11;
                    veri = 11 - aux;
                }

                if (veri == int.Parse(validarCedula[9].ToString()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool VerificarSectorPublico(char[] validarCedula)
        {
            int aux = 0, prod, veri;
            veri = int.Parse(validarCedula[9].ToString()) + int.Parse(validarCedula[10].ToString()) + int.Parse(validarCedula[11].ToString()) + int.Parse(validarCedula[12].ToString());
            if (veri > 0)
            {
                int[] coeficiente = new int[8] { 3, 2, 7, 6, 5, 4, 3, 2 };

                for (int i = 0; i < 8; i++)
                {
                    prod = int.Parse(validarCedula[i].ToString()) * coeficiente[i];
                    aux += prod;
                }

                if (aux % 11 == 0)
                {
                    veri = 0;
                }
                else if (aux % 11 == 1)
                {
                    return false;
                }
                else
                {
                    aux = aux % 11;
                    veri = 11 - aux;
                }

                if (veri == int.Parse(validarCedula[8].ToString()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
