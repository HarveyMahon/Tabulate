using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tabulate
{
    public partial class HelpForm : Form
    {
        #region Constructors

        public HelpForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void HelpForm_Load(object sender, EventArgs e)
        {
            string newLine = "\n\n";
            string tempoButInfo = " - Click the button on the form, until you think the correct tempo is shown, then close the form.";
            string tempoLabInfo = " - Double click the text, and a form will appear that will let you type in the desired bpm";
            string tabButInfo = " - Once the button has been pressed, the audio loaded will be transcribed onto the sheet music, this can take some time for larger samples";
            string editButInfo = " - Click and drag the sliders, so that only the desired part of the sample may be seen on the graph, then click trim";
            string printButInfo = " - When clicked, the sheet music shown on the screen will be sent to your default printer, and printed (unless cancel is clicked)";
            string listenButInfo = "\n - When clicked, the loaded audio sample will be played, to stop, click the button again";
            string recordButInfo = " - When clicked, the program begins recording, it will do this until the button is clicked again";
            richTextBox1.Text = tempoButInfo + newLine + tempoLabInfo + newLine + tabButInfo + newLine + editButInfo + newLine + printButInfo + newLine + listenButInfo + newLine + recordButInfo;
            string settingButInfo = " - When clicked, the settings window will open, allowing the program to be altered, in order to benefit usability";
            string metButInfo = " - When clicked, a metronome of the stored bpm will be played, to stop, click the button again";
            richTextBox2.Text = settingButInfo + newLine + metButInfo;
        }

        #endregion
    }
}
