using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectExploration : MonoBehaviour
{
    public ExplorationDialogueSystem dialogueSystem;
    public Dialogue[] dialogues;

    private bool playerInRange = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (dialogues.Length > 0)
            {
                int randomIndex = Random.Range(0, dialogues.Length);
                dialogueSystem.ShowDialogue(dialogues[randomIndex]);
            }
        }
    }
}
