using UnityEngine;

public class DialogueButtons : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //TO DO: Make the string changeable.
            EventManager<DialogueEventType, string>.Invoke(DialogueEventType.startDialogue, "Test 1");
        }
    }
}
