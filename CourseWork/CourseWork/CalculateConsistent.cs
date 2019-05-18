using System;
using System.Collections.Generic;
using System.Text;

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
			view.Writer("C:/Users/brija/Desktop/1.txt", exactSolution);
			view.Writer("C:/Users/brija/Desktop/2.txt", appoximateSolution);
		}
	}
}
