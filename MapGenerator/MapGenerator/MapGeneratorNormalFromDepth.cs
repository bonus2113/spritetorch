using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra.Double;

namespace MapGenerator{
    class MapGeneratorNormalFromDepth {

        public static Bitmap GenNormals(Bitmap _bmp) {
            Bitmap outBmp = new Bitmap(_bmp.Width, _bmp.Height);
            for(int x = 0; x < _bmp.Width; x++) {
                for (int y = 0; y < _bmp.Height; y++) {
			        Color pixel = _bmp.GetPixel(x, y);
                    Color[] samples = new Color[4];
                    samples[0] = _bmp.GetPixel(x - 1 < 0 ? x : x - 1, y);
                    samples[1] = _bmp.GetPixel(x + 1 == _bmp.Width ? x : x + 1, y);
                    samples[2] = _bmp.GetPixel(x, y - 1 < 0 ? y : y - 1);
                    samples[3] = _bmp.GetPixel(x, y + 1 == _bmp.Height ? y : y + 1);


                    double depth = (double)pixel.R/5;
                    Vector dSamples = new DenseVector(4);
                    for(int i = 0; i < 4; i++)
                        dSamples[i] = (double)samples[i].R/5;

                    outBmp.SetPixel(x, y, GetNormal(depth, dSamples, x, y));

			    }
            }
            return outBmp;
        }

        private static DenseVector CrossProduct(DenseVector a, DenseVector b)
        {
            return new DenseVector(new double[] { a[1] * b[2] - a[2] * b[1], a[2] * b[0] - a[0] * b[2], a[0] * b[1] - a[1] * b[0] });
        }

        private static Color GetNormal(double _depth, Vector _samples, int x, int y) {

            DenseVector pos = new DenseVector(new double[] { x, y, _depth });

            DenseVector pos01 = new DenseVector(new double[] { x - 1, y, _samples[0] });
            DenseVector pos02 = new DenseVector(new double[] { x + 1, y, _samples[1] });

            DenseVector pos03 = new DenseVector(new double[] { x, y - 1, _samples[2] });
            DenseVector pos04 = new DenseVector(new double[] { x, y + 1, _samples[3] });


            DenseVector dx = (DenseVector)(pos02 - pos01);
            DenseVector dy = (DenseVector)(pos04 - pos02);

            DenseVector normal = CrossProduct(dx, dy);
            normal = (DenseVector)normal.Normalize(2);

            return Color.FromArgb(128 + (int)(normal[0] * 128), 128 + (int)(normal[1] * 128), (int)(normal[2] * 255));
        }

    }
}
