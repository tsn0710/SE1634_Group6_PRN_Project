using _6.Models;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    internal class Playing
    {
        public static string pathOfSongPlaying { get; set; }
        public static IWavePlayer waveOutDevice { get; set; }
        public static AudioFileReader audioFileReader { get; set; }
    }
}
