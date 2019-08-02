using UnityEngine;

[CreateAssetMenu(fileName = "LvlSettings", menuName = "Level/Settings")]
public class LvlSettings : ScriptableObject
{
    public float[] Lvls { get => lvls; }
    public int MaxLvl { get => lvls.Length; }

    [Tooltip("Required expierience to reach next lvl")]
    [SerializeField] float[] lvls;
}