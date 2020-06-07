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
    public partial class KeySelectionForm : Form
    {
        #region Attributes

        public string key = "";
        RadioButton[] buttons;
        //0-6 = A-G, 7 = Maj/Min
        RadioButton[] checkedButtons = new RadioButton[8];
        //Array of keys
        string[] keys = new string[] { "" };

        #endregion

        #region Constructors

        public KeySelectionForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void RadioButton_Checked(object sender, EventArgs e)
        {
            //find RadioButton's corresponding note
            RadioButton button = (RadioButton)sender;
            char note = button.Name.ToCharArray()[0];
            //skipping events where a button is unchecked
            if (!button.Checked) return;
            //for Maj/Min, note = 'M'
            else if (note == 'M')
            {
                checkedButtons[7] = button;
            }
            else
            {
                //for A-G, note - 65 is index
                checkedButtons[note - 65] = button;
            }
            UpdateOutput();
        }

        private void KeySelectionForm_Load(object sender, EventArgs e)
        {
            //creating a list containing all of the RadioButtons
            buttons = new RadioButton[] { ASharp, AFlat, ANat, BSharp, BFlat, BNat, CSharp, CFlat, CNat, DSharp, DFlat, DNat, ESharp, EFlat, ENat, FSharp, FFlat, FNat, GSharp, GFlat, GNat, Major, Minor };
            int i = 0;
            foreach (RadioButton button in buttons)
            {
                button.CheckedChanged += new EventHandler(RadioButton_Checked);
                button.Text = button.Name;
                if (button.Checked)
                {
                    checkedButtons[i] = button;
                    i++;
                }
            }
            UpdateOutput();
        }

        #endregion

        #region Methods

        private void UpdateOutput()
        {
            int sharpCount = 0;
            int flatCount = 0;
            bool major = true;
            foreach (RadioButton button in checkedButtons)
            {
                if (button.Name.Contains("Sharp")) sharpCount++;
                else if (button.Name.Contains("Flat")) flatCount++;

                if (button.Name == "Major") major = true;
                else if (button.Name == "Minor") major = false;
            }
            //finding key
            if (major)
            {
                if (sharpCount == 0 && flatCount == 0) key = "C/Maj";
                else if (sharpCount > flatCount)
                {
                    switch (sharpCount)
                    {
                        case 1:
                            key = "G/Maj";
                            break;
                        case 2:
                            key = "D/Maj";
                            break;
                        case 3:
                            key = "A/Maj";
                            break;
                        case 4:
                            key = "E/Maj";
                            break;
                        case 5:
                            key = "B/Maj";
                            break;
                        case 6:
                            key = "F#/Maj";
                            break;
                        case 7:
                            key = "C#/Maj";
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (flatCount)
                    {
                        case 1:
                            key = "F/Maj";
                            break;
                        case 2:
                            key = "B♭/Maj";
                            break;
                        case 3:
                            key = "E♭/Maj";
                            break;
                        case 4:
                            key = "A♭/Maj";
                            break;
                        case 5:
                            key = "D♭/Maj";
                            break;
                        case 6:
                            key = "G♭/Maj";
                            break;
                        case 7:
                            key = "C♭/Maj";
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                if (sharpCount == 0 && flatCount == 0) key = "a/Min";
                else if (sharpCount > flatCount)
                {
                    switch (sharpCount)
                    {
                        case 1:
                            key = "e/Min";
                            break;
                        case 2:
                            key = "b/Min";
                            break;
                        case 3:
                            key = "f#/Min";
                            break;
                        case 4:
                            key = "c#/Min";
                            break;
                        case 5:
                            key = "g#/Min";
                            break;
                        case 6:
                            key = "d#/Min";
                            break;
                        case 7:
                            key = "a#/Min";
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (flatCount)
                    {
                        case 1:
                            key = "d/Min";
                            break;
                        case 2:
                            key = "g/Min";
                            break;
                        case 3:
                            key = "c/Min";
                            break;
                        case 4:
                            key = "f/Min";
                            break;
                        case 5:
                            key = "b♭/Min";
                            break;
                        case 6:
                            key = "e♭/Min";
                            break;
                        case 7:
                            key = "a♭/Min";
                            break;
                        default:
                            break;
                    }
                }
            }
            //outputting key
            Output.Text = key;
        }

        #endregion
    }
}
