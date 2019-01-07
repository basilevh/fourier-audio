// 20-12-2015, BVH
// 07-01-2019: Changed DFT to FFT

using System;

namespace FourierAudio
{
    public struct FrequencyComponent
    {
        public FrequencyComponent(double f, double r, double i)
        {
            Frequency = f;
            Real = r;
            Imaginary = i;
            Magnitude = Math.Sqrt(r * r + i * i);
            Phase = Math.Atan2(i, r);
        }

        public readonly double Frequency;
        public readonly double Real, Imaginary;
        public readonly double Magnitude, Phase;
    }

    public class FFT
    {
        private static readonly double TWO_PI = 2.0 * Math.PI;

        /// <summary>
        /// Calculates the frequency spectrum of a time-domain signal using a Fast Fourier Transform algorithm.
        /// </summary>
        /// <param name="timeComps">The time-domain signal, the length (N) of which must be a power of two.</param>
        /// <param name="samplePeriod">The sampling period of the time-domain signal.
        /// This parameter is not necessary but can be useful to mark the actual output frequencies correctly.</param>
        /// <returns>An array of length N containing detailed information about the DFT values at each frequency.</returns>
        public static FrequencyComponent[] CalculateFrequencyComps(double[] timeComps, double samplePeriod)
        {
            // Verify length
            int N = timeComps.Length;
            if ((N & (N - 1)) != 0)
            {
                throw new ArgumentException("The input signal size is not a power of two.");
            }

            // Calculate and convert FFT
            FrequencyComponent[] result = new FrequencyComponent[N];
            double[,] fft = CooleyTukeyFFT(timeComps, N, 0, 1);
            for (int k = 0; k < N; k++)
            {
                double frequency = 1.0 / samplePeriod * k / N;
                result[k] = new FrequencyComponent(frequency, fft[k, 0], fft[k, 1]);
            }
            return result;
        }

        private static double[,] CooleyTukeyFFT(double[] input, int N, int offset, int step)
        {
            double[,] result = new double[N, 2];
            if (N > 1)
            {
                // X(k)     = E(k) - O(k) * w^k
                // X(k+N/2) = E(k) + O(k) * w^k
                // where E(k) = FFT{x(0), x(2), x(4), ...}
                //       O(k) = FFT{x(1), x(3), x(5), ...}
                //       w = exp(-i*2*pi/N)
                double[,] even = CooleyTukeyFFT(input, N / 2, offset, step * 2);
                double[,] odd = CooleyTukeyFFT(input, N / 2, offset + step, step * 2);
                for (int k = 0; k < N / 2; k++)
                {
                    double angle = TWO_PI * k / N;
                    double cos = Math.Cos(angle);
                    double sin = Math.Sin(angle);
                    double oddTermReal = odd[k, 0] * cos + odd[k, 1] * sin;
                    double oddTermImag = odd[k, 1] * cos - odd[k, 0] * sin;
                    result[k, 0] = even[k, 0] + oddTermReal;
                    result[k, 1] = even[k, 1] + oddTermImag;
                    result[k + N / 2, 0] = even[k, 0] - oddTermReal;
                    result[k + N / 2, 1] = even[k, 1] - oddTermImag;
                }
            }
            else
            {
                result[0, 0] = input[offset];
                result[0, 1] = 0.0;
            }
            return result;
        }
    }
}
