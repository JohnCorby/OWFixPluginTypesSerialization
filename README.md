# OWFixPluginTypesSerialization

A port of https://github.com/xiaoxiao921/FixPluginTypesSerialization for Outer Wilds

## What it does

This mod does nothing to the game. Instead, it patches the native UnityPlayer.dll in order to fix a bug where `[Serializable]` classes/structs in mod DLLs don't get deserialized properly.

## Disabling/Uninstalling

This mod installs BepInEx in order to function. In addition to disabling/uninstalling the mod in the manager, you must delete any (or all) of these three files/folders in the game directory.

![image](https://user-images.githubusercontent.com/26337121/213887298-389581bb-b3e7-47a9-9d9d-562e0dd451ac.png)

## Making it work on Linux

Add this launch option lol

![image](https://github.com/JohnCorby/OWFixPluginTypesSerialization/assets/26337121/55f1ce55-0ac4-4074-9210-9aa7e3988a1e)
