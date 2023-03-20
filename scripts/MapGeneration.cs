using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    private GameObject clone;
    // Start is called before the first frame update
    void Start()
    {
        int random = Random.Range(0, objects.Length);

        clone = Instantiate(objects[random], transform.position, Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
