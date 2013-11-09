using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra.Double;

namespace MapGenerator{
    class MapGeneratorNormalFromDepth {

        public static void GenNormals(Bitmap _bmp) {
            Bitmap outBmp = new Bitmap(_bmp.Width, _bmp.Height);
            for(int x = 0; x < _bmp.Width; x++) {
                for (int y = 0; y < _bmp.Height; y++) {
			        Color pixel = _bmp.GetPixel(x, y);
                    Color[] samples = new Color[4];
                    samples[0] = _bmp.GetPixel(x - 1 < 0 ? x : x - 1, y);
                    samples[1] = _bmp.GetPixel(x + 1 == _bmp.Width ? x : x + 1, y);
                    samples[2] = _bmp.GetPixel(x, y - 1 < 0 ? y : y - 1);
                    samples[3] = _bmp.GetPixel(x, y + 1 == _bmp.Height ? y : y + 1);


                    double depth = (double)pixel.R / 255; ;
                    Vector dSamples = new DenseVector(4);
                    for(int i = 0; i < 4; i++)
                        dSamples[i] = (double)samples[i].R/255;

                    outBmp.SetPixel(x, y, GetNormal(depth, dSamples));

			    }
            }
        }

        private static Color GetNormal(double _depth, Vector _samples) {
            Vector normal = new DenseVector( new double[]{ 0, 0, 0 } );

            return new Color();
        }

    }
}
