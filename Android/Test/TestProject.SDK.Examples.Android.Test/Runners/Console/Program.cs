﻿using System.Reflection;
using TestProject.SDK.Examples.Android.Test;

namespace TestProject.SDK.Examples.Android.Runners.Console
{
	class Program
	{
		public static string DevToken = "YOUR_DEV_TOKEN";
		public static string DeviceUDID = "DEVICE_UDID";
		public static string PackageName = "io.testproject.demo";
		public static string ActivityName = ".MainActivity";

		static void Main(string[] args)
		{
			using (Runner runner = new RunnerBuilder(DevToken).AsAndroid(DeviceUDID, PackageName, ActivityName).Build())
			{
				runner.Run(new BasicTest());
				runner.Run(new ExtendedTest(), true);

				/**
				* Load proxy assembly into memory to allow SDK finding it's classes
				* This is only required when running the action proxy in Debug mode via IDE 
				* This not not needed when running from TestProject platform
				*/
				Assembly.LoadFrom("AddonProxy.dll");
				runner.Run(new ProxyTest(), true);
			}
		}
	}
}