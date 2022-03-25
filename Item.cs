using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory Item")]
public class Item : ScriptableObject
{
    public string displayName;
    public Sprite icon;
    public GameObject prefab;
    private bool discovered = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //effect of Object
    void effect()
    {

    }

    Sprite getIcon()
    {
        return icon;
    }
}
