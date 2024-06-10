using System.Collections.Generic;
using UnityEngine;

public class NPCHandler : MonoBehaviour
{
    public List<NPCController> npcControllers;

    void Start(){
        foreach(NPCController npc in npcControllers){
            npc.typeCode = Random.Range(1, 4);

            // move in random direction just for now
            npc.npc_direction = Random.Range(0, 1);
            npc.speed = Random.Range(3f, 7f);

            npc.timeDuration = Random.Range(1f, 4f);
        }
    }

    // TODO : Set Characters According to its Type
}
