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

    // Função para iniciar a digitação do texto letra por letra.
    private void StartTyping()
    {
        isTyping = true;
        dialogueText.text = "";
        StartCoroutine(TypeText(dialogues[currentDialogueIndex]));
    }

    // Função para avançar o diálogo
    public void NextDialogue()
    {
        if (isTyping) // Se o texto ainda estiver sendo escrito, acelere o texto.
        {
            StopAllCoroutines();
            dialogueText.text = dialogues[currentDialogueIndex];
            isTyping = false;
        }
        else if (currentDialogueIndex < dialogues.Length - 1) // Avance para o próximo diálogo.
        {
            currentDialogueIndex++;
            StartTyping();
        }
        else // Caso contrário, encerre o diálogo.
        {
            EndDialogue();
        }
    }

    // Função para finalizar o diálogo.
    private void EndDialogue()
    {
        dialogueText.text = "";
        // Aqui você pode adicionar ações adicionais após o término do diálogo, se desejar.
    }

    // Corrotina para digitar o texto letra por letra.
    private IEnumerator TypeText(string text)
    {
        dialogueText.text = "";
        foreach (char letter in text)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.03f); // Ajuste a velocidade da digitação conforme necessário.
        }
        isTyping = false;
    }

    // Função para verificar a entrada do jogador.
    private void Update()
    {
        if (!isTyping && Input.GetKeyDown(KeyCode.Space)) // Avance para o próximo diálogo ao pressionar a tecla de espaço.
        {
            NextDialogue();
        }
    }
}