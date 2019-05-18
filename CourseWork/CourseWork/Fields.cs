using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseWork
{
	partial class Calculations
	{
		View view = new View();
		object newObject = new object();
		int taskNumber = 0;
		double x = 0;
		double t = 0;
		const int xSteps = 10;
		const int tSteps = 200;
		Solutions solutions = new Solutions();
		public double[,] exactSolution = new double[tSteps, xSteps];
		public double[,] appoximateSolution = new double[tSteps, xSteps];
		public double[,] exactSolutionParallel = new double[tSteps, xSteps];
		public double[,] appoximateSolutionParallel = new double[tSteps, xSteps];
		List<Task> awaitList = new List<Task>();
	}
}
