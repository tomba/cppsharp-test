using System;
using CppSharp;
using CppSharp.Generators;

namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length != 3)
			{
				Console.WriteLine("usage: cmd <header-path> <lib-path> <out-path>\n");
				return;
			}

			var p1 = System.IO.Path.GetFullPath(args[0]);
			var p2 = System.IO.Path.GetFullPath(args[1]);
			var p3 = System.IO.Path.GetFullPath(args[2]);

			Console.WriteLine("HeaderPath: {0}", p1);
			Console.WriteLine("LibPath: {0}", p2);
			Console.WriteLine("OutPath: {0}", p3);

			ConsoleDriver.Run(new MyLib(p1, p2, p3));
			Console.WriteLine("done");
		}
	}

	class MyLib : ILibrary
	{
		string m_headerPath;
		string m_libPath;
		string m_outPath;

		public MyLib(string headerPath, string libPath, string outPath)
		{
			m_headerPath = headerPath;
			m_libPath = libPath;
			m_outPath = outPath;
		}

		public void Setup(Driver driver)
		{
			var options = driver.Options;

			options.GeneratorKind = GeneratorKind.CSharp;
			options.LibraryName = "native";

			options.OutputDir = m_outPath;

			options.addLibraryDirs(m_libPath);
			options.Libraries.Add("libnative.so");

			options.addIncludeDirs(m_headerPath);
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
