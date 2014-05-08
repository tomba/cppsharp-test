using System;

class Program
{
	static void Main()
	{
		int sum;

		sum = native.native.addCpp(5, 6);
		Console.WriteLine(sum);

		sum = native.native.addC(5, 6);
		Console.WriteLine(sum);

		var ob = new native.TestClass();
		ob.set_values(5, 6);
		sum = ob.sum();
		Console.WriteLine(sum);
	}
}
