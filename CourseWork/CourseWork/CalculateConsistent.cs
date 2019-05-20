
namespace CourseWork
{
	partial class Calculations
	{
		public void CalculateConsistent()
		{
			ExactSolution();
			InitialConditions();
			BoundaryConditions();
			ApproximateSolution();
		}
	}
}
