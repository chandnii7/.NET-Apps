namespace SlotMachine
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
            this.leverPictureBox = new System.Windows.Forms.PictureBox();
            this.rotor1PictureBox = new System.Windows.Forms.PictureBox();
            this.rotor2PictureBox = new System.Windows.Forms.PictureBox();
            this.rotor3PictureBox = new System.Windows.Forms.PictureBox();
            this.coinTrayPictureBox = new System.Windows.Forms.PictureBox();
            this.coinsTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.leverPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotor1PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotor2PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotor3PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coinTrayPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // leverPictureBox
            // 
            this.leverPictureBox.Image = global::SlotMachine.Properties.Resources.lever;
            this.leverPictureBox.Location = new System.Drawing.Point(389, 13);
            this.leverPictureBox.Name = "leverPictureBox";
            this.leverPictureBox.Size = new System.Drawing.Size(72, 304);
            this.leverPictureBox.TabIndex = 0;
            this.leverPictureBox.TabStop = false;
            this.leverPictureBox.Click += new System.EventHandler(this.leverPictureBox_Click);
            // 
            // rotor1PictureBox
            // 
            this.rotor1PictureBox.Image = global::SlotMachine.Properties.Resources.slot_machine_bell;
            this.rotor1PictureBox.Location = new System.Drawing.Point(117, 129);
            this.rotor1PictureBox.Name = "rotor1PictureBox";
            this.rotor1PictureBox.Size = new System.Drawing.Size(60, 70);
            this.rotor1PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.rotor1PictureBox.TabIndex = 1;
            this.rotor1PictureBox.TabStop = false;
            // 
            // rotor2PictureBox
            // 
            this.rotor2PictureBox.Image = global::SlotMachine.Properties.Resources.slot_machine_bell;
            this.rotor2PictureBox.Location = new System.Drawing.Point(183, 129);
            this.rotor2PictureBox.Name = "rotor2PictureBox";
            this.rotor2PictureBox.Size = new System.Drawing.Size(60, 70);
            this.rotor2PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.rotor2PictureBox.TabIndex = 2;
            this.rotor2PictureBox.TabStop = false;
            // 
            // rotor3PictureBox
            // 
            this.rotor3PictureBox.Image = global::SlotMachine.Properties.Resources.slot_machine_bell;
            this.rotor3PictureBox.Location = new System.Drawing.Point(249, 129);
            this.rotor3PictureBox.Name = "rotor3PictureBox";
            this.rotor3PictureBox.Size = new System.Drawing.Size(60, 70);
            this.rotor3PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.rotor3PictureBox.TabIndex = 3;
            this.rotor3PictureBox.TabStop = false;
            // 
            // coinTrayPictureBox
            // 
            this.coinTrayPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.coinTrayPictureBox.Image = global::SlotMachine.Properties.Resources.coin_tray_empty;
            this.coinTrayPictureBox.Location = new System.Drawing.Point(166, 257);
            this.coinTrayPictureBox.Name = "coinTrayPictureBox";
            this.coinTrayPictureBox.Size = new System.Drawing.Size(100, 50);
            this.coinTrayPictureBox.TabIndex = 4;
            this.coinTrayPictureBox.TabStop = false;
            // 
            // coinsTextBox
            // 
            this.coinsTextBox.Location = new System.Drawing.Point(374, 330);
            this.coinsTextBox.Name = "coinsTextBox";
            this.coinsTextBox.ReadOnly = true;
            this.coinsTextBox.Size = new System.Drawing.Size(100, 20);
            this.coinsTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(325, 333);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Coins";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SlotMachine.Properties.Resources.machine_front;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(486, 362);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.coinsTextBox);
            this.Controls.Add(this.coinTrayPictureBox);
            this.Controls.Add(this.rotor3PictureBox);
            this.Controls.Add(this.rotor2PictureBox);
            this.Controls.Add(this.rotor1PictureBox);
            this.Controls.Add(this.leverPictureBox);
            this.Name = "Form1";
            this.Text = "Slot Machine";
            ((System.ComponentModel.ISupportInitialize)(this.leverPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotor1PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotor2PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotor3PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coinTrayPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox leverPictureBox;
        private System.Windows.Forms.PictureBox rotor1PictureBox;
        private System.Windows.Forms.PictureBox rotor2PictureBox;
        private System.Windows.Forms.PictureBox rotor3PictureBox;
        private System.Windows.Forms.PictureBox coinTrayPictureBox;
        private System.Windows.Forms.TextBox coinsTextBox;
        private System.Windows.Forms.Label label1;
    }
}

