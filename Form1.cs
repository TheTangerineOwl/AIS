using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*ToolStripMenuItem newStrip = new ToolStripMenuItem("newStrip");
newStrip.Name = "newStrip";
newStrip.Text = "Пункт 1";
newStrip.Dock = DockStyle.Left;
newStrip.Size = new System.Drawing.Size(80, 24);

menuStrip1.Items.Add(newStrip);

ToolStripMenuItem newStrip2 = new ToolStripMenuItem("newStrip2");
newStrip2.Name = "newStrip2";
newStrip2.Text = "Пункт 2";
newStrip2.Dock = DockStyle.Left;
newStrip2.Size = new System.Drawing.Size(80, 24);

menuStrip1.Items.Add(newStrip2);*/

/*foreach (var pars in stripArgs)
{
    if (pars[0] == "0")
    {
        ToolStripMenuItem newStrip = new ToolStripMenuItem();
        newStrip.Name = pars[1];
        newStrip.Text = pars[1];
        switch (pars[2])
        {
            case "0": { newStrip.Enabled = true; newStrip.Visible = true; break; }
            case "1": { newStrip.Enabled = false; newStrip.Visible = true; break; }
            case "2": { newStrip.Enabled = false; newStrip.Visible = false; break; }
        }
        //if (pars.Length > 3) newStrip.Click += new EventHandler(methods[pars[3]]);
        if (pars.Length > 3)
        {
            //newStrip.Tag = pars[3];
            newStrip.Click += new EventHandler(OnClick);
        }
        else
        {
            //newStrip.DropDown = new ToolStripDropDown();
            //newStrip.DropDown.Items.Add(new ToolStripMenuItem(pars[1] + "submenu"));

            //newStrip.DropDown.Items[0]

            //newStrip.DropDown = new ToolStripDropDown();
            ToolStripMenuItem submenu = new ToolStripMenuItem("submenu");
            submenu.DropDown.Items.Add("cool0");
            newStrip.DropDown.Items.Add(submenu);


            //newStrip.DropDown.Items[0].Click += new EventHandler(OnClick);
        }

        menuStrip1.Items.Add(newStrip);
    }

}*/

namespace wuf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // работает, но не распознает уровни иерархии

        /*private void Form1_Load(object sender, EventArgs e) // добавить распознование уровней иерархии
        {
            // Номер_уровня_в_иерархии Название_пункта Статус_пункта ИмяМетода

            List<string> stripArgs = ParamsReader.LoadMenu("menu.txt");

            for (int i = 0; i < stripArgs.Count; i++) AddNewStrip(menuStrip1.Items, ref i, stripArgs);

        }

        private void AddNewStrip(ToolStripItemCollection ownerItems, ref int index, List<string> parameters)
        {
            ToolStripMenuItem newStrip = new ToolStripMenuItem();
            string[] pars = parameters[index].Split(' ');
            newStrip.Name = pars[1];
            newStrip.Text = pars[1];
            switch (pars[2])
            {
                case "0": { newStrip.Enabled = true; newStrip.Visible = true; break; }
                case "1": { newStrip.Enabled = false; newStrip.Visible = true; break; }
                case "2": { newStrip.Enabled = false; newStrip.Visible = false; break; }
            }
            if (pars.Length > 3)
            {
                //newStrip.Tag = parameters[index][3];
                newStrip.Click += new EventHandler(OnClick);
            }
            else
            {
                index++;
                AddNewStrip(newStrip.DropDown.Items, ref index, parameters);
            }
            ownerItems.Add(newStrip);
        }*/

        // распознает уровни иерархии, но не работает

        /*private void Form1_Load(object sender, EventArgs e) // добавить распознование уровней иерархии
        {
            // Номер_уровня_в_иерархии Название_пункта Статус_пункта ИмяМетода

            stripArgs = ParamsReader.LoadMenu("menu.txt");
            menuStrip1.Items.Add(new ToolStripMenuItem());
            current = (ToolStripMenuItem)menuStrip1.Items[0];
            AddNewStrip(out current, 0);

            for (int i = 1; i < stripArgs.Count; i++)
            {
                int hierarchy = int.Parse(stripArgs[i][0]) - int.Parse(stripArgs[i - 1][0]);
                if (hierarchy == 0)
                {
                    current = (ToolStripMenuItem)current.OwnerItem;
                    if (current == null)
                    {
                        menuStrip1.Items.Add(new ToolStripMenuItem());
                        current = (ToolStripMenuItem)menuStrip1.Items[menuStrip1.Items.Count - 1];
                        current.Owner = menuStrip1;
                    } 
                    else
                    {
                        current.DropDownItems.Add(new ToolStripMenuItem());
                        current = (ToolStripMenuItem)current.DropDownItems[current.DropDownItems.Count - 1];
                    }

                    AddNewStrip(out current, i);
                    i = i;
                }
                else if (hierarchy > 0)
                {
                    owner = current;
                    current.DropDownItems.Add(new ToolStripMenuItem());
                    current = (ToolStripMenuItem)current.DropDownItems[current.DropDownItems.Count - 1];
                    AddNewStrip(out current, i);
                    i = i;
                }
                else
                {
                    //current = current.Owner;
                    current = (ToolStripMenuItem)current.OwnerItem;
                    AddNewStrip(out current, i);
                    i = i;
                }
            }

        }

        
        ToolStripMenuItem current;
        ToolStripMenuItem owner;
        List<string[]> stripArgs;

        private void AddNewStrip(out ToolStripMenuItem ownerItems, int index)
        {
            ToolStripMenuItem newStrip = new ToolStripMenuItem();
            newStrip.Name = stripArgs[index][1];
            newStrip.Text = stripArgs[index][1];


            switch (stripArgs[index][2])
            {
                case "0": { newStrip.Enabled = true; newStrip.Visible = true; break; }
                case "1": { newStrip.Enabled = false; newStrip.Visible = true; break; }
                case "2": { newStrip.Enabled = false; newStrip.Visible = false; break; }
            }
            if (stripArgs[index].Length > 3)
            {
                //newStrip.Tag = parameters[index][3];
                newStrip.Click += new EventHandler(OnClick);
            }
            //else
            //{
            //    index++;
            //    AddNewStrip(newStrip.DropDown.Items, ref index, pars);
            //}
            //ownerItems.DropDownItems.Add(newStrip);

            //ownerItems = newStrip;

            ownerItems = newStrip;
            index = index;

            //ownerItems.DropDownItems.Add(newStrip);
        } */


        ToolStripMenuItem currentItem;
        int heir = 0;
        int index = 0;
        List<string[]> stripArgs;

        private void Form1_Load(object sender, EventArgs e) // добавить распознование уровней иерархии
        {
            // Номер_уровня_в_иерархии Название_пункта Статус_пункта ИмяМетода

            stripArgs = ParamsReader.LoadMenu("menu.txt");
            menuStrip1.Items.Add(new ToolStripMenuItem());
            //currentItem = (ToolStripMenuItem)menuStrip1.Items[0];

            ToolStripMenuItem anchor = new ToolStripMenuItem();
            anchor.DropDownItems.Add(new ToolStripMenuItem());

            currentItem = (ToolStripMenuItem)anchor.DropDownItems[0];
            

            for (index = 0; index < stripArgs.Count; index++)
            {
                int currentHeir = int.Parse(stripArgs[index][0]);
                if (index == 0) heir = currentHeir;

                if (currentHeir - heir == 0)
                {
                    currentItem = (ToolStripMenuItem)currentItem.OwnerItem;
                    currentItem.DropDownItems.Add(CreateStrip());
                    currentItem = (ToolStripMenuItem)currentItem.DropDownItems[currentItem.DropDownItems.Count - 1];
                } 
                else if (currentHeir - heir > 0)
                {
                    currentItem.DropDownItems.Add(CreateStrip());
                    currentItem = (ToolStripMenuItem)currentItem.DropDownItems[currentItem.DropDownItems.Count - 1];
                }
                else if (currentHeir - heir < 0)
                {
                    while (currentHeir != heir)
                    {
                        currentItem = (ToolStripMenuItem)currentItem.OwnerItem;
                        heir--;
                    }
                    currentItem = (ToolStripMenuItem)currentItem.OwnerItem;
                    currentItem.DropDownItems.Add(CreateStrip());
                    currentItem = (ToolStripMenuItem)currentItem.DropDownItems[currentItem.DropDownItems.Count - 1];
                }



                heir = currentHeir;
            }

            //menuStrip1 = new MenuStrip();


            menuStrip1.Items.AddRange(anchor.DropDownItems);
            //foreach (var item in anchor.DropDownItems) menuStrip1.Items.Add((ToolStripMenuItem)item);
        }

        private ToolStripMenuItem CreateStrip()
        {
            ToolStripMenuItem newItem = new ToolStripMenuItem();
            newItem.Name = stripArgs[index][1];
            newItem.Text = stripArgs[index][1];


            switch (stripArgs[index][2])
            {
                case "0": { newItem.Enabled = true; newItem.Visible = true; break; }
                case "1": { newItem.Enabled = false; newItem.Visible = true; break; }
                case "2": { newItem.Enabled = false; newItem.Visible = false; break; }
            }
            if (stripArgs[index].Length > 3)
            {
                //newStrip.Tag = parameters[index][3];
                newItem.Click += new EventHandler(OnClick);
            }

            //item = newItem;
            index = index;
            return newItem;
        }


        private void OnClick(object sender, EventArgs e)
        {
            WriteOnClick((ToolStripMenuItem)sender);
        }

        private void WriteOnClick(ToolStripMenuItem strip)
        {
            outputLabel.Text = "Нажат " + strip.Name;
        } 

    }

    public static class ParamsReader
    {
        private static List<string[]> menuStrips = new List<string[]>();
        //private static List<string> users = new List<string>();

        public static List<string[]> LoadMenu(string filename)
        {
            using (StreamReader reader = new StreamReader("menu.txt"))
            {
                if (reader == null) throw new FileLoadException("Не удалось загрузить файл 'menu.txt'!\n");
                while (!reader.EndOfStream) menuStrips.Add(reader.ReadLine().Split(' '));
            }

            return menuStrips;
        }

        //public static List<string> LoadUsers(string filename)
        //{
        //    StreamReader reader = new StreamReader("users.txt");
        //    while (!reader.EndOfStream) users.Add(reader.ReadLine());
        //    return users;
        //}
    }
}
