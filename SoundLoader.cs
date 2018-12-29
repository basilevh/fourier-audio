// 29-12-2018, BVH

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FourierAudio
{
    /// <summary>
    /// Responsible for reading music files and presenting
    /// their data in an accessible format (i.e. arrays).
    /// </summary>
    public static class SoundLoader
    {
        public static SoundFile ReadFile(string path)
        {
            if (Path.GetExtension(path).ToLower() == ".wav")
            {
                byte[] fileBytes = File.ReadAllBytes(path);
                var result = new SoundFile(fileBytes);
                return result;
            }
            else
                throw new Exception("Only .WAV files are supported for now");
        }
    }
}
