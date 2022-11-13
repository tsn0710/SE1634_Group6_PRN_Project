using _2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NAudio;
using NAudio.Wave;
using _6.Models;

namespace _6
{
    public partial class PlayerGUI : Form
    {
        private PrnProjectCuoiKy2Context prnProjectCuoiKy2Context;
        private readonly Form99 _form1;
        //private ListGUI listGUI;
        //private IWavePlayer waveOutDevice;
        //private AudioFileReader audioFileReader;
        public PlayerGUI()
        {
            InitializeComponent();
            ////if song playing thi tat di
            //if (Playing.waveOutDevice != null)
            //{
            //    Playing.waveOutDevice.Stop();
            //    Playing.audioFileReader.Dispose();
            //    Playing.waveOutDevice.Dispose();
            //}
            ////khoi dau va choi
            //Playing.waveOutDevice = new WaveOut();
            //Playing.audioFileReader = new AudioFileReader("Songs//sample1.mp3");
            //Playing.waveOutDevice.Init(Playing.audioFileReader);
            //Playing.waveOutDevice.Play();

            binz();
        }
        public void binz()
        {
            prnProjectCuoiKy2Context = new PrnProjectCuoiKy2Context();
            if (Playing.pathOfSongPlaying == null)
            {
                //hien thi anh
                pictureBox1.ImageLocation = @"C:\\Users\\Thinkpad\\Desktop\\projectPRN\\6\\bin\\Debug\\net6.0-windows\\Image\\defaultIMG.png";
                //hien thi ten author
                label3.Text = "";
                //hien thi ten bai hat
                label4.Text = "";
                //hien thi lyric
                textBox1.Text = "";
                return;
            }
            //lay bai hat dang choi
            Song thisSongPlaying = prnProjectCuoiKy2Context.Songs.Where(s=>s.AudioPath.Equals(Playing.pathOfSongPlaying)).FirstOrDefault();
            //hien thi anh
            string path = Application.StartupPath + @"Image\" + thisSongPlaying.ImgPath;
            string path2 = path.Replace(@"\", @"\\");
            pictureBox1.ImageLocation = path2;
            if (thisSongPlaying.ImgPath==null || thisSongPlaying.ImgPath.Trim().Length == 0)
            {
                pictureBox1.ImageLocation = @"C:\\Users\\Thinkpad\\Desktop\\projectPRN\\6\\bin\\Debug\\net6.0-windows\\Image\\defaultIMG.png";
            }
            //hien thi ten author
            label3.Text = thisSongPlaying.Author ;
            //hien thi ten bai hat
            label4.Text = thisSongPlaying.Name ;
            //hien thi lyric
            textBox1.Text = thisSongPlaying.Lyric;
            textBox1.ReadOnly = true;
            //textBox1.Text = path2;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if song not playing thi thoi
            if (Playing.waveOutDevice == null)
            {
            }
            //if song playing thi tat di roi thoi
            else
            {
                Playing.waveOutDevice.Stop();
                Playing.audioFileReader.Dispose();
                Playing.waveOutDevice.Dispose();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
