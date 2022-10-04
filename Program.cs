using System;

namespace FontStashSharpTest
{
	public static class Program
	{
		[STAThread]
		static void Main()
		{
			using (var game = new FontStashSharpTest())
				game.Run();
		}
	}
}