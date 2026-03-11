using TMPro;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text messageText;
    [SerializeField] TMP_Text promptText;
    [SerializeField] string prompt;

    private Coroutine _fadeCoroutine;

    [SerializeField] float _messageDuration = 3.0f;
    [SerializeField] float _fadeOutTime = 0.5f;

    public void ShowPrompt()
    {
        promptText.text = prompt;
    }

    public void HidePrompt()
    {
        promptText.text = "";
    }

    public void DisplayMessage(string message)
    {

        if(_fadeCoroutine != null)
        {
            StopCoroutine(_fadeCoroutine);
        }
        _fadeCoroutine = StartCoroutine(DisplayMessageAndFade(message));
    }

    private IEnumerator DisplayMessageAndFade(string message)
    {
        messageText.text = message;
        messageText.color = Color.black;
        messageText.alpha = 1;
        float elaspedTime = 0f;

        yield return new WaitForSeconds(_messageDuration);

        while(elaspedTime < _messageDuration)
        {
            elaspedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elaspedTime / _fadeOutTime);
            messageText.alpha = alpha;
            yield return null;
        }

        messageText.text = "";


    }
}
