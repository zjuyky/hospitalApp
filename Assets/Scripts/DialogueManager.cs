using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    float fadeTime = 0.5f;
    DialogueBox dialogueBox;
    CanvasGroup canvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox = FindObjectOfType<DialogueBox>();
        canvasGroup = GetComponent<CanvasGroup>();
        StartCoroutine(StartDialogue("Can you help us find our shadows?", 5f));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator StartDialogue(string content, float showTime)
    {
        dialogueBox.GetComponent<DialogueBox>().UpdateDialogueBox(content);
        yield return FadeOut(fadeTime);
        yield return new WaitForSeconds(showTime);
        yield return FadeIn(fadeTime);
    }
    

    public IEnumerator FadeIn(float time)
    {
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / time;
            yield return null;
        }
    }

    public IEnumerator FadeOut(float time)
    {
        while (canvasGroup.alpha < 0.8f)
        {
            canvasGroup.alpha += Time.deltaTime / time;
            yield return null;
        }
    }

}
