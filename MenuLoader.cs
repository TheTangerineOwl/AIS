using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wuf
{
    internal class MenuLoader
    {
        public int count = 0;
        List<string[]> itemArgs;

        public MenuLoader(string filename = "menu.txt")
        {
            if (!File.Exists(filename))
                throw new FileNotFoundException($"Файл \"{filename}\" не найден!");
            using (StreamReader reader = new StreamReader(filename))
            {
                itemArgs= new List<string[]>();
                while (!reader.EndOfStream)
                {
                    itemArgs.Add(reader.ReadLine().Split('~'));
                    count++;
                }
            }
            if (!CorrectFormat())
                throw new FormatException($"Некорректный формат заполнения файла меню \"{filename}\"!");
        }

        // Номер_уровня_в_иерархии Название_пункта Статус_пункта ИмяМетода

        public string[] this[int index]
        {
            get { return itemArgs[index]; }
            set { itemArgs[index] = value; }
        }

        public bool CorrectFormat()
        {
            foreach (var args in itemArgs)
            {
                if (args == null)
                    return false;
                if (args.Length < 3 || args.Length > 4)
                    return false;
                if (!int.TryParse(args[0], out _))
                    return false;
                if (!int.TryParse(args[2], out _))
                    return false;
                if (args[1].Length < 1)
                    return false;
            }
            return true;
        }

    }
}
