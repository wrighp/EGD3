using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "NewObjectTags", menuName = "ScriptableObjects/ObjectTags", order = 1)]
public class ObjectTags : ScriptableObject
{
    public List<Tags> tags = new List<Tags>();
    public List<Requirement> friendRequirements = new List<Requirement>();
}

[System.Serializable]
public class Requirement
{
    public Tags requirement;
    public int quantity;
    public int remaining;
}

public enum Tags { Plant, Water, Garbage, Food, Mail, Other };