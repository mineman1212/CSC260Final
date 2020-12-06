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
    public partial class Stats : Form
    {
        public Stats()
        {
            InitializeComponent();

            SqlConnection con = new SqlConnection("Data Source=K-PC;Initial Catalog=OWSTATS;Integrated Security=True;Pooling=False");
            SqlCommand cmd = new SqlCommand("SELECT Name FROM Teams", con);
            con.Open();
            SqlDataReader da = cmd.ExecuteReader();

            while (da.Read())
            {
                LeftTeamBox.Items.Add(da.GetValue(0).ToString());
                RightTeamBox.Items.Add(da.GetValue(0).ToString());
            }
            con.Close();
        }


        //the two things below will not do anything but they are required for the program for some reason?
        //Breaks the whole program when they are removed
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LabelName_TextChanged(object sender, EventArgs e)
        {

        }
        private void LeftTeamBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=K-PC;Initial Catalog=OWSTATS;Integrated Security=True;Pooling=False");
            SqlCommand cmd = new SqlCommand("SELECT Name, Role, kills, deaths, timePlayed FROM Players WHERE TeamID =@ID",con);

            SqlConnection con1 = new SqlConnection("Data Source=K-PC;Initial Catalog=OWSTATS;Integrated Security=True;Pooling=False");
            SqlCommand cmd1 = new SqlCommand("SELECT Id FROM Teams WHERE Name =@NAME", con1);

            con1.Open();
            cmd1.Parameters.AddWithValue("@NAME", LeftTeamBox.Text);
            SqlDataReader da1 = cmd1.ExecuteReader();
            da1.Read();
            var ID = da1.GetValue(0).ToString();
            cmd.Parameters.AddWithValue("@ID", ID);
            con1.Close();
            con.Open();
            SqlDataReader da = cmd.ExecuteReader();

            if (da.Read())
            {
                leftplayer1name.Text = da.GetValue(0).ToString();
                leftplayer1role.Text = da.GetValue(1).ToString();
                leftplayer1kills.Text = da.GetValue(2).ToString();
                leftplayer1deaths.Text = da.GetValue(3).ToString();
                leftplayer1time.Text = da.GetValue(4).ToString();
            }

            if (da.Read())
            {
                leftplayer2name.Text = da.GetValue(0).ToString();
                leftplayer2role.Text = da.GetValue(1).ToString();
                leftplayer2kills.Text = da.GetValue(2).ToString();
                leftplayer2deaths.Text = da.GetValue(3).ToString();
                leftplayer2time.Text = da.GetValue(4).ToString();
            }

            if (da.Read())
            {
                leftplayer3name.Text = da.GetValue(0).ToString();
                leftplayer3role.Text = da.GetValue(1).ToString();
                leftplayer3kills.Text = da.GetValue(2).ToString();
                leftplayer3deaths.Text = da.GetValue(3).ToString();
                leftplayer3time.Text = da.GetValue(4).ToString();
            }

            if (da.Read())
            {
                leftplayer4name.Text = da.GetValue(0).ToString();
                leftplayer4role.Text = da.GetValue(1).ToString();
                leftplayer4kills.Text = da.GetValue(2).ToString();
                leftplayer4deaths.Text = da.GetValue(3).ToString();
                leftplayer4time.Text = da.GetValue(4).ToString();
            }

            if (da.Read())
            {
                leftplayer5name.Text = da.GetValue(0).ToString();
                leftplayer5role.Text = da.GetValue(1).ToString();
                leftplayer5kills.Text = da.GetValue(2).ToString();
                leftplayer5deaths.Text = da.GetValue(3).ToString();
                leftplayer5time.Text = da.GetValue(4).ToString();
            }

            if (da.Read())
            {
                leftplayer6name.Text = da.GetValue(0).ToString();
                leftplayer6role.Text = da.GetValue(1).ToString();
                leftplayer6kills.Text = da.GetValue(2).ToString();
                leftplayer6deaths.Text = da.GetValue(3).ToString();
                leftplayer6time.Text = da.GetValue(4).ToString();
            }

            con.Close();
        }

        private void RightTeamBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=K-PC;Initial Catalog=OWSTATS;Integrated Security=True;Pooling=False");
            SqlCommand cmd = new SqlCommand("SELECT Name, Role, kills, deaths, timePlayed FROM Players WHERE TeamID =@ID", con);

            SqlConnection con1 = new SqlConnection("Data Source=K-PC;Initial Catalog=OWSTATS;Integrated Security=True;Pooling=False");
            SqlCommand cmd1 = new SqlCommand("SELECT Id FROM Teams WHERE Name =@NAME", con1);

            con1.Open();
            cmd1.Parameters.AddWithValue("@NAME", RightTeamBox.Text);
            SqlDataReader da1 = cmd1.ExecuteReader();
            da1.Read();
            var ID = da1.GetValue(0).ToString();
            cmd.Parameters.AddWithValue("@ID", ID);
            con1.Close();
            con.Open();
            SqlDataReader da = cmd.ExecuteReader();

            if (da.Read())
            {
                rightplayer1name.Text = da.GetValue(0).ToString();
                rightplayer1role.Text = da.GetValue(1).ToString();
                rightplayer1kills.Text = da.GetValue(2).ToString();
                rightplayer1deaths.Text = da.GetValue(3).ToString();
                rightplayer1time.Text = da.GetValue(4).ToString();
            }

            if (da.Read())
            {
                rightplayer2name.Text = da.GetValue(0).ToString();
                rightplayer2role.Text = da.GetValue(1).ToString();
                rightplayer2kills.Text = da.GetValue(2).ToString();
                rightplayer2deaths.Text = da.GetValue(3).ToString();
                rightplayer2time.Text = da.GetValue(4).ToString();
            }

            if (da.Read())
            {
                rightplayer3name.Text = da.GetValue(0).ToString();
                rightplayer3role.Text = da.GetValue(1).ToString();
                rightplayer3kills.Text = da.GetValue(2).ToString();
                rightplayer3deaths.Text = da.GetValue(3).ToString();
                rightplayer3time.Text = da.GetValue(4).ToString();
            }

            if (da.Read())
            {
                rightplayer4name.Text = da.GetValue(0).ToString();
                rightplayer4role.Text = da.GetValue(1).ToString();
                rightplayer4kills.Text = da.GetValue(2).ToString();
                rightplayer4deaths.Text = da.GetValue(3).ToString();
                rightplayer4time.Text = da.GetValue(4).ToString();
            }

            if (da.Read())
            {
                rightplayer5name.Text = da.GetValue(0).ToString();
                rightplayer5role.Text = da.GetValue(1).ToString();
                rightplayer5kills.Text = da.GetValue(2).ToString();
                rightplayer5deaths.Text = da.GetValue(3).ToString();
                rightplayer5time.Text = da.GetValue(4).ToString();
            }

            if (da.Read())
            {
                rightplayer6name.Text = da.GetValue(0).ToString();
                rightplayer6role.Text = da.GetValue(1).ToString();
                rightplayer6kills.Text = da.GetValue(2).ToString();
                rightplayer6deaths.Text = da.GetValue(3).ToString();
                rightplayer6time.Text = da.GetValue(4).ToString();
            }

            con.Close();
        }


        private void clearBtn_Click(object sender, EventArgs e)
        {
            leftplayer1name.Text = " ";
            leftplayer1role.Text = " ";
            leftplayer1kills.Text = " ";
            leftplayer1deaths.Text = " ";
            leftplayer1time.Text = " ";
            
            leftplayer2name.Text = " ";
            leftplayer2role.Text = " ";
            leftplayer2kills.Text = " ";
            leftplayer2deaths.Text = " ";
            leftplayer2time.Text = " ";
            
            leftplayer3name.Text = " ";
            leftplayer3role.Text = " ";
            leftplayer3kills.Text = " ";
            leftplayer3deaths.Text = " ";
            leftplayer3time.Text = " ";
            
            leftplayer4name.Text = " ";
            leftplayer4role.Text = " ";
            leftplayer4kills.Text = " ";
            leftplayer4deaths.Text = " ";
            leftplayer4time.Text = " ";
            
            leftplayer5name.Text = " ";
            leftplayer5role.Text = " ";
            leftplayer5kills.Text = " ";
            leftplayer5deaths.Text = " ";
            leftplayer5time.Text = " ";
            
            leftplayer6name.Text = " ";
            leftplayer6role.Text = " ";
            leftplayer6kills.Text = " ";
            leftplayer6deaths.Text = " ";
            leftplayer6time.Text = " ";

            rightplayer1name.Text = " ";
            rightplayer1role.Text = " ";
            rightplayer1kills.Text = " ";
            rightplayer1deaths.Text = " ";
            rightplayer1time.Text = " ";

            rightplayer2name.Text = " ";
            rightplayer2role.Text = " ";
            rightplayer2kills.Text = " ";
            rightplayer2deaths.Text = " ";
            rightplayer2time.Text = " ";

            rightplayer3name.Text = " ";
            rightplayer3role.Text = " ";
            rightplayer3kills.Text = " ";
            rightplayer3deaths.Text = " ";
            rightplayer3time.Text = " ";

            rightplayer4name.Text = " ";
            rightplayer4role.Text = " ";
            rightplayer4kills.Text = " ";
            rightplayer4deaths.Text = " ";
            rightplayer4time.Text = " ";

            rightplayer5name.Text = " ";
            rightplayer5role.Text = " ";
            rightplayer5kills.Text = " ";
            rightplayer5deaths.Text = " ";
            rightplayer5time.Text = " ";

            rightplayer6name.Text = " ";
            rightplayer6role.Text = " ";
            rightplayer6kills.Text = " ";
            rightplayer6deaths.Text = " ";
            rightplayer6time.Text = " ";
        }

        private void addPlayerBtn_Click(object sender, EventArgs e)
        {
            AddPlayer a = new AddPlayer();
            a.ShowDialog();
        }

        private void AddTeamBtn_Click(object sender, EventArgs e)
        {
            AddTeam a = new AddTeam();
            a.ShowDialog();
        }

        private void editPlayerBtn_Click(object sender, EventArgs e)
        {
            EditPlayer a = new EditPlayer();
            a.ShowDialog();
        }

        private void editTeamBtn_Click(object sender, EventArgs e)
        {
            EditTeam a = new EditTeam();
            a.ShowDialog();
        }
    }
}
