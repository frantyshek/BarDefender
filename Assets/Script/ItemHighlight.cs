using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHighlight : MonoBehaviour
{

    Color startColor;
    [SerializeField] Color hightlightColor;
    public Renderer[] childTrans;
    public List<Color> startcolors;

    private void Awake()
    {
        childTrans = GetComponentsInChildren<Renderer>(true);
        foreach(Renderer i in childTrans)
        {
            startcolors.Add(i.material.color);
        }
    }

    private void OnMouseEnter()
    {
        foreach(Renderer i in childTrans)
        {
            i.material.color = hightlightColor;
        }
    }

    private void OnMouseExit()
    {
        for(int i = 0; i < childTrans.Length; i++)
        {
            childTrans[i].material.color = startcolors[i];
        }
    }
}
