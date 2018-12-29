// 20-12-2015, BVH

using System;

namespace FourierAudio
{
    public class Spectral
    {
        private static double TWO_PI = 2 * Math.PI;

        public Spectral(double[] input)
        {
            this.input = input;
        }

        private double[] input; // 0 to 1

        // Get frequency components (strength); input must be at least size N
        public double[] GetFreqComps(int N)
        {
            double[] dft = new double[N / 2];
            for (int k = 0; k < N / 2; k++) // stop at N/2 because other half is symmetric anyway due to real-valued input
            {
                double sumReal = 0;
                double sumImag = 0;
                double freqFact = TWO_PI * k / N;
                for (int m = 0; m < N; m++)
                {
                    double arg = freqFact * m;
                    double timeVal = input[m];
                    sumReal += timeVal * Math.Cos(arg);
                    sumImag -= timeVal * Math.Sin(arg);
                }
                dft[k] = Math.Sqrt(sumReal * sumReal + sumImag * sumImag);
            }
            return dft;
        }
    }
}
