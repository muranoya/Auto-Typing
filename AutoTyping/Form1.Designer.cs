namespace AutoTyping
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.startButton = new System.Windows.Forms.Button();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.fpsChangeNumericBox = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.capturePBox = new System.Windows.Forms.PictureBox();
            this.resultPBox = new System.Windows.Forms.PictureBox();
            this.controlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpsChangeNumericBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.capturePBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultPBox)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startButton.Location = new System.Drawing.Point(100, 56);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(51, 23);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // resultTextBox
            // 
            this.resultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultTextBox.Location = new System.Drawing.Point(12, 6);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ReadOnly = true;
            this.resultTextBox.ShortcutsEnabled = false;
            this.resultTextBox.Size = new System.Drawing.Size(139, 19);
            this.resultTextBox.TabIndex = 0;
            // 
            // stopButton
            // 
            this.stopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(43, 56);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(51, 23);
            this.stopButton.TabIndex = 4;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // controlPanel
            // 
            this.controlPanel.AutoScroll = true;
            this.controlPanel.BackColor = System.Drawing.SystemColors.Control;
            this.controlPanel.Controls.Add(this.label3);
            this.controlPanel.Controls.Add(this.fpsChangeNumericBox);
            this.controlPanel.Controls.Add(this.label2);
            this.controlPanel.Controls.Add(this.stopButton);
            this.controlPanel.Controls.Add(this.startButton);
            this.controlPanel.Controls.Add(this.resultTextBox);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlPanel.Location = new System.Drawing.Point(0, 77);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(163, 85);
            this.controlPanel.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "ms";
            // 
            // fpsChangeNumericBox
            // 
            this.fpsChangeNumericBox.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.fpsChangeNumericBox.Location = new System.Drawing.Point(36, 31);
            this.fpsChangeNumericBox.Maximum = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.fpsChangeNumericBox.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.fpsChangeNumericBox.Name = "fpsChangeNumericBox";
            this.fpsChangeNumericBox.Size = new System.Drawing.Size(50, 19);
            this.fpsChangeNumericBox.TabIndex = 2;
            this.fpsChangeNumericBox.ThousandsSeparator = true;
            this.fpsChangeNumericBox.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Wait";
            // 
            // capturePBox
            // 
            this.capturePBox.BackColor = System.Drawing.Color.Red;
            this.capturePBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.capturePBox.Location = new System.Drawing.Point(0, 0);
            this.capturePBox.Name = "capturePBox";
            this.capturePBox.Size = new System.Drawing.Size(163, 44);
            this.capturePBox.TabIndex = 3;
            this.capturePBox.TabStop = false;
            // 
            // resultPBox
            // 
            this.resultPBox.BackColor = System.Drawing.Color.Gray;
            this.resultPBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultPBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultPBox.Location = new System.Drawing.Point(0, 44);
            this.resultPBox.Name = "resultPBox";
            this.resultPBox.Size = new System.Drawing.Size(163, 33);
            this.resultPBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.resultPBox.TabIndex = 4;
            this.resultPBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(163, 162);
            this.Controls.Add(this.resultPBox);
            this.Controls.Add(this.capturePBox);
            this.Controls.Add(this.controlPanel);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "AutoTyping";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Red;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpsChangeNumericBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.capturePBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultPBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.PictureBox capturePBox;
        private System.Windows.Forms.PictureBox resultPBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown fpsChangeNumericBox;
        private System.Windows.Forms.Label label2;
    }
}

