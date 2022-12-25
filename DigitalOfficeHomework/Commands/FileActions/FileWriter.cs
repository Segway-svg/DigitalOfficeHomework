using DigitalOfficeHomework.FileConfiguration;
using DigitalOfficeHomework.Menu;

namespace DigitalOfficeHomework.Commands.FileActions
{
    public class FileWriter
    {
        private string _pathToWrite = ConfigureJson.GetPaths().pathToWrite;
        public async Task WriteFile()
        {
            if (File.Exists(_pathToWrite))
            {
                ColorHelper.SetColor("Текст записан в файл!", ConsoleColor.Blue);

                using (StreamWriter writer = new StreamWriter(_pathToWrite, false))
                {
                    await writer.WriteLineAsync();
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