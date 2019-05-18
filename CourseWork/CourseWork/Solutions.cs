using static System.Math;

namespace CourseWork
{
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
		public double GetApproximateSolution(double wPrev, double wNext, double wCurrent, double h, double tau)
		{
			return wCurrent + (tau * (wPrev - 2d * wCurrent + wNext) - tau * Pow(h, 2) * wCurrent * (1 - wCurrent) * (2 - wCurrent)) / Pow(h, 2);
		}
	}
}
