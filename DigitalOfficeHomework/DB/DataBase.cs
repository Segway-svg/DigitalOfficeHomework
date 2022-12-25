using DigitalOfficeHomework.Menu;

namespace DigitalOfficeHomework.DB
{
    public class DataBase
    {
        public void DataBaseMenu()
        {
            while (true)
            {
                ColorHelper.SetColor("Выберите команду, которую хотите исполнить в таблице Groups:\n" +
                                     "1) Создать строку\n" +
                                     "2) Прочитать строки таблицы\n" +
                                     "3) Редактировать таблицу\n" +
                                     "4) Удалить строку из таблицы\n" +
                                     "5) Выход", ConsoleColor.Yellow);
                
                if (int.TryParse(Console.ReadLine(), out var command))
                {
                    switch (command)
                    {
                        case 1:
                            Create();
                            break;
                        case 2:
                            Read();
                            break;
                        case 3:
                            Update();
                            break;
                        case 4:
                            Delete();
                            break;
                        case 5:
                            return;
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

        public void Create()
        {
            ColorHelper.SetColor("Введите имя группы:", ConsoleColor.Yellow);
            string name = Console.ReadLine();
            
            ColorHelper.SetColor("Введите описание группы:", ConsoleColor.Yellow);
            string description = Console.ReadLine();

            Provider provider = new Provider();
            provider.Create(name, description);
        }
        
        public void Read()
        {
            Provider provider = new Provider();
            provider.Read();
        }
        
        public void Update()
        {
            ColorHelper.SetColor("Введите guid группы, которую хотите обновить (лучше " +
                                 "скопировать их из Read):", ConsoleColor.Yellow);

            string guid;
            while (true)
            {
                guid = Console.ReadLine();
                if (Guid.TryParse(guid, out _))
                {
                    break;
                }
                ColorHelper.SetColor("Неверный формат, попробуйте снова", ConsoleColor.Red);
                return;
            }

            ColorHelper.SetColor("Введите имя, которое хотите установить" +
                                 "(если хотите оставить, нажмите Enter):", ConsoleColor.Yellow);
            string name = Console.ReadLine();
            
            ColorHelper.SetColor("Введите описание, которое хотите установить" +
                                 "(если хотите оставить, нажмите Enter):", ConsoleColor.Yellow);
            string description = Console.ReadLine();

            Provider provider = new Provider();
            provider.Update(name, description, guid);
        }
        
        public void Delete()
        {
            ColorHelper.SetColor("Введите guid группы, которую хотите удалить (лучше " +
                                 "скопировать их из Read):", ConsoleColor.Yellow);

            string guid;
            while (true)
            {
                guid = Console.ReadLine();
                if (Guid.TryParse(guid, out _))
                {
                    break;
                }
                ColorHelper.SetColor("Неверный формат, попробуйте снова", ConsoleColor.Red);
                return;
            }
            
            Provider provider = new Provider();
            provider.Delete(guid);
        }
    }
}