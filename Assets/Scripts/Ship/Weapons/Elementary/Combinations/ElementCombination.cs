using System;
using UnityEngine;

[Serializable]
public struct ElementCombination
{
    [SerializeField] private Element element;
    [SerializeField] private GameObject combinationPrefab;

    public Element GetElement() => element;
    public GameObject GetCombinationPrefab() => combinationPrefab;
}
