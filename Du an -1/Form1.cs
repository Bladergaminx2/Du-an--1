using System;
using System.Linq;
using System.Windows.Forms;

namespace Du_an__1
{
    public partial class Form1 : Form
    {
        public static string UserRole { get; set; } 

        public Form1()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string username = guna2TextBox1.Text;
            string password = guna2TextBox2.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Moi nhap username and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var context = new ShoeStore2Entities4())
            {
                if (radioButton1.Checked)
                {
                    var admin = context.Admins.SingleOrDefault(a => a.AUserName == username && a.APassword == password);
                    if (admin != null)
                    {
                        MessageBox.Show("Dang nhap thanh cong", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UserRole = "Admin";
                        OptionsA optionsAForm = new OptionsA();
                        optionsAForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Sai thong tin username hoac password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (radioButton2.Checked)
                {
                    var employee = context.Employees.SingleOrDefault(emp => emp.EUserName == username && emp.EPassword == password);
                    if (employee != null)
                    {
                        MessageBox.Show("Dang nhap thanh cong", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UserRole = "Employee";
                        OptionsE optionsEForm = new OptionsE();
                        optionsEForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Sai thong tin username hoac password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Moi chon Admin hoac Employee.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
