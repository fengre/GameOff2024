using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerData
{
    public static string playerName = "";
    public static HashSet<string> CollectedItems = new HashSet<string>();
    public static bool IsLensToggled = false;
    public static Vector3 LensPosition = Vector3.zero;
}
