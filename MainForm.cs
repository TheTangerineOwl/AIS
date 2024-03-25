using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIS
{
    public partial class MainForm : Form
    {
        readonly MenuLoader menu;
        readonly User currentUser;
        int index = 0;

        public MainForm(User user, MenuLoader menu)
        {
            this.menu = menu;
            currentUser = user;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
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
            ToolStripMenuItem strip = (ToolStripMenuItem)sender;
            outputLabel.Text = "Нажат \"" + strip.Text + "\"";
        }


    }
}
