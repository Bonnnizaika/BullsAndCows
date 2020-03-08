using System;
using System.Linq;

namespace BullsAndCows
{
    public static class Helper
    {
        public static bool InputCheck(int value) //Проверяет повторяются символы или нет
        {
            var array = new int[4];
            try
            {
                for (var i = 0; value > 0; i++)
                {
                    array[i] = value % 10;
                    value /= 10;
                }

                
                for (var b = 0; b < 4; b++)
                {
                    for (int j = 0, result = 0; j < 4; j++)
                    {
                        if (array[b] == array[j]) result++;
                        if (result != 2) continue;
                        Console.WriteLine("Некорректный запрос(Есть повторяющиеся символы)");
                        return true;
                    }
                }
            }
            catch
            {
                // ignored
            }
            return false;
        }

        public static bool IsTrueAnswer(string question, string answer) //Проверяет верный ли был дан ответ одним из игроков
        {
            int bulls = 0,
                cows = 0;

            try
            {
                for (var i = 0; i < 4; i++)
                {
                    for (var j = 0; j < 4; j++)
                    {
                        if (question[i] == answer[j] && i == j)
                            bulls++;
                        else if (question[i] == answer[j])
                            cows++;
                    }
                }

                if (bulls == 4)
                {
                    Console.WriteLine("Вы победили!");
                    return true;
                }
            }
            catch
            {
                // ignored
            }
            Console.WriteLine($"Быков: {bulls} \n" +
                              $" Коров: {cows}");
                return false;
        }
        public static bool IsTrueInput(string num)  //Проверяет всем ли требованиям соответствует введенное число 
        {
            var i = 0;

            if (num != "") i += num.Count();

            if (i < 4 && num != "")
            {
                Console.WriteLine("Некорректный запрос(Было введено меньше четырёх символов)");
                return true;
            }

            if (!int.TryParse(num, out _) && num != "")
            {
                Console.WriteLine("Некорректный запрос(Были введено(ы) не целочисленные значения!)");
                return true;
            }

            if (num == "")
            {
                Console.WriteLine("Некорректный запрос(Вы ничего не ввели!)");
                return true;
            }

            if (i > 4)
            {
                Console.WriteLine("Некорректный запрос(Было введено больше четырёх символов)");
                return true;
            }
            return false;
        }

        public static bool GuessingQuestion(ref string question, ref string answer, ref int number)
        {
            Console.WriteLine($"Угадывает игрок #{number}");
            switch (number)
            {
                case 1:
                    number++;
                    break;
                case 2:
                    number--;
                    break;
            }
            answer = Reading(answer);
            return Helper.IsTrueAnswer(question, answer);
        }
        public static string Reading(string player)
        {
            while (true)
            {
                player = Console.ReadLine();
                if (Helper.IsTrueInput(player)) continue;
                if (Helper.InputCheck(Convert.ToInt32(player)) == false && Helper.IsTrueInput(player) == false)
                    return player;
            }
        }
    }
}
