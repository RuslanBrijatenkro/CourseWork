using System.Threading.Tasks;

namespace CourseWork
{
	partial class Calculations
	{
		async public void CalculateParallel()
		{
			for (int i = 0; i < 4; i++)
			{
				awaitList.Add(Task.Factory.StartNew(delegate () { ExactSolutionParallel(taskNumber++); }));
			}
			await Task.WhenAll(awaitList);
			Parallel.For(0, xSteps, (int i) =>
			{
				double xLocal = 1d / xSteps * i;
				appoximateSolutionParallel[0, i] = solutions.GetExactSolution(xLocal, 0);
			});
			Parallel.For(0, tSteps, (int i) => {
				double tLocal = i * 1d / tSteps;
				appoximateSolutionParallel[i, 0] = solutions.GetExactSolution(0, tLocal);
				appoximateSolutionParallel[i, xSteps - 1] = solutions.GetExactSolution(1, tLocal);
			});
			ApproximateSolutionParallel();
			view.Writer("C:/Users/brija/Desktop/3.txt", appoximateSolutionParallel);
			view.Writer("C:/Users/brija/Desktop/4.txt", exactSolutionParallel);

		}
	}
}
