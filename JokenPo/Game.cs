
namespace JokenPo;

public class Game
{
    public static void RunGame()
    {
        int rodada = 1;
        int vitoriasJogador = 0;
        int vitoriasComputador = 0;

        Random random = new Random();

        Console.WriteLine("===== JOKENPÔ =====");

        while (rodada <= 3)
        {
            Console.WriteLine($"\nRodada: {rodada}");
            Console.WriteLine("1 - Pedra");
            Console.WriteLine("2 - Papel");
            Console.WriteLine("3 - Tesoura");

            Console.Write("Escolha sua jogada: ");

            string? response = Console.ReadLine();

            int option;

            while (!int.TryParse(response, out option) ||
                   option < 1 || option > 3)
            {
                Console.WriteLine("Escolha inválida. Digite de 1 a 3:");
                response = Console.ReadLine();
            }

            int optionComputer = random.Next(1, 4);

            Console.WriteLine($"\nVocê escolheu: {ObterJogada(option)}");
            Console.WriteLine($"Computador escolheu: {ObterJogada(optionComputer)}");

            if (option == optionComputer)
            {
                Console.WriteLine("Empate nesta rodada!");
            }
            else if (VerificarVitoria(option, optionComputer))
            {
                Console.WriteLine("Você venceu esta rodada!");
                vitoriasJogador++;
            }
            else
            {
                Console.WriteLine("Computador venceu esta rodada!");
                vitoriasComputador++;
            }

            rodada++;
        }

        Console.WriteLine("\n===== RESULTADO FINAL =====");
        Console.WriteLine($"Suas vitórias: {vitoriasJogador}");
        Console.WriteLine($"Vitórias do computador: {vitoriasComputador}");

        if (vitoriasJogador > vitoriasComputador)
        {
            Console.WriteLine("Parabéns, você venceu o jogo!");
        }
        else if (vitoriasComputador > vitoriasJogador)
        {
            Console.WriteLine("O Computador venceu!");
        }
        else
        {
            Console.WriteLine("Jogo Finalizado");
        }
    }

    static string ObterJogada(int option)
    {
        return option switch
        {
            1 => "Pedra",
            2 => "Papel",
            3 => "Tesoura",
            _ => "Inválido"
        };
    }

    static bool VerificarVitoria(int player, int computer)
    {
        return (player == 1 && computer == 3) ||
               (player == 2 && computer == 1) ||
               (player == 3 && computer == 2);
    }
}
