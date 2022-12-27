using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GachiTours
{
    public partial class sign_up : Form
    {

        DataBase dataBase = new DataBase();
        public sign_up()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
        }

        private void sign_up_Load(object sender, EventArgs e)
        {
            textBoxPassword2.Text = "";
            textBoxPassword2.PasswordChar = '*';
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            var login = textBoxLogin2.Text;
            var password = textBoxPassword2.Text;

            if (checkUser())

            {
                return;
            }

            string querystring = $"insert into register(login_user,password_user) values('{login}', '{password}')";

            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());

            dataBase.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {

                MessageBox.Show("Account created", "Good");
                log_in frm_login = new log_in();
                this.Hide();
                frm_login.ShowDialog();
            }
            else
            {
                MessageBox.Show("Account dont created");
            }
            dataBase.closeConnection();



        }

        private Boolean checkUser()

        {



            var loginUser = textBoxLogin2.Text;
            var passUser = textBoxPassword2.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select login_user, password_user from register where login_user = '{loginUser}' and password_user = '{passUser}'";

            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Polzovatelya uzhe est");
                return true;
            }
            else
            {
                return false;
            }

          

        }

    }
}
