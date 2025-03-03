using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MudarCorCarro : MonoBehaviour
{
    [SerializeField] Material material;
    [SerializeField] Slider r;
    [SerializeField] Slider g;
    [SerializeField] Slider b;

    [SerializeField] Color color;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        color = new Color(r.value, g.value, b.value);

        material.color = color;

        Debug.Log(r.value);
    }
}
