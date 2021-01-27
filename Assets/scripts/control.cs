using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    private Rigidbody rb;
    public float HorizontalSpeed;
    public Joystick joystick;
    public float speed;          
    private Transform tr;
    private float forward_direction;
    
    void Start()
    {
        anim=this.GetComponent<Animator>();
        rb=GetComponent<Rigidbody>();
        tr=GetComponent<Transform>();
    }
    void Update()
    {
        animate();
        changeDirection();
    }
    void animate()
    {
        if(HorizontalSpeed!=0)
        {
            anim.SetBool("isruning",true);
        }
        else
        {
             anim.SetBool("isruning",false);
        }
    }
    void changeDirection()
        {
            if(HorizontalSpeed>0)
            {
                tr.eulerAngles = new Vector3 (0, 90, 0);
                forward_direction=90;
            }
            if(HorizontalSpeed<0)
            {
                tr.eulerAngles = new Vector3 (0, -90, 0);
                forward_direction=-90;
            }
            else

            {
                tr.eulerAngles = new Vector3 (0,forward_direction , 0)
                
            }
        }
    public void FixedUpdate()
    {
    ProcessInputs();
       move();
    }
    void ProcessInputs()
    {
        HorizontalSpeed=joystick.Horizontal;
    }
    void move()
    {
        rb.velocity=new Vector3 (HorizontalSpeed*speed,rb.velocity.y ,rb.velocity.z);
      //  rb.AddForce(HorizontalSpeed*speed,0 , 0, ForceMode.Impulse);
    }
    public void Jump()
    {
        rb.AddForce(0, 5, 0, ForceMode.Impulse);
    }
}
