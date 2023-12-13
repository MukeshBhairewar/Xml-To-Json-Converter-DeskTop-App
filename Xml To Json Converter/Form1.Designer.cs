namespace Xml_To_Json_Converter
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
            label1 = new Label();
            openFileDialog1 = new OpenFileDialog();
            textBox1 = new TextBox();
            browsebutton_Click = new Button();
            convertbutton_click = new Button();
            openfilebutton_click = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label1.Location = new Point(194, 18);
            label1.Name = "label1";
            label1.Size = new Size(288, 31);
            label1.TabIndex = 0;
            label1.Text = "XML To JSON Converter";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(172, 122);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(250, 27);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // browsebutton_Click
            // 
            browsebutton_Click.FlatAppearance.BorderColor = Color.Black;
            browsebutton_Click.FlatAppearance.BorderSize = 2;
            browsebutton_Click.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            browsebutton_Click.Location = new Point(447, 120);
            browsebutton_Click.Name = "browsebutton_Click";
            browsebutton_Click.Size = new Size(94, 29);
            browsebutton_Click.TabIndex = 2;
            browsebutton_Click.Text = "Browse";
            browsebutton_Click.UseVisualStyleBackColor = true;
            browsebutton_Click.Click += button1_Click;
            // 
            // convertbutton_click
            // 
            convertbutton_click.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            convertbutton_click.Location = new Point(172, 210);
            convertbutton_click.Name = "convertbutton_click";
            convertbutton_click.Size = new Size(94, 29);
            convertbutton_click.TabIndex = 3;
            convertbutton_click.Text = "Convert";
            convertbutton_click.UseVisualStyleBackColor = true;
            convertbutton_click.Click += button2_Click;
            // 
            // openfilebutton_click
            // 
            openfilebutton_click.FlatAppearance.BorderColor = Color.Maroon;
            openfilebutton_click.FlatAppearance.BorderSize = 4;
            openfilebutton_click.FlatAppearance.MouseDownBackColor = Color.Maroon;
            openfilebutton_click.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            openfilebutton_click.Location = new Point(339, 210);
            openfilebutton_click.Name = "openfilebutton_click";
            openfilebutton_click.Size = new Size(143, 29);
            openfilebutton_click.TabIndex = 4;
            openfilebutton_click.Text = "OpenJsonFile";
            openfilebutton_click.UseVisualStyleBackColor = true;
            openfilebutton_click.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(800, 450);
            Controls.Add(openfilebutton_click);
            Controls.Add(convertbutton_click);
            Controls.Add(browsebutton_Click);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private OpenFileDialog openFileDialog1;
        private TextBox textBox1;
        private Button browsebutton_Click;
        private Button convertbutton_click;
        private Button openfilebutton_click;
    }
}