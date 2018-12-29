// 20-12-2015, BVH

using System;
using System.IO;
using System.Text;

namespace FourierAudio
{
    /// <summary>
    /// Represents all parameters of a WAVE audio file, including samples.
    /// </summary>
    public class SoundFile
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

        public SoundFile(byte[] fileBytes)
        {
            this.fileBytes = fileBytes;
            ChunkID = Encoding.Default.GetString(fileBytes, 0, 4); // "RIFF"
            ChunkSize = BitConverter.ToInt32(fileBytes, 4); // 36 + Subchunk2Size
            Format = Encoding.Default.GetString(fileBytes, 8, 4); // "WAVE"

            // Subchunk 1
            Subchunk1ID = Encoding.Default.GetString(fileBytes, 12, 4); // "fmt "
            Subchunk1Size = BitConverter.ToInt32(fileBytes, 16); // 16 for PCM
            AudioFormat = BitConverter.ToInt16(fileBytes, 20); // 1 for PCM (Linear quantization)
            NumChannels = BitConverter.ToInt16(fileBytes, 22); // Mono = 1, Stereo = 2, etc.
            SampleRate = BitConverter.ToInt32(fileBytes, 24); // eg. 44100
            ByteRate = BitConverter.ToInt32(fileBytes, 28); // SampleRate * NumChannels * BitsPerSample / 8
            BlockAlign = BitConverter.ToInt16(fileBytes, 32); // NumChannels * BitsPerSample / 8
            BitsPerSample = BitConverter.ToInt16(fileBytes, 34);
            // (assuming no ExtraParams)

            // Subchunk 2
            Subchunk2ID = Encoding.Default.GetString(fileBytes, 36, 4); // "data"
            Subchunk2Size = BitConverter.ToInt32(fileBytes, 40); // NumSamples * NumChannels * BitsPerSample / 8
            sampleBytes = new byte[Subchunk2Size];
            Array.Copy(fileBytes, 44, sampleBytes, 0, Subchunk2Size);

            // Extra derived information
            NumSamples = Subchunk2Size / BlockAlign;
            LengthMs = 1000.0 * NumSamples / SampleRate;

            initSamples();
        }

        private byte[] fileBytes;
        private byte[] sampleBytes;
        private short[,] samples; // channel index -> sample index

        public byte[] FileBytes
        {
            get { return fileBytes; }
        }

        public byte[] SampleBytes
        {
            get { return sampleBytes; }
        }

        public short[,] Samples
        {
            get { return samples; }
        }

        private void initSamples()
        {
            // TODO: support more than 16 bit

            if (BitsPerSample == 16)
            {
                samples = new short[NumChannels, NumSamples];
                for (int i = 0; i < sampleBytes.Length; i += 2)
                {
                    int channel = (i / 2) % NumChannels;
                    int sample = i / (2 * NumChannels);
                    samples[channel, sample] = BitConverter.ToInt16(sampleBytes, i);
                }
            }
            else
                throw new Exception("Only 16-bit samples are supported for now");
        }
    }
}
