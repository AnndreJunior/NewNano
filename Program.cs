namespace NewNano;

class Program
{
    public static void Main(string[] args)
    {
        MainMenu();
    }

    static void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("O que você deseja fazer?");
        Console.WriteLine("1. Abrir arquivo");
        Console.WriteLine("2. Criar arquivo");
        Console.WriteLine("0. Sair");
        Console.Write("Opção: ");
        short option = short.Parse(Console.ReadLine());

        switch (option)
        {
            case 0:
                Environment.Exit(0);
                break;
            case 1:
                OpenFile();
                break;
            case 2:
                CreateFile();
                break;
            default:
                MainMenu();
                break;
        }
    }

    static void OpenFile()
    {
        Console.Clear();
        Console.WriteLine("Qual o caminho do arquivo?");
        string path = Console.ReadLine();

        using (var file = new StreamReader(path))
        {
            Console.Clear();
            string text = file.ReadToEnd();
            Console.WriteLine(text);
            Console.WriteLine("-----------------");
        }
        Console.WriteLine("Pressione qualquer tecla para continuar");
        Console.ReadKey();
        MainMenu();
    }

    static void CreateFile()
    {
        Console.Clear();
        Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
        Console.WriteLine("-----------------------");
        string text = "";

        do
        {
            text += Console.ReadLine();
            // adding break lines in the text
            text += Environment.NewLine;
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
        SaveFile(text);
    }

    static void SaveFile(string text)
    {
        Console.Clear();
        Console.WriteLine("Qual o caminho para salvar o arquivo?");

        var path = Console.ReadLine();

        // gera o objeto e já fecha ele, assim evitando dores de cabeça em relação a memória
        using (var file = new StreamWriter(path) /*recebe o path para salvar*/)
        {
            file.Write(text); // salva o arquivo no path enviado para o StreamWriter
        }
        Console.WriteLine($"Arquivo salvo com sucesso no diretório {path}");
        Console.WriteLine("Aperte qualquer tecla para continuar");
        Console.ReadKey();
        MainMenu();
    }
}
