using UnityEngine;

public class NPCController : MonoBehaviour
{
    public enum NPCType{
        Traveller,
        Missionary,
        Group_Chatter,
        Shopper
    }

    [HideInInspector] public NPCType npcType;
    [HideInInspector] public int typeCode; // > 4 Codes according to no. of States

    private const float MIN_DIST_FROM_PLAYER = 1.5f;

    public Transform player;

    private Rigidbody2D rb;
    private Collider2D coll;

    private float startTime; // > creating my own alarm
    [HideInInspector] public float timeDuration;

    [Space(10)]
    public float minTimeDuration;
    public float maxTimeDuration;
    [Space(10)]

    public float speed;
    public int npc_direction;// 0 -> left, 1 -> right

    [Space(10), Header("NPC Characters")]
    public bool knowsHisSurrounding;
    public bool groups;
    public bool chats;
    // public bool canUseCabs;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();

        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        SetState();
        ChangeTrigger();

        if(npc_direction == 0) MoveInDirection(Vector2.left);
        else if(npc_direction == 1) MoveInDirection(Vector2.right);

        if(Time.time > startTime + timeDuration){
            // Demo Code 
            if(npc_direction == 0) npc_direction = 1;
            else npc_direction = 0;

            // Randomize Time Duration
            timeDuration = Random.Range(minTimeDuration, maxTimeDuration);

            // Reset Alarm
            startTime = Time.time;
        }
    }

    void MoveInDirection(Vector2 direction){
        rb.velocity = speed * direction;
    }

    void SetState(){
        if(typeCode == 1) npcType = NPCType.Traveller;
        else if(typeCode == 2) npcType = NPCType.Missionary;
        else if(typeCode == 3) npcType = NPCType.Group_Chatter;
        else if(typeCode == 4) npcType = NPCType.Shopper;
    }

    void ChangeTrigger(){
        float distance = player.position.x - transform.position.x;
        if(distance < MIN_DIST_FROM_PLAYER){
            coll.isTrigger = true;
        }
        else if(distance > MIN_DIST_FROM_PLAYER){
            coll.isTrigger = false;
        }
    }
}
