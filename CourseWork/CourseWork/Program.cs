using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static System.Math;
namespace CourseWork
{
	class Program
	{
		static void Main(string[] args)
		{
			Calculations calculations = new Calculations();
			View view = new View();
			calculations.CalculateConsistent();
			calculations.CalculateParallel();
			Console.ReadKey();
		}
	}
}
