using System.Collections;
using UnityEngine;

public static class Vibration {
    public static AndroidJavaClass unityPlayer;
    public static AndroidJavaObject currentActivity;
    public static AndroidJavaObject vibrator;

    public static bool IsAndroid() {
        try {
#if UNITY_ANDROID
            using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
                using (AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {
                    vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
                }
            }
            return true;
#else
        return false;
#endif
        }
        catch {
            Debug.LogWarning("It is simulator, not Android.");
            return false;
        }
    }

    /// 

    /// �_��
    /// 
    public static void Vibrate() {
        if (IsAndroid())
            vibrator.Call("vibrate");
        else
            Handheld.Vibrate();
    }

    /// 

    /// �_��(�@��)
    /// 
    /// 
    public static void Vibrate(long milliseconds) {
        if (IsAndroid())
            vibrator.Call("vibrate", milliseconds);
        else
            Handheld.Vibrate();
    }

    /// 

    /// �Ҧ��_��
    /// ����
    /// 
    /// 
    /// 
    public static void Vibrate(long[] pattern, int repeat) {
        if (IsAndroid())
            vibrator.Call("vibrate", pattern, repeat);
        else
            Handheld.Vibrate();
    }

    /// 

    /// �P�_�O�_�_�ʾ�
    /// 
    /// 
    public static bool HasVibrator() {
        return IsAndroid();
    }

    /// 

    /// ����
    /// 
    public static void Cancel() {
        if (IsAndroid())
            vibrator.Call("cancel");
    }
}