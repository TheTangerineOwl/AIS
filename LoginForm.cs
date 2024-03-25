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
    public partial class LoginForm : Form
    {
        MainForm menuForm;


        public LoginForm()
        {
            InitializeComponent();
            menuForm = new MainForm();
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                capsStatus.Text = "123123";
                InitializeComponent();
            }
            else
            {
                capsStatus.Text = "asdfsdf";
                InitializeComponent();
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {


            //MainForm newForm = new MainForm();
            //newForm.ShowDialog();

            //this.Hide();
            menuForm.Show();
            menuForm.Activate();
            //this.Close();

            //newForm = newForm;

            //var a = Application.OpenForms;
            //a = a;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
