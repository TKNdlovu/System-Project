using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace OneBank
{
    public partial class SIgnUpcs : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=PROLIFIC24;Initial Catalog=OneBank;Integrated Security=False");

        public SIgnUpcs()
        {
            InitializeComponent();
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            CreateAcc cForm = new CreateAcc();
            cForm.Show();
            Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int accountNum;
            Random random = new Random();
            accountNum = random.Next(0, 999999999);

           
            String TransactionType="NO Transactions";


            if (textBoxID.Text=="" || textBoxName.Text=="" || textBoxSurname.Text == "" ||textBoxAddress.Text == ""||textBoxContact.Text==""||textBoxEmail.Text==""||textBoxPIN.Text=="")
            {
                MessageBox.Show("Please fill in yhe blanks", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State != ConnectionState.Open)
                {
                    try
                    {
                        connect.Open();
                        String CheckUserID = "Select * from Customer WHERE IdNumber = '" + textBoxID.Text.Trim() + "' ";

                        using (SqlCommand CheckUser = new SqlCommand(CheckUserID, connect))
                        {
                            SqlDataAdapter adapter = new SqlDataAdapter(CheckUser);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count > 0)
                            {
                                MessageBox.Show(textBoxSurname + " already exist", "error message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                            else
                            {
                                String insertCust = "Insert INTO Customer(IdNumber,Fname,LName,Adress,Contact,Email,Pin) Values(@IdNumber,@Fname,@LName,@adress,@contact,@Email,@Pin)";
                                String insertAcc = "Insert INTO Account (AccountNumber,CheckingsBal,SavingsBal,IdNumber) Values (@AccountNumber,@CheckingsBal,@SavingsBal,@IdNumber)";
                                String insertTransactions = "Insert INTO Transactions(TransactionsID,Amount,TransactionType,IdNumber) Values(@TransactionsID,@Anount,@TransactionType,@IdNumber)";
                                String insertBank = "Insert INTO Bank (BankID,BankName,BankAddress,IdNumber) Values(@BankID,@BankName,@BankAddress,@IdNumber)";
                                SqlCommand cmd = new SqlCommand(insertCust, connect);
                                
                                    cmd.Parameters.AddWithValue("@IdNumber", textBoxID.Text);
                                    cmd.Parameters.AddWithValue("@Fname", textBoxName.Text);
                                    cmd.Parameters.AddWithValue("@LName", textBoxSurname.Text);
                                    cmd.Parameters.AddWithValue("@Adress", textBoxAddress.Text);
                                    cmd.Parameters.AddWithValue("@Contact", textBoxContact.Text);
                                    cmd.Parameters.AddWithValue("@Email", textBoxEmail.Text);
                                    cmd.Parameters.AddWithValue("@Pin", textBoxPIN.Text);
                                    cmd.ExecuteNonQuery();
                                    cmd.Parameters.Clear();

                                SqlCommand cmd2 = new SqlCommand(insertAcc, connect);
                                    
                                        cmd2.Parameters.AddWithValue("@AccountNumber", accountNum);
                                        cmd2.Parameters.AddWithValue("@CheckingsBal", 0.0);
                                        cmd2.Parameters.AddWithValue("@SavingsBal", 0.0);
                                        cmd2.Parameters.AddWithValue("@IDNumber", textBoxID.Text);
                                        cmd2.ExecuteNonQuery();
                                        cmd2.Parameters.Clear();

                                SqlCommand cmd3 = new SqlCommand(insertTransactions, connect);
                                    
                                        cmd3.Parameters.AddWithValue("@Amount", 0.0);
                                        cmd3.Parameters.AddWithValue("@TransactionType", TransactionType);
                                        cmd3.Parameters.AddWithValue("@AccountID","@CustomerID");
                                        cmd3.Parameters.AddWithValue("@IDNumber", textBoxID.Text);

                                        cmd3.ExecuteNonQuery();
                                        cmd3.Parameters.Clear();

                                SqlCommand cmd4 = new SqlCommand(insertBank, connect);
                                    
                                
                                        cmd4.Parameters.AddWithValue("@BankName", "One Bank");
                                        cmd4.Parameters.AddWithValue("@BankAddress","3 Edwin Conroy, Vanderbiljpark");
                                        cmd4.Parameters.AddWithValue("@IdNumber", textBoxID.Text);
                                        cmd4.ExecuteNonQuery();
                                        cmd4.Parameters.Clear();
                                    

                                        MessageBox.Show("Registered successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    CreateAcc cForm = new CreateAcc();
                                    cForm.Show();
                                    Visible = false;
                                
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

        private void textBoxPIN_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxContact_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxSurname_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
