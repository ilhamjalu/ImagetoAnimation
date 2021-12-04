using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildMaterial : MonoBehaviour
{
    public MeshRenderer parent, child;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        child.material = parent.material;
    }
}
