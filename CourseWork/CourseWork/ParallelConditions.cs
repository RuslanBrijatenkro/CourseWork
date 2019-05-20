using System.Threading.Tasks;

namespace CourseWork
{
	partial class Calculations
	{
		public void InitialConditionsParallel()
		{
			Parallel.For(0, xSteps, (int i) =>
			{
				double xLocal = h * i;
				approximateSolutionParallel[0, i] = solutions.GetExactSolution(xLocal, 0);
			});
		}
		public void BoundaryConditionsParallel()
		{
			Parallel.For(0, tSteps, (int i) => {
				double tLocal = i * tau;
				approximateSolutionParallel[i, 0] = solutions.GetExactSolution(0, tLocal);
				approximateSolutionParallel[i, xSteps - 1] = solutions.GetExactSolution(1, tLocal);
			});
		}
	}
}
