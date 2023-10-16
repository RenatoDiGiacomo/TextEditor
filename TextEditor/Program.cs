using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor
{
    internal class Program
    {

        /*
         FEATURES

        -- MELHORAR A FORMA DE EXIBIÇÃO
        -- COLOCAR UM CAMPO DE DIGITO
        -- NO ADD DE TEXTO , APRESENTAR SEM TER QUE APERTAR UM BTN ANTES DE COMEÇAR A DIGITAR
         */
        static void ExibirTexto(string arquivo)
        {
            try
            {
                string line = "";
                StreamReader sr = new StreamReader(arquivo);
                line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Mensagem: ");
                Console.WriteLine("Arquivo em Branco ou Não Existe");
            }
            Console.WriteLine("");
            Console.WriteLine("Pressione qualquer botão para continuar...");
            Console.ReadKey();
        }


        static void GravarTexto(string arquivo, string texto, bool add)
        {
            try
            {
                StreamWriter sr = new StreamWriter(arquivo, add);
                sr.WriteLine(texto);
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        static int Menu()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("Editor de Texto");
            Console.WriteLine("Escolha uma opção abaixo..");
            Console.WriteLine("================================");
            Console.WriteLine("(1) - Abrir/Criar um Arquivo");
            Console.WriteLine("(2) - Exibir o texto do Arquivo");
            Console.WriteLine("(3) - Cria novo um texto no arquivo");
            Console.WriteLine("(4) - Adiciona um Texto no arquivo");
            Console.WriteLine("(5) - Sair");
            Console.WriteLine("================================");

            Console.Write("Opção: ");
            int op = Convert.ToInt32(Console.ReadLine());

            return op;
        }
        static void Main(string[] args)
        {

            int op = 0;
            string arquivo = "";
            string texto = "";

            while (op < 5)
            {
                op = Menu();
                Console.Clear();
                switch (op)
                {
                    case 1:
                        Console.WriteLine("================================");
                        if (arquivo == "")
                        {
                            Console.WriteLine("Não tem arquivo aberto");
                            Console.WriteLine("Informe o nome do arquivo que irá abrir");
                            Console.WriteLine("Caso o arquivo não exista ele irá criar um com o nome que der");
                            Console.WriteLine("Exemplo: text.txt");
                            Console.WriteLine("");
                            arquivo = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("o arquivo {0} está aberto!!", arquivo);
                            Console.WriteLine("Pressione Qualquer tecla para voltar");
                            Console.ReadKey();
                        }
                        break;
                    case 2:
                        Console.WriteLine("==========================================");
                        Console.WriteLine("==============| {0} |==============", arquivo);
                        Console.WriteLine("==========================================");
                        Console.WriteLine("");
                        ExibirTexto(arquivo);
                        break;
                    case 3:
                        Console.WriteLine("================================");
                        Console.WriteLine("Gravar um texto no arquivo");
                        Console.WriteLine("================================");
                        Console.WriteLine("Digite o texto que irá gravar: ");
                        Console.Write("#:");
                        texto = Console.ReadLine();
                        GravarTexto(arquivo, texto, false);
                        break;
                    case 4:
                        Console.WriteLine("================================");
                        Console.WriteLine("Adicione um novo Texto no arquivo {0}", arquivo);
                        Console.WriteLine("================================");
                        ExibirTexto(arquivo);
                        Console.Write("#:");
                        texto = Console.ReadLine();
                        GravarTexto(arquivo, texto, true);
                        break;
                }
            }
        }
    }
}
