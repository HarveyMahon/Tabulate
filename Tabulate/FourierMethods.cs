using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.IntegralTransforms;
using MathNet.Numerics;

namespace Tabulate
{
    class FourierMethods
    {
        #region Attributes

        //stores the notes used in the program
        static Dictionary<String, double> notes = new Dictionary<string, double>();
        //c0 is the note used for tuning
        static double c0 = 16.35;
        /*
         * value of 2^(1/12)
         * * comes out as 1 when calculated so is best stored in this manner
         */
        static double a = 1.0594630943592952646;

        #endregion

        #region Methods

        static void fillNoteDict()
        {
            /*
             * 63 notes
             * adding the notes that the program will be able to identify
             * fn = f0 * (a)^n
             * f0 is a fixed note that is defined
             * n = number of half steps away
             * a = 2(1/12)
             */
            //starting octave is 0
            int octave = 0;
            //the set note
            /*
             * the below loop creates all of the appropriate notes in a dictionary
             * * i represents the amount of halftones above c0
             */
            for (int i = 0; i < 108; i++)
            {
                string note = "";
                double frequency = c0 * Math.Pow(a, i);
                //the below switch creates the keys and assigns them the appropriate frequency
                switch (i % 12)
                {
                    case 0:
                        note = "C" + octave.ToString();
                        notes.Add(note, frequency);
                        break;
                    case 1:
                        note = "C#" + octave.ToString();
                        notes.Add(note, frequency);
                        break;
                    case 2:
                        note = "D" + octave.ToString();
                        notes.Add(note, frequency);
                        break;
                    case 3:
                        note = "D#" + octave.ToString();
                        notes.Add(note, frequency);
                        break;
                    case 4:
                        note = "E" + octave.ToString();
                        notes.Add(note, frequency);
                        break;
                    case 5:
                        note = "F" + octave.ToString();
                        notes.Add(note, frequency);
                        break;
                    case 6:
                        note = "F#" + octave.ToString();
                        notes.Add(note, frequency);
                        break;
                    case 7:
                        note = "G" + octave.ToString();
                        notes.Add(note, frequency);
                        break;
                    case 8:
                        note = "G#" + octave.ToString();
                        notes.Add(note, frequency);
                        break;
                    case 9:
                        note = "A" + octave.ToString();
                        notes.Add(note, frequency);
                        break;
                    case 10:
                        note = "A#" + octave.ToString();
                        notes.Add(note, frequency);
                        break;
                    case 11:
                        note = "B" + octave.ToString();
                        notes.Add(note, frequency);
                        octave++;
                        break;
                    default:
                        Console.WriteLine("Unknown Error: i = " + i);
                        break;
                }
            }
        }

        public static Complex32[] fourier(float[] sample)
        {
            /*
             * Field        Length  Contents
             * ckID         4       chunk ID: "RIFF"
             * ckSize       4       chunk size: 4+n
             * WaveID       4       wave ID: "Wave"
             * wave chunks  n       the audio 
             * ---------------------------------
             * ck size says each chunk is 4 bytes long (ignore n)
             * 4*(4+4+4) = 48
             * therefore remove first 48 bytes
             */

            Complex32[] audioData = new Complex32[sample.Length - 44];
            
            //first 48 bytes are header

            for (int i = 44; i < audioData.Length; i++)
            {
                audioData[i-44] = new Complex32(0, sample[i]);
            }
            for (int i = 0; i < audioData.Length; ++i)
            {
                Complex32 c = audioData[i];
                if (c == null) break;
                float c1 = c.Real;
                string cStr = c1.ToString();
            }
            Fourier.Forward(audioData);
            return audioData;
        }

        public static string[] getNotesFromFourier(Complex32[] audioData)
        {
            string[] output = new string[44100];
            float freq = 0;
            float sr = 44100;
            int count = 0;
            float cLast1 = 0;
            float cLast2 = 0;
            for (int i = 0; i < audioData.Length / 2; ++i)
            {
                //tranformed audio
                Complex32 c = audioData[i];
                //shouldn't trigger, but here to stop null pointer error
                if (c == null) break;
                //finding the absolute value of the point on the graph
                float c1 = (float)Math.Sqrt(Math.Pow((double)c.Real, 2) + Math.Pow((double)c.Imaginary, 2));
                //detecting the frequncy at this point on the graph
                float c2 = (float)((i * sr) / (float)audioData.Length);
                //break when above the maximum frequcny the application wants to detect
                if (c2 > 8000) break;
                //detecting peaks
                if (cLast1 > cLast2 && cLast1 > c1 && cLast1 > 5)
                {
                    string outp = noteFromFrequency(freq);
                    //Console.WriteLine(freq);
                    //Console.WriteLine(outp);
                    if (outp.Length < 5) { 
                        string note = noteFromFrequency(freq);
                        if (!output.Contains<string>(note)) {
                            output[count] = note;
                        }
                        count++;
                    }
                }
                string cStr = c1.ToString();
                //cStr = Regex.Replace(cStr, @"\(", "");
                //cStr = Regex.Replace(cStr, @"\)", "");
                //setting vars for detecting peaks
                freq = c2;
                cLast2 = cLast1;
                cLast1 = c1;
            }
            return output;
        }

        public static string noteFromFrequency(double frequency)
        {
            //inputNote ~= c0 * Math.Pow(a, i);
            int i = (int)Math.Round(Math.Log((frequency / c0), a));
            //getting the note name
            int octave = i / 12;
            string note = "";

            switch (i % 12)
            {
                case 0:
                    note = "C" + octave.ToString();
                    break;
                case 1:
                    note = "C#" + octave.ToString();
                    break;
                case 2:
                    note = "D" + octave.ToString();
                    break;
                case 3:
                    note = "D#" + octave.ToString();
                    break;
                case 4:
                    note = "E" + octave.ToString();
                    break;
                case 5:
                    note = "F" + octave.ToString();
                    break;
                case 6:
                    note = "F#" + octave.ToString();
                    break;
                case 7:
                    note = "G" + octave.ToString();
                    break;
                case 8:
                    note = "G#" + octave.ToString();
                    break;
                case 9:
                    note = "A" + octave.ToString();
                    break;
                case 10:
                    note = "A#" + octave.ToString();
                    break;
                case 11:
                    note = "B" + octave.ToString();
                    break;
                default:
                    //Console.WriteLine("Unknown Error: i = " + i);
                    break;
            }

            return note;
        }

        #endregion
    }
}
