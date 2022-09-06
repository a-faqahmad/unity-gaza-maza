using UnityEngine;

public class delliksawMovement : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private float turnTime = 0.1f;
    [SerializeField] private float turnVelocity;
    [SerializeField] private bool canMove = true;
    [SerializeField] private Transform cam;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
    
    void Update() {
        if (!canMove) {
            return;
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 newDirection = new Vector3(horizontal, 0, vertical);
        
        if(newDirection.magnitude > 0) {
            // using tan inverse to find a new angle
            float newAngle = Mathf.Atan2(newDirection.x, newDirection.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            // making the transition smoother
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, newAngle, ref turnVelocity, turnTime);
            // doing the actual rotation
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            // changing direction according to camera rotation
            Vector3 direction = Quaternion.Euler(0f, newAngle, 0f).normalized * Vector3.forward;
            anim.SetFloat("Speed", 1f);
            // changing positions
            transform.position += (direction.normalized * speed * Time.deltaTime);
        }
        else {
            anim.SetFloat("Speed", 0f);
        }
    }
    
    public void stopMovement() {
        canMove = false;
    }

    // Update is called once per frame
    // FixedUpdate is to deal with physics
    // void FixedUpdate()
    // {
    //     if(Input.GetKey("w")) {
    //         // deltaTime is the time difference between two frames, more the delay
    //         // more the delay, more force will be added, and vice versa
    //         rb.AddForce(0,0,300 * Time.deltaTime);
    //     }
    //     else if(Input.GetKey("s")) {
    //         rb.AddForce(0,0,-300 * Time.deltaTime);
    //     }
    //     else if(Input.GetKey("a")) {
    //         rb.AddForce(-300 * Time.deltaTime,0,0);
    //     }
    //     else if(Input.GetKey("d")) {
    //         rb.AddForce(300 * Time.deltaTime,0,0);
    //     }
    // }
}
