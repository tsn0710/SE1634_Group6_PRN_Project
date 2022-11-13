using ProjectPRN211;
using User_MusicStore;

namespace _6
{
    public partial class Form99 : Form
    {
        private PlayerGUI playerGUI;
        private ListGUI listGUI;

        public Form99()
        {
            InitializeComponent();
            if (UserNow.thisUser.Role != 1)
            {
                adminManageUsersToolStripMenuItem.Visible = false;
                adminManageSongsToolStripMenuItem.Visible = false;
            }
            else
            {
                adminManageUsersToolStripMenuItem.Visible = true;
                adminManageSongsToolStripMenuItem.Visible = true;
            }
        }

        private void playerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            playerGUI = new PlayerGUI();
            playerGUI.TopLevel = false;
            playerGUI.FormBorderStyle = FormBorderStyle.None;
            playerGUI.Show();

            toolStripContainer2.ContentPanel.Controls.Clear();
            toolStripContainer2.ContentPanel.Controls.Add(playerGUI);
        }

        private void mainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listGUI = new ListGUI();
            listGUI.TopLevel = false;
            listGUI.FormBorderStyle = FormBorderStyle.None;
            listGUI.Show();

            toolStripContainer2.ContentPanel.Controls.Clear();
            toolStripContainer2.ContentPanel.Controls.Add(listGUI);
        }

        private void playerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            playerGUI = new PlayerGUI();
            playerGUI.TopLevel = false;
            playerGUI.FormBorderStyle = FormBorderStyle.None;
            playerGUI.Show();

            toolStripContainer2.ContentPanel.Controls.Clear();
            toolStripContainer2.ContentPanel.Controls.Add(playerGUI);
        }

        private void adminManageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminManageUsers adminManageUsers = new AdminManageUsers();
            adminManageUsers.TopLevel = false;
            adminManageUsers.FormBorderStyle = FormBorderStyle.None;
            adminManageUsers.Show();

            toolStripContainer2.ContentPanel.Controls.Clear();
            toolStripContainer2.ContentPanel.Controls.Add(adminManageUsers);
        }

        private void adminManageSongsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminManageSongs adminManageSongs = new AdminManageSongs();
            adminManageSongs.TopLevel = false;
            adminManageSongs.FormBorderStyle = FormBorderStyle.None;
            adminManageSongs.Show();

            toolStripContainer2.ContentPanel.Controls.Clear();
            toolStripContainer2.ContentPanel.Controls.Add(adminManageSongs);
        }

        private void myMusicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyMusic myMusic = new MyMusic();
            myMusic.TopLevel = false;
            myMusic.FormBorderStyle = FormBorderStyle.None;
            myMusic.Show();

            toolStripContainer2.ContentPanel.Controls.Clear();
            toolStripContainer2.ContentPanel.Controls.Add(myMusic);
        }

        private void Form99_Load(object sender, EventArgs e)
        {
        }

        private void toolStripContainer2_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserNow.thisUser = null;
            this.Close();
        }
    }
}