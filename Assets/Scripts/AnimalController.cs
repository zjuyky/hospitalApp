using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    GameController gameController;
    [SerializeField] string name;
    [SerializeField] Transform shadow;
    [SerializeField] string completeText;

    DialogueManager dialogueManager;
    SkinnedMeshRenderer myRenderer;
    Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        myRenderer = transform.GetChild(0).GetComponent<SkinnedMeshRenderer>();
        myAnimator = transform.GetComponent<Animator>();
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        var distanceToShadow = Vector3.Distance(transform.position, shadow.position);
        if(distanceToShadow <0.15f && myRenderer.enabled)
        {
            gameController.UpdateCurrentObject(null);
            myRenderer.enabled = false;
            StartCoroutine(dialogueManager.StartDialogue(name + ": " + completeText, 2f));
            shadow.GetComponent<Animator>().SetInteger("animation", 3);
            shadow.GetChild(0).GetComponent<SkinnedMeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        }
    }

    private void OnMouseDown()
    {
        print(name);
        gameController.UpdateCurrentObject(this.gameObject);
        myAnimator.SetInteger("animation", 1);
    }

    public void StopControl()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        myAnimator.SetInteger("animation", 0);
    }
    
}
