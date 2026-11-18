namespace JogoDaForca;

public class Game
{
    public static void RunGame()
    {
        string[] palavras = { "COMPUTADOR", "PROGRAMACAO", "DESENVOLVEDOR", "ALGORITMO", "SOFTWARE" };

        Random random = new Random();

        string palavra = palavras[random.Next(palavras.Length)];
        char[] palavraOculta = new char[palavra.Length];

        int tentativas = 6;
        List<char> letrasUtilizadas = new List<char>();

        for (int i = 0; i < palavra.Length; i++)
        {
            palavraOculta[i] = '_';
        }

        Console.WriteLine("JOGO DA FORCA");

        while (tentativas > 0)
        {
            Console.WriteLine($"\nTentativas restantes: {tentativas}");

            Console.WriteLine($"Palavra: {string.Join(" ", palavraOculta)}");

            Console.WriteLine($"Letras utilizadas: {string.Join(", ", letrasUtilizadas)}");

            Console.Write("\nDigite uma letra: ");

            string? response = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(response) ||
                   response.Length != 1 ||
                   !char.IsLetter(response[0]))
            {
                Console.WriteLine("Digite apenas uma letra válida.");
                response = Console.ReadLine();
            }

            char letra = char.ToUpper(response[0]);

            if (letrasUtilizadas.Contains(letra))
            {
                Console.WriteLine("Você já utilizou essa letra. Tente novamente.");
                continue;
            }

            letrasUtilizadas.Add(letra);

            if (palavra.Contains(letra))
            {
                Console.WriteLine("Você acertou!");

                for (int i = 0; i < palavra.Length; i++)
                {
                    if (palavra[i] == letra)
                    {
                        palavraOculta[i] = letra;
                    }
                }
            }
            else
            {
                Console.WriteLine("Você errou!");
                tentativas--;
            }

            if (new string(palavraOculta) == palavra)
            {
                Console.WriteLine($"\nParabéns! Você descobriu a palavra: {palavra}");
                return;
            }
        }

        Console.WriteLine("\nVocê perdeu!");
        Console.WriteLine($"A palavra era: {palavra}");
    }
}