// 20-12-2015, BVH

using System;
using System.Drawing;

namespace FourierAudio
{
    public static class SoundDrawer
    {
        public static bool Draw(MySoundPlayer player, ucSoundDisplay display,
                                Graphics graphics, int centerIndex, double scaleFact,
                                bool lowQuality, bool spectrum, int N, int sampleStep)
        {
            if (player == null || display == null)
                return false;

            var file = player.File;

            graphics.Clear(Color.Transparent);
            int leftY = 2 * display.Height / 5;
            int rightY = 3 * display.Height / 5;
            int lineWidth = (lowQuality ? 3 : 1);
            Pen leftPen = new Pen(Color.Lime, lineWidth);
            Pen rightPen = new Pen(Color.Red, lineWidth);

            for (int i = 1; i < display.Width; i += (lowQuality ? 6 : 2))
            {
                int sample = (int)(centerIndex + (i - display.Width / 2) * scaleFact);
                if (sample < 0 || sample >= file.NumSamples)
                    continue;

                short sam1 = file.Samples[0, sample];
                short sam2;
                if (file.NumChannels > 1)
                    sam2 = file.Samples[1, sample];
                else
                    sam2 = sam1;

                graphics.DrawLine(leftPen, i, leftY, i, leftY - sam1 / 128);
                graphics.DrawLine(rightPen, i + lineWidth, rightY, i + lineWidth, rightY + sam2 / 128);
            }

            // Frequency spectrum
            if (spectrum)
            {
                // Draw boundaries
                float leftX = (float)(display.Width / 2 - (sampleStep * N / 2) / scaleFact);
                float rightX = (float)(display.Width / 2 + (sampleStep * N / 2) / scaleFact);
                graphics.DrawLine(Pens.Yellow, leftX, 0, leftX, display.Height);
                graphics.DrawLine(Pens.Yellow, rightX, 0, rightX, display.Height);

                // Sample the interval [-N/2,  N/2)*sampleStep
                double[] sampled = new double[N];
                for (int i = 0; i < N; i++)
                {
                    int index = centerIndex + (i - N / 2) * sampleStep;
                    if (index >= 0 && index < file.NumSamples)
                        sampled[i] = (file.Samples[0, index] + 32768.0) / 65535.0;
                }
                FrequencyComponent[] freqComps = FFT.CalculateFrequencyComps(sampled, sampleStep / file.SampleRate);

                // Ignore first one (= constant coefficient, frequency 0)
                for (int i = 1; i < N / 2; i++)
                {
                    float x = display.Width / 2 + 8 * (i - N / 4);
                    double green = Math.Min(Math.Max(freqComps[i].Magnitude * 64, 0), 255);
                    Pen pen = new Pen(Color.FromArgb(0, (int)green, 255), 5);
                    graphics.DrawLine(pen, x, display.Height, x, (float)(display.Height - freqComps[i].Magnitude * 64));
                }
            }

            return true;
        }
    }
}
