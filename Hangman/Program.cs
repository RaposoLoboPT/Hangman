// Varíaveis/Arrays:

Dictionary<string, string[]> Words = [];

Words.Add("Jogos", ["Super Mario Bros", "The Legend of Zelda", "Pokemon", "Minecraft", "Stardew Valley"]);

Words.Add("Profições", ["Carteiro", "Medico", "Professor", "Programador", "Advogado", "Policia"]);

string[] Themes = ["Jogos", "Profições"];

Random rnd = new();

int themeMin;
int themeMax;
int theme;
string themeChoosed;

int wordMin;
int wordMax;
int word;
string wordChoosed;

List<string> letters = [];
List<string> wordTransformedList = [];

int attempts = 7;
var answer = "";
bool foundedLetter = false;

// Funções:

void chooseTheme()
{
    themeMin = 0;
    themeMax = Themes.Length;
    theme = rnd.Next(themeMin, themeMax);
    themeChoosed = Themes[theme];
}

void chooseWord()
{
    wordMin = 0;
    wordMax = Words[themeChoosed].Length;
    word = rnd.Next(wordMin, wordMax);
    wordChoosed = Words[themeChoosed][word];
}

void tranformWord()
{
    foreach (char letter in wordChoosed)
    {
        wordTransformedList.Add("_");
        
        letters.Add(letter.ToString().ToLower());
    }
}

void game()
{
    for (int c = 0; c < letters.Count; c++)
    {
        if (letters[c] == " ")
        {
            wordTransformedList[c] = " ";
        }
    }
    Console.WriteLine(string.Join(" ", wordTransformedList));
    do
    {
        Console.WriteLine("Diga uma letra:");
        answer = Console.ReadLine();

        if (answer is string)
        {
           if (answer.Length > 1)
            {
                Console.WriteLine("[Error] resposta invalida! Por favor coloque apenas uma letra.");
            }
            else
            {

                for (int i = 0; i < letters.Count; i++)
                {
                    if (answer == letters[i])
                    {
                        for (int j = 0; j < letters.Count; j++)
                        {
                            if (letters[j] == answer)
                            {
                                wordTransformedList[j] = answer;
                            }
                        }
                        foundedLetter = true;
                    }
                }
                
                Console.WriteLine(string.Join(" ", wordTransformedList));

                if (foundedLetter != true)
                {
                    attempts--;
                    Console.WriteLine($"Letra incorreta, faltam {attempts} tentativas!");
                }
            }
        }
        else
        {
            Console.WriteLine("[ERROR] Tipo inválido! Por favor responda uma Letra.");
        }
        foundedLetter = false;

    } while(attempts > 0 && wordTransformedList.Contains("_") == true);

    if (attempts == 0)
    {
        Console.WriteLine("Fim do Jogo!");
        Console.WriteLine($"Que pena, perdeste, a palavra era {wordChoosed}!");
    }
    else
    {
        Console.WriteLine("Fim do Jogo!");
        Console.WriteLine($"Parabéns, ganhaste, a palavra era {wordChoosed}!");
    }
}

void initGame()
{
    chooseTheme();
    chooseWord();
    tranformWord();
    game();
}

//Código:
initGame();