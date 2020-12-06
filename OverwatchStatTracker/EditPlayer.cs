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
    public partial class EditPlayer : Form
    {
        public EditPlayer()
        {
            InitializeComponent();

            SqlConnection con = new SqlConnection("Data Source=K-PC;Initial Catalog=OWSTATS;Integrated Security=True;Pooling=False");
            SqlCommand cmd = new SqlCommand("SELECT Name FROM Players", con);
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


        //Actually an edit button click messed up the order when creating this.
        private void addBtn_Click(object sender, EventArgs e)
        {
            if (nameBox.Text.Length == 0 || teamidBox.Text.Length == 0)
                MessageBox.Show("Name and TeamID are required");
            else
            {
                SqlConnection con = new SqlConnection("Data Source=K-PC;Initial Catalog=OWSTATS;Integrated Security=True;Pooling=False");
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Players set Name=@name,Role=@role,timePlayed=@time,kills=@kills,deaths=@deaths,dmgDone=@dmg,healingDone=@healing,TeamID=@teamID,rank=@rank WHERE Name=@Name", con);
                cmd.Parameters.AddWithValue("@name", nameBox.Text);
                cmd.Parameters.AddWithValue("@role", roleBox.Text);
                cmd.Parameters.AddWithValue("@time", int.Parse(timeBox.Text));
                cmd.Parameters.AddWithValue("@kills", int.Parse(killsBox.Text));
                cmd.Parameters.AddWithValue("@deaths", int.Parse(deathsBox.Text));
                cmd.Parameters.AddWithValue("@dmg", int.Parse(dmgBox.Text));
                cmd.Parameters.AddWithValue("@healing", int.Parse(healingBox.Text));
                cmd.Parameters.AddWithValue("@teamID", int.Parse(teamidBox.Text));
                cmd.Parameters.AddWithValue("@rank", int.Parse(rankBox.Text));
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Succesfully Updated");
                this.Close();
            }
        }

        private void nameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=K-PC;Initial Catalog=OWSTATS;Integrated Security=True;Pooling=False");
            SqlCommand cmd = new SqlCommand("SELECT Role, timePlayed, kills, deaths, dmgDone, healingDone, TeamID, rank FROM Players WHERE Name =@name", con);
            con.Open();
            cmd.Parameters.AddWithValue("@name", nameBox.Text);
            SqlDataReader da = cmd.ExecuteReader();

            if (da.Read())
            {
                roleBox.Text = da.GetValue(0).ToString();
                timeBox.Text = da.GetValue(1).ToString();
                killsBox.Text = da.GetValue(2).ToString();
                deathsBox.Text = da.GetValue(3).ToString();
                dmgBox.Text = da.GetValue(4).ToString();
                healingBox.Text = da.GetValue(5).ToString();
                teamidBox.Text = da.GetValue(6).ToString();
                rankBox.Text = da.GetValue(7).ToString();
            }
        }
    }
}
