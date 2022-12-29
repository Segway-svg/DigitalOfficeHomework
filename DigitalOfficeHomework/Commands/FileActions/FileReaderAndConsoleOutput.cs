using DigitalOfficeHomework.FileConfiguration;
using DigitalOfficeHomework.Menu;

namespace DigitalOfficeHomework.Commands.FileActions
{
    public class FileReaderAndConsoleOutput
    {
        private string _pathToRead = ConfigureJson.GetPaths().pathToRead;
        public void GetNum()
        {
            ColorHelper.SetColor("\nВведите нужное для вывода кол-во строк " +
                                 "(для вывода всех строк введите 0):", ConsoleColor.Yellow);
            
            while (true)
            {
                if (uint.TryParse(Console.ReadLine(), out var num))
                {
                    ReadFileAndWriteToConsole(num);
                    break;
                }
                ColorHelper.SetColor("Неверное значение, повторите снова, оно обязательно " +
                                     "должно являться цифрой и быть больше нуля!", ConsoleColor.Red);
            }
        }

        private void ReadFileAndWriteToConsole(uint num)
        {
            if (File.Exists(_pathToRead))
            {
                using (StreamReader reader = new StreamReader(_pathToRead))
                {
                    ColorHelper.SetColor($"Файл прочитан! Вот его содержимое " +
                                         $"из {num} строк!", ConsoleColor.Blue);
                    
                    string line;
                    int i = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (i == num)
                        {
                            break;
                        }
                        Console.WriteLine(line);
                        i++;
                    }

                    Console.WriteLine();
                }
            }
            else
            {
                ColorHelper.SetColor("Данного файла не существует! Установите путь к существующему " +
                                     "и перезапустите программу!\n", ConsoleColor.Red);
            }
        }
    }
}