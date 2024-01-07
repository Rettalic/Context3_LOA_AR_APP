using UnityEngine;
public class DialogFunctionality
{
    public DialogSystem Owner;

    public void SetEvents() {
        EventManager<DialogEvents, float>.Subscribe(DialogEvents.PLAY_AUDIO, PlayAudio);
        Debug.Log("Te");
        EventManager<DialogEvents, bool>.Subscribe(DialogEvents.ON_TEST_EVENT, OnTestCallRun);
        EventManager<DialogEvents, float>.Subscribe(DialogEvents.SET_TYPE_TIME, SetSpeed);
    }

    public void OnTestCallRun(bool yes) {

    }

    public void SetSpeed(float speed) {
        Owner.CurrentTimeBetweenChars = speed;
    }

    public void PlayAudio(float index)
    {
        Debug.Log("AAAA");
        Owner.theAudio.clip = Owner.TaetsAudio[(int)index];
        Debug.Log(Owner.TaetsAudio.Count);
        Owner.theAudio.Play();
    }
}

public enum DialogEvents {
    ON_TEST_EVENT,
    SET_TYPE_TIME,
    PLAY_AUDIO,
}