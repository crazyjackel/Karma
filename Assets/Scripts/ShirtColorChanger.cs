using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShirtColorChanger : MonoBehaviour
{
    public MeshRenderer meshRenderer;

    public Color shirtColor;

    private void Start()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        changeShirtColor();
    }
    public void changeShirtColor(Color min, Color max)
    {
        Color newColor = new Color(Random.Range(min.r,max.r), Random.Range(min.g, max.g), Random.Range(min.b, max.b), 1);
    }

    public void changeShirtColor(Vector2 Red, Vector2 Green, Vector2 Blue)
    {
        Color newColor = new Color(Random.Range(Red.x,Red.y),Random.Range(Green.x,Green.y),Random.Range(Blue.x,Blue.y),1);
    }

    public void changeShirtColor(Color c)
    {
        Material[] mats = new Material[2];
        mats[1] = meshRenderer.materials[1];
        Material edit = meshRenderer.materials[0];
        edit.color = c;
        mats[0] = edit;
        meshRenderer.sharedMaterials = mats;
    }

    public void changeShirtColor()
    {
        changeShirtColor(shirtColor);
    }
}
