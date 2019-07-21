﻿using UnityEngine;

[CreateAssetMenu(fileName = "PlatformManager", menuName = "Platform/Settings")]
public class PlatformManager : ScriptableObject
{
    [SerializeField] static MobileInput mobile;
    [SerializeField] static PCInput pc;


    public static InputManager GetPlayerInputDependsOnPlatform()
    {
        return pc; 
        if (IsPC())
            return pc;
        else if (IsMobile())
            return mobile;
        else
           return mobile;
    }

    private static bool IsMobile()
    {
        return Application.platform == RuntimePlatform.Android ||
            Application.platform == RuntimePlatform.IPhonePlayer;
    }

    private static bool IsPC()
    {
        return Application.platform == RuntimePlatform.LinuxPlayer ||
            Application.platform == RuntimePlatform.WindowsPlayer ||
            Application.platform == RuntimePlatform.WindowsEditor;
    }
}