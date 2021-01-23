using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lastDialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Animator camAnim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            TriggerDialogue();
            camAnim.SetBool("Cutscene2", true);

        }
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
