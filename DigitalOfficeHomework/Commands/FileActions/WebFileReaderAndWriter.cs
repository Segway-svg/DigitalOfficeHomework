using DigitalOfficeHomework.FileConfiguration;
using DigitalOfficeHomework.Menu;
using HtmlAgilityPack;

namespace DigitalOfficeHomework.Commands.FileActions
{
    public class WebFileReaderAndWriter
    {
        private string _pathToRead = ConfigureJson.GetPaths().webURL;
        private string _pathToWrite = ConfigureJson.GetPaths().pathToWrite;
        private string Text { get; set; }
        public void GetCode()
        {
            try
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument document = web.Load(_pathToRead);

                if (web.ToString().Length != 0)
                {
                    ColorHelper.SetColor("Код web-страницы прочитан! Вот его содержимое!", ConsoleColor.Blue);

                    Text = document.Text;
                    ColorHelper.SetColor(Text, ConsoleColor.White);
                    Console.WriteLine();
                    WriteIntoFile();
                }
            }
            catch
            {
                ColorHelper.SetColor("Проблема с доступом к web-странице! Установите путь к существующему " +
                                  "и перезапустите программу!\n", ConsoleColor.Red);
            }
        }

        public void WriteIntoFile()
        {
            if (File.Exists(_pathToWrite))
            {
                using (StreamWriter writer = new StreamWriter(_pathToWrite, false))
                {
                    writer.WriteLineAsync(Text);
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