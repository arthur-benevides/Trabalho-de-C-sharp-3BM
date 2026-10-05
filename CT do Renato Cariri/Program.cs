using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CT_do_Renato_Cariri
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Grupo: Arthur Benevides, Davi Ramos, Miguel Ferreira, Willian Paz, Wilmar Vinhas
            //Exibir o cabeçalho do programa
            Cabeçalho("CT do Renato Cariri");
            Console.WriteLine("Bem-vindo ao programa de controle de frequência e treinos dos alunos do CT do Renato Cariri!");

            //Vetor de nomes dos alunos
            string[] nomes =
            {
                "Carlos",
                "Miguel",
                "Benevides",
                "Nelson",
                "Breno"
            };

            //Pesquisa sequencial de um nome no vetor de nomes
            Console.WriteLine("\nNome para ser procurado: ");
            string nomeProcurado = "Benevides";

            int posicao = PesquisaSequencial(nomes, nomeProcurado);

            if (posicao != -1)
            {
                Console.WriteLine($"O nome {nomeProcurado} foi encontrado na posição {posicao + 1}/5.");
            }
            else
            {
                Console.WriteLine($"O nome {nomeProcurado} não foi encontrado.");
            }

            //Frequencia dos alunos em uma matriz
            int[,] frequencia = new int[,]
            {
                {1, 1, 1, 0, 1, 1, 0 }, //Carlos
                {0, 1, 1, 1, 0, 1, 1 }, //Miguel
                {0, 1, 0, 1, 0, 1, 0 }, //Benevides
                {1, 1, 1, 1, 1, 1, 1 }, //Nelson
                {0, 1, 0, 1, 0, 0, 0 }  //Breno
            };

            string[][] treinos =
            {
                new string [] {"Peito", "Perna", "Costas", "Superiores", "Inferiores"},
                new string [] {"Quadriceps", "Superiores", "Posterior", "Glúteos", "Abdomen"},
                new string [] {"Posterior de Dorsal", "Inferior de Bacia", "Esternocleidomastóideo"},
                new string [] {"Peito", "Glúteos", "Peito", "Glúteos", "Peito", "Glúteos", "Peito" },
                new string [] {"Pescoço", "Glúteos" }
            };

            double[] mensalidade = { 150.00, 120.00, 167.42, 60.00, 200.00 };

            // Funçao Local
            double CalcularFaturamento()
            {
                double total = 0;
                for (int i = 0; i < mensalidade.Length; i++)
                {
                    total += mensalidade[i];
                }
                return total;
            }
            Double FatMensal = CalcularFaturamento();


            // Exibir os dados completos antes da ordenação
            Cabeçalho("Nomes antes de Ordenar");
            ExibirDadosCompletos(nomes, frequencia, treinos, mensalidade);

            // Ordenar os nomes em ordem alfabética usando Bubble Sort
            Cabeçalho("Nomes Em Ordem Alfabetica!");

            BubbleSort(nomes, frequencia, treinos, mensalidade);

            //Dados apos ordenaçao
            ExibirDadosCompletos(nomes, frequencia, treinos, mensalidade);

            // Pesquisa Binária (após ordenação)
            string nomeBuscaBinaria = "Nelson";
            int posBinaria = PesquisaBinaria(nomes, nomeBuscaBinaria);

            Console.WriteLine($"\n[Pesquisa Binária] Procurando {nomeBuscaBinaria} no vetor ordenado");
            if (posBinaria != -1)
                Console.WriteLine($"O nome {nomeBuscaBinaria} foi encontrado na posição ordenada {posBinaria + 1}/5.");
            else
                Console.WriteLine($"O nome {nomeBuscaBinaria} não foi encontrado.");

            //Exibiçao da funçao local
            Console.WriteLine($"\nO faturamento do CT DO CARIRI este mês foi de R${FatMensal}");

            Cabeçalho("     FIM DO PROGRAMA");

        }
        // Função para exibir o cabeçalho do programa
        static void Cabeçalho(string Título)
        {
            Console.WriteLine("\n===================================");
            Console.WriteLine($"  {Título}");
            Console.WriteLine("===================================");
        }

        // Função para trocar os nomes de posição
        static void TrocarNomes(ref string a, ref string b)
        {
            string temp = a;
            a = b;
            b = temp;
        }

        // Função para trocar as mensalidades de posição
        static void TrocarMensalidade(ref double a, ref double b)
        {
            double temp = a;
            a = b;
            b = temp;
        }


        // Função para trocar os treinos de posição
        static void TrocarTreinos(ref string[] a, ref string[] b)
        {
            string[] temp = a;
            a = b;
            b = temp;
        }


        // Função para ordenar os nomes em ordem alfabética usando Bubble Sort
        static void BubbleSort(string[] nomes, int[,] frequencia, string[][] treinos, double[] mensalidade)
        {
            int n = nomes.Length;
            int numDiasFrequencia = frequencia.GetLength(1);

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (nomes[j].CompareTo(nomes[j + 1]) > 0)
                    {
                        TrocarNomes(ref nomes[j], ref nomes[j + 1]);
                        TrocarMensalidade(ref mensalidade[j], ref mensalidade[j + 1]);
                        TrocarTreinos(ref treinos[j], ref treinos[j + 1]);

                        for (int k = 0; k < numDiasFrequencia; k++)
                        {
                            int tempFreq = frequencia[j, k];
                            frequencia[j, k] = frequencia[j + 1, k];
                            frequencia[j + 1, k] = tempFreq;
                        }
                    }
                }
                Console.WriteLine("");
            }
        }

        // Função para exibir os dados completos dos alunos
        static void ExibirDadosCompletos(string[] nomes, int[,] frequencia, string[][] treinos, double[] mensalidade)
        {
            for (int i = 0; i < nomes.Length; i++)
            {
                Console.WriteLine($"\n Aluno: {nomes[i]}");
                Console.WriteLine($"   Mensalidade: R$ {mensalidade[i]:f2}");
                Console.Write($"   Treinos: {string.Join(", ", treinos[i])}");
                Console.WriteLine();

                Console.Write("   Frequência (7 dias): [ ");
                for (int k = 0; k < frequencia.GetLength(1); k++)
                {
                    Console.Write(frequencia[i, k] + " ");
                }
                Console.WriteLine("]");
            }
        }

        // Função para realizar a pesquisa sequencial de um nome no vetor de nomes
        static int PesquisaSequencial(string[] nomes, string nomeProcurado)
        {
            for (int i = 0; i < nomes.Length; i++)
            {
                if (nomes[i] == nomeProcurado)
                    return i;
            }
            return -1;
        }

        //Função de Pesquisa Binária sobre vetor ordenado
        static int PesquisaBinaria(string[] nomes, string nomeProcurado)
        {
            int meio;
            int Min = 0;
            int Max = nomes.Length - 1;

            do
            {
                meio = (Min + Max) / 2;

                if (nomes[meio] == nomeProcurado)
                {

                    return meio;
                }
                else if (nomeProcurado.CompareTo(nomes[meio]) > 0)
                {
                    Min = meio + 1;
                }
                else
                {
                    Max = meio - 1;
                }

            } while (Min <= Max);

            // Caso o retorno for -1, então o aluno não existe na sequência.
            return -1;
        }
    
    }
}
