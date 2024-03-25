using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace wuf
{
    internal class User
    {
        readonly List<string[]> perms;

        public User(string login, string filename = "USERS.txt")
        {
            if (!File.Exists(filename))
                throw new FileNotFoundException($"Файл \"{filename}\" не найден!");

            if (!CorrectUsersFormat(filename))
                throw new FormatException($"Некорректный формат заполнения файла пользователей \"{filename}\"!");


            // аутентификацию вставить

            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.ReadLine().StartsWith($"#{login}"));
                if (reader.EndOfStream)
                    throw new Exception("Пользователь не найден!");

                perms = new List<string[]>();
                while (!reader.EndOfStream)
                {
                    string str = reader.ReadLine();
                    if (str.StartsWith("#"))
                        break;
                    perms.Add(str.Split('~'));
                }
            }

            if (!CorrectPermsFormat())
                throw new FormatException($"Некорректный формат заполнения файла меню \"{filename}\": названия пунктов не могут повторяться!");
        }


        public void SetPerms(MenuLoader menu)
        {
            for (int i = 0; i < menu.count; i++)
            {
                int index = perms.FindIndex(x => x[0] == menu[i][1]);
                if (index != -1)
                    menu[i][2] = perms[index][1];
            }
        }

        // заглушка для проверки формата записи пользователей в файл
        public bool CorrectUsersFormat(string filename)
        {
            //List<string> content = new List<string>();

            List<string> users = new List<string>();
            using (StreamReader reader = new StreamReader(filename))
            {
                string str;
                while (!reader.EndOfStream)
                {
                    str = reader.ReadLine();
                    if (str.StartsWith("#"))
                        users.Add(str);
                }
            }
            //List<string> users = content.FindAll(x => x.StartsWith("#"));
            if (users == null || users.Count == 0)
                return false;

            var buf = users.Distinct().ToList<string>();
            if (!users.SequenceEqual(users.Distinct()))
                return false;
            
            return true;
        }

        // заглушка для проверки разрешений для данного пользователя
        public bool CorrectPermsFormat()
        {
            if (perms == null)
                return false;
            if (perms.Count == 0)
                return true;
            perms.Sort((x, y) => string.Compare(x[0], y[0]));
            if (perms.Aggregate((x, y) => x[0] == y[0] ? y : x) != perms[0])
                return false;
            foreach (var args in perms)
            {
                if (args == null)
                    return false;
                if (args.Length != 2)
                    return false;
                if (!int.TryParse(args[1], out _))
                    return false;
                if (args[0].Length < 1)
                    return false;
            }
            return true;
        }
    }
}
