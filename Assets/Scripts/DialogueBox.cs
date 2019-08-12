using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    Text text;
    string currentText;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = currentText;
    }

    public void UpdateDialogueBox(string content)
    {
        print(content);
        currentText = content;
        
    }
}
