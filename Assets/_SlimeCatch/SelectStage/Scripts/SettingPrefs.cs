using UnityEngine;

public class SettingPrefs : MonoBehaviour
{
    public static bool GetBool(string key, bool defalutValue)
    {
        var value = PlayerPrefs.GetInt(key, defalutValue ? 1 : 0);
        return value == 1;
    }

    public static bool IsClearStage(string stageName)
    {
        var value = PlayerPrefs.GetInt(stageName);
        return value != 0;
    }

    public static void SetBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
    }
}
