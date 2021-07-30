using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    // public Animator animator;
    public Transform cam;
    
    // CharacterCombat combat;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    [SerializeField]
    private float jumpSpeed, gravity;

    private bool playerGrounded;
    private Vector3 jumpDirection = Vector3.zero;

    public Transform birdTarget;

    // int isRunningHash = Animator.StringToHash("isRunning");
    // int isJumpingHash = Animator.StringToHash("isJumping");

    // Start is called before the first frame update
    // void Start()
    // {
    //     combat = GetComponent<CharacterCombat>();
    // }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        

        if (direction.magnitude >= 0.1f){
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDirection.normalized * speed* Time.deltaTime);
        }

        playerGrounded = controller.isGrounded;

        // Jumping
        if(Input.GetButton("Jump") && playerGrounded)
        {
            jumpDirection.y = jumpSpeed;
        }
        jumpDirection.y -= gravity * Time.deltaTime;

        controller.Move(jumpDirection * Time.deltaTime);

        // //animations
        // animator.SetBool(isRunningHash, direction.magnitude >= 0.1f);
        // animator.SetBool(isJumpingHash, !controller.isGrounded);
    }

    public void AttractBirdsWithFood(string birdTypeToAttract)
    {
        // Trigger arm hold out animation..

		// Check if there are birds of the right kind in the near vicinity
        Collider bird;
		Collider[] hitColliders = Physics.OverlapSphere(birdTarget.position,20f);
		for(int i=0;i<hitColliders.Length;i++){
			if (hitColliders[i].tag == "lb_bird"){
				if (hitColliders[i].name.Contains(birdTypeToAttract)){
					// Attract bird
					Debug.Log(birdTypeToAttract + " found!");
                    bird = hitColliders[i];
                    bird.SendMessage ("FlyToTarget",birdTarget.position);
                    Debug.Log("Bird flying to player.");
                    break;
				}
			}
			else{
				Debug.Log("No birds that like this food are in reach");
			}
		}

    }
}
