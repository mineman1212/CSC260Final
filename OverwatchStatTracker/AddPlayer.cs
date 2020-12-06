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
    public partial class AddPlayer : Form
    {
        public AddPlayer()
        {
            InitializeComponent();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (nameBox.Text.Length == 0 || teamidBox.Text.Length == 0)
                MessageBox.Show("Name and TeamID are required");
            else
            {
                SqlConnection con = new SqlConnection("Data Source=K-PC;Initial Catalog=OWSTATS;Integrated Security=True;Pooling=False");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT into Players values (@name,@role,@time,@kills,@deaths,@dmg,@healing,@teamID,@rank)", con);
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
                MessageBox.Show("Succesfully Added");
                this.Close();
            }
        }
    }
}
