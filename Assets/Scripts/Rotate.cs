using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    [SerializeField] private GameObject coin;
    [SerializeField] private float rotationSpeed = 10f;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
       
        coin.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
