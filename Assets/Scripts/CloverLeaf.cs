using System;
using UnityEngine;

public class CloverLeaf : MonoBehaviour, ICollection
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static event Action<int> OnCloverCollect;
        public void Collect()
    {
        OnCloverCollect?.Invoke(1);
        Destroy(gameObject);
    }
}
