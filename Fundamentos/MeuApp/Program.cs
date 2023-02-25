using System;

/* Namespace */
namespace MyApp
{
    // class principal do programa
    internal class Program
    {
        // Funçao principal do programa
        static void Main(string[] args)
        {
            // var texto = "Testando";
            // Console.WriteLine(texto);

            // byte meuByte = 127;
            // sbyte meuSyte = -127;

            // int idade = -25;
            // uint uidade = 25;

            // short num = -30;
            // ushort unum = 30;

            // long num2 = -30;
            // ulong unum2 = 30;

            // float salario = 5000.50f;

            // double salarioBase = 5000.60;

            // decimal salarioAnual = 120000.50m;

            // bool usuarioCadastrado = false;

            // bool paymentReceived = true;

            // char primeiraLetra = 'C';

            // string primeiraString = "alguma coisa qualquer";

            // int? nome = null;

            // var converter = Convert.ToInt32("100");
            // Console.WriteLine(converter);

            int inteiro = 100;
            float real = 25.5f;

            // real = inteiro;

            // inteiro = (int)real;

            string valorReal = real.ToString();
            inteiro = int.Parse(valorReal);
            Console.WriteLine(inteiro);
        }
    }
}



// See https://aka.ms/new-console-template for more information
