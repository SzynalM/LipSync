﻿using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace AudioConverter
{
	public class AsyncConveter
	{
		private const int outRate = 16000; 

		public async Task ConvertFiles(List<Tuple<string, string>> pathTuples)
		{
			List<Task> tasks = new List<Task>();
			foreach (var tuple in pathTuples)
			{
				var task = CreateConvertTask(tuple.Item1, tuple.Item2);
				task.Start();
			}
			await Task.WhenAll(tasks);
		}

		private Task CreateConvertTask(string inPath, string outPath)
		{
			return new Task(() =>
			{
				using (var reader = new AudioFileReader(inPath))
				{
					var forcedStereo = reader.ToStereo();
					var mono = new StereoToMonoSampleProvider(forcedStereo);
					var resampler = new WdlResamplingSampleProvider(mono, outRate);
					WaveFileWriter.CreateWaveFile16(outPath, resampler);
				}
			});
		}
	}
}