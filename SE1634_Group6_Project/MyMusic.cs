using Microsoft.EntityFrameworkCore;
using NAudio.Wave;
using System.Security.Cryptography.X509Certificates;
using _6.Models;
using _2;
using _6;

namespace User_MusicStore
{
    public partial class MyMusic : Form
    {
        PrnProjectCuoiKy2Context _context = new();
        User userform = UserNow.thisUser;
        public MyMusic()
        {
            InitializeComponent();
            _context = new PrnProjectCuoiKy2Context();
            userform = UserNow.thisUser;
            bindGrid();
        }
        void bindGrid()
        {
            textBox1.Enabled = true;
            _context = new PrnProjectCuoiKy2Context();
            dataGridView1.Columns.Clear();
            DataGridViewButtonColumn Play = new DataGridViewButtonColumn
            {
                Text = "Play",
                Name = "Play",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Insert(0, Play);
            dataGridView1.DataSource = _context.Songs.Where(a=> a.IsHide == false).ToList();
            dataGridView1.Columns["AuthorNavigation"].Visible = false;
            dataGridView1.Columns["ListSongs"].Visible = false;
            dataGridView1.Columns["isHide"].Visible = false;
            int count = dataGridView1.Columns.Count;
            DataGridViewButtonColumn AddToFavoriteList = new DataGridViewButtonColumn
            {
                Text = "Add To Favorite List",
                Name = "Add To Favorite List",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Insert(count, AddToFavoriteList);
            button3.Visible = false;
            button3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            dataGridView1.DataSource = _context.Songs.Where(a => a.Author == userform.UserName && a.IsHide == false).ToList();
            int count = dataGridView1.Columns.Count;
            button3.Visible = true;
            button3.Enabled = true;
            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn()
            {
                Text = "Edit",
                Name = "Edit",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Insert(count, btnEdit);
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn()
            {
                Text = "Delete",
                Name = "Delete",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Insert(count + 1, btnDelete);
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            button1.Enabled = true;
            bindGrid();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            EditAddMusic form2 = new EditAddMusic(-1);
            form2.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }



        private void playSong(string audioPath)
        {
            Playing.pathOfSongPlaying = audioPath;
            //if song not playing thi khoi dau va choi
            if (Playing.waveOutDevice == null)
            {
            }
            //if song playing thi tat di va khoi dau va choi
            else
            {
                Playing.waveOutDevice.Stop();
                Playing.audioFileReader.Dispose();
                Playing.waveOutDevice.Dispose();
            }
            Playing.waveOutDevice = new WaveOut();
            audioPath = Application.StartupPath + @"\song\" + audioPath;
            //MessageBox.Show("bin//Debug//net6.0-windows//song//"+audioPath);
            //Playing.audioFileReader = new AudioFileReader("Songs//sample1.mp3");

            Playing.audioFileReader = new AudioFileReader(audioPath);
            Playing.waveOutDevice.Init(Playing.audioFileReader);
            Playing.waveOutDevice.Play();
        }

        private void stopSong()
        {
            //if song not playing thi khoi dau va choi
            if (Playing.waveOutDevice == null)
            {
            }
            //if song playing thi tat di va khoi dau va choi
            else
            {
                Playing.waveOutDevice.Stop();
                Playing.audioFileReader.Dispose();
                Playing.waveOutDevice.Dispose();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            stopSong();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Play"].Index)
            {
                string audioPath = (string)dataGridView1.Rows[e.RowIndex].Cells["audioPath"].Value;
                playSong(audioPath);
                return;
            }
            if (e.ColumnIndex == dataGridView1.Columns["Add To Favorite List"].Index)
            {
                int songNumber = (int)dataGridView1.Rows[e.RowIndex].Cells["songNumber"].Value;
                AddToFavoriteList(songNumber);
                return;
            }
            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
            {
                int songNumber = (int)dataGridView1.Rows[e.RowIndex].Cells["songNumber"].Value;
                DialogResult dr = MessageBox.Show("Do you want to delete?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        Song song = _context.Songs.Find(songNumber);
                        _context.Songs.Remove(song);
                        _context.SaveChanges();
                        MessageBox.Show("Deleted!");
                        dataGridView1.Columns.Clear();
                        bindGrid();
                    }
                    catch
                    {
                        MessageBox.Show("Failled");
                    }
                }
                return;
            }
            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index)
            {
                int songNumber = (int)dataGridView1.Rows[e.RowIndex].Cells["songNumber"].Value;
                EditAddMusic form2 = new EditAddMusic(songNumber);
                DialogResult dr = form2.ShowDialog();
                if (dr == DialogResult.OK)
                    dataGridView1.Columns.Clear();
                bindGrid();
                return;
            }
        }

        private void AddToFavoriteList(int songNumber)
        {
            _context = new PrnProjectCuoiKy2Context();
            int listNumber = _context.Lists.Where(a => a.Author == UserNow.thisUser.UserName).Select(a => a.ListNumber).FirstOrDefault();
            var x = _context.ListSongs.Where(a => a.ListNumber == listNumber && a.SongNumber == songNumber);
            bool isAdded = x.Count() != 0;
            if (isAdded == false)
            {
                _context.ListSongs.Add(new ListSong() { ListNumber = listNumber, SongNumber = songNumber });
                _context.SaveChanges();
                MessageBox.Show("This song added to favorite list");
            }
            else
            {
                MessageBox.Show("This song added to favorite list");
            }
            
        }

        private void aaa(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            var songs = _context.Songs.Where(a => a.Name.Contains(textBox1.Text) && a.IsHide==false).ToList();
            _context = new PrnProjectCuoiKy2Context();
            dataGridView1.Columns.Clear();
            DataGridViewButtonColumn Play = new DataGridViewButtonColumn
            {
                Text = "Play",
                Name = "Play",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Insert(0, Play);
            
            dataGridView1.DataSource = songs;
            dataGridView1.Columns["AuthorNavigation"].Visible = false;
            dataGridView1.Columns["ListSongs"].Visible = false;
            dataGridView1.Columns["isHide"].Visible = false;
            int count = dataGridView1.Columns.Count;
            DataGridViewButtonColumn AddToFavoriteList = new DataGridViewButtonColumn
            {
                Text = "Add To Favorite List",
                Name = "Add To Favorite List",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Insert(count, AddToFavoriteList);
            button3.Visible = false;
            button3.Enabled = false;
        }
    }
}