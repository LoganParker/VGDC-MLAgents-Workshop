using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
// public class CubeScript : MonoBehaviour
public class CubeScript : Agent
{
    [SerializeField] public float horizontalForce = 0.1f;
    [SerializeField] private KeyCode leftKey = KeyCode.LeftArrow;
    [SerializeField] private KeyCode rightKey = KeyCode.RightArrow;
    
    private Vector3 startPosition;
    public ObstacleSpawner ObstacleSpawner;

    public event Action OnReset;

    // Start is called before the first frame update
    void Start()
    {
        //Set the starting position of the cube to be... well where it started (for resetting cube position)
        startPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RequestDecision();

        // if(Input.GetKey(rightKey))
        // {
        //     //Move right
        //     Move(0);   
        // }
        // if(Input.GetKey(leftKey))
        // {
        //     //Move left
        //     Move(1);
        // }
    }
    public override void OnActionReceived(float[] vectorAction)
    {
        //Move left
        if(Mathf.FloorToInt(vectorAction[0])==1)
        {
            Move(1);
        }
        //Move Right
        if(Mathf.FloorToInt(vectorAction[1])==1)
        {
            Move(0);
        }
    }
    public override void Heuristic(float[] actionsOut)
    {
        // set moveleft and moveright to be 0 
        actionsOut[0] = 0;
        actionsOut[1] = 0;



        if(Input.GetKey(leftKey))
        {
            Move(1);
            //indicate we're movin and groovin
            actionsOut[0] = 1;
        }
        if(Input.GetKey(rightKey))
        {
            Move(0);
            actionsOut[1] = 1;
        }

    }


    /* Move fucntion using transform. For future addition of the MLAgents, 
    movement by transform is better as the Agent can learn quicker than if
    using force based movement. 
    */
    private void Move(int dir)
    {
        Vector3 position = transform.position;
        //if input of dir is 1, we want to move left, otherwise we want to move right
        if(dir == 1) position.x += horizontalForce;
        else position.x -= horizontalForce;
        transform.position = position;
    }
    private void Reset()
    {
        transform.position = startPosition;
        ObstacleSpawner.DestroyObstacles();
        //allows the MLAgents framework to use the reset function when 
        OnReset?.Invoke();
    }
    private void OnCollisionEnter(Collision collision)
    {
        //check if object we are colliding with is a barrier / wall
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            // punish our boi (assign negative reward)
            AddReward(increment: -1.0f);
            // Reset the training episode
            EndEpisode();
            //Reset();
        }
    }
    //Have we passed through the gap in the wall 
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Score"))
        {
            AddReward(increment: -1.0f);
            //Debug.Log("Score");
        }   
    }
    //Called at the start of every new episode
    public override void OnEpisodeBegin()
    {
        Reset();
    }

}
