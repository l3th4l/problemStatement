using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{

    [SerializeField]
    float spawnDistance;
    [SerializeField]
    float spawnHeight;
    [SerializeField]
    float distanceVariation;
    [SerializeField]
    float heightvariation;
    [SerializeField]
    int platformBufferSize;
    [SerializeField]
    int extraPlatforms;
    [SerializeField]
    GameObject startingPlatform;

    public List<GameObject> platformBuffer;

    Vector3 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        platformBuffer = new List<GameObject>(platformBufferSize);
        initPlatforms();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void initPlatforms()
    {
        lastPos = startingPlatform.transform.position;
        for(int i = 0; i < platformBufferSize - extraPlatforms; i++)
        {
            Vector3 spawnPos = new Vector3(spawnDistance + Random.Range(-distanceVariation / 2, distanceVariation / 2), spawnHeight + Random.Range(-heightvariation / 2, heightvariation / 2));
            platformBuffer.Add(GameObject.Instantiate(startingPlatform, lastPos + spawnPos, startingPlatform.transform.rotation));
            lastPos += spawnPos;
        }
    }

    public void spawnPlatform()
    {
        Vector3 spawnPos = new Vector3(spawnDistance + Random.Range(-distanceVariation / 2, distanceVariation / 2), spawnHeight + Random.Range(-heightvariation / 2, heightvariation / 2));
        platformBuffer.Add(GameObject.Instantiate(startingPlatform, lastPos + spawnPos, startingPlatform.transform.rotation));
        lastPos += spawnPos;
        if(platformBuffer.Count >= platformBufferSize)
        {
            GameObject.Destroy(platformBuffer[0]);
            platformBuffer.RemoveAt(0);
        }
    }
}
