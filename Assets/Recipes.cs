using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Recipes : ScriptableObject
{
    [SerializeField] List<Item> ingredients;
    [SerializeField] Item finalItem;

    public List<Item> GetIngredients() { return ingredients; }
    public Item GetFinalItem() { return finalItem; }

}
