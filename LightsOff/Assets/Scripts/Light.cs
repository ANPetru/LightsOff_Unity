using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour {

    public bool isOn = false;
    HashSet<Light> neighbours = new HashSet<Light>();



    private void Update()
    {
        if (isOn)
        {
            GetComponent<Renderer>().material.color = Color.white;
        } else
        {
            GetComponent<Renderer>().material.color = Color.black;
        }
    }

    public void AddNeighbour(Light l)
    {
        if (l != null)
        {
            neighbours.Add(l);
        }
    }

    

    private void OnMouseDown()
    {
        ChangeLight();
        foreach (Light l in neighbours)
        {
            l.ChangeLight();
        }
    }

    public void ChangeLight()
    {
        isOn=(isOn)?false:true;
    }
}
