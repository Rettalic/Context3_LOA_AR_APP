using UnityEngine;

public class DialogueButtons : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            EventManager<DialogueEventType, string>.Invoke(DialogueEventType.startDialogue, "Test 1");
        }
    }
}
