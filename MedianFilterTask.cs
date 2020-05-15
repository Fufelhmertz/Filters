using System.Linq;
using System;
using System.Collections.Generic;

namespace Recognizer
{
	internal static class MedianFilterTask
	{
		
		/* 
		 * Для борьбы с пиксельным шумом, обычно применяют медианный фильтр, в котором цвет каждого пикселя, 
		 * заменяется на медиану всех цветов в некоторой окрестности пикселя.
		 *
		 * 
		 * Используйте окно размером 3х3 для не граничных пикселей,
		 * Окно размером 2х2 для угловых и 3х2 или 2х3 для граничных.
		 */
		public static double[,] MedianFilter(double[,] original)
		{		
			int rowsLenght = original.GetLength(0); //y - строки
			int columsLenght = original.GetLength(1); // x - колонки
			double[,] result = new double[rowsLenght,columsLenght];
			
			for(int y=0; y< rowsLenght; y++)
				for(int x=0; x< columsLenght; x++)
				{	
					int up =0, down =0, right = 0, left = 0;
					
					List<double> list = new List<double>();	

					list.Add(original[y,x]);

					if(x-1>=0)
					{
						left =1;
						list.Add(original[y,x-1]);
					}
					if(x+1<=columsLenght-1)
					{
						right = 1;
						list.Add(original[y,x+1]);
					}
					if(y-1>=0)
					{
						up =1;
						list.Add(original[y-1,x]);
					}
					if(y+1<=rowsLenght-1)
					{
						down =1;
						list.Add(original[y+1,x]);
					}

					if(up == 1 && left == 1 )
						list.Add(original[y-1,x-1]);
					if(up == 1 && right == 1 )
						list.Add(original[y-1,x+1]);
					if(down == 1 && left == 1 )
						list.Add(original[y+1,x-1]);
					if(down == 1 && right == 1 )
						list.Add(original[y+1,x+1]);	
					list.Sort();

					if(list.Count()%2!=0)
							result[y,x]=list[list.Count()/2];
						else
							result[y,x]=(list[list.Count()/2]+list[(list.Count()/2)-1])/2;
				}			
						return result;
		}

	}
}
					