using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wuf
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        MenuLoader menu = new MenuLoader();
        User currentUser = new User("admin");////////////////////////////////////////////////////////
        int index = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            ToolStripMenuItem buffer = new ToolStripMenuItem();
            currentUser.SetPerms(menu);

            for (index = 0; index < menu.count; index++)
            {
                CreateSubmenu(ref buffer);
                menuStrip.Items.Add(buffer.DropDownItems[0]);
            }

        }

        private void CreateSubmenu(ref ToolStripMenuItem parent)
        {
            ToolStripMenuItem item = new ToolStripMenuItem();
            //item.Name = menu[index][1];
            item.Text = menu[index][1];
            switch (menu[index][2])
            {
                case "0":
                {
                    item.Visible = true;
                    item.Enabled = true;
                } break;
                case "1":
                {
                    item.Visible = true;
                    item.Enabled = false;
                } break;
                case "2":
                {
                    item.Visible = false;
                    item.Enabled = false;
                } break;
                default: { break; }
            }
            int prevLevel = int.Parse(menu[index][0]);
            if (menu[index].Count<string>() < 4 && (index + 1 < menu.count))
                while ((prevLevel < int.Parse(menu[index + 1][0])))
                {
                    index++;
                    CreateSubmenu(ref item);
                    if (index + 1 >= menu.count)
                        break;
                }
            else
            {
                item.Tag = menu[index][3];////////////////////////////////// убрать
                item.Click += new EventHandler(OnClick);
            }

            parent.DropDownItems.Add(item);
        }

        private void OnClick(object sender, EventArgs e)
        {
            WriteOnClick((ToolStripMenuItem)sender);
        }

        private void WriteOnClick(ToolStripMenuItem strip)
        {
            //outputLabel.Text = "Нажат \"" + strip.Text + "\"";    // то, что нужно

            outputLabel.Text = strip.Tag.ToString();        // для теста
        }


    }
}
