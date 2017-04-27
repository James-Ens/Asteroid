namespace CMPE2800_AsteROID
{
    partial class AsteROID
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
            this.UI_T_Timer = new System.Windows.Forms.Timer(this.components);
            this.UI_P_StartPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.UI_B_Exit = new System.Windows.Forms.Button();
            this.UI_B_Start = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.UI_P_PausedPanel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.UI_P_GameOverPanel = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.UI_P_NextLevel = new System.Windows.Forms.Panel();
            this.UI_LB_Level = new System.Windows.Forms.Label();
            this.UI_P_StartPanel.SuspendLayout();
            this.UI_P_PausedPanel.SuspendLayout();
            this.UI_P_GameOverPanel.SuspendLayout();
            this.UI_P_NextLevel.SuspendLayout();
            this.SuspendLayout();
            // 
            // UI_T_Timer
            // 
            this.UI_T_Timer.Enabled = true;
            this.UI_T_Timer.Interval = 10;
            this.UI_T_Timer.Tick += new System.EventHandler(this.UI_T_Timer_Tick);
            // 
            // UI_P_StartPanel
            // 
            this.UI_P_StartPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UI_P_StartPanel.Controls.Add(this.label5);
            this.UI_P_StartPanel.Controls.Add(this.UI_B_Exit);
            this.UI_P_StartPanel.Controls.Add(this.UI_B_Start);
            this.UI_P_StartPanel.Controls.Add(this.label4);
            this.UI_P_StartPanel.Controls.Add(this.label3);
            this.UI_P_StartPanel.Controls.Add(this.label2);
            this.UI_P_StartPanel.Controls.Add(this.label1);
            this.UI_P_StartPanel.Location = new System.Drawing.Point(154, 12);
            this.UI_P_StartPanel.Name = "UI_P_StartPanel";
            this.UI_P_StartPanel.Size = new System.Drawing.Size(645, 315);
            this.UI_P_StartPanel.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Moire", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(208, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 23);
            this.label5.TabIndex = 5;
            this.label5.Text = "PAUSE-------------P";
            // 
            // UI_B_Exit
            // 
            this.UI_B_Exit.Location = new System.Drawing.Point(548, 274);
            this.UI_B_Exit.Name = "UI_B_Exit";
            this.UI_B_Exit.Size = new System.Drawing.Size(94, 38);
            this.UI_B_Exit.TabIndex = 4;
            this.UI_B_Exit.Text = "Exit";
            this.UI_B_Exit.UseVisualStyleBackColor = true;
            this.UI_B_Exit.Click += new System.EventHandler(this.UI_B_Exit_Click);
            // 
            // UI_B_Start
            // 
            this.UI_B_Start.Location = new System.Drawing.Point(3, 274);
            this.UI_B_Start.Name = "UI_B_Start";
            this.UI_B_Start.Size = new System.Drawing.Size(94, 38);
            this.UI_B_Start.TabIndex = 0;
            this.UI_B_Start.Text = "Start Game";
            this.UI_B_Start.UseVisualStyleBackColor = true;
            this.UI_B_Start.Click += new System.EventHandler(this.UI_B_Start_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Moire", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(208, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(350, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "ROTATE-------------LEFT AND RIGHT ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Moire", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(208, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "SHOOT-------------UP ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Moire", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(172, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(316, 58);
            this.label2.TabIndex = 1;
            this.label2.Text = "ASTEROIDS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("Moire", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(265, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Controls";
            // 
            // UI_P_PausedPanel
            // 
            this.UI_P_PausedPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UI_P_PausedPanel.Controls.Add(this.label6);
            this.UI_P_PausedPanel.Location = new System.Drawing.Point(805, 63);
            this.UI_P_PausedPanel.Name = "UI_P_PausedPanel";
            this.UI_P_PausedPanel.Size = new System.Drawing.Size(200, 100);
            this.UI_P_PausedPanel.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Font = new System.Drawing.Font("Moire", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(34, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 35);
            this.label6.TabIndex = 1;
            this.label6.Text = "PAUSED";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UI_P_GameOverPanel
            // 
            this.UI_P_GameOverPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UI_P_GameOverPanel.Controls.Add(this.label8);
            this.UI_P_GameOverPanel.Controls.Add(this.label7);
            this.UI_P_GameOverPanel.Location = new System.Drawing.Point(368, 359);
            this.UI_P_GameOverPanel.Name = "UI_P_GameOverPanel";
            this.UI_P_GameOverPanel.Size = new System.Drawing.Size(367, 138);
            this.UI_P_GameOverPanel.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Font = new System.Drawing.Font("Moire", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(89, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(197, 35);
            this.label7.TabIndex = 1;
            this.label7.Text = "GAME OVER";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Font = new System.Drawing.Font("Moire", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(12, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(346, 35);
            this.label8.TabIndex = 2;
            this.label8.Text = "PRESS A TO REPLAY...";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UI_P_NextLevel
            // 
            this.UI_P_NextLevel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UI_P_NextLevel.Controls.Add(this.UI_LB_Level);
            this.UI_P_NextLevel.Location = new System.Drawing.Point(34, 374);
            this.UI_P_NextLevel.Name = "UI_P_NextLevel";
            this.UI_P_NextLevel.Size = new System.Drawing.Size(200, 100);
            this.UI_P_NextLevel.TabIndex = 3;
            // 
            // UI_LB_Level
            // 
            this.UI_LB_Level.AutoSize = true;
            this.UI_LB_Level.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UI_LB_Level.Font = new System.Drawing.Font("Moire", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UI_LB_Level.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UI_LB_Level.Location = new System.Drawing.Point(34, 29);
            this.UI_LB_Level.Name = "UI_LB_Level";
            this.UI_LB_Level.Size = new System.Drawing.Size(120, 35);
            this.UI_LB_Level.TabIndex = 1;
            this.UI_LB_Level.Text = "Level 1";
            this.UI_LB_Level.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AsteROID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.UI_P_NextLevel);
            this.Controls.Add(this.UI_P_GameOverPanel);
            this.Controls.Add(this.UI_P_PausedPanel);
            this.Controls.Add(this.UI_P_StartPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AsteROID";
            this.Load += new System.EventHandler(this.AsteROID_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AsteROID_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AsteROID_KeyUp);
            this.UI_P_StartPanel.ResumeLayout(false);
            this.UI_P_StartPanel.PerformLayout();
            this.UI_P_PausedPanel.ResumeLayout(false);
            this.UI_P_PausedPanel.PerformLayout();
            this.UI_P_GameOverPanel.ResumeLayout(false);
            this.UI_P_GameOverPanel.PerformLayout();
            this.UI_P_NextLevel.ResumeLayout(false);
            this.UI_P_NextLevel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer UI_T_Timer;
        private System.Windows.Forms.Panel UI_P_StartPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button UI_B_Exit;
        private System.Windows.Forms.Button UI_B_Start;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel UI_P_PausedPanel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel UI_P_GameOverPanel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel UI_P_NextLevel;
        private System.Windows.Forms.Label UI_LB_Level;
    }
}

