using System;
using System.Collections.Generic;
using System.IO;

namespace AIS
{
    /// <summary>
    /// Класс для загрузки параметров меню из файла.
    /// </summary>
    public class MenuLoader
    {
        public int count = 0;
        List<string[]> itemArgs;

        /// <summary>
        /// Класс для загрузки параметров меню из файла.
        /// </summary>
        /// <param name="filename">Имя файла с динамическими параметрами меню.</param>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="FormatException"></exception>
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

        public string[] this[int index]
        {
            get { return itemArgs[index]; }
            set { itemArgs[index] = value; }
        }

        /// <summary>
        /// Проверка корректности формата файла с параметрами меню.
        /// </summary>
        /// <returns>true, если формат корректный; иначе false.</returns>
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
