using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHighlight : MonoBehaviour
{

    Color startColor;
    [SerializeField] Color hightlightColor;
    Transform[] childTrans;
    List<Color> startcolors;

    private void Awake()
    {
        childTrans = GetComponentsInChildren<Transform>();
    }

    private void OnMouseEnter()
    {
        foreach(Transform i in childTrans)
        {
            startcolors.Add(i.GetComponent<Renderer>().material.color);
            i.GetComponent<Renderer>().material.color = hightlightColor;
        }
    }

    private void OnMouseExit()
    {
        for(int i = 0; i <= childTrans.Length; i++)
        {
            childTrans[i].GetComponent<Renderer>().material.color = startcolors[i];
        }
    }
}
