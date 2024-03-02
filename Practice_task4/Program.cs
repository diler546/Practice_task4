using System;
using System.Text.RegularExpressions;

namespace Cheesboard
{
    class Program
    {
        static string input = "";
        static string kingCoordinates = "";
        static string figureCoordinates = "";

        static bool IsValidChessCoordinateFormat()
        {
            string patter = @"^[a-h]+[1-8]\s[a-h]+[1-8]$";
            return Regex.IsMatch(input, patter);
        }

        static void EnteringString()
        {
            Console.WriteLine("Введите координаты короля x1y1 и координаты фигуры x2y2(Пример:a1 a2): ");
            input = Console.ReadLine().ToLower();
        }

        static void SplittingAString()
        {
            string[] parts = input.Split(' ');
            kingCoordinates = parts[0];
            figureCoordinates = parts[1];
        }

        static void ConvertChessCoordinatesToArray(string str, out int[] shape)
        {
            shape = new int[2];
            switch (str[0])
            {
                case 'a': shape[0] = 0; break;
                case 'b': shape[0] = 1; break;
                case 'c': shape[0] = 2; break;
                case 'd': shape[0] = 3; break;
                case 'e': shape[0] = 4; break;
                case 'f': shape[0] = 5; break;
                case 'g': shape[0] = 6; break;
                case 'h': shape[0] = 7; break;
            }

            shape[1] = Convert.ToInt32(str[1].ToString()) - 1;
        }

        static bool IsKingTargetingFigure()
        {
            int[] kingPosition = new int[2];

            int[] figurePosition = new int[2];

            ConvertChessCoordinatesToArray(kingCoordinates, out kingPosition);

            ConvertChessCoordinatesToArray(figureCoordinates, out figurePosition);

            for (int i = kingPosition[1] - 1; i <= kingPosition[1] + 1; i++)
            {
                for (int j = kingPosition[0] - 1; j <= kingPosition[0] + 1; j++)
                {
                    if (i == figurePosition[1] && j == figurePosition[0])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        static void CanKingAttack()
        {
            if (IsKingTargetingFigure())
            {
                Console.WriteLine("Король сможет побить фигуру");
            }
            else
            {
                Console.WriteLine("Король не сможет побить фигуру");
            }
        }

        static bool CheckKingMoveValidity()
        {
            if (!(IsValidChessCoordinateFormat()))
            {
                Console.WriteLine("Вы вели строку неправильного формата \n" +
                                  "Формат:a1 a2");
                return true;
            }
            else if (input[0] == input[3] && input[1] == input[4])
            {
                Console.WriteLine("Вы вели одинаковые позиции фигур \n" +
                                  "Введите разные позиции фигур");
                return true;
            }
            return false;
        }

        static void Main()
        {
            do
            {
                EnteringString();

            } while (CheckKingMoveValidity());

            SplittingAString();

            CanKingAttack();

        }
    }
}