using System.Collections.Generic;
using System.Linq;

namespace Recognizer
{
	/*
	 * Пора превратить изображение в черно-белое.
	Сделать это можно с помощью порогового преобразования. Реализуйте его в методе
	public static double[,] ThresholdFilter(double[,] original, double whitePixelsFraction)
	Метод должен заменять пиксели со значением больше либо равному порогу T на белый (1.0), а остальные на черный (0.0).
	Пороговое значение T найдите так, чтобы:
	если N — общее количество пикселей изображения, то как минимум (int)(whitePixelsFraction*N) пикселей стали белыми;
	при этом белыми стало как можно меньше пикселей.
	 */
	public static class ThresholdFilterTask
	{
		public static double[,] ThresholdFilter(double[,] original, double whitePixelsFraction)
		{
			int rowsLenght = original.GetLength(0); //y - строки
			int columsLenght = original.GetLength(1); // x - колонки			
			double[,] result = new double [rowsLenght , columsLenght];			
			int t = (int)(whitePixelsFraction* result.Length);	
			
			List<double> list = new List<double>();		
			
			foreach(var c in original)
				list.Add(c);	
			while(t>0)
			{
				double value = list.Max();
				for(int y=0; y< rowsLenght; y++)
					for(int x=0; x< columsLenght; x++)
					{						
						if(value == original[y,x])							
						{
								result[y,x]=1.0;
								t--;
						}	
					}
				if(list.Count>1)
					list.Remove(value);				
			}
			return result;
		}
	}
}