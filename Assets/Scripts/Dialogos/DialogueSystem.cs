using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public TMP_Text dialogueText;
    public string[] dialogues;
    private int currentDialogueIndex = 0;
    private bool isTyping = false;


    private void Start()
    {
        StartTyping();
    }

    // Fun��o para iniciar a digita��o do texto letra por letra.
    private void StartTyping()
    {
        isTyping = true;
        dialogueText.text = "";
        StartCoroutine(TypeText(dialogues[currentDialogueIndex]));
    }

    // Fun��o para avan�ar o di�logo
    public void NextDialogue()
    {
        if (isTyping) // Se o texto ainda estiver sendo escrito, acelere o texto.
        {
            StopAllCoroutines();
            dialogueText.text = dialogues[currentDialogueIndex];
            isTyping = false;
        }
        else if (currentDialogueIndex < dialogues.Length - 1) // Avance para o pr�ximo di�logo.
        {
            currentDialogueIndex++;
            StartTyping();
        }
        else // Caso contr�rio, encerre o di�logo.
        {
            EndDialogue();
        }
    }

    // Fun��o para finalizar o di�logo.
    private void EndDialogue()
    {
        dialogueText.text = "";
        // Aqui voc� pode adicionar a��es adicionais ap�s o t�rmino do di�logo, se desejar.
    }

    // Corrotina para digitar o texto letra por letra.
    private IEnumerator TypeText(string text)
    {
        dialogueText.text = "";
        foreach (char letter in text)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.03f); // Ajuste a velocidade da digita��o conforme necess�rio.
        }
        isTyping = false;
    }

    // Fun��o para verificar a entrada do jogador.
    private void Update()
    {
        if (!isTyping && Input.GetKeyDown(KeyCode.Space)) // Avance para o pr�ximo di�logo ao pressionar a tecla de espa�o.
        {
            NextDialogue();
        }
    }
}