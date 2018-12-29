// 29-12-2018, BVH

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;

namespace FourierAudio
{
    /// <summary>
    /// Responsible for the looped playback of audio files.
    /// </summary>
    public class MySoundPlayer
    {
        public enum PlayerState
        {
            Playing, Stopped
        }

        public MySoundPlayer(SoundFile file)
        {
            this.file = file;
            state = PlayerState.Stopped;
        }

        private SoundFile file;
        private PlayerState state;
        private SoundPlayer player;
        private DateTime playStart;

        public SoundFile File => file;

        public PlayerState State => state;

        public void Start()
        {
            var stream = new MemoryStream(file.FileBytes);
            player = new SoundPlayer(stream);
            player.PlayLooping();
            playStart = DateTime.Now;
            state = PlayerState.Playing;
        }

        public void Stop()
        {
            player.Stop();
            state = PlayerState.Stopped;
        }

        public void Restart()
        {
            Stop();
            Start();
        }

        public void Toggle()
        {
            if (state == PlayerState.Stopped)
                Start();
            else
                Stop();
        }
    }
}
