using NAudio.Dsp;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace Tabulate
{
    public partial class Tabulate : Form
    {
        #region Variables
        //source of bars image https://www.dreamstime.com/blank-sheet-music-sheet-notation-voice-solo-instruments-blank-sheet-music-vector-blank-sheet-music-sheet-image133333973
        //global vars
        //this is to help people who find it difficult to read black on white sheet music
        Color chosenColor = Color.Black;
        //
        int tempo = 0;
        bool recentSave = true;
        #endregion

        #region Constants
        //c0 is the note used for tuning
        static double c0 = 16.35;
        /*
         * value of 2^(1/12)
         * * comes out as 1 when calculated so is best stored in this manner
         */
        static double a = 1.0594630943592952646;
        //selected file (changed by load)
        string file = @"";
        //all recordings are saved to temp file, and when save is clicked, loaded into file
        string tempFile = @"..\..\audio files\temp.wav";
        #endregion

        #region Contructors
        public Tabulate()
        {
            FillNoteDict();
            InitializeComponent();
        }
        #endregion

        #region Methods
        //stores the notes used in the program
        static Dictionary<String, double> notes = new Dictionary<string, double>();
        static void FillNoteDict()
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
        //adding notes to user interface
        //when key is added, this will need to know key
        private void AddNote(object sender, int count, int lines, string notes)
        {
            //fingding the details of the note(s)
            //  to start, the notes will be plotted without regard for octave
            //  then, only octaves +- 1 will be ploted, other octaves will be ignored
            string[] notesArray = new string[notes.Length / 2];
            int[] octaves = new int[notes.Length / 2];
            //the maximum amout of notes in the note string is half the amount of characters in the string
            string holder = "";
            int i = 0;
            foreach (char c in notes)
            {
                if (!Char.IsDigit(c)) holder += c;
                else
                {
                    octaves[i] = (int)Char.GetNumericValue(c);
                    notesArray[i] = holder;
                    holder = "";
                    i++;
                }
            }
            //0 for g
            for (int j = 0; j < notesArray.Length; j++)
            {
                if (notesArray[j] == null) break;
                notesArray[j] = notesArray[j].Replace(" ", "");
                const int perNote = 5;
                //finding 
                int octaveOffset = 0;
                int median = octaves[(int)Math.Floor((double)i / 2d)];
                //offsetting the note based on octave - only accepting +- 1 of the median octave
                if (Math.Abs(octaves[j] - median) <= 1)
                {
                    octaveOffset = (median - octaves[j]) * (7 * perNote);
                }
                else
                {
                    //if the octave is not valid, we go to the next no  te
                    continue;
                }
                int noteOffset = 0;
                //notes per octave
                switch (notesArray[j].ToCharArray()[0].ToString())
                {
                    case "A":
                        noteOffset = 0;
                        break;
                    case "B":
                        noteOffset = perNote;
                        break;
                    case "C":
                        noteOffset = 2 * perNote;
                        break;
                    case "D":
                        noteOffset = 3 * perNote;
                        break;
                    case "E":
                        noteOffset = 4 * perNote;
                        break;
                    case "F":
                        noteOffset = 5 * perNote;
                        break;
                    case "G":
                        noteOffset = 6 * perNote;
                        break;
                    default:
                        Console.WriteLine("error : " + notesArray[j]);
                        break;
                }

                //constants for positioning
                //distances from top and left borders
                const int fromLeft = 85;
                const int fromTop = perNote * 6;
                //distance between notes
                const float xOffset = 34.5f;
                //distance between staves
                const float yOffset = 110f;
                //adding the label with the note
                Label noteLabel = new Label
                {
                    Font = new Font("Symbola", 32.5F),//*0.7f;
                    Text = "♩"
                };
                int x = fromLeft + (int)(count * xOffset);
                int y = fromTop + (int)(lines * yOffset) + noteOffset + octaveOffset;
                noteLabel.BackColor = Color.Transparent;
                noteLabel.ForeColor = chosenColor;
                noteLabel.BorderStyle = BorderStyle.FixedSingle;
                noteLabel.Height = 45;//*0.7f;
                                      //bottom note is @ j = 0
                if (j == 0) noteLabel.SendToBack();
                if (j != 0) noteLabel.BringToFront();
                noteLabel.Width = 25;
                noteLabel.BorderStyle = BorderStyle.None;
                noteLabel.Location = new Point(x, y);
                //adding the label to the screen
                panel1.Controls.Add(noteLabel);
                //adding an accidental if there is one
                if (notesArray[j].Length != 1)
                {
                    //accidental
                    string type = notesArray[j].ElementAt(1).ToString();
                    Label accidentalLabel = new Label
                    {
                        Font = new Font("Times New Roman", 15F),//*0.7f;
                        Text = type,
                        BackColor = Color.Transparent,
                        ForeColor = chosenColor,
                        BorderStyle = BorderStyle.None,
                        Location = new Point(x + 25, y + 30),
                        Width = 17,
                        Height = 20
                    };
                    accidentalLabel.BringToFront();
                    panel1.Controls.Add(accidentalLabel);
                }
            }
        }
        private void AddRest(object sender, int count, int lines)
        {
            //constants for positioning
            const int fromLeft = 85;
            const int fromTop = 20;
            const float xOffset = 34.5f;
            const float yOffset = 110f;
            //adding the label with the note
            Label note = new Label
            {
                Font = new Font("Symbola", 37.5F),
                Text = "𝄽"
            };
            int x = fromLeft + (int)(count * xOffset);
            int y = fromTop + (int)(lines * yOffset);
            note.BackColor = Color.Transparent;
            note.ForeColor = chosenColor;
            note.BorderStyle = BorderStyle.FixedSingle;
            note.Height = 60;
            note.Width = (int)xOffset;
            note.BorderStyle = BorderStyle.None;
            note.Location = new Point(x, y);
            //adding the label to the screen
            panel1.Controls.Add(note);
        }
        #endregion

        #region UI events
        private void ButEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.FromArgb(0x222222);
        }

        private void ButLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Black;
        }
        //prompt the user to save if the have recently made a change
        private void Tabulate_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!recentSave)
            {
                //show save prompt dialogue
                string msgText = "If you close the program now, all your data will be lost. Would you like to save?";
                DialogResult dr = MessageBox.Show(msgText, "Tabulate", MessageBoxButtons.YesNoCancel);

                if (dr == DialogResult.Yes) SaveButton_Click(sender, EventArgs.Empty);
                else if (dr == DialogResult.Cancel) e.Cancel = true;
                //if the result is No, the program will close without performing any extra actions.
            }
        }
        //force the user to select a file to use when the program is loaded
        //this prevents the crash case for when no file is selected, and a save
        //is attempted
        private void Tabulate_Load(object sender, EventArgs e)
        {
            this.Activate();
            //recentSave = false;
            while (file == @"")
            {
                LoadButton_Click(sender, e);
                if (file == @"")
                {
                    DialogResult dr = MessageBox.Show("You must select a file to launch the app, would you like to exit?", "Tabulate", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        break;
                    }
                }
            }
            if (file == @"")
            {
                Close();
            }
            record = RecordButton;
            listen = ListenButton;
        }


        bool playing = false;
        SoundPlayer sound;
        private void MetronomeButton_Click(object sender, EventArgs e)
        {
            if (!playing)
            {
                //source : https://freewavesamples.com/cowbell-1
                string metronomeFile = @"..\..\audio files\bell.wav";
                //
                if (tempo <= 0 || tempo > 500)
                {
                    MessageBox.Show("Please enter a valid tempo. (1-500bpm)", "Tabulate");
                    return;
                }
                playing = true;
                //bell.wav wf = (44100, 16, 2)
                //finding time between tones (in samples)

                //An unhandled exception of type 'System.IO.EndOfStreamException' occurred in NAudio.dll
                //Unable to read beyond the end of the stream.
                AudioFileReader reader = new AudioFileReader(metronomeFile);
                WaveFormat wf = reader.WaveFormat;
                int samplesPerTone = (int)reader.Length;
                //44100 samples per second
                //tempo / 60 notes per second
                int samplesPerSecond = (int)(44100f / (((float)tempo / 8f) / 60f));
                samplesPerSecond += 1024 - (samplesPerSecond % 1024);
                byte[] buffer = new byte[samplesPerSecond];
                reader.Read(buffer, 0, samplesPerSecond);
                for (int i = samplesPerTone; i < samplesPerSecond; i++)
                {
                    buffer[i] = 0;
                }
                reader.Dispose();
                WaveFileWriter writer = new WaveFileWriter(metronomeFile, wf);
                writer.Write(buffer, 0, buffer.Length);
                writer.Dispose();
                //
                sound = new SoundPlayer(metronomeFile);
                sound.PlayLooping();
            }
            else
            {
                playing = false;
                sound.Stop();
                sound.Dispose();
            }
        }

        private void NotesButton_Click(object sender, EventArgs e)
        {

        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            using (SettingsForm sf = new SettingsForm())
            {
                sf.ShowDialog();
                //placed into temp Color to prevent warning about runtime exception
                Color temp = sf.c;
                if (!temp.IsEmpty) chosenColor = temp;
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            //using the read code from the tabulate button
            using (AudioFileReader reader = new AudioFileReader(tempFile))
            using (WaveChannel32 wave = new WaveChannel32(reader))
            using (EditForm ef = new EditForm(wave, reader))
            {
                //wave.Dispose();
                ef.ShowDialog();
            }
            recentSave = false;
        }

        private void TempoButton_Click(object sender, EventArgs e)
        {
            int bpm = 0;
            using (TempoClickForm tcf = new TempoClickForm())
            {
                tcf.ShowDialog();
                bpm = (int)tcf.bpm;
            }
            tempo = bpm;
            BpmLabel.Text = bpm.ToString() + " BPM";
        }

        private void BpmLabel_DoubleClick(object sender, EventArgs e)
        {
            int bpm = 0;
            using (TempoTypeForm ttf = new TempoTypeForm())
            {
                ttf.ShowDialog();
                bpm = (int)ttf.bpm;
            }
            tempo = bpm;
            BpmLabel.Text = bpm.ToString() + " BPM";
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            using (HelpForm hf = new HelpForm())
            {
                hf.ShowDialog();
            }
        }
        private void HelpButton_Click(object sender, HelpEventArgs hlpevent)
        {
            using (HelpForm hf = new HelpForm())
            {
                hf.ShowDialog();
            }
        }

        string key;
        private void KeyButton_Click(object sender, EventArgs e)
        {
            using (KeySelectionForm ksf = new KeySelectionForm())
            {
                ksf.ShowDialog();
                key = ksf.key;
            }
            KeyLabel.Text = key;
        }

        //wav making the location of the tempfile the same as that of the normal file - making temp file redundant
        private void LoadButton_Click(object sender, EventArgs e)
        {
            //https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/how-to-open-files-using-the-openfiledialog-component
            //version 1 - use file explorer to select file - with filtered file type (.wav)
            string fileOriginal = file;
            OpenFileDialog open = new OpenFileDialog
            {
                Filter = "WAVE files (*.wav, *.wave)|*.wav;*.wave"
            };
            open.ShowDialog();
            file = open.FileName;
            //checking if the file type is really .wav - prevents shortcuts from being loaded
            //forced to lower to assist in checking the string (.Wav should be the same as .wav)
            string ext = Path.GetExtension(file).ToLower();
            //if the user exits out of the dialog without selecting a file, this makes it so that the file doesn't change
            //it also prevents shortcuts from being loaded as files
            if (!(ext == ".wav" || ext == ".wave"))
            {
                file = fileOriginal;
                return;
            }
            //
            AudioFileReader fileReader = new AudioFileReader(file);
            WaveChannel32 wave = new WaveChannel32(fileReader);
            byte[] buffer = new byte[wave.Length];
            wave.Read(buffer, 0, buffer.Length);
            WaveFileWriter fileWriter = new WaveFileWriter(tempFile, fileReader.WaveFormat);
            panel1.Controls.Clear();
            fileWriter.Write(buffer, 0, buffer.Length);
            wave.Dispose();
            fileReader.Dispose();
            fileWriter.Dispose();
            //
            open.Dispose();
            recentSave = true;
            return;
        }
        //crashes if no file has been loaded
        private void SaveButton_Click(object sender, EventArgs e)
        {
            AudioFileReader tempFileReader = new AudioFileReader(tempFile);
            WaveChannel32 wave = new WaveChannel32(tempFileReader);
            byte[] buffer = new byte[wave.Length];
            wave.Read(buffer, 0, buffer.Length);
            WaveFileWriter fileWriter = new WaveFileWriter(file, tempFileReader.WaveFormat);
            fileWriter.Write(buffer, 0, buffer.Length);

            wave.Dispose();
            tempFileReader.Dispose();
            fileWriter.Dispose();
            recentSave = true;
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            string bmpFile = @"..\..\src\printout.bmp";
            //https://stackoverflow.com/questions/4246905/print-print-preview-a-bitmap-in-c-sharp
            using (Bitmap bmp = new Bitmap(panel1.Width, panel1.Height))
            using (PrintForm pf = new PrintForm(bmp))
            {
                Rectangle r = new Rectangle(0, 0, panel1.Width, panel1.Height);
                panel1.DrawToBitmap(bmp, r);
                //fails when:
                //  run more than once
                bmp.Save(bmpFile);
                pf.ShowDialog(this);
            }
        }
        //recording audio
        WaveIn src;
        WaveFileWriter writer;
        Button record;
        private void RecordButton_Click(object sender, EventArgs e)
        {
            recentSave = false;
            //https://stackoverflow.com/questions/2853413/getting-data-from-a-microphone-in-c-sharp
            //https://markheath.net/post/recording-soundcard-output-to-wav-in
            //https://github.com/naudio/NAudio
            //https://stackoverflow.com/questions/8821410/why-is-access-to-the-path-denied
            //https://stackoverflow.com/questions/17982468/naudio-record-sound-from-microphone-then-save/17983876
            if (src == null && waveOut == null)
            {
                record.Text = "STOP";
                src = new WaveIn
                {
                    WaveFormat = new WaveFormat(44100, 32, 2)
                };

                src.DataAvailable += new EventHandler<WaveInEventArgs>(DataAvailible);

                //src.RecordingStopped += new EventHandler<StoppedEventArgs>(RecordingStopped);
                writer = new WaveFileWriter(tempFile, src.WaveFormat);

                src.StartRecording();
            }
            else
            {

                if (src != null)
                {
                    src.Dispose();
                    src = null;
                }
                if (writer != null)
                {
                    writer.Dispose();
                    writer = null;
                }

                record.Text = "Record";
            }
        }
        
        //playing audio back - only works once, crashes program if attempted twice without loading a new file
        WaveOut waveOut;
        WaveFileReader reader;
        Button listen;
        private void ListenButton_Click(object sender, EventArgs e)
        {
            //https://github.com/naudio/NAudio/wiki/Playing-an-Audio-File
            if (waveOut == null && file != @"")
            {
                //if recording, end recording
                if (src != null) RecordButton_Click(sender, e);
                waveOut = new WaveOut();
                reader = new WaveFileReader(tempFile);
                waveOut.Init(reader);
                waveOut.PlaybackStopped += new EventHandler<StoppedEventArgs>(PlaybackStopped);
                waveOut.Play();
                ((Button)sender).Text = "stop";
            }
            else if (file == @"")
            {
                MessageBox.Show("Please make sure an audio file is loaded before attempting to play audio.", "Tabulate");
            }
            else
            {
                waveOut.Stop();
            }
        }
        //functioning :)
        private void TabulateButton_Click(object sender, EventArgs e)
        {
            //https://stackoverflow.com/questions/15159739/hamming-window-generates-a-line
            //http://www-mmsp.ece.mcgill.ca/Documents/AudioFormats/WAVE/WAVE.html
            //the above source shows that the first 48 bytes are header - and will need to be removed for tabulation
            panel1.Controls.Clear();

            //checking the user has entered a tempo (must be positive - but this is handled by the system)

            if (file == @"")
            {
                MessageBox.Show("Please select a file to tabulate.", "Tabulate");
                return;
            }
            //only allowing reasonable tempos
            if (tempo <= 0 || tempo >= 999)
            {
                MessageBox.Show("Please enter a valid tempo.", "Tabulate");
                return;
            }
            //when keys are fully implemented a check for key having been entered will be added here


            
            //audio recorded by the app is 2 channel
            TabulateButton.Text = "...";
            //update is needed so that it updates during the method - otherwise there is no change until after compeltion - which is useless
            TabulateButton.Update();
            //finding the specifications of the wave file being read
            AudioFileReader reader = new AudioFileReader(tempFile);
            WaveChannel32 wave = new WaveChannel32(reader);
            int channels = wave.WaveFormat.Channels;
            //Console.WriteLine(channels);
            int bytesPer = wave.WaveFormat.BitsPerSample / 8;
            float sampleRate = wave.WaveFormat.SampleRate;
            //finding the original waveform
            byte[] buffer = new byte[wave.Length];
            float[] channel1Data = new float[wave.Length / (bytesPer * channels)];
            float[] channel2Data = new float[wave.Length / (bytesPer * channels)];
            int read = wave.Read(buffer, 0, (int)wave.Length); 
            //wave files store bytes from separate channels alternating - therfore this will read from 1 channel
            for (int i = 0; i < (channel1Data.Length); i += channels)
            {
                int j = i;
                channel1Data[j] = (float)BitConverter.ToSingle(buffer, i * bytesPer);
            }
            for (int i = 1; i < channel2Data.Length; i+=channels)
            {
                int j = i;
                channel2Data[j] = (float)BitConverter.ToSingle(buffer, i * bytesPer);
            }
            //both channels will be transformed separately, and the output will be formed from that
            //      could be implemented into a proceadure
            //working on first channel
            //1 beat on a channel requires dividing sample rate by beats per second (bpm/60) 
            float beatLength = (sampleRate / ((float)tempo / 60f));
            int count = 0;
            int lines = 0;
            //constants used in the placement of the new labels
            for (int i = 0; i < (int)(channel1Data.Length/beatLength); i++)
            {
                //creating an array which represents 1 beat, which will be analysed
                //length is samples per beat (samples/s / beats/s)
                float[] beat1 = new float[(int)beatLength];
                //copying the data from the channel data, to the beat data
                Array.ConstrainedCopy(channel1Data, (int)(i * beatLength), beat1, 0, (int)beat1.Length);
                //if the beat is below the silence threshhold, it is not transcribed, and a - is placed
                //if (!(beat1.Max() < 0.1f)) addNote(sender, count, lines, "♩");
                float[] beat2 = new float[(int)beatLength];
                //copying the data from the channel data, to the beat data
                Array.ConstrainedCopy(channel1Data, (int)(i * beatLength), beat2, 0, (int)beat2.Length);
                //if the beat is below the silence threshhold, it is not transcribed, and a 𝄽 is placed
                float silenceThreshold = 0.1f;
                if (beat2.Max() < silenceThreshold && beat1.Max() < silenceThreshold) AddRest(sender, count, lines);//, "𝄽");
                else AddNote(sender, count, lines, TransformArray(beat1, sampleRate) + TransformArray(beat2, sampleRate));//"♩");


                count++;
                //if true, the stave is full, and the program must move onto the next stave
                if (count == 20)
                {
                    count = 0;
                    lines++;
                }
            }
            wave.Dispose();
            wave = null;
            TabulateButton.Text = "tabs";
        }

        #endregion

        #region Other events
        void DataAvailible(object sender, WaveInEventArgs e)
        {
            if (writer != null)
            {
                writer.Write(e.Buffer, 0, e.BytesRecorded);
                writer.Flush();
            }
        }
        void PlaybackStopped(object sender, StoppedEventArgs e)
        {
            waveOut.Stop();
            waveOut.Dispose();
            waveOut = null;
            reader.Dispose();
            reader = null;
            listen.Text = "Listen";
        }
        #endregion

        #region Utility Functions
        //converts 2 bytes from starting index into a float value
        //not used as audio recoreded is now 32 bit, so can be converted into double
        private float ToFloat(byte[] arr, int startIndex)
        {
            float output = 0f;
            output += (float)arr[startIndex]; 
            output += (float)arr[startIndex + 1] / 256f;// / constant due to positional values
            return output;
        }

        private string TransformArray(float[] data, float sr)
        {
            //collecting important infor for transform
            int length = data.Length;
            int n = (int)Math.Log(length, 2);
            //converting audio data into complex array for the transform
            Complex[] set = new Complex[length];
            for (int i = 0; i < length; i++)
            {
                set[i].X = (float)data[i];
                set[i].Y = 0f;
            }
            //performing the transform
            FastFourierTransform.FFT(true, n, set);
            //computing the info to find the freq
            double[] graph = new double[length];
            for (int i = 0; i < length; i++)
            {
                float x = set[i].X;
                float y = set[i].Y;
                //finding distance from source of point
                graph[i] = Math.Sqrt(x * x + y * y);

            }
            //finding the peaks on the graph and adding the associated freq to output str
            //length is n
            //taking log2 of sr
            string output = "";
            double min = 0.005;
            double sr2 = Math.Log(sr, 2) + 1;
            for (int i = 1; i < (length/2)-1; i++)
            {
                double factor = Math.Pow(2, (double)n - sr2);
                double freq = (double)i / factor;
                //if it's a peak and is over a set min
                if (graph[i] > graph[i-1] && graph[i] > graph[i+1] && graph[i] > min && freq < 8000)
                {
                    output += FourierMethods.noteFromFrequency(freq);
                }
            }
            //returning data
            return output;
        }
        #endregion
    }
}
