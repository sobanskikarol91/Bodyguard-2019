using UnityEngine;

[CreateAssetMenu(fileName = "PlatformManager", menuName = "Platform/Settings")]
public class PlatformManager : ScriptableObject
{
    [SerializeField] MobileInput mobile;
    [SerializeField] PCInput pc;


    public PlayerInput GetPlayerInputDependsOnPlatform()
    {
        if (IsPC())
            return pc;
        else
            return mobile;
    }


    private static bool IsPC()
    {
        return Application.platform == RuntimePlatform.LinuxPlayer ||
            Application.platform == RuntimePlatform.WindowsPlayer ||
            Application.platform == RuntimePlatform.WindowsEditor;
    }
}