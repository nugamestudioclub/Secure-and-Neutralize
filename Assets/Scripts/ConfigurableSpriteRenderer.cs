using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ConfigurableSpriteRenderer : MonoBehaviour
{
    [SerializeField]
    private Sprite[] texs;
    [SerializeField]
    private int selected;

    private Material mat;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        mat.SetTexture("_BaseColorMap", texs[selected].texture);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
