using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MudarCorCarro : MonoBehaviour
{
    [SerializeField] GameObject[] carModelMaterial; // Array de GameObjects
    [SerializeField] Slider r;
    [SerializeField] Slider g;
    [SerializeField] Slider b;

    [SerializeField] Color color;
    List<Material> materials = new List<Material>();

    void Start()
    {
        carModelMaterial = GameObject.FindGameObjectsWithTag("CorCaro");

        if (carModelMaterial.Length == 0)
        {
            return;
        }

        foreach (var model in carModelMaterial)
        {
            Renderer renderer = model.GetComponent<Renderer>();
            if (renderer != null)
            {
                materials.Add(renderer.material); 
            }

        }
    }

    void Update()
    {
        if (materials.Count == 0) return;

        color = new Color(r.value, g.value, b.value);

        foreach (var mat in materials)
        {
            mat.color = color;
        }
    }
}
