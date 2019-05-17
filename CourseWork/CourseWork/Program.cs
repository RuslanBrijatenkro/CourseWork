using System;
using System.Threading.Tasks;
using static System.Math;
namespace CourseWork
{
	class Program
	{
		static void Main(string[] args)
		{
			Start start = new Start();
			start.Run();
			Console.ReadKey();
		}
	}
	partial class Calculations
	{
		double x = 0;
		double t = 0;
		static int xSteps = 10;
		static int tSteps = 200;
		Solutions solutions = new Solutions();
		double[,] exactSolution = new double[tSteps, xSteps];
		double[,] appoximateSolution = new double[tSteps, xSteps];
	}
	partial class Calculations
	{
		public void ConsistentCalculation()
		{
			for (int k = 0; k < tSteps; k++)
			{
				x = 0d;
				for (int i = 0; i < xSteps; i++)
				{
					exactSolution[k, i] = solutions.GetExactSolution(x, t);
					x += 1d / xSteps;
				}
				t += 1d / tSteps;
			}
			x = 0d;
			for (int i = 0; i < xSteps; i++)
			{
				appoximateSolution[0, i] = solutions.GetExactSolution(x, 0);
				x += 1d / xSteps;
			}
			t = 0d;
			for (int i = 0; i < tSteps; i++)
			{
				appoximateSolution[i, 0] = solutions.GetExactSolution(0, t);
				appoximateSolution[i, xSteps - 1] = solutions.GetExactSolution(1, t);
				t += 1d / tSteps;
			}
			for (int k = 1; k < tSteps; k++)
			{
				for (int i = 1; i < xSteps - 1; i++)
				{
					appoximateSolution[k, i] = solutions.GetApproximateResolution(
						appoximateSolution[k - 1, i - 1],
						appoximateSolution[k - 1, i + 1],
						appoximateSolution[k - 1, i],
						1d / xSteps,
						1d / tSteps
					);
					if (appoximateSolution[k, i] - exactSolution[k, i] > 0.01d)
						Console.WriteLine($"{k}:{i}" + false);
				}
			}
			Console.WriteLine();
		}
	}
	partial class Calculations
	{
		public void ParallelCalculating()
		{
			for (int k = 0; k < tSteps; k++)
			{
				x = 0d;
				for (int i = 0; i < xSteps; i++)
				{
					exactSolution[k, i] = solutions.GetExactSolution(x, t);
					x += 1d / xSteps;
				}
				t += 1d / tSteps;
			}
		}
	}
	class Start
	{
		public void Run()
		{
			Calculations calculations = new Calculations();
			calculations.ConsistentCalculation();
			Console.WriteLine();
		}
	}
	class Solutions
	{
		double a = 1;
		double b = 1;
		double c = 1;
		double C = 1;

		public double GetExactSolution(double x, double t)
		{
			return b * (1d / (1 + C * Exp((1d / 2) * Sqrt(2 * a) * b * x + (1d / 2) * a * b * (2d * c - b) * t)));
		}
		public double GetApproximateResolution(double wPrev,double wNext, double wCurrent,double h,double tau)
		{
			return wCurrent + (tau * (wPrev - 2d * wCurrent + wNext) - tau * Pow(h, 2) * wCurrent * (1 - wCurrent) * (2 - wCurrent))/Pow(h,2);
		}
	}
}
