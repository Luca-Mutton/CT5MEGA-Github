using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //creates variables for movement
    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    [SerializeField] private float movementSpeed;
    public BoundingCircle FPplayer;

    private CharacterController charController;

    void Start()
    {
        FPplayer = new BoundingCircle(transform.position, 0.5f);
    }

    //creates a controller for the character
    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementControls();

        FPplayer.CentrePoint = transform.position;
    }

    //movement inputs
    private void MovementControls()
    {
        //creates movement variable in the forward and backwards direction.
        float verticalInput = Input.GetAxis(verticalInputName) * movementSpeed * Time.deltaTime;

        //creates movement variable in the right and left directons
        float horizontalInput = Input.GetAxis(horizontalInputName) * movementSpeed * Time.deltaTime;

        //transformation for forward and backwards direction.
        Vector3 ForwardMovement = transform.forward * verticalInput;

        //transformation for right and left directons
        Vector3 RightMovement = transform.right * horizontalInput;

        //gets the transformation for the character gameObject
        charController.Move(ForwardMovement + RightMovement);

    }
}
