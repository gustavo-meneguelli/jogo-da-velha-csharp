namespace Jogo_Da_Velha_App
{
    internal class Program
    {
        public static int player = 1;
        public static string[,] matriz = new string[,]
        {
            {"1", "2", "3" }, //00, 01, 02
            {"4", "5", "6" }, //10, 11, 12
            {"7", "8", "9" }, //20, 21, 22
        };

        public static void Tabuleiro() 
        {
            Console.WriteLine("   {0}   |   {1}   |   {2}   ", matriz[0, 0], matriz[0, 1], matriz[0, 2]);
            Console.WriteLine("   {0}   |   {1}   |   {2}   ", matriz[1, 0], matriz[1, 1], matriz[1, 2]);
            Console.WriteLine("   {0}   |   {1}   |   {2}   ", matriz[2, 0], matriz[2, 1], matriz[2, 2]);
        }//Estrutura do Jogo da Velha
        public static void Partida() 
        {
            bool encerrarPartida = false;

            do
            {
                Console.Clear();
                Tabuleiro();
                Console.Write("\nPlayer ({0}) joga: ", player);
                try
                {
                    int inputPlayer = Convert.ToInt32(Console.ReadLine());
                    Jogadas(inputPlayer);
                    Console.Clear();
                    Tabuleiro();
                    if (TemGanhador())
                        encerrarPartida = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Digite um número válido para jogar.");
                    Console.ReadKey();
                }
            } while (!encerrarPartida);

        }//Gerenciar a Partida em tempo real
        public static void Jogadas(int numeroDaJogada) 
        {
            //O jogo da velha possui 9 campos jogáveis, então o número da jogada precisa esta entre 1 e 9 
            if (numeroDaJogada > 0 && numeroDaJogada < 10)  
            {
                int linha = (numeroDaJogada - 1) / 3; 
                int coluna = (numeroDaJogada - 1) % 3; 

                if (matriz[linha, coluna] == "X" || matriz[linha, coluna] == "O") 
                {
                    Console.WriteLine("Valor do campo já foi preenchido, digite outro valor");
                    Console.ReadKey();
                }
                else
                {
                    matriz[linha, coluna] = player == 1 ? "X" : "O";

                    if (player == 1)
                        player = 2;
                    else
                        player = 1;
                }
            }
            else
            {
                Console.WriteLine("Número inválido, digite um número válido.");
                Console.ReadKey();
            }
        }//Jogadas do Usuario
        public static bool TemGanhador()
        {
            //verificação horizontal e vertical
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                if((matriz[i, 0].Equals(matriz[i, 1]) && matriz[i, 1].Equals(matriz[i, 2])) || (matriz[0, i].Equals(matriz[1, i]) && matriz[1, i].Equals(matriz[2, i])))
                {
                    AnunciarGanhador();
                    return true;
                }
            }
            //Verificação diagonal
            if ((matriz[0, 0].Equals(matriz[1, 1]) && matriz[1, 1].Equals(matriz[2, 2])) || (matriz[0, 2].Equals(matriz[1, 1]) && matriz[1, 1].Equals(matriz[2, 0])))
            {
                AnunciarGanhador();
                return true;
            }
            return false;
        }  
        public static void AnunciarGanhador()
        {
            Console.WriteLine("Temos um vencedor!");
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            Partida();
        }
    }
}

