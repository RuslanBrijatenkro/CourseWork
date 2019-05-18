using System;

namespace CourseWork
{
	partial class Calculations
	{
		void ExactSolution()
		{
			for (int k = 0; k < tSteps; k++)
			{
				x = 0d;
				for (int i = 0; i < xSteps; i++)
				{
					exactSolution[k, i] = solutions.GetExactSolution(x, t);
					x += 1d / xSteps;
				}
				t += 1d / tSteps;
			}
		}
		void ApproximateSolution()
		{
			for (int k = 1; k < tSteps; k++)
			{
				for (int i = 1; i < xSteps - 1; i++)
				{
					appoximateSolution[k, i] = solutions.GetApproximateSolution(
						appoximateSolution[k - 1, i - 1],
						appoximateSolution[k - 1, i + 1],
						appoximateSolution[k - 1, i],
						1d / xSteps,
						1d / tSteps
					);
					//if (appoximateSolution[k, i] - exactSolution[k, i] > 0.01d)
					//	Console.WriteLine(appoximateSolution[k, i]+" != "+ exactSolution[k, i]);

				}
			}
		}
	}
}
