using OWML.Common;
using OWML.ModHelper;

namespace OWFixPluginTypesSerialization;

public class OWFixPluginTypesSerialization : ModBehaviour
{
	private void Start()
	{
		ModHelper.Console.WriteLine("This mod now removes BepInEx, since it had the chance to brick the game even after verifying game files. It will be removed from the mod db at some point.", MessageType.Error);
	}
}
