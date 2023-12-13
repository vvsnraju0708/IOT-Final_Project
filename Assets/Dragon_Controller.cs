using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Controller : MonoBehaviour
{
    [SerializeField] private float Speed;

    private FixedJoystick fixedJoystick;
    private Rigidbody RigidBody;

    private void OnEnable()
    {
       fixedJoystick = FindObjectOfType<FixedJoystick>();
        RigidBody = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float xVal = fixedJoystick.Horizontal;
        float yVal = fixedJoystick.Vertical;

        Vector3 movement = new Vector3 (xVal, yVal, 0);

        RigidBody.velocity = movement * Speed;

        if(xVal !=0 && yVal !=0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2 (xVal, yVal)*Mathf.Rad2Deg,transform.eulerAngles.z);
        }
    }
}
