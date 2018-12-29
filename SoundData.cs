// 20-12-2015, BVH

using System;
using System.IO;
using System.Text;

namespace FourierSong
{
    public class SoundData
    {
        public readonly string ChunkID;
        public readonly int ChunkSize;
        public readonly string Format;
        public readonly string Subchunk1ID;
        public readonly int Subchunk1Size;
        public readonly short AudioFormat;
        public readonly short NumChannels;
        public readonly int SampleRate;
        public readonly int ByteRate;
        public readonly short BlockAlign;
        public readonly short BitsPerSample;
        public readonly string Subchunk2ID;
        public readonly int Subchunk2Size;
        public readonly int NumSamples;
        public readonly double LengthMs;

        public SoundData(string path)
        {
            file = File.ReadAllBytes(path);
            ChunkID = Encoding.Default.GetString(file, 0, 4); // "RIFF"
            ChunkSize = BitConverter.ToInt32(file, 4); // 36 + Subchunk2Size

            Format = Encoding.Default.GetString(file, 8, 4); // "WAVE"
            Subchunk1ID = Encoding.Default.GetString(file, 12, 4); // "fmt "
            Subchunk1Size = BitConverter.ToInt32(file, 16); // 16 for PCM
            // Subchunk 1
            AudioFormat = BitConverter.ToInt16(file, 20); // 1 for PCM (Linear quantization)
            NumChannels = BitConverter.ToInt16(file, 22); // Mono = 1, Stereo = 2, etc.
            SampleRate = BitConverter.ToInt32(file, 24); // eg. 44100
            ByteRate = BitConverter.ToInt32(file, 28); // SampleRate * NumChannels * BitsPerSample / 8
            BlockAlign = BitConverter.ToInt16(file, 32); // NumChannels * BitsPerSample / 8
            BitsPerSample = BitConverter.ToInt16(file, 34);
            // <assuming no ExtraParams>

            Subchunk2ID = Encoding.Default.GetString(file, 36, 4); // "data"
            Subchunk2Size = BitConverter.ToInt32(file, 40); // NumSamples * NumChannels * BitsPerSample / 8
            // Subchunk 2
            bytes = new byte[Subchunk2Size];
            Array.Copy(file, 44, bytes, 0, Subchunk2Size);

            // Derived
            NumSamples = Subchunk2Size / BlockAlign;
            LengthMs = 1000.0 * NumSamples / SampleRate;

            initSamples();
        }

        private byte[] file;
        private byte[] bytes;
        private short[,] samples; // channel index -> sample index

        public byte[] FileBytes
        {
            get { return file; }
        }

        public byte[] Bytes
        {
            get { return bytes; }
        }

        public short[,] Samples
        {
            get { return samples; }
        }

        private void initSamples()
        {
            // assumes 16 bits per sample!
            samples = new short[NumChannels, NumSamples];
            for (int i = 0; i < bytes.Length; i += 2)
            {
                int channel = (i / 2) % NumChannels;
                int sample = i / (2 * NumChannels);
                samples[channel, sample] = BitConverter.ToInt16(bytes, i);
            }
        }
    }
}
