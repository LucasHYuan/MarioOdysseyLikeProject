using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LevelStarter:Singleton<LevelStarter>
{
    public UnityEvent OnStart;
    protected Level m_level => Level.instance;
    protected LevelScore m_score => LevelScore.instance;
    protected LevelPauser m_pauser => LevelPauser.instance;
    public float enablePlayerDelay = 1f;
    protected virtual IEnumerator Routinue()
    {
        Game.LockCursor();
        m_level.player.controller.enabled = false;
        m_level.player.inputs.enabled = false;
        yield return new WaitForSeconds(enablePlayerDelay);
        m_score.stopTime = false;
        m_level.player.controller.enabled = true;
        m_level.player.inputs.enabled = true;
        m_pauser.canPaused = true;
        OnStart?.Invoke();

    }
    protected void Start()
    {
        StartCoroutine(Routinue());
    }
}