namespace DigitalOfficeHomework.Menu
{
    public static class ColorHelper
    {
        public static void SetColor(string sentence, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(sentence);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}