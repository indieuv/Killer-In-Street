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

            SetCharacter(npc);
        }
    }

    // TODO : Set Characters According to its Type
    void SetCharacter(NPCController npc){
        switch(npc.typeCode){
            case 1 :
                // Traveller
                npc.knowsLocation = false;
                npc.groups = false;
                npc.chats = true;
                break;
            
            case 2 :
                // Missionary
                npc.knowsLocation = true;
                npc.groups = false;
                npc.chats = true;
                break;

            case 3 :
                // Group Chatter
                npc.knowsLocation = true;
                npc.groups = true;
                npc.chats = true;
                break;

            case 4 :
                // Shoppper
                npc.knowsLocation = true;
                npc.groups = (Random.Range(0, 2) == 0);
                npc.chats = (Random.Range(0,2) == 0);
                break;
        }
    }
}
