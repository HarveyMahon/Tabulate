namespace Tabulate
{
    partial class Tabulate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tabulate));
            this.logoBox = new System.Windows.Forms.PictureBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.ListenButton = new System.Windows.Forms.Button();
            this.RecordButton = new System.Windows.Forms.Button();
            this.TempoButton = new System.Windows.Forms.Button();
            this.KeyButton = new System.Windows.Forms.Button();
            this.NotesButton = new System.Windows.Forms.Button();
            this.BpmLabel = new System.Windows.Forms.Label();
            this.KeyLabel = new System.Windows.Forms.Label();
            this.helpButton = new System.Windows.Forms.Button();
            this.TabulateButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MetronomeButton = new System.Windows.Forms.Button();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.PrintButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // logoBox
            // 
            this.logoBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("logoBox.BackgroundImage")));
            this.logoBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logoBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("logoBox.InitialImage")));
            this.logoBox.Location = new System.Drawing.Point(0, 0);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(179, 155);
            this.logoBox.TabIndex = 0;
            this.logoBox.TabStop = false;
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.Black;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("Castellar", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.ForeColor = System.Drawing.Color.White;
            this.SaveButton.Location = new System.Drawing.Point(179, 0);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(265, 78);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            this.SaveButton.MouseEnter += new System.EventHandler(this.ButEnter);
            this.SaveButton.MouseLeave += new System.EventHandler(this.ButLeave);
            // 
            // LoadButton
            // 
            this.LoadButton.BackColor = System.Drawing.Color.Black;
            this.LoadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadButton.Font = new System.Drawing.Font("Castellar", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadButton.ForeColor = System.Drawing.Color.White;
            this.LoadButton.Location = new System.Drawing.Point(179, 77);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(265, 78);
            this.LoadButton.TabIndex = 2;
            this.LoadButton.Text = "LOad";
            this.LoadButton.UseVisualStyleBackColor = false;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            this.LoadButton.MouseEnter += new System.EventHandler(this.ButEnter);
            this.LoadButton.MouseLeave += new System.EventHandler(this.ButLeave);
            // 
            // EditButton
            // 
            this.EditButton.BackColor = System.Drawing.Color.Black;
            this.EditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditButton.Font = new System.Drawing.Font("Castellar", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditButton.ForeColor = System.Drawing.Color.White;
            this.EditButton.Location = new System.Drawing.Point(444, 0);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(269, 78);
            this.EditButton.TabIndex = 3;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = false;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            this.EditButton.MouseEnter += new System.EventHandler(this.ButEnter);
            this.EditButton.MouseLeave += new System.EventHandler(this.ButLeave);
            // 
            // ListenButton
            // 
            this.ListenButton.BackColor = System.Drawing.Color.Black;
            this.ListenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ListenButton.Font = new System.Drawing.Font("Castellar", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListenButton.ForeColor = System.Drawing.Color.White;
            this.ListenButton.Location = new System.Drawing.Point(982, 77);
            this.ListenButton.Name = "ListenButton";
            this.ListenButton.Size = new System.Drawing.Size(277, 78);
            this.ListenButton.TabIndex = 4;
            this.ListenButton.Text = "Listen";
            this.ListenButton.UseVisualStyleBackColor = false;
            this.ListenButton.Click += new System.EventHandler(this.ListenButton_Click);
            this.ListenButton.MouseEnter += new System.EventHandler(this.ButEnter);
            this.ListenButton.MouseLeave += new System.EventHandler(this.ButLeave);
            // 
            // RecordButton
            // 
            this.RecordButton.BackColor = System.Drawing.Color.Black;
            this.RecordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RecordButton.Font = new System.Drawing.Font("Castellar", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecordButton.ForeColor = System.Drawing.Color.White;
            this.RecordButton.Location = new System.Drawing.Point(982, 0);
            this.RecordButton.Name = "RecordButton";
            this.RecordButton.Size = new System.Drawing.Size(277, 78);
            this.RecordButton.TabIndex = 5;
            this.RecordButton.Text = "Record";
            this.RecordButton.UseVisualStyleBackColor = false;
            this.RecordButton.Click += new System.EventHandler(this.RecordButton_Click);
            this.RecordButton.MouseEnter += new System.EventHandler(this.ButEnter);
            this.RecordButton.MouseLeave += new System.EventHandler(this.ButLeave);
            // 
            // TempoButton
            // 
            this.TempoButton.BackColor = System.Drawing.Color.Black;
            this.TempoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TempoButton.Font = new System.Drawing.Font("Castellar", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TempoButton.ForeColor = System.Drawing.Color.White;
            this.TempoButton.Location = new System.Drawing.Point(0, 155);
            this.TempoButton.Name = "TempoButton";
            this.TempoButton.Size = new System.Drawing.Size(179, 78);
            this.TempoButton.TabIndex = 6;
            this.TempoButton.Text = "Tempo";
            this.TempoButton.UseVisualStyleBackColor = false;
            this.TempoButton.Click += new System.EventHandler(this.TempoButton_Click);
            this.TempoButton.MouseEnter += new System.EventHandler(this.ButEnter);
            this.TempoButton.MouseLeave += new System.EventHandler(this.ButLeave);
            // 
            // KeyButton
            // 
            this.KeyButton.BackColor = System.Drawing.Color.Black;
            this.KeyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KeyButton.Font = new System.Drawing.Font("Castellar", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyButton.ForeColor = System.Drawing.Color.White;
            this.KeyButton.Location = new System.Drawing.Point(0, 311);
            this.KeyButton.Name = "KeyButton";
            this.KeyButton.Size = new System.Drawing.Size(179, 78);
            this.KeyButton.TabIndex = 7;
            this.KeyButton.Text = "Key";
            this.KeyButton.UseVisualStyleBackColor = false;
            this.KeyButton.Click += new System.EventHandler(this.KeyButton_Click);
            this.KeyButton.MouseEnter += new System.EventHandler(this.ButEnter);
            this.KeyButton.MouseLeave += new System.EventHandler(this.ButLeave);
            // 
            // NotesButton
            // 
            this.NotesButton.BackColor = System.Drawing.Color.Black;
            this.NotesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NotesButton.Font = new System.Drawing.Font("Castellar", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NotesButton.ForeColor = System.Drawing.Color.White;
            this.NotesButton.Location = new System.Drawing.Point(0, 467);
            this.NotesButton.Name = "NotesButton";
            this.NotesButton.Size = new System.Drawing.Size(179, 78);
            this.NotesButton.TabIndex = 8;
            this.NotesButton.Text = "Notes";
            this.NotesButton.UseVisualStyleBackColor = false;
            this.NotesButton.Click += new System.EventHandler(this.NotesButton_Click);
            this.NotesButton.MouseEnter += new System.EventHandler(this.ButEnter);
            this.NotesButton.MouseLeave += new System.EventHandler(this.ButLeave);
            // 
            // BpmLabel
            // 
            this.BpmLabel.AutoSize = true;
            this.BpmLabel.BackColor = System.Drawing.Color.Black;
            this.BpmLabel.Font = new System.Drawing.Font("Castellar", 24F);
            this.BpmLabel.ForeColor = System.Drawing.Color.White;
            this.BpmLabel.Location = new System.Drawing.Point(1, 233);
            this.BpmLabel.MinimumSize = new System.Drawing.Size(177, 78);
            this.BpmLabel.Name = "BpmLabel";
            this.BpmLabel.Size = new System.Drawing.Size(177, 78);
            this.BpmLabel.TabIndex = 10;
            this.BpmLabel.Text = "???BPM";
            this.BpmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BpmLabel.DoubleClick += new System.EventHandler(this.BpmLabel_DoubleClick);
            // 
            // KeyLabel
            // 
            this.KeyLabel.AutoSize = true;
            this.KeyLabel.BackColor = System.Drawing.Color.Black;
            this.KeyLabel.Font = new System.Drawing.Font("Castellar", 24F);
            this.KeyLabel.ForeColor = System.Drawing.Color.White;
            this.KeyLabel.Location = new System.Drawing.Point(1, 389);
            this.KeyLabel.MinimumSize = new System.Drawing.Size(177, 78);
            this.KeyLabel.Name = "KeyLabel";
            this.KeyLabel.Size = new System.Drawing.Size(177, 78);
            this.KeyLabel.TabIndex = 11;
            this.KeyLabel.Text = "C/Maj";
            this.KeyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // helpButton
            // 
            this.helpButton.BackColor = System.Drawing.Color.Black;
            this.helpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpButton.Font = new System.Drawing.Font("Castellar", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpButton.ForeColor = System.Drawing.Color.White;
            this.helpButton.Location = new System.Drawing.Point(0, 621);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(179, 78);
            this.helpButton.TabIndex = 12;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = false;
            this.helpButton.Click += new System.EventHandler(this.HelpButton_Click);
            this.helpButton.MouseEnter += new System.EventHandler(this.ButEnter);
            this.helpButton.MouseLeave += new System.EventHandler(this.ButLeave);
            // 
            // TabulateButton
            // 
            this.TabulateButton.BackColor = System.Drawing.Color.Black;
            this.TabulateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TabulateButton.Font = new System.Drawing.Font("Castellar", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabulateButton.ForeColor = System.Drawing.Color.White;
            this.TabulateButton.Location = new System.Drawing.Point(0, 544);
            this.TabulateButton.Name = "TabulateButton";
            this.TabulateButton.Size = new System.Drawing.Size(179, 78);
            this.TabulateButton.TabIndex = 13;
            this.TabulateButton.Text = "Tabs";
            this.TabulateButton.UseVisualStyleBackColor = false;
            this.TabulateButton.Click += new System.EventHandler(this.TabulateButton_Click);
            this.TabulateButton.MouseEnter += new System.EventHandler(this.ButEnter);
            this.TabulateButton.MouseLeave += new System.EventHandler(this.ButLeave);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Location = new System.Drawing.Point(183, 155);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(799, 544);
            this.panel1.TabIndex = 15;
            // 
            // MetronomeButton
            // 
            this.MetronomeButton.BackColor = System.Drawing.Color.Black;
            this.MetronomeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MetronomeButton.Font = new System.Drawing.Font("Castellar", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MetronomeButton.ForeColor = System.Drawing.Color.White;
            this.MetronomeButton.Location = new System.Drawing.Point(713, 0);
            this.MetronomeButton.Name = "MetronomeButton";
            this.MetronomeButton.Size = new System.Drawing.Size(269, 78);
            this.MetronomeButton.TabIndex = 16;
            this.MetronomeButton.Text = "Metronome";
            this.MetronomeButton.UseVisualStyleBackColor = false;
            this.MetronomeButton.Click += new System.EventHandler(this.MetronomeButton_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.BackColor = System.Drawing.Color.Black;
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsButton.Font = new System.Drawing.Font("Castellar", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsButton.ForeColor = System.Drawing.Color.White;
            this.SettingsButton.Location = new System.Drawing.Point(444, 77);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(269, 78);
            this.SettingsButton.TabIndex = 17;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = false;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // PrintButton
            // 
            this.PrintButton.BackColor = System.Drawing.Color.Black;
            this.PrintButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PrintButton.Font = new System.Drawing.Font("Castellar", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintButton.ForeColor = System.Drawing.Color.White;
            this.PrintButton.Location = new System.Drawing.Point(713, 77);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(269, 78);
            this.PrintButton.TabIndex = 18;
            this.PrintButton.Text = "Print";
            this.PrintButton.UseVisualStyleBackColor = false;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // Tabulate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1259, 701);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.MetronomeButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TabulateButton);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.KeyLabel);
            this.Controls.Add(this.BpmLabel);
            this.Controls.Add(this.NotesButton);
            this.Controls.Add(this.KeyButton);
            this.Controls.Add(this.TempoButton);
            this.Controls.Add(this.RecordButton);
            this.Controls.Add(this.ListenButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.logoBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Tabulate";
            this.Text = "Tabulate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Tabulate_FormClosing);
            this.Load += new System.EventHandler(this.Tabulate_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.HelpButton_Click);
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button ListenButton;
        private System.Windows.Forms.Button RecordButton;
        private System.Windows.Forms.Button TempoButton;
        private System.Windows.Forms.Button KeyButton;
        private System.Windows.Forms.Button NotesButton;
        private System.Windows.Forms.Label BpmLabel;
        private System.Windows.Forms.Label KeyLabel;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Button TabulateButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button MetronomeButton;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Button PrintButton;
    }
}

