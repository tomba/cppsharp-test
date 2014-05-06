using System;
using CppSharp;
using CppSharp.Generators;

namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{
			ConsoleDriver.Run(new MyLib());
			Console.WriteLine("done");
		}
	}

	class MyLib : ILibrary
	{
		public void Setup(Driver driver)
		{
			var options = driver.Options;

			options.GeneratorKind = GeneratorKind.CSharp;
			options.LibraryName = "native";

			options.OutputDir = "./";

			options.addLibraryDirs("./");
			options.Libraries.Add("libnative.so");

			options.addIncludeDirs("./");
			options.Headers.Add("native.h");

		}

		public void SetupPasses(Driver driver)
		{
		}

		public void Preprocess(Driver driver, CppSharp.AST.ASTContext ctx)
		{
		}

		public void Postprocess(Driver driver, CppSharp.AST.ASTContext lib)
		{
		}
	}
}
