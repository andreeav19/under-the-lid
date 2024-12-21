using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandlePotMovement();
    }

    void HandlePotMovement()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            gameObject.transform.eulerAngles = new Vector3(0, 0, 90);
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            gameObject.transform.eulerAngles = new Vector3(0, 0, -90);
    }
}
