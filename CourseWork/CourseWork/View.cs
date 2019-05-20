using System.IO;

namespace CourseWork
{
	class View
	{
		string path;
		Calculations calculations;
		public View(Calculations calculations, string path)
		{
			this.path = path;
			this.calculations = calculations;
		}

		public void WriteResults()
		{
			NewFile();
			AddArray(calculations.exactSolution, "a");
			AddArray(calculations.approximateSolution, "b");
			AddListPlot3D();
		}
		void NewFile()
		{
			using (StreamWriter writer = new StreamWriter(path))
			{
				writer.Write("");
			}
		}
		void AddArray(double[,] solution, string name)
		{
			using (StreamWriter writer = new StreamWriter(path, true))
			{
				writer.Write(writer.NewLine);
				writer.Write($"{name} = " + "{");
				for (int i = 0; i < calculations.GettSteps; i++)
				{
					writer.Write("{");
					for (int j = 0; j < calculations.GetxSteps; j++)
					{
						writer.Write(solution[i, j]);
						if (j != calculations.GetxSteps - 1)
							writer.Write(",");
					}
					writer.Write("}");
					if (i != calculations.GettSteps - 1)
						writer.Write(",");
				}
				writer.Write("};");
			}
		}
		void AddListPlot3D()
		{
			using (StreamWriter writer = new StreamWriter(path, true))
			{
				writer.Write(writer.NewLine);
				writer.Write("ListPlot3D[{a,b},PlotStyle->{Red,Green},ImageSize->Full]");
			}
		}
	}
}
