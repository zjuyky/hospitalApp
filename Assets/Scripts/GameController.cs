using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 5f;

    GameObject currentControlObject;
    Rigidbody myRigidbody;
    DialogueManager dialogueManager;

    bool isFinished = false;


    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (currentControlObject != null)
        {
            Move();
        }
        isFinished = CheckSuccess();
        if (isFinished)
        {
            StartCoroutine(dialogueManager.StartDialogue("Great! All the animals have found their shadows!", 20f));
            print("finish!");
        }
    }

    private bool CheckSuccess()
    {
        var animals = GameObject.FindGameObjectsWithTag("Animals");
        foreach (GameObject animal in animals)
        {
            if (animal.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().enabled == true)
            {
                return false;
            }
        }
        return true;
    }

    private void Move()
    {
        var controlThrow = new Vector3(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
        myRigidbody.velocity = controlThrow;
        if (controlThrow != Vector3.zero)
        {
            currentControlObject.transform.rotation = Quaternion.Slerp(
                currentControlObject.transform.rotation,
                Quaternion.LookRotation(controlThrow),
                Time.deltaTime * rotationSpeed);
        }
    }

    public void UpdateCurrentObject(GameObject gameObject)
    {
        if (currentControlObject != null)
        {
            currentControlObject.GetComponent<AnimalController>().StopControl();
        }
        
        currentControlObject = gameObject;

        if (currentControlObject != null)
        {
            print(gameObject.name);
            myRigidbody = currentControlObject.GetComponent<Rigidbody>();
        }
    }
    
}
