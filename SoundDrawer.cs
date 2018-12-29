// 20-12-2015, BVH

using System;
using System.Drawing;

namespace FourierSong
{
    public class SoundDrawer
    {
        public SoundDrawer(SoundData data)
        {
            this.data = data;
        }

        private SoundData data;

        public bool Draw(Graphics gfx, int width, int height, int centerIndex, double scaleFact, bool lowQuality, bool spectrum, int N, int sampleStep)
        {
            if (data == null)
                return false;

            gfx.Clear(Color.Transparent);
            int leftY = 2 * height / 5;
            int rightY = 3 * height / 5;
            int lineWidth = (lowQuality ? 3 : 1);
            Pen leftPen = new Pen(Color.Lime, lineWidth);
            Pen rightPen = new Pen(Color.Red, lineWidth);

            for (int i = 1; i < width; i += (lowQuality ? 6 : 2))
            {
                int sample = (int)(centerIndex + (i - width / 2) * scaleFact);
                if (sample < 0 || sample >= data.NumSamples)
                    continue;

                short sam1 = data.Samples[0, sample];
                short sam2;
                if (data.NumChannels > 1)
                    sam2 = data.Samples[1, sample];
                else
                    sam2 = sam1;

                gfx.DrawLine(leftPen, i, leftY, i, leftY - sam1 / 128);
                gfx.DrawLine(rightPen, i + lineWidth, rightY, i + lineWidth, rightY + sam2 / 128);
            }

            // Frequency spectrum
            if (spectrum)
            {
                // Draw boundaries
                float leftX = (float)(width / 2 - (sampleStep * N / 2) / scaleFact);
                float rightX = (float)(width / 2 + (sampleStep * N / 2) / scaleFact);
                gfx.DrawLine(Pens.Yellow, leftX, 0, leftX, height);
                gfx.DrawLine(Pens.Yellow, rightX, 0, rightX, height);

                // Sample the interval [-N/2,  N/2)*sampleStep
                double[] sampled = new double[N];
                for (int i = 0; i < N; i++)
                {
                    int index = centerIndex + (i - N / 2) * sampleStep;
                    if (index >= 0 && index < data.NumSamples)
                        sampled[i] = getAbsSample(0, index) / 65535.0;
                }
                double[] dft = new Spectral(sampled).GetFreqComps(N); // real_freq [Hz] = (index / N) * (sample_rate / sample_step)

                // Ignore first one (= constant coefficient, frequency 0)
                for (int i = 1; i < N / 2; i++)
                {
                    float x = width / 2 + 8 * (i - N / 4);
                    double green = Math.Min(Math.Max(dft[i] * 64, 0), 255);
                    Pen pen = new Pen(Color.FromArgb(0, (int)green, 255), 5);
                    gfx.DrawLine(pen, x, height, x, (float)(height - dft[i] * 64));
                }
            }

            return true;
        }

        private ushort getAbsSample(int channel, int sample)
        {
            // zero = lowest
            return (ushort)(data.Samples[channel, sample] + 32768);
        }
    }
}
