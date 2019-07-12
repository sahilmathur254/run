using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    private Transform LookAt;
    private Vector3 startOffset;
    private Vector3 moveVector;

    private float transition = 0.0f;
    private float animationDuration = 2.0f;
    private Vector3 animationOffset = new Vector3(0, 5, 5);
    // Start is called before the first frame update
    void Start()
    {
        LookAt = GameObject.FindGameObjectWithTag ("Player").transform;
        startOffset = transform.position - LookAt.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = LookAt.position + startOffset;

        //X
        moveVector.x = 0;


        //Y

        moveVector.y = Mathf.Clamp(moveVector.y, 3, 5);

        if (transition > 1.0f)
        {
            transform.position = moveVector;
        }

        else
        {
            //animation at the start of the game
            transform.position = Vector3.Lerp(moveVector + animationOffset,moveVector,transition);
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(LookAt.position + Vector3.up);
        }




        transform.position = LookAt.position + startOffset;
    }
}
