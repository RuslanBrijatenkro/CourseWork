using System;

namespace CourseWork
{
	class Program
	{
		static void Main(string[] args)
		{
			string mathematicaPath = @"C:\Users\brija\Desktop\CourseWork\CourseWork\CourseWork\results\3.nb";
			Timer timer = new Timer();
			Errors errors = new Errors();
			Calculations calculations = new Calculations();
			View view = new View(calculations,mathematicaPath);
			long time;

			time = timer.StartWork(calculations.CalculateConsistent);
			Console.WriteLine($"Consistent:{time} ms");

			time = timer.StartWork(calculations.CalculateParallel);
			Console.WriteLine($"Parallel:{time} ms");

			view.WriteResults();

			errors.CalculateAbsoluteError(
				calculations.exactSolution,
				calculations.approximateSolution,
				calculations.GetxSteps,
				calculations.GettSteps
			);

			errors.CalculateRelativeError(calculations.exactSolution);

			Console.ReadKey();
		}
	}
}
