using System.Formats.Asn1;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hangman!");
            Console.WriteLine("Loading words...");
            string[] animals;
            try
            {
                animals = File.ReadAllLines("animals.txt");
            }
            catch
            {
                Console.WriteLine("Error: 'animals.txt' file not found. Please ensure the file is in the correct location.");
                return;
            }
            Console.WriteLine("Words loaded successfully!");
            //string[] animals = { "elephant", "giraffe", "alligator", "kangaroo", "dolphin", "lion", "ostrich", "penguin" };
            Console.WriteLine("Guess a letter to complete an animal!");
            Random random = new Random();
            string word = animals[random.Next(animals.Length)];
            char[] guessedLetters = new char[word.Length];
            for (int i = 0; i < guessedLetters.Length; i++)
            {
                guessedLetters[i] = '_';
            }
            int attemptsLeft = 6;
            while (attemptsLeft > 0 && new string(guessedLetters) != word)
            {
                Console.Clear();
                Console.WriteLine("");
                DisplayHangman(attemptsLeft);
                Console.WriteLine($"Word: {new string(guessedLetters)}");
                Console.WriteLine($"Attempts left: {attemptsLeft}");
                Console.Write("Enter a letter: ");
                string? input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && input.Length == 1 && char.IsLetter(input[0]))
                {
                    char guessedLetter = char.ToLower(input[0]);
                    if (word.Contains(guessedLetter))
                    {
                        for (int i = 0; i < word.Length; i++)
                        {
                            if (word[i] == guessedLetter)
                            {
                                guessedLetters[i] = guessedLetter;
                            }
                        }
                    }
                    else
                    {
                        attemptsLeft--;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a single valid letter.");
                    Console.ReadKey();
                }
            }
            if (new string(guessedLetters) == word)
            {
                Console.Clear();
                Console.WriteLine("");
                DisplayHangman(-1);
                Console.WriteLine($"Congratulations! You've guessed the word: {word}");
                Console.WriteLine("Would you like to try again? (y/n)");
                string? playAgain = Console.ReadLine();
                if (playAgain == "Y" || playAgain == "y")
                {
                    Main(args);
                }
                else
                {
                    Console.WriteLine("Thanks for playing!");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("");
                DisplayHangman(attemptsLeft);
                Console.WriteLine("Game over! You ran out of attempts.");
                Console.WriteLine($"The word was: {word}");
                Console.WriteLine("Would you like to try again? (y/n)");
                string? playAgain = Console.ReadLine();
                if (playAgain == "Y" || playAgain == "y")
                {
                    Main(args);
                }
                else
                {
                    Console.WriteLine("Thanks for playing!");
                    Console.ReadKey();
                }

            }

        }
        static void DisplayHangman(int attemptsLeft)
        {
            switch (attemptsLeft)
            {
                case 6:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;
                case 5:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  O   |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;
                case 4:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  O   |");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;
                case 3:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  O   |");
                    Console.WriteLine(" /|   |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;
                case 2:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  O   |");
                    Console.WriteLine(" /|\\  |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;
                case 1:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  O   |");
                    Console.WriteLine(" /|\\  |");
                    Console.WriteLine(" /    |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;
                case 0:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  O   |");
                    Console.WriteLine(" /|\\  |");
                    Console.WriteLine(" / \\  |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;
                case -1:
                    Console.WriteLine("        ");
                    Console.WriteLine("    :D  ");
                    Console.WriteLine("   /|\\  ");
                    Console.WriteLine("   / \\  ");
                    Console.WriteLine("=========");
                    break;
            }
}
    }

}
