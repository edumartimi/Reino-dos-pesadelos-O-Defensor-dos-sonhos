using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoActiveObject : MonoBehaviour
{
    public string[] sentences; // Defina os di�logos do objeto com ativa��o autom�tica
    public float dialogueDisplayTime = 3f; // Tempo adicional ap�s o t�rmino do di�logo
    private bool dialogueActive = false;
    public bool leu_a_mensagem;
    public CameraController Cameras;
    public Animator portao;

    private void Start()
    {
     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !dialogueActive)
        {
            StartDialogue();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        StartDialogue();
        if (collision.CompareTag("Anel_int")) 
        {
            leu_a_mensagem = true;
        }
    }

    private void Update()
    {
        if (dialogueActive && Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
        }

     
    }

    private void StartDialogue()
    {
        dialogueActive = true;
        FindObjectOfType<DialogueManager>().StartDialogue(sentences);
    }

    private void OnDialogueEnd()
    {
        dialogueActive = false;
    }
}