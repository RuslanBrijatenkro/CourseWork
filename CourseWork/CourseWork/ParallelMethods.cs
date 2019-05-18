using System;
using System.Threading;
using System.Threading.Tasks;

namespace CourseWork
{
	partial class Calculations
	{
		void ExactSolutionParallel(int taskNumber)
		{
			int startIndex = taskNumber * (tSteps / 4);
			int endIndex;
			if (taskNumber == 3)
			{
				endIndex = tSteps;
			}
			else
			{
				endIndex = startIndex + tSteps / 4;
			}
			double tLocal = (double)startIndex / tSteps;
			double xLocal;
			for (int k = startIndex; k < endIndex; k++)
			{
				xLocal = 0d;
				for (int i = 0; i < xSteps; i++)
				{
					Interlocked.Exchange(ref exactSolutionParallel[k, i], solutions.GetExactSolution(xLocal, tLocal));
					xLocal += 1d / xSteps;
				}
				tLocal += 1d / tSteps;
			}
		}
		void ApproximateSolutionParallel()
		{
			for (int k = 1; k < tSteps; k++)
			{
				Parallel.For(1, xSteps - 1, (int i) =>
				{
					appoximateSolution[k, i] = solutions.GetApproximateSolution(
						appoximateSolution[k - 1, i - 1],
						appoximateSolution[k - 1, i + 1],
						appoximateSolution[k - 1, i],
						1d / xSteps,
						1d / tSteps
					);
					//if (appoximateSolution[k, i] - exactSolution[k, i] > 0.01d)
					//	Console.WriteLine($"{k}:{i}" + false);
				});
			}
		}
	}
}
