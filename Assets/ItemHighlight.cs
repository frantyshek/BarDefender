using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHighlight : MonoBehaviour
{

    Color startColor;
    [SerializeField] Color hightlightColor;
    Renderer ren;

    private void Awake()
    {
        ren = GetComponent<Renderer>();
    }

    private void OnMouseEnter()
    {
        startColor = ren.material.color;
        ren.material.color = hightlightColor;
    }

    private void OnMouseExit()
    {
        ren.material.color = startColor;
    }
}
