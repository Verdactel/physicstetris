using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePoint : MonoBehaviour
{
    public THEGAME script;
    public List<GameObject> gameobjects = new List<GameObject>();
    public List<GameObject> destroyedObjects = new List<GameObject>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            gameobjects.Clear();
            destroyedObjects.Clear();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Point")
        {
            gameobjects.Add(other.gameObject);
        }
        while(gameobjects.Count > 18)
        {
            int i = 0;
            destroyedObjects.Add(gameobjects[i]);
            gameobjects.Remove(gameobjects[i]);
            i++;
        }
        foreach(GameObject go in destroyedObjects)
        {
            Destroy(go.gameObject);
            script.score += 10;
        }
        destroyedObjects.Clear();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Point")
        {
            gameobjects.Remove(other.gameObject);
        }
    }
}
