using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level : MonoBehaviour {

    public List<GameObject> prefabs = new List<GameObject>();               //  The different level pieces

    // Lists for Recycling objects
    public List<GameObject> unloadedObjects = new List<GameObject>();       //  Unloaded objects
    public List<GameObject> loadedObjects = new List<GameObject>();         //  Loaded objects

    //Initial values
    public int objectsLoadedAtStart = 30;                                    //  How many level pieces are spawned in at the beginning.
    public int prefabsToPreLoad = 10;                                       //  How many of each prefab type to load in.
    public float offsetX = 5.0f;                                            //  Offset between the pieces on the x-axis.

    //Store the position of the last object loaded for reference.
    private Vector3 lastObjectLoadedAt = Vector3.zero;
    private GameObject lastPrefabLoaded;

    public Vector3 LastObjectLoadedAt
    {
        get { return lastObjectLoadedAt; }
    }

    void Awake()
    {
        //Preload all the prefabs.
        for (int i = 0; i < prefabs.Count; i++)
        {
            for (int ii = 0; ii < prefabsToPreLoad; ii++ )
            {
                GameObject prefab = Instantiate(prefabs[i], Vector3.zero, Quaternion.identity) as GameObject;
                unloadedObjects.Add(prefab);
                prefab.SetActive(false);
            }

        }

        //Do some shufflin' to add extra randomization.
        for (int i = 0; i < 5; i++)
        {
            unloadedObjects.Shuffle<GameObject>();
        }
    }

    void Start() 
    {
        //Load the initial level
        for (int i = 0; i < objectsLoadedAtStart; i++)
        {
            //Generate a random number
            int random = Random.Range(0, unloadedObjects.Count);
            
            //Grab one of the unloaded level pieces.
            GameObject obj = unloadedObjects[random];

            //Set new position for said object
            Vector3 objPosition = new Vector3(i * offsetX, 0f, 0f);
            obj.transform.position = objPosition;

            //Activate piece
            obj.gameObject.SetActive(true);

            unloadedObjects.Remove(obj);
            loadedObjects.Add(obj);

            if (i == objectsLoadedAtStart - 1)
            {
                lastObjectLoadedAt = obj.transform.position;
            }
        }

        DepressionManager.Depress(60);
	}

    public void AddPiece()
    {
        int random = Random.Range(0, unloadedObjects.Count);
        GameObject nextPiece;
        nextPiece = unloadedObjects[random].gameObject;

        if (lastPrefabLoaded != null)
        {
            if (nextPiece.gameObject.tag == lastPrefabLoaded.gameObject.tag)
            {
                Debug.LogError("Skipping duplicate");
                random = Random.Range(0, unloadedObjects.Count);
                nextPiece = unloadedObjects[random].gameObject;
            }
        }

        Vector3 nextPosition = lastObjectLoadedAt;
        nextPosition.x += offsetX;
        nextPiece.transform.position = nextPosition;
        nextPiece.SetActive(true);
        unloadedObjects.Remove(nextPiece);
        loadedObjects.Add(nextPiece);

        lastObjectLoadedAt = nextPosition;
        lastPrefabLoaded = nextPiece;
    }

    public void RemovePiece()
    {
        GameObject objectToRemove = loadedObjects[0].gameObject;
        objectToRemove.SetActive(false);
        loadedObjects.Remove(objectToRemove);
        unloadedObjects.Add(objectToRemove);
        
    }

    // Update is called once per frame
    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            
            DepressionManager.Depress(10);
        }
	}
}
