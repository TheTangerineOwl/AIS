using System;
using System.Linq;
using System.Windows.Forms;

namespace AIS
{
    /// <summary>
    /// Форма меню с динамически определенными параметрами.
    /// </summary>
    public partial class MainForm : Form
    {
        readonly MenuLoader menu;
        readonly User currentUser;
        int index = 0;

        /// <summary>
        /// Форма меню с динамически определенными параметрами.
        /// </summary>
        /// <param name="user">Информация о пользователе.</param>
        /// <param name="menu">Параметры меню.</param>
        public MainForm(User user, MenuLoader menu)
        {
            this.menu = menu;
            currentUser = user;
            InitializeComponent();
        }

        /// <summary>
        /// Вызывается при загрузке меню.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            ToolStripMenuItem buffer = new ToolStripMenuItem();
            // Установка разрешений пользователя в список параметров.
            currentUser.SetPerms(menu);

            // Рекурсивная загрузка подменю.
            for (index = 0; index < menu.count; index++)
            {
                CreateSubmenu(ref buffer);
                menuStrip.Items.Add(buffer.DropDownItems[0]);
            }

        }

        /// <summary>
        /// Загрузка подменю из списка параметров.
        /// </summary>
        /// <param name="parent">Родительский объект подменю.</param>
        private void CreateSubmenu(ref ToolStripMenuItem parent)
        {
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Text = menu[index][1];
            // Установка видимости и доступности.
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
            // Если пункт имеет подменю, то создает его.
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
                item.Click += new EventHandler(OnClick);
            }
            // Добавление к родительском элементу.
            parent.DropDownItems.Add(item);
        }

        /// <summary>
        /// Возникает при нажатии на пункт меню.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClick(object sender, EventArgs e)
        {
            ToolStripMenuItem strip = (ToolStripMenuItem)sender;
            outputLabel.Text = "Нажат \"" + strip.Text + "\"";
        }


    }
}
