namespace Recognizer
{
	public static class GrayscaleTask
	{
		/* 
		 * Переведите изображение в серую гамму.
		 * 
		 * original[x, y] - массив пикселей с координатами x, y. 
		 * Каждый канал R,G,B лежит в диапазоне от 0 до 255. 
		 * 
		 */

		public static double[,] ToGrayscale(Pixel[,] original)
		{
			int colum = original.GetLength(0);
			int line = original.GetLength(1);
			double[,] result= new double[colum, line];	
			
				for(int i = 0; i<colum;i++)
					for(int j = 0; j<line; j++)					
						result[i,j]=(0.299*original[i,j].R + 0.587*original[i,j].G + 0.114*original[i,j].B) / 255;	

			return result;
		}
	}
}