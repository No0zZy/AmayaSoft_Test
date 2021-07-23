using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item", order = 51)]
public class Item : ScriptableObject
{
    [SerializeField] private string value;
    public string Value => value;
    [SerializeField] private Sprite sprite;
    public Sprite Sprite => sprite;
}