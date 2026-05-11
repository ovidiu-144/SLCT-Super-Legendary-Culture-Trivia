namespace SLCT
{
    partial class CategoryMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryMenu));
            labelCategories = new Label();
            buttonPR = new Button();
            buttonMA = new Button();
            buttonIS = new Button();
            buttonGE = new Button();
            buttonFI = new Button();
            buttonSP = new Button();
            comboStrategy = new ComboBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // labelCategories
            // 
            labelCategories.Anchor = AnchorStyles.Top;
            labelCategories.AutoSize = true;
            labelCategories.BackColor = Color.Transparent;
            labelCategories.Font = new Font("Stencil", 48F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelCategories.ForeColor = SystemColors.Control;
            labelCategories.Location = new Point(471, 144);
            labelCategories.Name = "labelCategories";
            labelCategories.Size = new Size(462, 95);
            labelCategories.TabIndex = 0;
            labelCategories.Text = "Categorii";
            labelCategories.TextAlign = ContentAlignment.TopCenter;
            // 
            // buttonPR
            // 
            buttonPR.Anchor = AnchorStyles.Top;
            buttonPR.BackColor = Color.Navy;
            buttonPR.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonPR.ForeColor = Color.WhiteSmoke;
            buttonPR.Location = new Point(370, 395);
            buttonPR.Margin = new Padding(3, 4, 3, 4);
            buttonPR.Name = "buttonPR";
            buttonPR.Size = new Size(209, 91);
            buttonPR.TabIndex = 1;
            buttonPR.Text = "PROGRAMARE";
            buttonPR.UseVisualStyleBackColor = false;
            buttonPR.Click += buttonPR_Click;
            // 
            // buttonMA
            // 
            buttonMA.Anchor = AnchorStyles.Top;
            buttonMA.BackColor = Color.Navy;
            buttonMA.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonMA.ForeColor = Color.WhiteSmoke;
            buttonMA.Location = new Point(370, 514);
            buttonMA.Margin = new Padding(3, 4, 3, 4);
            buttonMA.Name = "buttonMA";
            buttonMA.Size = new Size(209, 91);
            buttonMA.TabIndex = 2;
            buttonMA.Text = "MATEMATICĂ";
            buttonMA.UseVisualStyleBackColor = false;
            buttonMA.Click += buttonMA_Click;
            // 
            // buttonIS
            // 
            buttonIS.Anchor = AnchorStyles.Top;
            buttonIS.BackColor = Color.Navy;
            buttonIS.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonIS.ForeColor = Color.WhiteSmoke;
            buttonIS.Location = new Point(370, 628);
            buttonIS.Margin = new Padding(3, 4, 3, 4);
            buttonIS.Name = "buttonIS";
            buttonIS.Size = new Size(209, 91);
            buttonIS.TabIndex = 3;
            buttonIS.Text = "ISTORIE";
            buttonIS.UseVisualStyleBackColor = false;
            buttonIS.Click += buttonIS_Click;
            // 
            // buttonGE
            // 
            buttonGE.Anchor = AnchorStyles.Top;
            buttonGE.BackColor = Color.Navy;
            buttonGE.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonGE.ForeColor = Color.WhiteSmoke;
            buttonGE.Location = new Point(783, 395);
            buttonGE.Margin = new Padding(3, 4, 3, 4);
            buttonGE.Name = "buttonGE";
            buttonGE.Size = new Size(209, 91);
            buttonGE.TabIndex = 4;
            buttonGE.Text = "GEOGRAFIE";
            buttonGE.UseVisualStyleBackColor = false;
            buttonGE.Click += buttonGE_Click;
            // 
            // buttonFI
            // 
            buttonFI.Anchor = AnchorStyles.Top;
            buttonFI.BackColor = Color.Navy;
            buttonFI.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonFI.ForeColor = Color.WhiteSmoke;
            buttonFI.Location = new Point(783, 514);
            buttonFI.Margin = new Padding(3, 4, 3, 4);
            buttonFI.Name = "buttonFI";
            buttonFI.Size = new Size(209, 91);
            buttonFI.TabIndex = 5;
            buttonFI.Text = "FIZICĂ";
            buttonFI.UseVisualStyleBackColor = false;
            buttonFI.Click += buttonFI_Click;
            // 
            // buttonSP
            // 
            buttonSP.Anchor = AnchorStyles.Top;
            buttonSP.BackColor = Color.Navy;
            buttonSP.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonSP.ForeColor = Color.WhiteSmoke;
            buttonSP.Location = new Point(783, 628);
            buttonSP.Margin = new Padding(3, 4, 3, 4);
            buttonSP.Name = "buttonSP";
            buttonSP.Size = new Size(209, 91);
            buttonSP.TabIndex = 6;
            buttonSP.Text = "SPORT";
            buttonSP.UseVisualStyleBackColor = false;
            buttonSP.Click += buttonSP_Click;
            // 
            // comboStrategy
            // 
            comboStrategy.FormattingEnabled = true;
            comboStrategy.Items.AddRange(new object[] { "Negative Scoring", "Simple Scoring", "Timed Scoring" });
            comboStrategy.Location = new Point(614, 880);
            comboStrategy.Margin = new Padding(3, 4, 3, 4);
            comboStrategy.Name = "comboStrategy";
            comboStrategy.Size = new Size(158, 28);
            comboStrategy.TabIndex = 7;
            comboStrategy.SelectedIndexChanged += comboStrategy_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(559, 840);
            label1.Name = "label1";
            label1.Size = new Size(280, 20);
            label1.TabIndex = 8;
            label1.Text = "Strategie de acordare a scorului";
            // 
            // CategoryMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1401, 969);
            Controls.Add(label1);
            Controls.Add(comboStrategy);
            Controls.Add(buttonSP);
            Controls.Add(buttonFI);
            Controls.Add(buttonGE);
            Controls.Add(buttonIS);
            Controls.Add(buttonMA);
            Controls.Add(buttonPR);
            Controls.Add(labelCategories);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CategoryMenu";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCategories;
        private System.Windows.Forms.Button buttonPR;
        private System.Windows.Forms.Button buttonMA;
        private System.Windows.Forms.Button buttonIS;
        private System.Windows.Forms.Button buttonGE;
        private System.Windows.Forms.Button buttonFI;
        private System.Windows.Forms.Button buttonSP;
        private System.Windows.Forms.ComboBox comboStrategy;
        private System.Windows.Forms.Label label1;
    }
}