using UnityEngine;

[CreateAssetMenu(fileName = "PlatformManager", menuName = "Platform/Settings")]
public class PlatformManager : ScriptableObject
{
    [SerializeField] MobileInput mobile;
    [SerializeField] PCInput pc;


    public InputManager GetInpuntDependsOnPlatform()
    {
        return mobile;
        //if (IsPC())
        //    return new PCInput();
        //else if (IsMobile())
        //    return new MobileInput();
        //else
        //    return null;
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