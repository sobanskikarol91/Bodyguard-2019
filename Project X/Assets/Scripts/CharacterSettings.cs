using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "Settings/Character", fileName = "Settings")]
public class CharacterSettings : ScriptableObject
{
    [SerializeField] float horizontalSpeed = 10;
    [SerializeField] float verticalSpeed = 10f;
    [SerializeField] bool useAi = true;

    public Vector2 Speed { get { return new Vector2(horizontalSpeed, verticalSpeed); } }
    public bool UseAi { get { return useAi; } }
}