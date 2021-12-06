using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetNameGenerator : MonoBehaviour
{
    [SerializeField]
    ScriptableString suffixes;

    List<char> vowels = new List<char>(){ 'a', 'e', 'i', 'u', 'o'};
    List<char> consonants = new List<char>() { 'w', 'r', 't', 'p', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'v', 'b', 'n', 'm' };

    enum CharType
    {
        Vowel,
        Consonant
    }

    public string GenerateName
    {
        get
        {
            int len = Random.Range(3, 5);
            string name = consonants[Random.Range(0, consonants.Count - 1)].ToString().ToUpperInvariant();
            CharType last_letter = CharType.Consonant; //false - vowel   true - consonant
            bool second_consonant = false;
            for (int i = 0; i < len; i++)
            {
                if (last_letter == CharType.Consonant)
                {
                    int choice;

                    if (!second_consonant)
                        choice = Random.Range(0, 1); //0 - vowel   1 - consonant
                    else
                        choice = 0;

                    if (choice == 0)
                    {
                        name += vowels[Random.Range(0, vowels.Count - 1)];
                        second_consonant = false;
                        last_letter = CharType.Vowel;
                    }
                    else
                    {
                        name += consonants[Random.Range(0, consonants.Count - 1)];
                        second_consonant = true;
                        last_letter = CharType.Consonant;
                    }
                }
                else
                {
                    name += consonants[Random.Range(0, consonants.Count - 1)];
                    last_letter = CharType.Consonant;
                }
            }
            string suff = suffixes[Random.Range(0, suffixes.Symbols.Count - 1)];
            for (int i = 0; i < vowels.Count; i++)
                if (suff[0] == vowels[i])
                {
                    if (last_letter == CharType.Vowel)
                        name = name.Remove(name.Length - 1, 1);
                    break;
                }
            name += suff;
            return name;
        }
    }
    void Start()
    {
        //for (int i=0; i<50; i++)
        //    GenerateName();
    }

    void Update()
    {
        
    }
}
