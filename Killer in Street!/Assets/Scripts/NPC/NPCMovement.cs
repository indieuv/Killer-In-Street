using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public enum NPCState{
        Group,
        MoveLeft,
        MoveRight
    }

    public Transform player;

    [HideInInspector]
    public NPCState currentState;
    [HideInInspector]
    public int stateCode;

    private Rigidbody2D rb;
    private Collider2D coll;
    
    private float startTime;
    private float timeDuration = 3f;

    [Space(10)]
    public float minTimeDuration;
    public float maxTimeDuration;
    [Space(10)]
    public float minDistance;
    [Space(10)]

    [HideInInspector]
    public float speed;
    private bool checkWall = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();

        startTime = Time.time;
    }

    void Update()
    {
        ChangeColliderTrigger();
        SetState();

        if(currentState == NPCState.MoveLeft) {
            MoveInDirection(Vector2.left);
        }
        else if (currentState == NPCState.MoveRight) {
            MoveInDirection(Vector2.right);
        }

        if(!checkWall){

            #region Time Calculations
            if(Time.time >= startTime + timeDuration){
                // Change State (Move Left -> Move Right and vice versa)
                ChangeDirectionThroughState();

                // Randomize timeDuration
                timeDuration = Random.Range(minTimeDuration, maxTimeDuration);

                // Reset Alarm
                startTime = Time.time;
            }
            #endregion
        
        }
        else{
            ChangeDirectionThroughState();
        }
    }

    void MoveInDirection(Vector2 direction){
        rb.velocity = speed * direction;
    }

    void ChangeDirectionThroughState(){
        if(stateCode == 1) stateCode = 2;
        else stateCode = 1;
    }   

    void SetState(){
        if(stateCode == 0) currentState = NPCState.Group;
        else if(stateCode == 1) currentState = NPCState.MoveLeft;
        else if(stateCode == 2) currentState = NPCState.MoveRight;
    }

    // FIX BUG :: -> This occurs only during collision
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.collider.tag == "Wall"){
            ChangeDirectionThroughState();
            checkWall = true;
        }
        else{
            checkWall = false;
        }
    }

    void ChangeColliderTrigger(){
        float distance = player.position.x - transform.position.x;
        if(distance < minDistance){
            coll.isTrigger = true;
        }
        else if(distance > minDistance){
            coll.isTrigger = false;
        }
    }
}
