using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MapGenerator {
	class MapGenerator {

		static Bitmap srcImg;

		public static float Grayscale(Color color) {
			return ((float)color.R * 0.3f + (float)color.G * 0.59f + (float)color.B * 0.11f) / 256f;
		}

		public static void loadIMG() {


		}
	}
}
