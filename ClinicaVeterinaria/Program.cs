using System;
using System.Linq;

namespace ClinicaVeterinaria
{
    class Program
    {
        static void Main(string[] args)
        {
            RegistarAnimal();
        }

        static void Menu()
        {
            Console.Write("");
        }

        static void RegistarAnimal()
        {
            string nome = "1";
            string especie = "1";
            int idade;
            Género genero = Género.Masculino;
            Console.WriteLine("REGISTAR ANIMAL DE ESTIMAÇÃO:");
            
            while (nome.All(char.IsDigit))
            {
                Console.Write("Insira o nome do animal (não pode conter dígitos): ");
                nome = Console.ReadLine();
            }

            while (especie.All(char.IsDigit))
            {
                Console.Write("Insira a espécie (não pode conter dígitos): ");
                especie = Console.ReadLine();
            }

            Console.Write("Insira a idade (não pode conter letras): ");
            string aux_Idade = Console.ReadLine();
            while (!int.TryParse(aux_Idade, out idade))
            {
                Console.Write("Insira a idade (não pode conter letras): ");
                aux_Idade = Console.ReadLine();
            }

            Console.Write("Insira o género (M-Masculino, F-Feminimo): ");
            string aux_Genero = Console.ReadLine();
            while (aux_Genero != "M" && aux_Genero != "F")
            {
                Console.Write("Insira o género (M-Masculino, F-Feminimo): ");
                aux_Genero = Console.ReadLine();
            }

            switch (aux_Genero) {
                case "M":
                    genero = Género.Masculino;
                    break;
                case "F":
                    genero = Género.Feminino;
                    break;
                default:
                    break;
            }

            AnimalEstimacao novoAnimal = new AnimalEstimacao(nome, idade, especie, genero);

        }

        static void RegistarCliente() { }

        static void RegistarProfissional()
        {

        }
    }
}
