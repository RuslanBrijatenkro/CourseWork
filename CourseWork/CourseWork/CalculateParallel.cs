using System.Threading.Tasks;

namespace CourseWork
{
	partial class Calculations
	{
		public void CalculateParallel()
		{
			Task.Factory.StartNew(ExactSolution).Wait();
			InitialConditionsParallel();
			BoundaryConditionsParallel();
			ApproximateSolutionParallel();
		}
		async public void ExactSolutionAsync()
		{
			for (int i = 0; i < processorCount; i++)
			{
				awaitTasks.Add(Task.Factory.StartNew(delegate () { ExactSolutionParallel(taskNumber++); }));
			}
			await Task.WhenAll(awaitTasks);
		}

	}
}
