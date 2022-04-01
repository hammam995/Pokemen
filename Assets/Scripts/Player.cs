using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    Vector3 targetPosition;
    Vector3 lookAtTarget;
    Quaternion playerRot;
    public float rotSpeed = 5f; // the speed of rotation
    public float speed = 2f; // by changing the speed move 
    bool moving = false;
    public delegate void delegadem();
    public delegadem delmovemen; //delegade variable for movement and their animation
    void Start()
    {
        base.Start();
        delmovemen += SetTargetPosition;

    }
    private void FixedUpdate()
    {
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            delmovemen();
        }
        
        Move();
        
    }
    void SetTargetPosition() // to make the player look to the mouse position
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            targetPosition = hit.point;
            Debug.DrawLine(Camera.main.transform.position, hit.point, Color.red, 0.5f);
            lookAtTarget = new Vector3(targetPosition.x - transform.position.x, transform.position.y, targetPosition.z - transform.position.z);
            playerRot = Quaternion.LookRotation(lookAtTarget);
            moving = true;
        }
    }
    void Move() // to make the player move after we look to the mouse position
    { // in the moment of the movement
        if (moving)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, playerRot, rotSpeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < 2f)
            {
                moving = false;
                characterAnimatior.SetBool("running", false);
            }
            else
            {
                moving = true;
                characterAnimatior.SetBool("running", true);
            }
        }
    }
}
