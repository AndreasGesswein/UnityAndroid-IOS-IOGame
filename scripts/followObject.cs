using UnityEngine;
public class followObject : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 offset;

    void Start()
    {
       offset = transform.position - target.position;
    }
    void FixedUpdate()
    {

        transform.position = target.position + offset;
    }
}



