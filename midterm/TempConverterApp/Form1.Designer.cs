namespace TempConverterApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            temperatureInput = new TextBox();
            label1 = new Label();
            unitInput = new ComboBox();
            label2 = new Label();
            btnConvert = new Button();
            lblOutput = new Label();
            SuspendLayout();
            // 
            // temperatureInput
            // 
            temperatureInput.Font = new Font("Segoe UI", 13.8F);
            temperatureInput.Location = new Point(120, 113);
            temperatureInput.Name = "temperatureInput";
            temperatureInput.Size = new Size(313, 38);
            temperatureInput.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F);
            label1.Location = new Point(120, 81);
            label1.Name = "label1";
            label1.Size = new Size(143, 31);
            label1.TabIndex = 1;
            label1.Text = "Temperature";
            // 
            // unitInput
            // 
            unitInput.Font = new Font("Segoe UI", 13.8F);
            unitInput.FormattingEnabled = true;
            unitInput.Items.AddRange(new object[] { "C", "F" });
            unitInput.Location = new Point(120, 203);
            unitInput.Name = "unitInput";
            unitInput.Size = new Size(313, 39);
            unitInput.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F);
            label2.Location = new Point(120, 169);
            label2.Name = "label2";
            label2.Size = new Size(57, 31);
            label2.TabIndex = 3;
            label2.Text = "Unit";
            // 
            // btnConvert
            // 
            btnConvert.Location = new Point(120, 294);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new Size(313, 29);
            btnConvert.TabIndex = 4;
            btnConvert.Text = "Convert";
            btnConvert.UseVisualStyleBackColor = true;
            btnConvert.Click += btnConvert_Click;
            // 
            // lblOutput
            // 
            lblOutput.AutoSize = true;
            lblOutput.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOutput.Location = new Point(481, 186);
            lblOutput.Name = "lblOutput";
            lblOutput.Size = new Size(96, 38);
            lblOutput.TabIndex = 5;
            lblOutput.Text = "label3";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblOutput);
            Controls.Add(btnConvert);
            Controls.Add(label2);
            Controls.Add(unitInput);
            Controls.Add(label1);
            Controls.Add(temperatureInput);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox temperatureInput;
        private Label label1;
        private ComboBox unitInput;
        private Label label2;
        private Button btnConvert;
        private Label lblOutput;
    }
}
