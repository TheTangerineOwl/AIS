using System;
using System.IO;
using System.Windows.Forms;

namespace AIS
{
    /// <summary>
    /// Форма для входа в АИС.
    /// </summary>
    public partial class LoginForm : Form
    {
        private MainForm menuForm;
        private const string usersFile = "USERS.txt";
        private const string menuFile = "menu.txt";

        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Указывает, задействована ли клавиша CapsLock.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CapsStatus_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
                capsStatus.Text = "Клавиша CapsLock нажата";
            else capsStatus.Text = "";
        }

        /// <summary>
        /// Указывает язык ввода клавиатуры.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LanguageLabel_InputLanguageChanged(object sender, InputLanguageChangedEventArgs e)
        {
            languageLabel.Text = InputLanguage.CurrentInputLanguage.Culture.DisplayName;
        }

        /// <summary>
        /// Проверка соответствия введенного логина и пароля в файле пользователей.
        /// </summary>
        /// <param name="login">Имя пользователя.</param>
        /// <param name="password">Пароль.</param>
        /// <param name="filename">Файл с данными о зарегистрированных пользователях.</param>
        /// <returns>true, если данные для входа соответствуют; иначе false.</returns>
        private bool CheckLoginInfo(string login, string password, string filename = usersFile)
        {
            string[] str;
            using (StreamReader reader = new StreamReader(filename))
            {
                str = reader.ReadLine().Split(' ');
                while (!str[0].StartsWith($"#{login}") && !reader.EndOfStream)
                    str = reader.ReadLine().Split(' ');
                // В случае, если не находит данного пользователя в файле, отображает окно ошибки.
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

        /// <summary>
        /// Возникает при нажатии на кнопку "Войти".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = loginBox.Text;
            string password = passwordBox.Text;
            if (CheckLoginInfo(username, password))
            {
                menuForm = new MainForm(new User(username, usersFile), new MenuLoader(menuFile));
                menuForm.Show();
            }
            // В случае, если были введены некорректные данные.
            else
            {
                MessageBox.Show("Неверные данные для входа!",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Возникает при нажатии кнопки "Отмена". Очищает поля для входа.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            loginBox.Text = "";
            passwordBox.Text = "";
        }

    }
}
