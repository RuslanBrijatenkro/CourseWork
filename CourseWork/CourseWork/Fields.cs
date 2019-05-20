using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseWork
{
	partial class Calculations
	{
		int processorCount = 4;
		int taskNumber = 0;
		double x;
		double t;
		const int xSteps = 51;
		const int tSteps = 5001;
		double h = 1d / (xSteps - 1);
		double tau = 1d / (tSteps - 1);
		Solutions solutions = new Solutions();
		public double[,] exactSolution = new double[tSteps, xSteps];
		public double[,] approximateSolution = new double[tSteps, xSteps];
		public double[,] exactSolutionParallel = new double[tSteps, xSteps];
		public double[,] approximateSolutionParallel = new double[tSteps, xSteps];
		List<Task> awaitTasks = new List<Task>();
		public int GetxSteps
		{
			get { return xSteps; }
		}
		public int GettSteps
		{
			get { return tSteps; }
		}
	}
}
