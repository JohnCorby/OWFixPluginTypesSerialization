using System;
using System.IO;

namespace Patcher;

public static class Patcher
{
	//Called by OWML
	public static void Main(string[] args)
	{
		var basePath = args.Length > 0 ? args[0] : ".";
		var gamePath = AppDomain.CurrentDomain.BaseDirectory;
		var managedPath = Path.Combine(gamePath, GetDataPath(gamePath), "Managed");

		// TODO: delete all the existing bep stuff just in case user still has old version

		// have to delete this owml dll so as to not conflict with a bepinex one of the same name
		File.Delete(Path.Combine(managedPath, "MonoMod.Utils.dll"));

		// copy over the right bep stuff to the game folder
		CopyGameFiles(gamePath, Path.Combine(basePath, "ToCopy"));

		// TODO: edit the config to point to the right file in our mod folder
	}

	private static string GetExecutableName(string gamePath)
	{
		var executableNames = new[] { "Outer Wilds.exe", "OuterWilds.exe" };
		foreach (var executableName in executableNames)
		{
			var executablePath = Path.Combine(gamePath, executableName);
			if (File.Exists(executablePath))
			{
				return Path.GetFileNameWithoutExtension(executablePath);
			}
		}

		throw new FileNotFoundException($"Outer Wilds exe file not found in {gamePath}");
	}

	private static string GetDataDirectoryName()
	{
		var gamePath = AppDomain.CurrentDomain.BaseDirectory;
		return $"{GetExecutableName(gamePath)}_Data";
	}

	private static string GetDataPath(string gamePath)
	{
		return Path.Combine(gamePath, $"{GetDataDirectoryName()}");
	}

	private static void CopyGameFiles(string gamePath, string filesPath)
	{
		// Get the subdirectories for the specified directory.
		var dir = new DirectoryInfo(filesPath);

		if (!dir.Exists)
		{
			throw new DirectoryNotFoundException(
				"Source directory does not exist or could not be found: "
				+ filesPath);
		}

		var dirs = dir.GetDirectories();

		// If the destination directory doesn't exist, create it.
		Directory.CreateDirectory(gamePath);

		// Get the files in the directory and copy them to the new location.
		var files = dir.GetFiles();
		foreach (var file in files)
		{
			var tempPath = Path.Combine(gamePath, file.Name);
			file.CopyTo(tempPath, true);
		}

		foreach (var subdir in dirs)
		{
			var tempPath = Path.Combine(gamePath, subdir.Name);
			CopyGameFiles(tempPath.Replace("OuterWilds_Data", GetDataDirectoryName()), subdir.FullName);
		}
	}
}
