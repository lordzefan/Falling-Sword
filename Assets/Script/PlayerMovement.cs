using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed ;
    public float rotationSpeed ;
    Animator animator;
    CharacterController characterController;
    // Start is called before the first frame update
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputMovement = Input.GetAxisRaw("Horizontal");
        Vector3 characterMovement = new Vector3(inputMovement, 0, 0).normalized;
        characterController.Move(characterMovement *movementSpeed* Time.deltaTime);
        animator.SetFloat("Movement", Mathf.Abs(inputMovement));
        
        Quaternion quaternionLookAt = Quaternion.LookRotation(characterMovement, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, quaternionLookAt, rotationSpeed);
    }
}
