using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SpeechUI : MonoBehaviour
{
    [SerializeField]
    private GameObject inventory;

    private List<string> dialogue;

    [SerializeField]
    private TextMeshProUGUI speech;

    [SerializeField]
    private GameManager gameManager;

    private int messageIncrement = -1;

    [SerializeField]
    private GameObject previousDialogue;

    private GameObject triggerToDisable;

    private GameObject triggerToEnable;

    [SerializeField]
    private Interactable resetInteractableData;

    private bool changeScene = false;
    private string scene_name;



    //For speech only
    public void SetMessage(List<string> message)
    {
        dialogue = message;

        gameObject.SetActive(true);
    }


    //For speech only
    public void SetMessage(List<string> message, string sceneName)
    {
        dialogue = message;

        gameObject.SetActive(true);

        scene_name = sceneName;

        changeScene = true;
    }



    public void ObjectsToSet(ObjectsToSet objectsToSet)
    {
        if (objectsToSet.shouldObjectBeDisabled)
        {
            triggerToDisable = objectsToSet.gameObject;
        }

        if (objectsToSet.objectToTrigger.objectsToEnable != null)
        {
            triggerToEnable = objectsToSet.objectToTrigger.objectsToEnable;
        }
    }



    private void ShouldLeftArrowBeDisplayed()
    {
        if (messageIncrement == 0)
        {
            previousDialogue.SetActive(false);
        }
        else
        {
            previousDialogue.SetActive(true);
        }
    }



    public void MessageNext()
    {
        if (messageIncrement < (dialogue.Count - 1))
        {
            messageIncrement++;

            speech.text = dialogue[messageIncrement];
        }
        else
        {
            inventory.SetActive(true);

            gameObject.SetActive(false);

            messageIncrement = -1;

            if (changeScene)
            {
                SceneManager.LoadScene(scene_name);
            }
        }

        ShouldLeftArrowBeDisplayed();
    }



    public void MessagePrevious()
    {
        if (messageIncrement > 0)
        {
            messageIncrement--;

            speech.text = dialogue[messageIncrement];
        }

        ShouldLeftArrowBeDisplayed();
    }



    private void OnEnable()
    {
        MessageNext();
    }



    private void OnDisable()
    {
        if (triggerToDisable != null)
        {
            triggerToDisable.SetActive(false);

            triggerToDisable = null;
        }

        if (triggerToEnable != null)
        {
            triggerToEnable.SetActive(true);

            triggerToEnable = null;
        }

        resetInteractableData.ResetData();
    }
}
