using _2;
using _6.Models;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6
{
    public partial class ListGUI : Form
    {
        PrnProjectCuoiKy2Context prnProjectCuoiKy2Context;
        private readonly Form99 _form1;
        public ListGUI()
        {
            InitializeComponent();
            //this.playerGUI = playerGUI;
            //if (playerGUI != null) playerGUI.stopSong();
            binz();
        }
        //internal void stopSong()
        //{
        //    waveOutDevice.Stop();
        //    audioFileReader.Dispose();
        //    waveOutDevice.Dispose();
        //}

        private void binz()
        {
            dataGridView1.AllowUserToAddRows = false;
            prnProjectCuoiKy2Context = new PrnProjectCuoiKy2Context();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            DataGridViewButtonColumn Play = new DataGridViewButtonColumn
            {
                Text = "Play",
                Name = "Play",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Insert(0, Play);
            DataGridViewTextBoxColumn txtName = new DataGridViewTextBoxColumn
            {
                Name = "Name of song",
                ReadOnly = true,
            };
            dataGridView1.Columns.Insert(1, txtName);

            DataGridViewTextBoxColumn txtAuthor = new DataGridViewTextBoxColumn
            {
                Name = "Author",
                ReadOnly = true,
            };
            dataGridView1.Columns.Insert(2, txtAuthor);
            DataGridViewButtonColumn Remove = new DataGridViewButtonColumn
            {
                Text = "Remove from list",
                Name = "Remove from list",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Insert(3, Remove);
            DataGridViewButtonColumn id = new DataGridViewButtonColumn
            {
                Text = "id",
                Name = "id",
                UseColumnTextForButtonValue = false
            };
            dataGridView1.Columns.Insert(4, id);
            dataGridView1.Columns[4].Visible = false;
            DataGridViewButtonColumn audioPath = new DataGridViewButtonColumn
            {
                Text = "audioPath",
                Name = "audioPath",
                UseColumnTextForButtonValue = false
            };
            dataGridView1.Columns.Insert(5, audioPath);
            dataGridView1.Columns[5].Visible = false;

            //lay ListNumber cua User
            int listNumber = prnProjectCuoiKy2Context.Lists.Where(a => a.Author.Equals(UserNow.thisUser.UserName)).FirstOrDefault().ListNumber;
            if (listNumber == null)
            {
                return;
            }
            var songNumbers = prnProjectCuoiKy2Context.ListSongs.Where(a => a.ListNumber== listNumber).Select(a=>a.SongNumber);
            label1.Text = "" + songNumbers.Count();
            var songRows = prnProjectCuoiKy2Context.Songs.Where(a=>songNumbers.Contains(a.SongNumber));
            foreach (Song s in songRows)
            {
                dataGridView1.Rows.Add(new Object[6] { null, s.Name, s.Author, null,s.SongNumber,s.AudioPath });
            }
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
            //Playing.audioFileReader = new AudioFileReader("Songs//sample1.mp3");
            //Playing.audioFileReader = new AudioFileReader(@"bin//Debug//net6.0-windows//Song//"+audioPath);
            audioPath = Application.StartupPath + @"\song\" + audioPath;
            Playing.audioFileReader = new AudioFileReader( audioPath);
            Playing.waveOutDevice.Init(Playing.audioFileReader);
            Playing.waveOutDevice.Play();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Play"].Index)
            {
                string audioPath = (string)dataGridView1.Rows[e.RowIndex].Cells["audioPath"].Value;
                label1.Text = audioPath;
                playSong(audioPath);
            }
            else if (e.ColumnIndex == dataGridView1.Columns["Name of song"].Index)
            {

            }
            else if (e.ColumnIndex == dataGridView1.Columns["Author"].Index)
            {

            }
            else if (e.ColumnIndex == dataGridView1.Columns["Remove from list"].Index)
            {
                int songNumber = (int)dataGridView1.Rows[e.RowIndex].Cells["id"].Value;
                removeFromList(songNumber);
                binz();
            }
        }

        private void removeFromList(int songNumber)
        {
            prnProjectCuoiKy2Context=new PrnProjectCuoiKy2Context();
            //lay ListNumber cua User
            int listNumber = prnProjectCuoiKy2Context.Lists.Where(a => a.Author.Equals(UserNow.thisUser.UserName)).FirstOrDefault().ListNumber;
            if (listNumber == null)
            {
                return;
            }
            ListSong thisSongNeedRemove = new ListSong() { ListNumber = listNumber, SongNumber = songNumber };
            prnProjectCuoiKy2Context.ListSongs.Remove(thisSongNeedRemove);
            prnProjectCuoiKy2Context.SaveChanges();
        }
    }
}
