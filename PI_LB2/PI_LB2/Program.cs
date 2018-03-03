using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PI_LB2
{
    class Program
    {
        // длина блока
        static int blockLength = 15;
        // левая граница алфавита
        static char leftRange = 'А';
        // правая граница алфавита
        static char rightRange = 'Я';
        // пробел
        static char space = ' ';
        // входная строка
        static string inputStr = "Я ВЫШЕЛ ИЗ ЛЕСУ БЫЛ СИЛЬНЫЙ МОРОЗ";
        static int[] indexMassiv = {13,8,2,0,6,1,10,14,16,11,3,15,5,9,7,12,4};
        // проверка строки на принадлежность к входному алфавиту
        static bool CheckStr(string s)
        {
            for (int i = 0; i < s.Length; i++)
                if ((s[i] < leftRange || s[i] > rightRange) && s[i] != space )
                    return false;
            return true;
        }
        // генерация функции подстановки
        static string Encode (string s, int length)
        {
            string outString="";
            for(int i = 0; i< length; i++)
            {
                outString += s[indexMassiv[i]];
            }
            return outString;
        }
        static string Decode(string s, int length)
        {
            string outString = "";
            for (int i = 0; i < length; i++)
                outString += space;
            StringBuilder builder = new StringBuilder(outString);
            for (int i = 0; i < length; i++)
            {
                
                builder[indexMassiv[i]] = s[i];
               
            }
            outString = builder.ToString();
            return outString;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Текст до шифрации: {0}", inputStr);
            //Проверка текста на принадлежность к входному алфавиту
            if (CheckStr(inputStr))
            {
                // расчет количества блоков
                int blockCount = inputStr.Length / blockLength;

                // дополнение недостающих элементов
                if (blockCount * blockLength < inputStr.Length)
                {
                    blockCount++;
                    while (inputStr.Length != blockCount * blockLength)
                        inputStr += space;
                }

                // разделение строки на блоки
                string[] inputStringMas = new string[blockCount];
                for (int i = 0; i < blockCount; i++)
                    inputStringMas[i] = inputStr.Substring(i * blockLength, blockLength);
                // шифрация
                for (int i = 0; i < blockCount; i++)
                    inputStringMas[i] = Encode(inputStringMas[i], blockLength);
                inputStr = "";
                // соединение в строку
                for (int i = 0; i < blockCount; i++)
                    inputStr += inputStringMas[i];
                Console.WriteLine("Текст после шифрации: {0}", inputStr);
                // разделение строки на блоки
                for (int i = 0; i < blockCount; i++)
                    inputStringMas[i] = inputStr.Substring(i * blockLength, blockLength);
                for (int i = 0; i < blockCount; i++)
                    inputStringMas[i] = Decode(inputStringMas[i], blockLength);
                // соединение в строку
                inputStr = "";
                for (int i = 0; i < blockCount; i++)
                    inputStr += inputStringMas[i];
                Console.WriteLine("Текст после дешифрации: {0}", inputStr);

            }
            else
                Console.WriteLine("Входная строка имеет неверный формат");
        }
    }
}
