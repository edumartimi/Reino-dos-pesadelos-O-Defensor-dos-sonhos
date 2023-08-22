using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class CharacterAnimation
{
    public string characterName;
    public Sprite[] animationSprites;
}

public class DialogueSystemWithImages : MonoBehaviour
{
    public TMP_Text dialogueText;
    public Image characterImage;
    public Image bordaimage;
    public string[] dialogues;
    public float delayBeforeStart = 2.0f; // Tempo de espera antes dos diálogos começarem

    public CharacterAnimation[] characterAnimations; // Configure no Inspector para cada personagem
    public float spriteChangeInterval = 0.2f; // Intervalo entre as mudanças de sprite da animação

    private int currentDialogueIndex = 0;
    private bool isTyping = false;

    private List<Sprite> currentCharacterSprites = new List<Sprite>();
    private int currentSpriteIndex = 0;
    private float nextSpriteChangeTime = 0.0f;
    public Animator carro;


    private void Start()
    {
        StartCoroutine(StartDialogueWithDelay());
    }

    private IEnumerator StartDialogueWithDelay()
    {
        yield return new WaitForSeconds(delayBeforeStart);
        StartTyping();
        if (!characterImage.gameObject.active)
        {
            characterImage.gameObject.SetActive(true);
            bordaimage.gameObject.SetActive(true);
        }

    }

    private void StartTyping()
    {
        isTyping = true;
        dialogueText.text = "";
        StartCoroutine(TypeText(dialogues[currentDialogueIndex]));
        UpdateCharacterAnimation(currentDialogueIndex);
    }

    public void NextDialogue()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            dialogueText.text = dialogues[currentDialogueIndex];
            isTyping = false;
        }
        else if (currentDialogueIndex < dialogues.Length - 1)
        {
            currentDialogueIndex++;
            StartTyping();
            UpdateCharacterAnimation(currentDialogueIndex);
        }
        else
        {
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        dialogueText.text = "";
        characterImage.sprite = null;
        characterImage.enabled = false;
        bordaimage.enabled = false;
        currentCharacterSprites.Clear();
        carro.SetTrigger("sair");
    }

    private IEnumerator TypeText(string text)
    {
        dialogueText.text = "";
        int endIndex = text.Length - 1;
        foreach (char letter in text)
        {
            if (text.IndexOf(letter) == endIndex)
            {
                dialogueText.text += "";
            }
            else
            {
                dialogueText.text += letter;
            }
            yield return new WaitForSeconds(0.03f);
        }
        isTyping = false;
    }

    private void UpdateCharacterAnimation(int index)
    {
        int characterNumber = ExtractCharacterNumber(dialogues[index]);
        if (characterNumber > 0 && characterNumber <= characterAnimations.Length)
        { 
            currentCharacterSprites = new List<Sprite>(characterAnimations[characterNumber - 1].animationSprites);
            nextSpriteChangeTime = Time.time + spriteChangeInterval;
            currentSpriteIndex = 0;
        }
    }

    private int ExtractCharacterNumber(string dialogue)
    {
        int characterNumber = 0;
        int.TryParse(dialogue.Substring(dialogue.Length - 1), out characterNumber);
        return characterNumber;
    }

    private void Update()
    {
        if (currentCharacterSprites.Count > 0 && Time.time > nextSpriteChangeTime)
        {
            characterImage.sprite = currentCharacterSprites[currentSpriteIndex];
            currentSpriteIndex = (currentSpriteIndex + 1) % currentCharacterSprites.Count;
            nextSpriteChangeTime = Time.time + spriteChangeInterval;
        }

        if (!isTyping && Input.GetKeyDown(KeyCode.Space))
        {
            NextDialogue();
        }
    }
}
