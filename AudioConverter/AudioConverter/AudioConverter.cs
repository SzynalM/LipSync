﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AudioConverter
{
	public class Program
	{ //arguments orignal, target, original2, target2 etc.

		public async Task Convert(string[] args)
		{
			HandleArgumentExceptions(args);

			List<StringTuple> pathTuples = GetPathTuples(args);

			Stopwatch stopWatch = new Stopwatch();
			stopWatch.Start();

			await new AsyncConveter().ConvertFiles(pathTuples);

			stopWatch.Stop();
			Console.WriteLine(stopWatch.ElapsedMilliseconds);
			Console.ReadLine();
		}

		private static void HandleArgumentExceptions(string[] args)
		{
			if (args.Length == 0)
			{
				throw new ArgumentException("No paths specified");
			}
			if (args.Length % 2 != 0)
			{
				throw new ArgumentException("Not even number of arguments, some file may not have an output path");
			}
		}

		private static List<StringTuple> GetPathTuples(string[] args)
		{
			List<StringTuple> result = new List<StringTuple>();
			for (int i = 0; i < args.Length; i += 2)
			{
				var newTuple = new StringTuple(args[i], args[i + 1]);
				result.Add(newTuple);
			}
			return result;
		}
	}
}