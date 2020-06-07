using NAudio.Wave;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Tabulate
{
    public partial class EditForm : Form
    {
        #region Attributes

        string tempFile = @"..\..\audio files\temp.wav";
        //
        AudioFileReader reader;
        WaveChannel32 sample;
        //byte[] data;
        int iniXs = 0;
        int iniXe = 0;
        int rightBoxStart;
        //both will be stored as a value between 1 and 0
        int start = 0;
        int end = 1;

        #endregion

        #region Constructors

        public EditForm(WaveChannel32 sample, AudioFileReader reader)
        {
            this.reader = reader;
            this.sample = sample;
            InitializeComponent();
            rightBoxStart = RightBox.Location.X;
        }

        #endregion

        #region Events

        private void EditForm_Load(object sender, EventArgs e)
        {
            StartSlider.Volume = 0;
            //showing the wave
            UpdateWaveform(sample);
        }

        private void ButEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.FromArgb(0x222222);
        }

        private void ButLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Black;
        }

        //slider values are between 0 and width

        private void TrimButton_Click(object sender, EventArgs e)
        {
            //attempt 4 - modified attempt 3
            //Read must read complete blocks, therefore this sometimes throws an error
            //int bytesPerMilli = sample.WaveFormat.AverageBytesPerSecond / 1000;
            start = (int)(sample.Length * ((float)(LeftBox.Width - 10) / (float)StartSlider.Width));
            end = (int)(sample.Length * ((float)(RightBox.Location.X - EndSlider.Location.X) / (float)EndSlider.Width));
            int newLength = end - start;
            //rounding newLength up to be a multiple of 1024 (the size of 1 block)
            newLength += (1024 - (newLength % 1024));
            Console.WriteLine(newLength / 1024);
            //
            reader.Position = start;
            byte[] buffer = new byte[newLength];
            //reading
            int numRead = reader.Read(buffer, 0, newLength);
            WaveFormat wf = reader.WaveFormat;
            reader.Dispose();
            reader = null;
            //writing
            WaveFileWriter writer = new WaveFileWriter(tempFile, wf);
            writer.Write(buffer, 0, numRead);
            writer.Dispose();
            writer = null;
            //recreating reader
            reader = new AudioFileReader(tempFile);
            //recreating sample
            sample = new WaveChannel32(reader);
            //updating the waveform
            UpdateWaveform(sample);
            //https://markheath.net/post/trimming-wav-file-using-naudio
            /*attempt 3 - very difficult to get working, required a new temp file
            start = (int)(sample.Length * ((float)(LeftBox.Width - 10) / (float)StartSlider.Width));
            end = (int)(sample.Length * ((float)(RightBox.Location.X - EndSlider.Location.X) / (float)EndSlider.Width));
            //
            reader.Position = start;
            //1024 is the size of 1 block
            byte[] buffer = new byte[1024];
            WaveFormat wf = new WaveFormat(44100, 32, 2);
            //not a supported file format !!!!!!
            //WaveStream ws = new NullWaveStream(wf, end - start);
            //creating an empty wavechannel , that will be used to write to the temp file after it has been trimmed
            //WaveChannel32 holder = new WaveChannel32(ws);
            //reading
            while (reader.Position < end)
            {
                int bytesRequired = end - (int)reader.Position;
                if (bytesRequired > 0)
                {
                    //setting the amount of bytes to read to the smaller value of bytesRequired and buffer.length
                    int toRead = (bytesRequired > buffer.Length) ? bytesRequired : buffer.Length;
                    int numRead = reader.Read(buffer, 0, toRead);
                    //writing
                    if (toRead > 0)
                    {
                        WaveFileWriter writer = new WaveFileWriter(tempFile, wf);   
                        writer.Write(buffer, 0, numRead);
                    }
                }
            }
            //reader.Dispose();
            ////writing
            ////recreating reader
            //reader = new AudioFileReader(tempFile);
            */
            /*attempt 2 - works, but ruins the audio quality ?????
            //Read must read complete blocks, therefore this sometimes throws an error
            //int bytesPerMilli = sample.WaveFormat.AverageBytesPerSecond / 1000;
            start = (int)(sample.Length * ((float)(LeftBox.Width - 10) / (float)StartSlider.Width));
            end = (int)(sample.Length * ((float)(RightBox.Location.X - EndSlider.Location.X) / (float)EndSlider.Width));
            //
            reader.Position = start;
            byte[] buffer = new byte[end-start];
            //reading
            int numRead = reader.Read(buffer, 0, end - start);
            reader.Dispose();
            //writing
            WaveFormat wf = new WaveFormat(44100, 32, 2);
            WaveFileWriter writer = new WaveFileWriter(tempFile, wf);
            writer.Write(buffer, 0 , numRead);
            writer.Dispose();
            //recreating reader
            reader = new AudioFileReader(tempFile);
            */
            /*attempt 1
            //reader.Dispose();
            byte[] data = new byte[sample.Length];
            int read = sample.Read(data, 0, (int)sample.Length);
            //this gets the amount of samples as well as copying the byte data to an array
            int sampleCount = sample.Read(data, 0, (int)sample.Length);
            //finding the start and end sample, based on the position of the sliders
            start = (int)(sampleCount * ((float)(LeftBox.Width - 10) / (float)StartSlider.Width));
            end = (int)(sampleCount * ((float)(RightBox.Location.X - EndSlider.Location.X) / (float)EndSlider.Width));
            int newLength = end - start;
            byte[] newSample = new byte[newLength];
            //copting the data from data to newSample from the start sample to the end sample
            //for some reason all copied values are 0
            ////all of the data in data appears to be 0
            Array.ConstrainedCopy(data, start, newSample, 0, newLength);
            //changing sample to have the data in newSample (by changing the data in tempFile)
            //https://stackoverflow.com/questions/2665362/convert-byte-array-to-wav-file
            //http://www.topherlee.com/software/pcm-tut-wavformat.html
            sample.Dispose();
            sample = null;
            //re-writing to sample
            //creating the header
            WaveFormat wf = new WaveFormat(44100, 32, 2);
            //writing the data
            WaveFileWriter writer = new WaveFileWriter(tempFile, wf);
            
            writer.Write(newSample, 0, newSample.Length);
            //File.WriteAllBytes(tempFile, newSample);
            //didn't work due to not having a RIFF header
            writer.Dispose();
            reader = new AudioFileReader(tempFile);
            sample = new WaveChannel32(reader);
            //Console.WriteLine("start " + start + " : end " + end);
            */
        }

        private void StartSlider_MouseDown(object sender, MouseEventArgs e)
        {
            UpdateStartSlider(e.X);
        }
        private void StartSlider_MouseMove(object sender, MouseEventArgs e)
        {
            //https://docs.microsoft.com/en-us/dotnet/api/system.windows.input.mouse.leftbutton?view=netframework-4.8
            //https://stackoverflow.com/questions/2186080/see-if-left-mouse-button-is-held-down-in-the-onmousemove-event
            //check if mouse is down
            if (e.Button == MouseButtons.Left) {
                UpdateStartSlider(e.X);
            }
        }
        private void StartSlider_MouseUp(object sender, MouseEventArgs e)
        {
            UpdateStartSlider(e.X);
        }

        private void EndSlider_MouseDown(object sender, MouseEventArgs e)
        {
            UpdateEndSlider(e.X);
        }
        private void EndSlider_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) UpdateEndSlider(e.X);
        }
        private void EndSlider_MouseUp(object sender, MouseEventArgs e)
        {
            UpdateEndSlider(e.X);
        }

        private void EditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            reader.Dispose();
            sample.Dispose();
        }

        #endregion

        #region Methods

        private void UpdateStartSlider(int x)
        {
            if (x > 0 && x < StartSlider.Width)
            {
                int pixelChange = (x - iniXs);
                iniXs = x;
                //Console.WriteLine(pixelChange);
                LeftBox.Width += pixelChange;
            }
        }

        private void UpdateEndSlider(int x)
        {
            if (x > 0 && x < EndSlider.Width)
            {
                int pixelChange = (x - iniXe);
                iniXe = x;
                //Console.WriteLine(pixelChange);
                RightBox.Width = rightBoxStart - (x + EndSlider.Location.X) + 10;
                RightBox.Location = new Point((x + EndSlider.Location.X), RightBox.Location.Y);
            }
        }

        private void UpdateWaveform(WaveChannel32 sample)
        {
            //
            int channels = sample.WaveFormat.Channels;
            int bytesPer = sample.WaveFormat.BitsPerSample / 8;
            float sampleRate = sample.WaveFormat.SampleRate;
            //finding the original waveform
            byte[] data = new byte[sample.Length];
            float[] channel1Data = new float[sample.Length / (bytesPer * channels)];
            float[] channel2Data = new float[sample.Length / (bytesPer * channels)];
            int read = sample.Read(data, 0, (int)sample.Length);
            //adding to the chart
            chart1.Series.Clear();
            var series1 = new Series
            {
                Name = "Audio",
                Color = Color.Red,
                ChartType = SeriesChartType.Line
            };
            chart1.Series.Add(series1);
            //wave files store bytes from separate channels alternating - therfore this will read from 1 channel
            for (int i = 0; i < (channel1Data.Length); i += channels)
            {
                int j = i;
                channel1Data[j] = (float)BitConverter.ToSingle(data, i * bytesPer);
                chart1.Series["Audio"].Points.AddXY((float)j / sampleRate, channel1Data[j]);
            }
            //resetting trim bars

        }

        #endregion
    }
}
