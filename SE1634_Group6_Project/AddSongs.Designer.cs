namespace ProjectPRN211
{
    partial class AddSongs
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.imageText = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSongPath = new System.Windows.Forms.TextBox();
            this.btnUploadSong = new System.Windows.Forms.Button();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.btnUploadImg = new System.Windows.Forms.Button();
            this.txtLyrics = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.songText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(173, 122);
            this.txtName.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(313, 35);
            this.txtName.TabIndex = 0;
            // 
            // imageText
            // 
            this.imageText.Location = new System.Drawing.Point(823, 322);
            this.imageText.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.imageText.Name = "imageText";
            this.imageText.Size = new System.Drawing.Size(313, 35);
            this.imageText.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(823, 230);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(315, 348);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(173, 800);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 46);
            this.button1.TabIndex = 3;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSongPath
            // 
            this.txtSongPath.Location = new System.Drawing.Point(173, 322);
            this.txtSongPath.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtSongPath.Name = "txtSongPath";
            this.txtSongPath.Size = new System.Drawing.Size(313, 35);
            this.txtSongPath.TabIndex = 5;
            // 
            // btnUploadSong
            // 
            this.btnUploadSong.Location = new System.Drawing.Point(533, 322);
            this.btnUploadSong.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnUploadSong.Name = "btnUploadSong";
            this.btnUploadSong.Size = new System.Drawing.Size(120, 46);
            this.btnUploadSong.TabIndex = 6;
            this.btnUploadSong.Text = "Upload";
            this.btnUploadSong.UseVisualStyleBackColor = true;
            this.btnUploadSong.Click += new System.EventHandler(this.btnUploadSong_Click);
            // 
            // txtImagePath
            // 
            this.txtImagePath.Location = new System.Drawing.Point(173, 650);
            this.txtImagePath.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.Size = new System.Drawing.Size(313, 35);
            this.txtImagePath.TabIndex = 7;
            // 
            // btnUploadImg
            // 
            this.btnUploadImg.Location = new System.Drawing.Point(533, 648);
            this.btnUploadImg.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnUploadImg.Name = "btnUploadImg";
            this.btnUploadImg.Size = new System.Drawing.Size(120, 46);
            this.btnUploadImg.TabIndex = 8;
            this.btnUploadImg.Text = "Upload";
            this.btnUploadImg.UseVisualStyleBackColor = true;
            this.btnUploadImg.Click += new System.EventHandler(this.btnUploadImg_Click);
            // 
            // txtLyrics
            // 
            this.txtLyrics.Location = new System.Drawing.Point(173, 408);
            this.txtLyrics.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtLyrics.Multiline = true;
            this.txtLyrics.Name = "txtLyrics";
            this.txtLyrics.Size = new System.Drawing.Size(313, 200);
            this.txtLyrics.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 128);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 30);
            this.label1.TabIndex = 10;
            this.label1.Text = "Song Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 236);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 30);
            this.label2.TabIndex = 11;
            this.label2.Text = "Author: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 330);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 30);
            this.label3.TabIndex = 12;
            this.label3.Text = "Song Path : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 496);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 30);
            this.label4.TabIndex = 13;
            this.label4.Text = "Lyrics :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 656);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 30);
            this.label5.TabIndex = 14;
            this.label5.Text = "Image Path :";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(173, 230);
            this.txtAuthor.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.ReadOnly = true;
            this.txtAuthor.Size = new System.Drawing.Size(313, 35);
            this.txtAuthor.TabIndex = 15;
            // 
            // songText
            // 
            this.songText.Location = new System.Drawing.Point(823, 478);
            this.songText.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.songText.Name = "songText";
            this.songText.Size = new System.Drawing.Size(313, 35);
            this.songText.TabIndex = 16;
            // 
            // AddSongs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 900);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLyrics);
            this.Controls.Add(this.btnUploadImg);
            this.Controls.Add(this.txtImagePath);
            this.Controls.Add(this.btnUploadSong);
            this.Controls.Add(this.txtSongPath);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.imageText);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.songText);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "AddSongs";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtName;
        private TextBox imageText;
        private PictureBox pictureBox1;
        private Button button1;
        private TextBox txtSongPath;
        private Button btnUploadSong;
        private TextBox txtImagePath;
        private Button btnUploadImg;
        private TextBox txtLyrics;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtAuthor;
        private TextBox songText;
    }
}