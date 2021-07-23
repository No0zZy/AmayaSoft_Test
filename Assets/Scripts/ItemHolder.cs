using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHolder : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    public Transform ItemTransform => itemImage.transform;
    private Item item;
    public string Value => item.Value;
    public void SetItem(Item newItem)
    {
        item = newItem;
        itemImage.sprite = newItem.Sprite;
    }
}