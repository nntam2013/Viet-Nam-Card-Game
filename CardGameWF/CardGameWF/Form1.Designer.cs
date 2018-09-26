namespace CardGameWF
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnReady = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.CardList = new System.Windows.Forms.ImageList(this.components);
            this.lbStatus = new System.Windows.Forms.Label();
            this.panelPlayerCards = new System.Windows.Forms.Panel();
            this.btnConnect = new System.Windows.Forms.Button();
            this.panelOpponentCards = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnReady
            // 
            this.btnReady.Location = new System.Drawing.Point(1027, 330);
            this.btnReady.Name = "btnReady";
            this.btnReady.Size = new System.Drawing.Size(109, 35);
            this.btnReady.TabIndex = 0;
            this.btnReady.Text = "Ready";
            this.btnReady.UseVisualStyleBackColor = true;
            this.btnReady.Click += new System.EventHandler(this.btnReady_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Enabled = false;
            this.btnPlay.Location = new System.Drawing.Point(1027, 386);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(109, 35);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(1027, 427);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(109, 35);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // CardList
            // 
            this.CardList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("CardList.ImageStream")));
            this.CardList.TransparentColor = System.Drawing.Color.Transparent;
            this.CardList.Images.SetKeyName(0, "3_1.png");
            this.CardList.Images.SetKeyName(1, "3_2.png");
            this.CardList.Images.SetKeyName(2, "3_3.png");
            this.CardList.Images.SetKeyName(3, "3_4.png");
            this.CardList.Images.SetKeyName(4, "4_1.png");
            this.CardList.Images.SetKeyName(5, "4_2.png");
            this.CardList.Images.SetKeyName(6, "4_3.png");
            this.CardList.Images.SetKeyName(7, "4_4.png");
            this.CardList.Images.SetKeyName(8, "5_1.png");
            this.CardList.Images.SetKeyName(9, "5_2.png");
            this.CardList.Images.SetKeyName(10, "5_3.png");
            this.CardList.Images.SetKeyName(11, "5_4.png");
            this.CardList.Images.SetKeyName(12, "6_1.png");
            this.CardList.Images.SetKeyName(13, "6_2.png");
            this.CardList.Images.SetKeyName(14, "6_3.png");
            this.CardList.Images.SetKeyName(15, "6_4.png");
            this.CardList.Images.SetKeyName(16, "7_1.png");
            this.CardList.Images.SetKeyName(17, "7_2.png");
            this.CardList.Images.SetKeyName(18, "7_3.png");
            this.CardList.Images.SetKeyName(19, "7_4.png");
            this.CardList.Images.SetKeyName(20, "8_1.png");
            this.CardList.Images.SetKeyName(21, "8_2.png");
            this.CardList.Images.SetKeyName(22, "8_3.png");
            this.CardList.Images.SetKeyName(23, "8_4.png");
            this.CardList.Images.SetKeyName(24, "9_1.png");
            this.CardList.Images.SetKeyName(25, "9_2.png");
            this.CardList.Images.SetKeyName(26, "9_3.png");
            this.CardList.Images.SetKeyName(27, "9_4.png");
            this.CardList.Images.SetKeyName(28, "10_1.png");
            this.CardList.Images.SetKeyName(29, "10_2.png");
            this.CardList.Images.SetKeyName(30, "10_3.png");
            this.CardList.Images.SetKeyName(31, "10_4.png");
            this.CardList.Images.SetKeyName(32, "11_1.png");
            this.CardList.Images.SetKeyName(33, "11_2.png");
            this.CardList.Images.SetKeyName(34, "11_3.png");
            this.CardList.Images.SetKeyName(35, "11_4.png");
            this.CardList.Images.SetKeyName(36, "12_1.png");
            this.CardList.Images.SetKeyName(37, "12_2.png");
            this.CardList.Images.SetKeyName(38, "12_3.png");
            this.CardList.Images.SetKeyName(39, "12_4.png");
            this.CardList.Images.SetKeyName(40, "13_1.png");
            this.CardList.Images.SetKeyName(41, "13_2.png");
            this.CardList.Images.SetKeyName(42, "13_3.png");
            this.CardList.Images.SetKeyName(43, "13_4.png");
            this.CardList.Images.SetKeyName(44, "14_1.png");
            this.CardList.Images.SetKeyName(45, "14_2.png");
            this.CardList.Images.SetKeyName(46, "14_3.png");
            this.CardList.Images.SetKeyName(47, "14_4.png");
            this.CardList.Images.SetKeyName(48, "15_1.png");
            this.CardList.Images.SetKeyName(49, "15_2.png");
            this.CardList.Images.SetKeyName(50, "15_3.png");
            this.CardList.Images.SetKeyName(51, "15_4.png");
            this.CardList.Images.SetKeyName(52, "background.jpg");
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.Location = new System.Drawing.Point(12, 481);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(99, 25);
            this.lbStatus.TabIndex = 3;
            this.lbStatus.Text = "Your Turn";
            // 
            // panelPlayerCards
            // 
            this.panelPlayerCards.Location = new System.Drawing.Point(108, 330);
            this.panelPlayerCards.Name = "panelPlayerCards";
            this.panelPlayerCards.Size = new System.Drawing.Size(766, 132);
            this.panelPlayerCards.TabIndex = 4;
            
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(1027, 25);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(109, 34);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // panelOpponentCards
            // 
            this.panelOpponentCards.Enabled = false;
            this.panelOpponentCards.Location = new System.Drawing.Point(108, 73);
            this.panelOpponentCards.Name = "panelOpponentCards";
            this.panelOpponentCards.Size = new System.Drawing.Size(700, 135);
            this.panelOpponentCards.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 515);
            this.Controls.Add(this.panelOpponentCards);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.panelPlayerCards);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnReady);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReady;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ImageList CardList;
        private System.Windows.Forms.Label lbStatus;
        public System.Windows.Forms.Panel panelPlayerCards;
        private System.Windows.Forms.Button btnConnect;
        public System.Windows.Forms.Panel panelOpponentCards;
    }
}

