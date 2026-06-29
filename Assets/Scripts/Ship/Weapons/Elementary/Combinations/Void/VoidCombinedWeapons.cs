using System.Collections.Generic;
using UnityEngine;

public class VoidCombinedWeapons : MonoBehaviour
{
    [SerializeField] private ElementCombination[] elementCombinations;

    private Dictionary<Element, GameObject> elementDict;

    void Awake()
    {
        elementDict = new Dictionary<Element, GameObject>();

        foreach(ElementCombination elementCombination in elementCombinations)
        {
            elementDict.Add(elementCombination.GetElement(), elementCombination.GetCombinationPrefab());
        }
    }

    public GameObject GetCombinationPrefab(Element combination)
    {
        return elementDict.TryGetValue(combination, out GameObject prefab) ? prefab : null;
    }
}
