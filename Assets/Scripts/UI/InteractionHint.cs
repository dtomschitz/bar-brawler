using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionHint : MonoBehaviour
{
    private Text interactionHint;
    private Coroutine hinteractionHintRoutine;

    void Start()
    {
        interactionHint = GetComponent<Text>();    
    }

    void Update()
    {
        if (Input.anyKey)
        {
            if (hinteractionHintRoutine != null)
            {
                StopCoroutine(hinteractionHintRoutine);
                hinteractionHintRoutine = null;
            }
        }    
    }

    public void DisplayInteractionHint(string text)
    {
        if (hinteractionHintRoutine != null)
        {
            StopCoroutine(hinteractionHintRoutine);
            hinteractionHintRoutine = null;
        }

        StartCoroutine(ShowInteractionHint(text));
    }

    private IEnumerator ShowInteractionHint(string text)
    {
        //interactionHint.gameObject.SetActive(true);
        interactionHint.text = text;
        yield return new WaitForSeconds(3f);
        interactionHint.text = "";
       // interactionHint.gameObject.SetActive(false);
    }
}
