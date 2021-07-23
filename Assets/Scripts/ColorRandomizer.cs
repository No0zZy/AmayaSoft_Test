using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ColorRandomizer : MonoBehaviour
{
    [Range(0, 1)] [SerializeField] private float hueMin;
    [Range(0, 1)] [SerializeField] private float hueMax;
    [Range(0, 1)] [SerializeField] private float saturationMin;
    [Range(0, 1)] [SerializeField] private float saturationMax;
    [Range(0, 1)] [SerializeField] private float valueMin;
    [Range(0, 1)] [SerializeField] private float valueMax;

    [SerializeField] private bool randomizeOnAwake;

    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();

        if (randomizeOnAwake)
            NewColor();
    }

    public void NewColor()
    {
        image.color = Random.ColorHSV(hueMin, hueMax, saturationMin, saturationMax, valueMin, valueMax, 1f, 1f);
    }
}
