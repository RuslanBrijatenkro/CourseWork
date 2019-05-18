using System;
using System.Diagnostics;
namespace CourseWork
{
	class Program
	{
		static Stopwatch stopwatch = new Stopwatch();
		static void Main(string[] args)
		{
			double absoluteError;
			double relativeError;
			Errors errors = new Errors();
			Calculations calculations = new Calculations();
			View view = new View();
			stopwatch.Start();
			calculations.CalculateConsistent();
			stopwatch.Stop();
			Console.WriteLine("Consistent: "+stopwatch.ElapsedMilliseconds);
			stopwatch.Reset();
			calculations.CalculateParallel();
			absoluteError=errors.CalculateAbsoluteError(calculations.exactSolution, 
													    calculations.appoximateSolution, 
													    calculations.GetxSteps, 
													    calculations.GettSteps);
			relativeError = errors.CalculateRelativeError(calculations.exactSolution);
			Console.WriteLine(absoluteError);
			Console.WriteLine(relativeError);
			Console.ReadKey();
		}
	}
}
