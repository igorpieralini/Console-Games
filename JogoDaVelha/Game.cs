namespace JogoDaVelha;

public class Game
{
    public static void RunGame()
    {
        int rodada = 1;
        char caractere = 'X';

        int result;
        char[,] tabuleiro = new char[3, 3];

        Console.WriteLine("Jogo da Velha");

        while (rodada <= 9)
        {
            Console.WriteLine($"\nRodada: {rodada}");
            Console.WriteLine($"Vez do jogador: {caractere}");

            ImprimirTabuleiro(tabuleiro);

            Console.Write("Digite qual posição você deseja (1 - 9): ");

            string? response = Console.ReadLine();

            while (!int.TryParse(response, out result) ||
                   result < 1 || result > 9)
            {
                Console.WriteLine("Digite uma posição válida entre 1 e 9.");
                response = Console.ReadLine();
            }

            int linha = (result - 1) / 3;
            int coluna = (result - 1) % 3;

            while (tabuleiro[linha, coluna] != '\0')
            {
                Console.WriteLine("Essa posição já está ocupada. Escolha outra:");

                response = Console.ReadLine();

                while (!int.TryParse(response, out result) ||
                       result < 1 || result > 9)
                {
                    Console.WriteLine("Digite uma posição válida entre 1 e 9.");
                    response = Console.ReadLine();
                }

                linha = (result - 1) / 3;
                coluna = (result - 1) % 3;
            }

            tabuleiro[linha, coluna] = caractere;

            ImprimirTabuleiro(tabuleiro);

            if (VerificarVitoria(tabuleiro, caractere))
            {
                Console.WriteLine($"Jogador {caractere} venceu!");
                return;
            }

            rodada++;

            caractere = caractere == 'X' ? 'O' : 'X';
        }

        Console.WriteLine("Empate! Ninguém venceu.");
    }

    static void ImprimirTabuleiro(char[,] tabuleiro)
    {
        int posicao = 1;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(tabuleiro[i, j] == '\0'
                    ? $" {posicao} "
                    : $" {tabuleiro[i, j]} ");

                if (j < 2)
                    Console.Write("|");

                posicao++;
            }

            Console.WriteLine();

            if (i < 2)
                Console.WriteLine("---|---|---");
        }
    }

    static bool VerificarVitoria(char[,] tabuleiro, char jogador)
    {
        // verifica por linhas
        for (int i = 0; i < 3; i++)
        {
            if (tabuleiro[i, 0] == jogador &&
                tabuleiro[i, 1] == jogador &&
                tabuleiro[i, 2] == jogador)
            {
                return true;
            }
        }
        
        // verifica por colunas
        for (int i = 0; i < 3; i++)
        {
            if (tabuleiro[0, i] == jogador &&
                tabuleiro[1, i] == jogador &&
                tabuleiro[2, i] == jogador)
            {
                return true;
            }
        }

        // verifica diagonal primária
        if (tabuleiro[0, 0] == jogador &&
            tabuleiro[1, 1] == jogador &&
            tabuleiro[2, 2] == jogador)
        {
            return true;
        }
        
        // verifica diagonal secundária
        if (tabuleiro[0, 2] == jogador &&
            tabuleiro[1, 1] == jogador &&
            tabuleiro[2, 0] == jogador)
        {
            return true;
        }

        return false;
    }
}