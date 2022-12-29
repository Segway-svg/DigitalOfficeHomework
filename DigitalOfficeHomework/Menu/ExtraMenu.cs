using DigitalOfficeHomework.Commands;
using DigitalOfficeHomework.Commands.FileActions;
using DigitalOfficeHomework.DB;

namespace DigitalOfficeHomework.Menu
{
    public static class ExtraMenu
    {
        public static void FileReaderAndConsoleOutputMenu()
        {
            while (true)
            {
                var fileReaderAndConsoleOutput = new FileReaderAndConsoleOutput();
                fileReaderAndConsoleOutput.GetNum();

                if (PrintExtraMenu())
                {
                    continue;
                }
                Console.WriteLine();
                Menu.Launch();
                return;
            }
        }

        public static void FileWriterMenu()
        {
            while (true)
            {
                FileWriter fileWriter = new FileWriter();
                fileWriter.WriteFile();
                
                if (PrintExtraMenu())
                {
                    continue;
                }
                Console.WriteLine();
                Menu.Launch();
                return;
            }
        }

        public static void WebFileReaderAndWriterMenu()
        {
            while (true)
            {
                WebFileReaderAndWriter webFileReaderAndWriter = new WebFileReaderAndWriter();
                webFileReaderAndWriter.GetCode();
                webFileReaderAndWriter.WriteIntoFile();
                
                if (PrintExtraMenu())
                {
                    continue;
                }
                Console.WriteLine(); 
                Menu.Launch();
                return;
            }
        }

        public static void FibonacciMenu()
        {
            while (true)
            {
                Fibonacci fibonacci = new Fibonacci();
                fibonacci.GetNum();
                
                if (PrintExtraMenu())
                {
                    continue;
                }
                Console.WriteLine();
                Menu.Launch();
                return;
            }
        }

        public static void DbMenu()
        {
            while (true)
            {
                DataBase dataBase = new DataBase();
                dataBase.DataBaseMenu();

                if (PrintExtraMenu())
                {
                    continue;
                }
                Console.WriteLine();
                Menu.Launch();
                return;
            }
        }

        private static bool PrintExtraMenu()
        {
            ColorHelper.SetColor("Хотите ли вы повторить операцию (1) или вернуться в главное меню (2)?\n" +
                                 "1) Повторить\n" +
                                 "2) Вернуться", ConsoleColor.Yellow);
            Console.WriteLine();
            while (true)
            {
                if (uint.TryParse(Console.ReadLine(), out var command))
                {
                    switch (command)
                    {
                        case 1:
                            return true;
                        case 2:
                            return false;
                        case > 2:
                            ColorHelper.SetColor("Неверное значение, повторите снова, оно обязательно" +
                                                 "должно являться цифрой и быть меньше 3!", ConsoleColor.Red);
                            break;
                    }
                }
                else
                {
                    ColorHelper.SetColor("Неверное значение, повторите снова, оно обязательно" +
                                         "должно являться цифрой и быть больше нуля!", ConsoleColor.Red);
                }
            }
        }
    }
}