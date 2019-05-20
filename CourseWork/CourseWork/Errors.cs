using System;
using static System.Math;
namespace CourseWork
{
	class Errors
	{
		double relativeError;
		int kMax;
		int iMax;
		double maxDifference;
		public void CalculateAbsoluteError(double[,] exactCondition, double[,] approximateCondition, int xSteps, int tSteps)
		{
			for (int k = 0; k < tSteps; k++)
			{
				for (int i = 0; i < xSteps; i++)
				{
					if (Abs(approximateCondition[k, i] - exactCondition[k, i]) > maxDifference)
					{
						maxDifference = Abs(approximateCondition[k, i] - exactCondition[k, i]);
						kMax = k;
						iMax = i;
					}
				}
			}
			Console.WriteLine($"Absolute error: {maxDifference}");

		}
		public void CalculateRelativeError(double[,] matrix)
		{
			relativeError = maxDifference / matrix[kMax, iMax];
			Console.WriteLine($"Relative error: {relativeError}");
		}
	}
}
