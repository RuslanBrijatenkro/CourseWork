using System;
using static System.Math;
namespace CourseWork
{
	class Errors
	{
		int kMax;
		int iMax;
		double maxDifference;
		public double CalculateAbsoluteError(double[,] matrix1, double[,] matrix2, int xSteps, int tSteps)
		{
			for (int k = 0; k < tSteps; k++)
			{
				for (int i = 0; i < xSteps ; i++)
				{
					if (Abs(matrix2[k,i] - matrix1[k,i]) > maxDifference)
					{
						maxDifference = Abs(matrix2[k,i] - matrix1[k,i]);
						kMax = k;
						iMax = i;
					}
				}
			}
			return maxDifference;
		}
		public double CalculateRelativeError(double[,] matrix)
		{
			return maxDifference / matrix[kMax,iMax];
		}
	}
}
