using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemDrop;

    // Start is called before the first frame update
    void Start()
    {
        Generate();
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Generate()
    {
        ItemType item = (ItemType)Random.Range(0, 1);
        GameObject spawned = Instantiate(itemDrop, transform.position, transform.rotation) as GameObject;
        spawned.GetComponent<Interactable>().SetType(item);
    }
}
