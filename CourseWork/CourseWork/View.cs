using System.IO;

namespace CourseWork
{
	class View
	{
		Calculations calculations;

		public View(Calculations calculations)
		{
			this.calculations = calculations;
		}
		public void Writer()
		{
			using (StreamWriter writer = new StreamWriter("C:/Users/brija/Desktop/1.txt"))
			{
				foreach(var number in calculations.appoximateSolution)
				{
					writer.Write(number+" ");
				}
			}
		}
	}
}
