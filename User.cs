using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AIS
{
    /// <summary>
    /// Информация о пользователе и разрешениях для него.
    /// </summary>
    public class User
    {
        readonly List<string[]> perms;

        /// <summary>
        /// Информация о разрешениях пользователя.
        /// </summary>
        /// <param name="login">Имя пользователя.</param>
        /// <param name="filename">Имя файла с данными о пользователях.</param>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="Exception"></exception>
        public User(string login, string filename = "USERS.txt")
        {
            if (!File.Exists(filename))
                throw new FileNotFoundException($"Файл \"{filename}\" не найден!");

            if (!CorrectUsersFormat(filename))
                throw new FormatException($"Некорректный формат заполнения файла пользователей \"{filename}\"!");

            using (StreamReader reader = new StreamReader(filename))
            {
                // Поиск пользователя в файле.
                while (!reader.ReadLine().StartsWith($"#{login}"));
                if (reader.EndOfStream)
                    throw new Exception("Пользователь не найден!");
                // Запись разрешений пользователя.
                perms = new List<string[]>();
                while (!reader.EndOfStream)
                {
                    string str = reader.ReadLine();
                    if (str.StartsWith("#"))
                        break;
                    perms.Add(str.Split('~'));
                }
            }
            // Если разрешения были считаны некорректно.
            if (!CorrectPermsFormat())
                throw new FormatException($"Некорректный формат заполнения файла меню \"{filename}\": названия пунктов не могут повторяться!");
        }

        /// <summary>
        /// Редактирование динамического меню в соответствии с разрешениями пользователя.
        /// </summary>
        /// <param name="menu">Динамическое меню.</param>
        public void SetPerms(MenuLoader menu)
        {
            for (int i = 0; i < menu.count; i++)
            {
                int index = perms.FindIndex(x => x[0] == menu[i][1]);
                if (index != -1)
                    menu[i][2] = perms[index][1];
            }
        }

        /// <summary>
        /// Проверяет корректность формата файла с пользователями.
        /// </summary>
        /// <param name="filename">Имя файла с информацией о пользователях.</param>
        /// <returns>true, если формат правильный; иначе false.</returns>
        public static bool CorrectUsersFormat(string filename)
        {
            List<string[]> users = new List<string[]>();
            using (StreamReader reader = new StreamReader(filename))
            {
                // Считывает всех пользователей из файла.
                string str;
                while (!reader.EndOfStream)
                {
                    str = reader.ReadLine();
                    if (str.StartsWith("#"))
                        users.Add(str.Split(' '));
                }
            }
            // Если не удалось найти пользователей или считать файл.
            if (users == null || users.Count == 0)
                return false;

            // Проверка, существуют ли совпадения в списке пользователей.
            foreach (var buf in users)
                if (users.FindAll(x => x[0] == buf[0]).Count > 1)
                    return false;

            return true;
        }

        /// <summary>
        /// Проверяет корректность формата разрешений для пользователя.
        /// </summary>
        /// <returns>true, если формат правильный; иначе false.</returns>
        public bool CorrectPermsFormat()
        {
            if (perms == null)
                return false;
            if (perms.Count == 0)
                return true;
            perms.Sort((x, y) => string.Compare(x[0], y[0]));
            // Если существуют повторы в пунктах с разрешениями.
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
