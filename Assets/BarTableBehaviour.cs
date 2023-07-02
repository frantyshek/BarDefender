using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarTableBehaviour : MonoBehaviour
{

    [SerializeField] List<Recipes> recipes;

    public List<Recipes> GetRecipes() { return recipes; }

}
