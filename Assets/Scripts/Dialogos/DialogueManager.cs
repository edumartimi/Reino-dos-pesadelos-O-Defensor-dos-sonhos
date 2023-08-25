using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public Image animationImage;

    public Sprite[] animationSprites; // Adicione os sprites da animação aqui
    public float animationFrameDuration = 0.1f; // Duração de cada frame da animação
    public float letterDelay = 0.05f;
    public float endDialogueDelay = 2f;

    private bool isDialogueActive = false;
    private string currentSentence;
    private int currentLetterIndex;
    private int currentAnimationIndex;
    private float letterTimer;
    private float endDialogueTimer;
    private float animationTimer;

    private void Start()
    {
        dialoguePanel.SetActive(false);
    }

    public void StartDialogue(string[] sentences)
    {
        currentSentence = string.Join(" ", sentences);
        currentLetterIndex = 0;
        currentAnimationIndex = 0;
        letterTimer = 0f;
        endDialogueTimer = 0f;
        animationTimer = 0f;

        isDialogueActive = true;
        dialoguePanel.SetActive(true);
    }

    public void DisplayNextSentence()
    {
        if (currentLetterIndex >= currentSentence.Length)
        {
            EndDialogue();
        }
        else
        {
            dialogueText.text = currentSentence.Substring(0, currentLetterIndex + 1);
            currentLetterIndex++;
        }
    }

    private void Update()
    {
        if (isDialogueActive)
        {
            if (currentLetterIndex < currentSentence.Length)
            {
                letterTimer += Time.deltaTime;
                if (letterTimer >= letterDelay)
                {
                    DisplayNextSentence();
                    letterTimer = 0f;
                }
            }
            else
            {
                endDialogueTimer += Time.deltaTime;
                if (endDialogueTimer >= endDialogueDelay)
                {
                    EndDialogue();
                }
            }

            AnimateImage();
        }
    }

    private void AnimateImage()
    {
        if (animationSprites.Length > 0)
        {
            if (currentLetterIndex < currentSentence.Length)
            {
                animationTimer += Time.deltaTime;
                if (animationTimer >= animationFrameDuration)
                {
                    animationImage.sprite = animationSprites[currentAnimationIndex];
                    currentAnimationIndex = (currentAnimationIndex + 1) % animationSprites.Length;
                    animationTimer = 0f;
                }
            }
            else
            {
                animationImage.sprite = animationSprites[animationSprites.Length - 1]; // Último sprite da animação
            }
        }
    }

    private void EndDialogue()
    {
        isDialogueActive = false;
        dialoguePanel.SetActive(false);
        animationImage.sprite = null;
    }
}
