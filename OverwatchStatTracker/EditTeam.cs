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
    public partial class EditTeam : Form
    {
        public EditTeam()
        {
            InitializeComponent();

            SqlConnection con = new SqlConnection("Data Source=K-PC;Initial Catalog=OWSTATS;Integrated Security=True;Pooling=False");
            SqlCommand cmd = new SqlCommand("SELECT Name FROM Teams", con);
            con.Open();
            SqlDataReader da = cmd.ExecuteReader();

            while (da.Read())
            {
                nameBox.Items.Add(da.GetValue(0).ToString());
            }
            con.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (nameBox.Text.Length == 0)
                MessageBox.Show("Name is required");
            else
            {
                SqlConnection con = new SqlConnection("Data Source=K-PC;Initial Catalog=OWSTATS;Integrated Security=True;Pooling=False");
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Teams set Name=@name,School=@school,Wins=@wins,Losses=@losses,Draws=@draws WHERE Name=@Name", con);
                cmd.Parameters.AddWithValue("@name", nameBox.Text);
                cmd.Parameters.AddWithValue("@school", SchoolName.Text);
                cmd.Parameters.AddWithValue("@wins", int.Parse(Wins.Text));
                cmd.Parameters.AddWithValue("@losses", int.Parse(Losses.Text));
                cmd.Parameters.AddWithValue("@draws", int.Parse(Draws.Text));
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Succesfully Updated");
                this.Close();
            }
        }

        private void nameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=K-PC;Initial Catalog=OWSTATS;Integrated Security=True;Pooling=False");
            SqlCommand cmd = new SqlCommand("SELECT School, Wins, Losses, Draws FROM Teams WHERE Name =@name", con);
            con.Open();
            cmd.Parameters.AddWithValue("@name", nameBox.Text);
            SqlDataReader da = cmd.ExecuteReader();

            if(da.Read())
            {
                SchoolName.Text = da.GetValue(0).ToString();
                Wins.Text = da.GetValue(1).ToString();
                Losses.Text = da.GetValue(2).ToString();
                Draws.Text = da.GetValue(3).ToString();
            }
        }
    }
}
