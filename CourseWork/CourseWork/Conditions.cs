namespace CourseWork
{
	partial class Calculations
	{
		void InitialConditions()
		{
			x = 0d;
			for (int i = 0; i < xSteps; i++)
			{
				appoximateSolution[0, i] = solutions.GetExactSolution(x, 0);
				x += 1d / xSteps;
			}
		}
		void BoundaryConditions()
		{
			t = 0d;
			for (int i = 0; i < tSteps; i++)
			{
				appoximateSolution[i, 0] = solutions.GetExactSolution(0, t);
				appoximateSolution[i, xSteps - 1] = solutions.GetExactSolution(1, t);
				t += 1d / tSteps;
			}
		}
	}
}
