using System.Threading.Tasks;

namespace CourseWork
{
	partial class Calculations
	{
		void ExactSolutionParallel(int taskNumber)
		{
			int startIndex = taskNumber * (tSteps / processorCount);
			int endIndex;
			if (taskNumber == processorCount - 1)
			{
				endIndex = tSteps;
			}
			else
			{
				endIndex = startIndex + tSteps / processorCount;
			}
			double tLocal = (double)startIndex / tSteps;
			double xLocal;
			for (int k = startIndex; k < endIndex; k++)
			{
				xLocal = 0d;
				for (int i = 0; i < xSteps; i++)
				{
					exactSolutionParallel[k, i] = solutions.GetExactSolution(xLocal, tLocal);
					xLocal += h;
				}
				tLocal += tau;
			}
		}
		void ApproximateSolutionParallel()
		{
			for (int k = 1; k < tSteps; k++)
			{
				Parallel.For(1, xSteps - 1, (int i) =>
				{
					approximateSolutionParallel[k, i] = solutions.GetApproximateSolution(
						approximateSolutionParallel[k - 1, i - 1],
						approximateSolutionParallel[k - 1, i + 1],
						approximateSolutionParallel[k - 1, i],
						h,
						tau
					);
				});
			}
		}
	}
}
