using System;

namespace BullsAndCows
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstPlayer = null,
                secondPlayer = null,
                firstPlayerAnswer = null,
                secondPlayerAnswer = null;
                var number = 1;

            Console.WriteLine("'Быки и коровы'\n" +
                              "Каждый игрок по очереди вводит четырехзначное число у которого не повторяются цифры \n" +
                              "Нажмите Enter чтобы начать");
            Console.ReadLine();

            Console.WriteLine("Игрок #1 вводит число: ");
            firstPlayer = Helper.Reading(firstPlayer);
                                                                        
            Console.WriteLine("Игрок #2 вводит число: ");
            secondPlayer = Helper.Reading(secondPlayer);

            while (true)            //Ввод ответов и проверка их на правильность
            {        
                if (Helper.GuessingQuestion(ref secondPlayer, ref firstPlayerAnswer, ref number)) break;
                if (Helper.GuessingQuestion(ref firstPlayer, ref secondPlayerAnswer, ref number)) break;
            }
        }
    }
}