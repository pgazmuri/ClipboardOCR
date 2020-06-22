namespace ClipboardOCR
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
            this.tbResults = new System.Windows.Forms.TextBox();
            this.cbAutoCopy = new System.Windows.Forms.CheckBox();
            this.cbRetainNewlines = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbResults
            // 
            this.tbResults.Location = new System.Drawing.Point(40, 38);
            this.tbResults.Multiline = true;
            this.tbResults.Name = "tbResults";
            this.tbResults.Size = new System.Drawing.Size(707, 362);
            this.tbResults.TabIndex = 0;
            // 
            // cbAutoCopy
            // 
            this.cbAutoCopy.AutoSize = true;
            this.cbAutoCopy.Location = new System.Drawing.Point(40, 407);
            this.cbAutoCopy.Name = "cbAutoCopy";
            this.cbAutoCopy.Size = new System.Drawing.Size(432, 36);
            this.cbAutoCopy.TabIndex = 1;
            this.cbAutoCopy.Text = "Copy text to clipboard automatically";
            this.cbAutoCopy.UseVisualStyleBackColor = true;
            // 
            // cbRetainNewlines
            // 
            this.cbRetainNewlines.AutoSize = true;
            this.cbRetainNewlines.Location = new System.Drawing.Point(40, 470);
            this.cbRetainNewlines.Name = "cbRetainNewlines";
            this.cbRetainNewlines.Size = new System.Drawing.Size(369, 36);
            this.cbRetainNewlines.TabIndex = 1;
            this.cbRetainNewlines.Text = "Retain Newlines in copied text";
            this.cbRetainNewlines.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 570);
            this.Controls.Add(this.cbRetainNewlines);
            this.Controls.Add(this.cbAutoCopy);
            this.Controls.Add(this.tbResults);
            this.Name = "Form1";
            this.Text = "Clipboard Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbResults;
        private System.Windows.Forms.CheckBox cbAutoCopy;
        private System.Windows.Forms.CheckBox cbRetainNewlines;
    }
}

