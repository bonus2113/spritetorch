﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MapGenerator {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void btnLoadImage_Click( object sender, EventArgs e ) {
			pictureInput.Image = Properties.Resources.test4;
			
			
		}

		private void btnDiffToNorm_Click( object sender, EventArgs e ) {
			Bitmap norm = MapGeneratorNormalFromDiffuse.generate(new Bitmap(pictureInput.Image));
			pictureOutput.Image = norm;
		}

		private void btnDepthToNorm_Click( object sender, EventArgs e ) {
            pictureOutput.Image = MapGeneratorNormalFromDepth.GenNormals(new Bitmap(pictureInput.Image));
		}

        private void btnSave_Click(object sender, EventArgs e)
        {
            pictureOutput.Image.Save("output.png");
        }
	}
}
