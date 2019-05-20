using System;
using System.Diagnostics;

namespace CourseWork
{
	class Timer
	{
		Stopwatch stopwatch = new Stopwatch();
		public long StartWork(Action action)
		{
			stopwatch.Reset();
			stopwatch.Start();
			action();
			stopwatch.Stop();
			return stopwatch.ElapsedMilliseconds;
		}
	}
}
