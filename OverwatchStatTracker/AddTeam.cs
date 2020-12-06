using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace OverwatchStatTracker
{
    public partial class AddTeam : Form
    {
        public AddTeam()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (TeamName.Text.Length == 0 || Wins.Text.Length == 0 || Losses.Text.Length == 0 || Draws.Text.Length == 0)
                MessageBox.Show("Name and TeamID are required");
            else
            {
                SqlConnection con = new SqlConnection("Data Source=K-PC;Initial Catalog=OWSTATS;Integrated Security=True;Pooling=False");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT into Teams values (@name,@school,@wins,@losses,@draws)", con);
                cmd.Parameters.AddWithValue("@name", TeamName.Text);
                cmd.Parameters.AddWithValue("@school", SchoolName.Text);
                cmd.Parameters.AddWithValue("@wins", int.Parse(Wins.Text));
                cmd.Parameters.AddWithValue("@losses", int.Parse(Losses.Text));
                cmd.Parameters.AddWithValue("@draws", int.Parse(Draws.Text));
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Succesfully Added");
                this.Close();
            }
        }
    }
}
