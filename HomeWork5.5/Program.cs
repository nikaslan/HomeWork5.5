using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5._5
{
    class Program
    {
        /// <summary>
        /// Метод перевода строки в массив слов. В строке слова разделены одним пробелом
        /// </summary>
        /// <param name="inputSentence">Строка, которую надо разбить на слова</param>
        /// <returns></returns>
        static string[] SplitStringIntoWords(string inputSentence)
        {
            string tempWord; // текущее слово, которое мы читаем до пробела
            int letterCount; // количество символов в текущем слове
            int readPosition = 0; // место начала нового слова. В начале стоит на 0.
            bool spaceBeforeWord = true; // индикатор, что следующий "не пробел" начинает новое слово
            int wordCount = 0; //колличество слов в строке
            string[] wordArray;

            // сначала подсчитываем количество слов в строке
            for (int i = 0; i < inputSentence.Length; i++)
            {
                string readLetter = inputSentence.Substring(i, 1);
                if (readLetter == " ")
                {
                    spaceBeforeWord = true;
                }
                else
                {
                    if (spaceBeforeWord)
                    {
                        wordCount++;
                        spaceBeforeWord = false;
                    }
                }
            }

            wordArray = new string[wordCount];
            // читаем слово и записываем в массив, повторяем пока не запишем все слова
            while(wordCount!=0)
            {
                letterCount = 0;
                tempWord = "";

                while (readPosition < inputSentence.Length)
                {
                    
                    string readLetter = inputSentence.Substring(readPosition, 1);
                    readPosition++; // переходим на следующий символ для чтения

                    if (readLetter != " ")
                    {
                        tempWord += readLetter;
                        letterCount++;
                    }
                    else
                    {
                        break;
                    }                    
                }
                if (letterCount != 0) //записываем "непустые" слова в массив
                {
                    wordArray[(wordArray.Length - wordCount)] = tempWord;
                    wordCount--;
                }

            }      
                        
            return wordArray;
        }

        static void PrintArray(string[] arrayToPrint)
        {
            foreach (var element in arrayToPrint)
            {
                Console.WriteLine(element);
            }
            return;
        }
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // без этого кириллица в консоли превращается в символы
            // объявление переменных

            string sentence; // введенная строка
            string[] splitSentence; //массив слов оригинальной строки

            // основная логика

            Console.WriteLine("Пожалуйста введите предложение, по окончанию нажмите Enter");
            sentence = Console.ReadLine();

            splitSentence = SplitStringIntoWords(sentence);
            Console.WriteLine("\nВывод строки по словам \n");
            PrintArray(splitSentence);
            Console.ReadKey();
        }
    }
}
