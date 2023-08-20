using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Egg", menuName = "ScriptableObjects/New Egg", order = 1)]
public class EggScriptable : ScriptableObject
{
    [Header("GENERAL")]
    [Tooltip("Egg name.")]
    public string EggName;
    [Tooltip("Egg GameObject.")]
    public GameObject PhysicalEgg;
    [Tooltip("How many seconds it takes to hatch.")]
    [Header("STATS")]
    [Range(0, 1000)]
    public float HatchTime = 120f;
    [Tooltip("The animal it will hatch.")]
    public AnimalScriptable Animal;
    [Range(0, 1000)]
    public float Rarity = 350;
}
