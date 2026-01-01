using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMovement : MonoBehaviour
{
   public float fallingSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down* fallingSpeed *Time.deltaTime);
    }
}
