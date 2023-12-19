using UnityEngine;
public class DialogFunctionality
{
    public DialogSystem Owner;

    public void SetEvents() {
        EventManager<DialogEvents, bool>.Subscribe(DialogEvents.ON_TEST_EVENT, OnTestCallRun);
        EventManager<DialogEvents, float>.Subscribe(DialogEvents.SET_TYPE_TIME, SetSpeed);
        EventManager<DialogEvents>.Subscribe(DialogEvents.PLAY_AUDIO, PlayAudio);
    }

    public void OnTestCallRun(bool yes) {

    }

    public void SetSpeed(float speed) {
        Owner.CurrentTimeBetweenChars = speed;
    }

    public void PlayAudio()
    {
        Owner.theAudio.clip = Owner.TaetsAudio[2];
        Owner.theAudio.Play();
        Debug.Log("AAAA");
    }
}

public enum DialogEvents {
    ON_TEST_EVENT,
    SET_TYPE_TIME,
    PLAY_AUDIO,
}