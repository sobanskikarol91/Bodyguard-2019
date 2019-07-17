using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class PlatformManager
{
    public static InputManager GetInpuntDependsOnPlatform()
    {
        if (IsPC())
            return new PCInput();
        else if (IsMobile())
            return new MobileInput();
        else
            return null;
    }

    private static bool IsMobile()
    {
        return Application.platform == RuntimePlatform.Android ||
            Application.platform == RuntimePlatform.IPhonePlayer;
    }

    private static bool IsPC()
    {
        return Application.platform == RuntimePlatform.LinuxPlayer ||
            Application.platform == RuntimePlatform.WindowsPlayer;
    }
}