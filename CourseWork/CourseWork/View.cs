using System.IO;

namespace CourseWork
{
	class View
	{
		public void Writer(string path,double[,] solution)
		{
			using (StreamWriter writer = new StreamWriter(path))
			{
				writer.Write("{");
				for(int i=0;i<200;i++)
				{
					writer.Write("{");
					for (int j = 0; j < 10; j++)
					{
						writer.Write(solution[i,j]);
						if (j != 9)
							writer.Write(",");
					}
					writer.Write("}");
					if (i != 199)
						writer.Write(",");
				}
				writer.Write("}");
			}
		}
	}
}
