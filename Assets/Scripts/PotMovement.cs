using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        destinationRotation = gameObject.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        HandlePotMovement();
    }


    private Quaternion destinationRotation;
    void HandlePotMovement()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            destinationRotation = Quaternion.Euler(new Vector3(0, 0, 180));
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            destinationRotation = Quaternion.Euler(new Vector3(0, 0, 270));
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            destinationRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        
        gameObject.transform.localRotation = Quaternion.Lerp(gameObject.transform.localRotation, destinationRotation, .5f);
    }
}
