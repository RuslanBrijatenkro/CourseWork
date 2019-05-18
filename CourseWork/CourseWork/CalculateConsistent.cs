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
		}
	}
}
