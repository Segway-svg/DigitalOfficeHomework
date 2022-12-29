namespace DigitalOfficeHomework.Menu
{
    public class Menu
    {
        public static void Launch()
        {
            PrintMainMenu();
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out var command))
                {
                    switch (command)
                    {
                        case 1:
                            ExtraMenu.FileReaderAndConsoleOutputMenu();
                            break;
                        case 2:
                            ExtraMenu.FileWriterMenu();
                            break;
                        case 3:
                            ExtraMenu.WebFileReaderAndWriterMenu();
                            break;
                        case 4:
                            ExtraMenu.FibonacciMenu();
                            break;
                        case 5:
                            ExtraMenu.DbMenu();
                            break;
                        case 6:
                            ColorHelper.SetColor("Вы вышли!", ConsoleColor.Yellow);
                            Environment.Exit(0);
                            break;
                        default:
                            ColorHelper.SetColor("Число должно быть больше 0, повторите снова!", ConsoleColor.Red);
                            break;
                    }
                }
                else
                {
                    ColorHelper.SetColor("Неверный номер команды, повторите снова!", ConsoleColor.Red);
                }
            }
        }

        private static void PrintMainMenu()
        {
            ColorHelper.SetColor("Выберите команду, которую хотите исполнить:\n" +
                                 "1) Прочитать файл и вывести данные в консоль\n" +
                                 "2) Записать текст в консоль\n" +
                                 "3) Прочитать код web-страницы и его записать в файл\n" +
                                 "4) Вывод числа Фибоначчи\n" +
                                 "5) Работа с БД\n" +
                                 "6) Выход", ConsoleColor.Yellow);
        }
    }
}