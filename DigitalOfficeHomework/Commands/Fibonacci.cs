using DigitalOfficeHomework.Menu;

namespace DigitalOfficeHomework.Commands
{
    public class Fibonacci
    {
        public void GetNum()
        {
            ColorHelper.SetColor("Введите порядковый номер:", ConsoleColor.Yellow);

            while (true)
            {
                if (uint.TryParse(Console.ReadLine(), out var num))
                {
                    FindFibonacci(num);
                    break;
                }
                ColorHelper.SetColor("Неверное значение, повторите снова, оно обязательно" +
                                     "должно являться цифрой и быть больше нуля!", ConsoleColor.Red);
            }
        }
        
        private void FindFibonacci(uint num)
        {
            int result = 0;
            int b = 1;
            int tmp;
 
            for (int i = 0; i < num && num != 1; i++)
            {
                tmp = result;
                result = b;
                b += tmp;
            }
            ColorHelper.SetColor($"Ответ: {result}\n", ConsoleColor.Blue);
        }
    }
}