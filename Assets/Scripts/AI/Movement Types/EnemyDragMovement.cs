using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using System.Linq;

public class EnemyDragMovement : MonoBehaviour
{
    public  float     movementSpeed;
    public  float     rotationSpeed;   // Turning circle
    public  float     drag;            // Rate of slowdown
    public  float     breakTime;       // Speed to stop sliding at
    public  float     delay;           // When to scooch again
    public  Transform target;          // What to chase
    public  Transform dummySprite;     // So the sprite doesn't keep rotating
    public  Vector3   spriteOffset;    // The sprite isn't always properly centred
    
    private float     currentSpeed;    // Actual moving speed of the object including drag
    private Transform leftWing;        // A position to the left of the gameObject
    private Transform rightWing;       // A position to the right of the gameObject
    private Vector2   leftWingVector;  // Depending on which side the target's closer to, it'll turn that way
    private Vector2   rightWingVector;
    private Animator  animator;

    // Start is called before the first frame update
    void Start()
    {
        Transform[] wings = gameObject.GetComponentsInChildren<Transform>();
        leftWing = wings.First(n => n.name == "LeftWing");
        rightWing = wings.First(n => n.name == "RightWing");
        currentSpeed = movementSpeed;
        animator = dummySprite.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(currentSpeed * Time.deltaTime, 0.0f, 0.0f);
        Vector3 newRot = new Vector3(0.0f, 0.0f, rotationSpeed * Time.deltaTime);
        leftWingVector = new Vector2(math.abs(leftWing.position.x - target.position.x), math.abs(leftWing.position.y - target.position.y));
        rightWingVector = new Vector2(math.abs(rightWing.position.x - target.position.x), math.abs(rightWing.position.y - target.position.y));

        if (currentSpeed > breakTime)
        {
            transform.Translate(newPos, Space.Self);
            animator.SetBool("Moving", true);
            spriteOffset.x = -5.0f;
        }
        else
        {
            animator.SetBool("Moving", false);
            spriteOffset.x = 0.0f;
        }

        transform.Rotate(leftWingVector.magnitude > rightWingVector.magnitude ? new Vector3(newRot.x, newRot.y, -newRot.z) : new Vector3(newRot.x, newRot.y, newRot.z));

        currentSpeed -= drag * Time.deltaTime;
        if (currentSpeed < -delay)
        {
            currentSpeed = movementSpeed;
        }

        dummySprite.position = transform.position + spriteOffset;
    }
}
