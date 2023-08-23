using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Animal", menuName = "ScriptableObjects/New Animal")]
public class AnimalScriptable : ScriptableObject
{
    [Header("GENERAL")]
    [Tooltip("Animal name.")]
    public string Name;
    [Tooltip("Animal picture shown on UI etc.")]
    public Sprite Icon;
    [Tooltip("Animal GameObject.")]
    public GameObject PhysicalAnimal;
    [TextArea]
    [Tooltip("Animal description.")]
    public string Description;
    [Header("STATS")]
    [Range(0, 100)]
    public float Power;
    [Range(0, 20)]
    public float Speed;
    [Range(0, 100)]
    public float Flight;
    [Range(0, 100)]
    public float Energy;
    [Range(0, 100)]
    public float Intelligence;
    [Header("GRADING")]
    [Tooltip("Animal tier used for battles and knowledge etc.")]
    public GradeEnum Tier;
    public enum GradeEnum { A, B, C, D, S, SS, SSS};

}
