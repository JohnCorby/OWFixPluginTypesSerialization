# OWFixPluginTypesSerialization

A port of https://github.com/xiaoxiao921/FixPluginTypesSerialization for Outer Wilds

## What it does

This mod does nothing to the game. Instead, it patches the native UnityPlayer.dll in order to fix a bug where `[Serializable]` classes/structs in mod DLLs don't get deserialized properly.

## Linux support

Add this launch option lol

```
WINEDLLOVERRIDES="winhttp=n,b" %command%
```

![image](https://github.com/JohnCorby/OWFixPluginTypesSerialization/assets/26337121/55f1ce55-0ac4-4074-9210-9aa7e3988a1e)
