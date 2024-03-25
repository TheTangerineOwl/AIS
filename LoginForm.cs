using System;
using System.IO;
using System.Windows.Forms;

namespace AIS
{
    public partial class LoginForm : Form
    {
        private MainForm menuForm;
        private const string usersFile = "USERS.txt";
        private const string menuFile = "menu.txt";


        public LoginForm()
        {
            InitializeComponent();
        }

        private void CapsStatus_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
                capsStatus.Text = "Клавиша CapsLock нажата";
            else capsStatus.Text = "";
        }

        private void LanguageLabel_InputLanguageChanged(object sender, InputLanguageChangedEventArgs e)
        {
            languageLabel.Text = InputLanguage.CurrentInputLanguage.Culture.DisplayName;
        }

        private bool CheckLoginInfo(string login, string password, string filename = usersFile)
        {
            string[] str;
            using (StreamReader reader = new StreamReader(filename))
            {
                str = reader.ReadLine().Split(' ');
                while (!str[0].StartsWith($"#{login}") && !reader.EndOfStream)
                    str = reader.ReadLine().Split(' ');
                if (reader.EndOfStream)
                {
                    MessageBox.Show("Пользователь не найден!",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
            }
            if (str[0] == $"#{login}" && str[1] == password)
                return true;
            else
                return false;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = loginBox.Text;
            string password = passwordBox.Text;
            if (CheckLoginInfo(username, password))
            {
                menuForm = new MainForm(new User(username, usersFile), new MenuLoader(menuFile));
                menuForm.Show();
            }
            else
            {
                MessageBox.Show("Неверные данные для входа!",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            loginBox.Text = "";
            passwordBox.Text = "";
        }

    }
}
