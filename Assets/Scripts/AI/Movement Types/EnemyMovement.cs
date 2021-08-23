using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using System.Linq;

public class EnemyMovement : MonoBehaviour
{
    public  float     movementSpeed;
    public  float     rotationSpeed;   // Turning circle
    public  Transform target;          // What to chase
    public  Transform dummySprite;     // So the sprite doesn't keep rotating
    
    private Transform leftWing;        // A position to the left of the gameObject
    private Transform rightWing;       // A position to the right of the gameObject
    private Vector2   leftWingVector;  // Depending on which side the target's closer to, it'll turn that way
    private Vector2   rightWingVector;

    // Start is called before the first frame update
    void Start()
    {
        Transform[] wings = gameObject.GetComponentsInChildren<Transform>();
        leftWing = wings.First(n => n.name == "LeftWing");
        rightWing = wings.First(n => n.name == "RightWing");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(movementSpeed * Time.deltaTime, 0.0f, 0.0f);
        Vector3 newRot = new Vector3(0.0f, 0.0f, rotationSpeed * Time.deltaTime);
        leftWingVector = new Vector2(math.abs(leftWing.position.x - target.position.x), math.abs(leftWing.position.y - target.position.y));
        rightWingVector = new Vector2(math.abs(rightWing.position.x - target.position.x), math.abs(rightWing.position.y - target.position.y));

        transform.Translate(newPos, Space.Self);
        transform.Rotate(leftWingVector.magnitude > rightWingVector.magnitude ? new Vector3(newRot.x, newRot.y, -newRot.z) : new Vector3(newRot.x, newRot.y, newRot.z));

        // The sprite doesn't wanna rotate with the movement, so use the dummy here
        dummySprite.position = transform.position;
    }
}
