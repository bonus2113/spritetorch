using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Drawing;
using MathNet;
//using MathNet.Numerics.LinearAlgebra.Single;

using Microsoft.Xna.Framework;

namespace MapGenerator {
	class MapGeneratorNormalFromDiffuse {

		static int[,] sampleOffsets = { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 },
									  { 1, 1 }, { -1, 1 }, { 1, -1 }, { -1, -1 }};
		/*static int[,] sampleOffsets = { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 },
									    { 1, 1 }, { -1, 1 }, { 1, -1 }, { -1, -1 },
									    { 2, 0 }, { -2, 0 }, { 0, 2 }, { 0, -2 },
									  { 3, 0 }, { -3, 0 }, { 0, 3 }, { 0, -3 },
									  { 4, 0 }, { -4, 0 }, { 0, 4 }, { 0, -4 },};*/
		/*static int[,] sampleOffsets = { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 },
									    { 1, 1 }, { -1, 1 }, { 1, -1 }, { -1, -1 },
									    { 10, 0 }, { -10, 0 }, { 0, 10 }, { 0, -10 },
									  { 15, 0 }, { -15, 0 }, { 0, 15 }, { 0, -15 },
									  { 20, 0 }, { -20, 0 }, { 0, 20 }, { 0, -20 },};*/

		const float thresholdMaxEdge = 0.01f;

		static void GenerateSampler(){
			int maxRadius = 3;
			int expansion = 1;
			sampleOffsets = new int[maxRadius * 8, 2];
			int[,] src = { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 },
						   { 1, 1 }, { -1, 1 }, { 1, -1 }, { -1, -1 }};
			for( int r = 1; r <= maxRadius; r++){
				for( int i = 0; i < 8; ++i){
					sampleOffsets[r * 8 + i - 8, 0] = src[i, 0] * r * expansion - (expansion - 1);
					sampleOffsets[r * 8 + i - 8, 1] = src[i, 1] * r * expansion - (expansion - 1);
				}
			}
		}

		static public System.Drawing.Bitmap generate(System.Drawing.Bitmap src) {

			GenerateSampler();

			System.Drawing.Bitmap output = new System.Drawing.Bitmap( src.Width, src.Height );

			float colorCurrent, colorSample;
			int x2, y2;
			for( int x = 0; x < src.Width; ++x ) {
				for( int y = 0; y < src.Height; ++y ) {

					colorCurrent = MapGenerator.Grayscale( src.GetPixel(x, y) );
					//Vector averageNorm = new DenseVector( new float[] { 0, 0, 0 } );
					Vector3 averageNorm = new Vector3(0, 0, 0);

					for( int i = 0; i < sampleOffsets.GetLength( 0 ); ++i ) {
						x2 = x + sampleOffsets[i, 0];
						y2 = y + sampleOffsets[i, 1];
						if( x2 < 0 || x2 >= src.Width || y2 < 0 || y2 >= src.Height ) { continue; }

						colorSample = MapGenerator.Grayscale( src.GetPixel(x2, y2) );


						// actuall processing
						float colorDelta = Math.Min( 1f, Math.Max( -1f, ((colorSample - colorCurrent) / thresholdMaxEdge) ) );
						
						
						/*Vector distanceDelta = new DenseVector( new float[]{ x2 - x, y2 - y, 0 } );
						distanceDelta.Norm(2);
						distanceDelta.Multiply( colorDelta, distanceDelta );
						Vector back = new DenseVector( new float[] { 0, 0, 0.25f * (1f - Math.Abs( colorDelta )) } );
						//back.Multiply( 1f - Math.Abs( colorDelta ), back );
						distanceDelta.Add( back, distanceDelta );
						distanceDelta.Norm(2);
						averageNorm.Add(distanceDelta, averageNorm);*/

						Vector3 distanceDelta = new Vector3( x2 - x, y2 - y, 0 );
						distanceDelta.Normalize();
						distanceDelta *= colorDelta;
						distanceDelta += new Vector3( 0, 0, 1) * (1f - Math.Abs( colorDelta ));
						distanceDelta.Normalize();
						averageNorm += distanceDelta;
					}

					//averageNorm.Norm(2);
					if( (averageNorm.X == 0 && averageNorm.Y == 0 && averageNorm.Z == 0)||
						(averageNorm.X == float.NaN || averageNorm.Y == float.NaN || averageNorm.Z == float.NaN) )
						averageNorm = new Vector3( 0, 0, 1 );
					else
						averageNorm.Normalize();

					//output.SetPixel( x, y, Color.FromArgb( (int)(colorCurrent * 256), (int)(colorCurrent * 256), (int)(colorCurrent * 256) ) );

					//output.SetPixel( x, y, Color.FromArgb( (int)((averageNorm[0] * 0.5f + 0.5f) * 256), (int)((averageNorm[1] * 0.5f + 0.5f) * 256), Math.Min( 255, (int)((averageNorm[2] * 0.5f + 0.5f) * 256) ) ) );
					output.SetPixel( x, y, System.Drawing.Color.FromArgb( (int)((averageNorm.X * 0.5f + 0.5f) * 255),
																		  (int)((averageNorm.Y * 0.5f + 0.5f) * 255),
																		  (int)((averageNorm.Z * 0.5f + 0.5f) * 255) ) );
				}
			}
			

			return output;
		}

	}
}
