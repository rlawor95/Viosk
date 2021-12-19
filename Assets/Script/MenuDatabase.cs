using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MenuDatabase : ScriptableObject
{
    [System.Serializable]
    public class Category
    {
        public string CategoryName;
        public DBEntry[] MenuArray;
    }

    [System.Serializable]
    public class DBEntry
    {
        public Sprite bigSprite;
        public Sprite smallSprite;
        public string Name;
        public int Price;
    }

    public Category[] MenuCategory;
}
