namespace MapGenerator {
	partial class Form1 {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing ) {
			if( disposing && (components != null) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.pictureInput = new System.Windows.Forms.PictureBox();
			this.pictureOutput = new System.Windows.Forms.PictureBox();
			this.btnLoadImage = new System.Windows.Forms.Button();
			this.btnDiffToNorm = new System.Windows.Forms.Button();
			this.btnDepthToNorm = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureOutput)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureInput
			// 
			this.pictureInput.Location = new System.Drawing.Point( 12, 12 );
			this.pictureInput.Name = "pictureInput";
			this.pictureInput.Size = new System.Drawing.Size( 300, 200 );
			this.pictureInput.TabIndex = 0;
			this.pictureInput.TabStop = false;
			// 
			// pictureOutput
			// 
			this.pictureOutput.Location = new System.Drawing.Point( 12, 218 );
			this.pictureOutput.Name = "pictureOutput";
			this.pictureOutput.Size = new System.Drawing.Size( 300, 200 );
			this.pictureOutput.TabIndex = 1;
			this.pictureOutput.TabStop = false;
			// 
			// btnLoadImage
			// 
			this.btnLoadImage.Location = new System.Drawing.Point( 341, 12 );
			this.btnLoadImage.Name = "btnLoadImage";
			this.btnLoadImage.Size = new System.Drawing.Size( 75, 23 );
			this.btnLoadImage.TabIndex = 2;
			this.btnLoadImage.Text = "load img src";
			this.btnLoadImage.UseVisualStyleBackColor = true;
			this.btnLoadImage.Click += new System.EventHandler( this.btnLoadImage_Click );
			// 
			// btnDiffToNorm
			// 
			this.btnDiffToNorm.Location = new System.Drawing.Point( 341, 66 );
			this.btnDiffToNorm.Name = "btnDiffToNorm";
			this.btnDiffToNorm.Size = new System.Drawing.Size( 75, 41 );
			this.btnDiffToNorm.TabIndex = 3;
			this.btnDiffToNorm.Text = "diffuse to normal";
			this.btnDiffToNorm.UseVisualStyleBackColor = true;
			this.btnDiffToNorm.Click += new System.EventHandler( this.btnDiffToNorm_Click );
			// 
			// btnDepthToNorm
			// 
			this.btnDepthToNorm.Location = new System.Drawing.Point( 341, 124 );
			this.btnDepthToNorm.Name = "btnDepthToNorm";
			this.btnDepthToNorm.Size = new System.Drawing.Size( 75, 41 );
			this.btnDepthToNorm.TabIndex = 4;
			this.btnDepthToNorm.Text = "depth to normal";
			this.btnDepthToNorm.UseVisualStyleBackColor = true;
			this.btnDepthToNorm.Click += new System.EventHandler( this.btnDepthToNorm_Click );
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 441, 434 );
			this.Controls.Add( this.btnDepthToNorm );
			this.Controls.Add( this.btnDiffToNorm );
			this.Controls.Add( this.btnLoadImage );
			this.Controls.Add( this.pictureOutput );
			this.Controls.Add( this.pictureInput );
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.pictureInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureOutput)).EndInit();
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureInput;
		private System.Windows.Forms.PictureBox pictureOutput;
		private System.Windows.Forms.Button btnLoadImage;
		private System.Windows.Forms.Button btnDiffToNorm;
		private System.Windows.Forms.Button btnDepthToNorm;
	}
}

