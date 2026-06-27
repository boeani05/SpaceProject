using System;
using UnityEngine;

[Serializable]
public struct ElementMultiplier
{
    [SerializeField] private float multiplier;

    [SerializeField] private Element element;

    public float GetMultiplier() => multiplier;
    public Element GetElement() => element;
}
