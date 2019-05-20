namespace CourseWork
{
	partial class Calculations
	{
		void InitialConditions()
		{
			x = 0d;
			for (int i = 0; i < xSteps; i++)
			{
				approximateSolution[0, i] = solutions.GetExactSolution(x, 0);
				x += h;
			}
		}
		void BoundaryConditions()
		{
			t = tau;
			for (int i = 1; i < tSteps; i++)
			{
				approximateSolution[i, 0] = solutions.GetExactSolution(0, t);
				approximateSolution[i, xSteps - 1] = solutions.GetExactSolution(1, t);
				t += tau;
			}
		}
	}
}
