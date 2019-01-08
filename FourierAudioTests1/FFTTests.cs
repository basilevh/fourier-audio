// 07-01-2019, BVH

using Microsoft.VisualStudio.TestTools.UnitTesting;
using FourierAudio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourierAudio.Tests
{
    [TestClass()]
    public class FFTTests
    {
        [TestMethod()]
        public void CalculateFrequencyCompsTest()
        {
            double[] input1 = { 1.337 };
            FrequencyComponent[] output1 = FFT.CalculateFrequencyComps(input1, 0.5);
            Assert.AreEqual(1, output1.Length);
            Assert.AreEqual(1.337, output1[0].Real);
            Assert.AreEqual(0.0, output1[0].Imaginary);
            Assert.AreEqual(1.337, output1[0].Magnitude);
            Assert.AreEqual(0.0, output1[0].Phase);
            Assert.AreEqual(0.0, output1[0].Frequency);

            double[] input2 = { 1.337, 0.0 };
            FrequencyComponent[] output2 = FFT.CalculateFrequencyComps(input2, 0.25);
            Assert.AreEqual(2, output2.Length);
            Assert.AreEqual(1.337, output2[0].Real);
            Assert.AreEqual(1.337, output2[1].Real);
            Assert.AreEqual(0.0, output2[0].Imaginary);
            Assert.AreEqual(0.0, output2[1].Imaginary);
            Assert.AreEqual(1.337, output2[0].Magnitude);
            Assert.AreEqual(1.337, output2[1].Magnitude);
            Assert.AreEqual(0.0, output2[0].Phase);
            Assert.AreEqual(0.0, output2[1].Phase);
            Assert.AreEqual(0.0, output2[0].Frequency);
            Assert.AreEqual(2.0, output2[1].Frequency);

            double[] input3 = { 2.34, 0.0, 0.0, 0.0, 2.34, 0.0, 0.0, 0.0 };
            FrequencyComponent[] output3 = FFT.CalculateFrequencyComps(input3, 0.2);
            Assert.AreEqual(8, output3.Length);
            Assert.AreEqual(4.68, output3[0].Real);
            Assert.AreEqual(0.0, output3[1].Real);
            Assert.AreEqual(4.68, output3[2].Real);
            Assert.AreEqual(0.0, output3[3].Real);
            Assert.AreEqual(4.68, output3[4].Real);
            Assert.AreEqual(0.0, output3[5].Real);
            Assert.AreEqual(4.68, output3[6].Real);
            Assert.AreEqual(0.0, output3[7].Real);
            Assert.AreEqual(0.0, output3[0].Imaginary);
            Assert.AreEqual(0.0, output3[1].Imaginary);
            Assert.AreEqual(0.0, output3[2].Imaginary);
            Assert.AreEqual(0.0, output3[3].Imaginary);
            Assert.AreEqual(0.0, output3[4].Imaginary);
            Assert.AreEqual(0.0, output3[5].Imaginary);
            Assert.AreEqual(0.0, output3[6].Imaginary);
            Assert.AreEqual(0.0, output3[7].Imaginary);
            Assert.AreEqual(0.0, output3[0].Frequency);
            Assert.AreEqual(0.625, output3[1].Frequency);
            Assert.AreEqual(1.25, output3[2].Frequency);
            Assert.AreEqual(1.875, output3[3].Frequency);
            Assert.AreEqual(2.5, output3[4].Frequency);
            Assert.AreEqual(3.125, output3[5].Frequency);
            Assert.AreEqual(3.75, output3[6].Frequency);
            Assert.AreEqual(4.375, output3[7].Frequency);

            // Compare against regular DFT (reference)
            Random rnd = new Random();
            const int N = 64;
            double[] input4 = Enumerable.Range(0, N).Select(x => rnd.NextDouble()).ToArray();
            FrequencyComponent[] output4 = FFT.CalculateFrequencyComps(input4, 1.0 / Math.E);
            for (int k = 0; k < N; k++)
            {
                double real = 0.0;
                double imag = 0.0;
                for (int n = 0; n < N; n++)
                {
                    double angle = 2.0 * Math.PI * k * n / N;
                    double cos = Math.Cos(angle);
                    double sin = Math.Sin(angle);
                    real += input4[n] * cos;
                    imag -= input4[n] * sin;
                }
                double magn = Math.Sqrt(real * real + imag * imag);
                double phase = Math.Atan2(imag, real);
                double freq = Math.E * k / N;
                Assert.AreEqual(real, output4[k].Real, 1e-6);
                Assert.AreEqual(imag, output4[k].Imaginary, 1e-6);
                Assert.AreEqual(magn, output4[k].Magnitude, 1e-6);
                try
                {
                    Assert.AreEqual(phase, output4[k].Phase, 1e-6);
                }
                catch (AssertFailedException e)
                {
                    // Might be -pi versus +pi
                    Assert.AreEqual((phase + 2.0 * Math.PI) % (2.0 * Math.PI),
                        (output4[k].Phase + 2.0 * Math.PI) % (2.0 * Math.PI), 1e-6);
                }
                Assert.AreEqual(freq, output4[k].Frequency, 1e-6);
            }
        }
    }
}
