using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ScriptableString")]
public class ScriptableString : ScriptableObject
{
    [SerializeField] 
    List<string> symbols = new List<string>();

    public List<string> Symbols
    {
        get { return symbols; }
    }

    public string this[int i]
    {
        get 
        {
            if (i < 0 && i >= symbols.Count)
                return "";

            return symbols[i]; 
        }
    }
}
