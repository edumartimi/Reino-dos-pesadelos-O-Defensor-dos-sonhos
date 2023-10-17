using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public string[] sentences; // Defina os diálogos do objeto interativo
    private bool canInteract = false;
    public bool anelscript = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !anelscript)
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = false;
        }
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            StartDialogue();
        }
    }

    private void StartDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(sentences);
    }
}