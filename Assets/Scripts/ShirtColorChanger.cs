using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShirtColorChanger : MonoBehaviour
{
    public static List<ShirtColorChanger> allshirts = new List<ShirtColorChanger>();
    public MeshRenderer meshRenderer;

    private void Start()
    {
        allshirts.Add(this);
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        changeShirtColor("0,0,0");
    }
    public void changeShirtColor(Color min, Color max)
    {
        Color newColor = new Color(Random.Range(min.r,max.r), Random.Range(min.g, max.g), Random.Range(min.b, max.b), 1);
    }

    public void changeShirtColor(Vector2 Red, Vector2 Green, Vector2 Blue)
    {
        Color newColor = new Color(Random.Range(Red.x,Red.y),Random.Range(Green.x,Green.y),Random.Range(Blue.x,Blue.y),1);
    }

    public void shirt(Color c)
    {
        Material[] mats = new Material[2];
        mats[1] = meshRenderer.materials[1];
        Material edit = meshRenderer.materials[0];
        edit.color = c;
        mats[0] = edit;
        meshRenderer.sharedMaterials = mats;
    }


    public void changeShirtColor(string readme)
    {
        string[] parsing = readme.Split(',');
        float r = float.Parse(parsing[0]);
        float g = float.Parse(parsing[1]);
        float b = float.Parse(parsing[2]);

        shirt(new Color(r,g,b,1));
    }

    public static void ChangeAllShirtsToColor(string readme)
    {
        foreach(ShirtColorChanger shirt in allshirts)
        {
            shirt.changeShirtColor(readme);
        }
    }

}
