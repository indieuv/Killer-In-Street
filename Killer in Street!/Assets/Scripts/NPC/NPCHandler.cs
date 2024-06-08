using System.Collections.Generic;
using UnityEngine;

public class NPCHandler : MonoBehaviour
{
    public List<NPCMovement> npcMovements;

    void Start(){
        // Set all the values of NPC Movements
        foreach(NPCMovement npc in npcMovements){

            // Not Starting the Range from 0 to avoid Stopping at The Beggining of the Game
            npc.stateCode = Random.Range(1, 2);

            // Setting the Speed
            npc.speed = Random.Range(1, 4);
        }
    }
}
