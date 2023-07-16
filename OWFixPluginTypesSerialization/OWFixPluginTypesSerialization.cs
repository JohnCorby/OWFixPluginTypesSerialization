using OWML.ModHelper;
using System.IO;

namespace OWFixPluginTypesSerialization;

public class OWFixPluginTypesSerialization : ModBehaviour
{
	private void OnApplicationQuit()
	{
		// disable bep by just deleting one of the three guys
		File.Delete(Path.Combine(ModHelper.OwmlConfig.GamePath, "doorstop_config.ini"));
	}
}
