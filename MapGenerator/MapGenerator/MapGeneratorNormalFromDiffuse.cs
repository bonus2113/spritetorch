using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MathNet;
using MathNet.Numerics.LinearAlgebra.Single;

namespace MapGenerator {
	class MapGeneratorNormalFromDiffuse {

		static int[,] sampleOffsets = { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
		const float thresholdMaxEdge = 1;

		static public Bitmap generate(Bitmap src) {
			
			Bitmap output = new Bitmap( src.Width, src.Height );

			float colorCurrent, colorSample;
			int x2, y2;
			for( int x = 0; x < src.Width; ++x ) {
				for( int y = 0; y < src.Height; ++y ) {

					colorCurrent = MapGenerator.Grayscale( src.GetPixel(x, y) );
					Vector averageNorm = new DenseVector( new float[] { 0, 0, 0 } );
					
					for( int i = 0; i < sampleOffsets.GetLength( 0 ); ++i ) {
						x2 = x + sampleOffsets[i, 0];
						y2 = y + sampleOffsets[i, 1];
						if( x2 < 0 || x2 >= src.Width || y2 < 0 || y2 >= src.Height ) { continue; }

						colorSample = MapGenerator.Grayscale( src.GetPixel(x2, y2) );


						// actuall processing
						float colorDelta = Math.Min( 1f, Math.Max( -1f, ((colorSample - colorCurrent) / thresholdMaxEdge) ) );
						Vector distanceDelta = new DenseVector( new float[]{ x2 - x, y2 - y, 0 } );
						distanceDelta.Norm(2);
						distanceDelta.Multiply( colorDelta, distanceDelta );
						Vector back = new DenseVector( new float[] { 0, 0, 0.25f * (1f - Math.Abs( colorDelta )) } );
						//back.Multiply( 1f - Math.Abs( colorDelta ), back );
						distanceDelta.Add( back, distanceDelta );
						distanceDelta.Norm(2);
						averageNorm.Add(distanceDelta, averageNorm);


					}

					averageNorm.Norm(2);

					//output.SetPixel( x, y, Color.FromArgb( (int)(colorCurrent * 256), (int)(colorCurrent * 256), (int)(colorCurrent * 256) ) );

					output.SetPixel( x, y, Color.FromArgb( (int)((averageNorm[0] * 0.5f + 0.5f) * 256), (int)((averageNorm[1] * 0.5f + 0.5f) * 256), Math.Min( 255, (int)((averageNorm[2] * 0.5f + 0.5f) * 256) ) ) );
				}
			}
			

			return output;
		}

	}
}
