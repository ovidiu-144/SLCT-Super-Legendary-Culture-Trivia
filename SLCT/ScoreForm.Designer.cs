namespace SLCT
{
    partial class ScoreForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScoreForm));
            labelScore = new Label();
            buttonPlayAgain = new Button();
            buttonExit = new Button();
            SuspendLayout();
            // 
            // labelScore
            // 
            labelScore.Anchor = AnchorStyles.Top;
            labelScore.AutoSize = true;
            labelScore.BackColor = Color.Navy;
            labelScore.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelScore.ForeColor = Color.White;
            labelScore.Location = new Point(188, 177);
            labelScore.Name = "labelScore";
            labelScore.Size = new Size(98, 36);
            labelScore.TabIndex = 0;
            labelScore.Text = "Score";
            // 
            // buttonPlayAgain
            // 
            buttonPlayAgain.Anchor = AnchorStyles.Top;
            buttonPlayAgain.BackColor = Color.Navy;
            buttonPlayAgain.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonPlayAgain.ForeColor = Color.White;
            buttonPlayAgain.Location = new Point(202, 422);
            buttonPlayAgain.Margin = new Padding(3, 4, 3, 4);
            buttonPlayAgain.Name = "buttonPlayAgain";
            buttonPlayAgain.Size = new Size(162, 76);
            buttonPlayAgain.TabIndex = 2;
            buttonPlayAgain.Text = "Joacă din nou";
            buttonPlayAgain.UseVisualStyleBackColor = false;
            buttonPlayAgain.Click += button1_Click;
            // 
            // buttonExit
            // 
            buttonExit.Anchor = AnchorStyles.Top;
            buttonExit.BackColor = Color.Navy;
            buttonExit.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonExit.ForeColor = Color.White;
            buttonExit.Location = new Point(438, 422);
            buttonExit.Margin = new Padding(3, 4, 3, 4);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(162, 76);
            buttonExit.TabIndex = 3;
            buttonExit.Text = "Ieșire";
            buttonExit.UseVisualStyleBackColor = false;
            buttonExit.Click += button2_Click;
            // 
            // ScoreForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 562);
            Controls.Add(buttonExit);
            Controls.Add(buttonPlayAgain);
            Controls.Add(labelScore);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ScoreForm";
            Text = "ScoreForm";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Button buttonPlayAgain;
        private System.Windows.Forms.Button buttonExit;
    }
}