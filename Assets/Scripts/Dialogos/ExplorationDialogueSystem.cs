using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Dialogue
{
    public string characterName;
    [TextArea(3, 10)]
    public string dialogueText;
}

public class ExplorationDialogueSystem : MonoBehaviour
{
    public TMP_Text dialogueText;
    public GameObject dialoguePanel;
    public float dialogueDisplayTime = 5.0f; // Tempo que o diálogo fica na tela

    private Dialogue currentDialogue;
    private bool isDisplayingDialogue = false;

    private void Start()
    {
        dialoguePanel.SetActive(false);
        ClearDialogue();
    }

    private void Update()
    {
        if (isDisplayingDialogue && Input.GetKeyDown(KeyCode.E))
        {
            HideDialogue();
        }
    }

    public void ShowDialogue(Dialogue dialogue)
    {
        currentDialogue = dialogue;
        dialogueText.text = currentDialogue.dialogueText;
        dialoguePanel.SetActive(true);
        isDisplayingDialogue = true;

        Invoke(nameof(HideDialogue), dialogueDisplayTime);
    }

    private void HideDialogue()
    {
        ClearDialogue();
        dialoguePanel.SetActive(false);
        isDisplayingDialogue = false;
    }

    private void ClearDialogue()
    {
        currentDialogue = null;
        dialogueText.text = "";
    }
}
