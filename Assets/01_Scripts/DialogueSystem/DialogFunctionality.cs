using UnityEngine;
public class DialogFunctionality
{
    public DialogSystem Owner;

    public void SetEvents() {
        EventManager<DialogEvents, float>.Subscribe(DialogEvents.PLAY_AUDIO, PlayAudio);
        EventManager<DialogEvents, bool>.Subscribe(DialogEvents.ON_TEST_EVENT, OnTestCallRun);
        EventManager<DialogEvents, float>.Subscribe(DialogEvents.SET_TYPE_TIME, SetSpeed);
        EventManager<DialogEvents>.Subscribe(DialogEvents.ENABLE_CONTINUE, EnableContinueButton);
        EventManager<DialogEvents>.Subscribe(DialogEvents.DISABLE_CONTINUE, DisableContinueButton);
        EventManager<DialogEvents>.Subscribe(DialogEvents.ENABLE_RESTART, EnableRestartButton);
        EventManager<DialogEvents>.Subscribe(DialogEvents.DISABLE_RESTART, DisableRestartButton);
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

    public void EnableContinueButton()
    {
        Owner.buttonContinue?.SetActive(true);
    }

    public void DisableContinueButton()
    {
        Owner.buttonContinue?.SetActive(false);
    }

    public void EnableRestartButton()
    {
        Owner.buttonRestart?.SetActive(true);
    }

    public void DisableRestartButton()
    {
        Owner.buttonRestart?.SetActive(false);
    }
}

public enum DialogEvents {
    ON_TEST_EVENT,
    SET_TYPE_TIME,
    PLAY_AUDIO,
    ENABLE_CONTINUE,
    DISABLE_CONTINUE,
    ENABLE_RESTART,
    DISABLE_RESTART,
}