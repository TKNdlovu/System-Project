using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;


namespace OneBank
{
    public partial class CreateAcc : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=PROLIFIC24;Initial Catalog=OneBank;Integrated Security=False");

        public CreateAcc()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            SIgnUpcs sForm = new SIgnUpcs();
            sForm.Show();
            Visible = false;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBoxPIN.PasswordChar = '\0';
            }
            else
            {
                textBoxPIN.PasswordChar = '*';
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(textBoxPIN.Text == "" || textBoxID.Text =="")
            {
                MessageBox.Show("Please fill up the blanks", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (connect.State != ConnectionState.Open)
                {
                    try
                    {
                        connect.Open();
                        String SelectData = "Select * from Customer WHERE IdNumber = @IdNumber AND Pin = @Pin ";

                        using (SqlCommand cmd = new SqlCommand(SelectData,connect))
                        {
                            cmd.Parameters.AddWithValue("IdNumber", textBoxID.Text);
                            cmd.Parameters.AddWithValue("Pin", textBoxPIN.Text);
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count >= 1)
                            {
                                MessageBox.Show("Logged in Successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoggedMain Lform = new LoggedMain();
                                Lform.Show();
                                Visible = false;
                            }
                            else
                            {
                                MessageBox.Show("Incorrect Pin", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error connecting database" + ex, "Error Merssage", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }
    }
}
