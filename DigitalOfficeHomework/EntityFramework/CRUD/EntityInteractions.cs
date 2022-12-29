using DigitalOfficeHomework.EntityFramework.DbConfig;
using DigitalOfficeHomework.Menu;

namespace DigitalOfficeHomework.EntityFramework.CRUD;

public class EntityInteractions
{
    public void EntityFrameworkMenu()
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
                            SetCreateValues();
                            break;
                        case 2:
                            Read();
                            break;
                        case 3:
                            SetUpdateValues();
                            break;
                        case 4:
                            SetDeleteValues();
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
    
        public void SetCreateValues()
        {
            ColorHelper.SetColor("Введите имя библиотеки:", ConsoleColor.Yellow);
            string name = Console.ReadLine();
            
            ColorHelper.SetColor("Введите адрес:", ConsoleColor.Yellow);
            string address = Console.ReadLine();
            
            Create(name, address);
        }

        private void Create(string name, string address)
        {
            DbLibrary library = new DbLibrary()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Address = address,
                FoundationDate = DateTime.Now
            };

            using (LibraryDbContext dbContext = new LibraryDbContext())
            {
                dbContext.Database.Migrate();
                dbContext.Libraries.Add(library);
                dbContext.SaveChanges();
            }
        }
        
        public void Read()
        {
            using (LibraryDbContext dbContext = new LibraryDbContext())
            {
                dbContext.Database.Migrate();
                foreach (DbLibrary db in dbContext.Libraries.Select(l => l))
                {
                    Console.WriteLine($"Id: {db.Id}; " +
                                      $"Name: {db.Name}; " +
                                      $"Address: {db.Address}; " +
                                      $"Foundation Date: {db.FoundationDate}");
                }
            }
        }
        
        public void SetUpdateValues()
        {
            ColorHelper.SetColor("Введите guid группы, которую хотите обновить (лучше " +
                                 "скопировать их из Read):", ConsoleColor.Yellow);

            string id;
            Guid guid = new Guid();
            while (true)
            {
                id = Console.ReadLine();
                if (Guid.TryParse(id, out _))
                {
                    guid = Guid.Parse(id);
                    break;
                }
                ColorHelper.SetColor("Неверный формат, попробуйте снова", ConsoleColor.Red);
                return;
            }

            ColorHelper.SetColor("Введите имя, которое хотите установить " +
                                 "(если хотите оставить, нажмите Enter):", ConsoleColor.Yellow);
            string name = Console.ReadLine();
            
            ColorHelper.SetColor("Введите описание, которое хотите установить " +
                                 "(если хотите оставить, нажмите Enter):", ConsoleColor.Yellow);
            string address = Console.ReadLine();
            
            Update(guid, name, address);
        }

        private void Update(Guid guid, string name, string address)
        {
            using (LibraryDbContext dbContext = new LibraryDbContext())
            {
                dbContext.Database.Migrate();
                DbLibrary library = dbContext.Libraries.FirstOrDefault(l => l.Id == guid);
                library.Name = name;
                library.Address = address;
                dbContext.SaveChanges();
            }
        }
        
        public void SetDeleteValues()
        {
            ColorHelper.SetColor("Введите guid группы, которую хотите удалить (лучше " +
                                 "скопировать их из Read):", ConsoleColor.Yellow);

            string id;
            Guid guid = new Guid();
            while (true)
            {
                id = Console.ReadLine();
                if (Guid.TryParse(id, out _))
                {
                    guid = Guid.Parse(id);
                    break;
                }
                ColorHelper.SetColor("Неверный формат, попробуйте снова", ConsoleColor.Red);
                return;
            }
            
            Delete(guid);
        }

        private void Delete(Guid guid)
        {
            using (LibraryDbContext dbContext = new LibraryDbContext())
            {
                dbContext.Database.Migrate();
                DbLibrary library = dbContext.Libraries.FirstOrDefault(l => l.Id == guid);
                dbContext.Libraries.Remove(library);
                dbContext.SaveChanges();
            }           
        }
}