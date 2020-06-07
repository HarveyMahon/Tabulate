using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace Tabulate
{
    partial class EditForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditForm));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.StartSlider = new NAudio.Gui.VolumeSlider();
            this.EndSlider = new sliderBackwards(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TrimButton = new System.Windows.Forms.Button();
            this.LeftBox = new System.Windows.Forms.RichTextBox();
            this.RightBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 143);
            this.chart1.Name = "chart1";
            var series1 = new Series
            {
                Name = "Audio",
                Color = Color.Red,
                ChartType = SeriesChartType.Line
            };
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(776, 295);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // StartSlider
            // 
            this.StartSlider.BackColor = System.Drawing.Color.Red;
            this.StartSlider.ForeColor = System.Drawing.Color.White;
            this.StartSlider.Location = new System.Drawing.Point(77, 83);
            this.StartSlider.Name = "StartSlider";
            this.StartSlider.Size = new System.Drawing.Size(573, 16);
            this.StartSlider.TabIndex = 2;
            this.StartSlider.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartSlider_MouseDown);
            this.StartSlider.MouseMove += new System.Windows.Forms.MouseEventHandler(this.StartSlider_MouseMove);
            this.StartSlider.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StartSlider_MouseUp);
            // 
            // EndSlider
            // 
            this.EndSlider.BackColor = System.Drawing.Color.LightGreen;
            this.EndSlider.Location = new System.Drawing.Point(77, 121);
            this.EndSlider.Name = "EndSlider";
            this.EndSlider.Size = new System.Drawing.Size(573, 16);
            this.EndSlider.TabIndex = 5;
            this.EndSlider.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EndSlider_MouseDown);
            this.EndSlider.MouseMove += new System.Windows.Forms.MouseEventHandler(this.EndSlider_MouseMove);
            this.EndSlider.MouseUp += new System.Windows.Forms.MouseEventHandler(this.EndSlider_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(82, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "End";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(82, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Start";
            // 
            // TrimButton
            // 
            this.TrimButton.FlatAppearance.BorderSize = 0;
            this.TrimButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TrimButton.Font = new System.Drawing.Font("Castellar", 24F);
            this.TrimButton.ForeColor = System.Drawing.Color.White;
            this.TrimButton.Location = new System.Drawing.Point(16, 13);
            this.TrimButton.Name = "TrimButton";
            this.TrimButton.Size = new System.Drawing.Size(146, 51);
            this.TrimButton.TabIndex = 6;
            this.TrimButton.Text = "Trim";
            this.TrimButton.UseVisualStyleBackColor = true;
            this.TrimButton.Click += new System.EventHandler(this.TrimButton_Click);
            this.TrimButton.Enter += new System.EventHandler(this.ButEnter);
            this.TrimButton.Leave += new System.EventHandler(this.ButLeave);
            // 
            // LeftBox
            // 
            this.LeftBox.BackColor = System.Drawing.Color.Black;
            this.LeftBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LeftBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.LeftBox.Location = new System.Drawing.Point(64, 161);
            this.LeftBox.Name = "LeftBox";
            this.LeftBox.Size = new System.Drawing.Size(10, 241);
            this.LeftBox.TabIndex = 7;
            this.LeftBox.Text = "";
            // 
            // RightBox
            // 
            this.RightBox.BackColor = System.Drawing.Color.Black;
            this.RightBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RightBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.RightBox.Location = new System.Drawing.Point(651, 161);
            this.RightBox.Name = "RightBox";
            this.RightBox.Size = new System.Drawing.Size(10, 241);
            this.RightBox.TabIndex = 8;
            this.RightBox.Text = "";
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(752, 450);
            this.Controls.Add(this.RightBox);
            this.Controls.Add(this.LeftBox);
            this.Controls.Add(this.TrimButton);
            this.Controls.Add(this.EndSlider);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartSlider);
            this.Controls.Add(this.chart1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditForm";
            this.Text = "EditForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditForm_FormClosing);
            this.Load += new System.EventHandler(this.EditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private NAudio.Gui.VolumeSlider StartSlider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private sliderBackwards EndSlider;
        private System.Windows.Forms.Button TrimButton;
        private System.Windows.Forms.RichTextBox LeftBox;
        private System.Windows.Forms.RichTextBox RightBox;
    }
}