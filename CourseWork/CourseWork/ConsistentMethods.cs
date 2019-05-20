using System;

namespace CourseWork
{
	partial class Calculations
	{
		void ExactSolution()
		{
			t = 0d;
			for (int k = 0; k < tSteps; k++)
			{
				x = 0d;
				for (int i = 0; i < xSteps; i++)
				{
					exactSolution[k, i] = solutions.GetExactSolution(x, t);
					x += h;
				}
				t += tau;
			}
		}
		void ApproximateSolution()
		{
			for (int k = 1; k < tSteps; k++)
			{
				for (int i = 1; i < xSteps - 1; i++)
				{
					approximateSolution[k, i] = solutions.GetApproximateSolution(
						approximateSolution[k - 1, i - 1],
						approximateSolution[k - 1, i + 1],
						approximateSolution[k - 1, i],
						h,
						tau
					);

					if (Math.Abs(approximateSolution[k, i] - exactSolution[k, i]) > 0.05)
						Console.WriteLine("Approximate: " + approximateSolution[k, i] + " != " + "Exact: " + exactSolution[k, i]);

				}
			}
		}
	}
}
