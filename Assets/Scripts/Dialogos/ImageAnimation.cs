using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageAnimation : MonoBehaviour
{
    public Image characterImage;
    public Sprite[] characterSprites; // Array de sprites para animação
    public float imageChangeInterval = 0.2f; // Intervalo entre as mudanças de imagem

    private int currentSpriteIndex = 0;
    private bool isAnimating = false;

    private void Start()
    {
        StartAnimation();
    }

    private void StartAnimation()
    {
        isAnimating = true;
        StartCoroutine(AnimateCharacter());
    }

    private IEnumerator AnimateCharacter()
    {
        while (isAnimating)
        {
            characterImage.sprite = characterSprites[currentSpriteIndex];
            currentSpriteIndex = (currentSpriteIndex + 1) % characterSprites.Length;
            yield return new WaitForSeconds(imageChangeInterval);
        }
    }

    private void StopAnimation()
    {
        isAnimating = false;
        characterImage.sprite = null;
    }

    private void OnDisable()
    {
        StopAnimation();
    }
}
