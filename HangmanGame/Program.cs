using System;
using System.Collections.Generic;
using System.Text;
using static System.Random;

namespace HangmanGame
{
    internal class MainGame
    {
        private static string WordChoice(int difficulty)
        {
            List<string> fourLetter = new List<string> { "four", "good", "help", "fart" };
            List<string> sixLetter = new List<string> { "snazzy", "ornery", "coccyx", "python", "panzer" };
            List<string> eightLetter = new List<string> { "absolute", "graduate", "wildlife", "volatile" };
            Random random = new Random();
            if (difficulty == 4)
            {

                int index = random.Next(fourLetter.Count);
                string randomWord = fourLetter[index];
                return randomWord;
            }
            else if (difficulty == 6)
            {
                int index = random.Next(sixLetter.Count);
                string randomWord = sixLetter[index];
                return randomWord;
            }
            else // (difficulty == 8)
            {
                int index = random.Next(eightLetter.Count);
                string randomWord = eightLetter[index];
                return randomWord;
            }
            
        }
        private static void showNoose(int miss)
        {
            if (miss == 0)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (miss == 1)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("O   |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (miss == 2)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("O   |");
                Console.WriteLine("|   |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (miss == 3)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|  |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (miss == 4)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|\\ |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (miss == 5)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|\\ |");
                Console.WriteLine("/   |");
                Console.WriteLine("   ===");
            }
            else if (miss == 6)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("/ \\  |");
                Console.WriteLine("    ===");
            }
        }
        private static int showWord(List<char> lettersGuessed, String targetWord)
        {
            int counter = 0;
            int lettersCorrect = 0;
            foreach (char x in targetWord)
            {
                if (lettersGuessed.Contains(x))
                {
                    Console.Write(x + " ");
                    lettersCorrect += 1;
                }
                else
                {
                    Console.Write("  ");
                }
                //Console.Write("\r");
                counter += 1;
            }
            return lettersCorrect;
        }
        private static void blankLines(String targetWord)
        {
            Console.Write("\r");
            foreach (char c in targetWord)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.Write("\u0305 ");
            }
        }
        public static void Main(string[] args)
        {
            string? choice;
            int difficulty;
            string targetWord;
            Console.WriteLine("Welcome to hangman game");
            Console.WriteLine("Please Choose a Difficulty based on word length:4, 6, 8");
            choice = Console.ReadLine();
            if (choice != "4" && choice != "6" && choice != "8")
            {
                Console.WriteLine("Please choose either 4, 6, or 8");
                choice = Console.ReadLine();
            }
            int.TryParse(choice, out difficulty);
            targetWord = WordChoice(difficulty);
            //Console.WriteLine(targetWord);
            foreach (char x in targetWord)
            {
                Console.Write("_ ");
            }
            //char inputChar = 'A';
            int wrongGuesses = 0;
            int counter = 0;
            //int wordLength = targetWord.Length;
            int lettersRight = 0;
            List<char> lettersGuessed = new List<char>();

            while (wrongGuesses != 6 && lettersRight != targetWord.Length)
            {
                //char guess;
                Console.WriteLine("\n Letters you have guessed");
                foreach (char l in lettersGuessed)
                {
                    Console.Write(l + " ");
                }
                Console.Write("\r\n Guess a letter: ");
                string input = Console.ReadLine() ?? " "; // null error bs  
                char guess= char.Parse(input);    // = Console.ReadLine()[0];had to parse to char to make it work
                if (lettersGuessed.Contains(guess))
                {
                    Console.Write("\r\n{0} has already been guessed", guess);
                    showNoose(wrongGuesses);
                    lettersRight = showWord(lettersGuessed, targetWord);
                    blankLines(targetWord);
                }
                else
                {
                    bool correctLetter = false;
                    for (int i = 0; i < targetWord.Length; i++)
                    {
                        if (guess == targetWord[i])
                        {
                            correctLetter = true;
                        }
                    }

                    if (correctLetter == true)
                    {
                        //Console.Write("this code works"); used for testing purposes to make sure the code was getting to this point
                        showNoose(wrongGuesses);
                        lettersGuessed.Add(guess);
                        lettersRight = showWord(lettersGuessed, targetWord);
                        Console.Write("\r\n");
                        blankLines(targetWord);
                    }
                    else
                    {
                        wrongGuesses += 1;
                        lettersGuessed.Add(guess);
                        showNoose(wrongGuesses);
                        lettersRight = showWord(lettersGuessed, targetWord);
                        Console.Write("\r\n");
                        blankLines(targetWord);
                    }
                }
            }
            Console.WriteLine("\nThank you for Playing the game");
            Console.ReadLine();
        }
    }
}