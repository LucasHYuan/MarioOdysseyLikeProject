using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class UIAnimator: MonoBehaviour
{
    public UnityEvent OnShow;
    public UnityEvent OnHide;
    
    protected Animator m_animator;

    public bool hidenOnAwake;
    public string normalTrigger = "Normal";
    public string hideTrigger = "Hide";
    public string showTrigger = "Show";

    protected virtual void Awake()
    {
        m_animator = GetComponent<Animator>();
        if (hidenOnAwake)
        {
            m_animator.Play(hideTrigger, 0, 1);
        }
    }

    public virtual void SetActive(bool value) => gameObject.SetActive(value);

    public virtual void Show()
    {
        m_animator.SetTrigger(showTrigger);
        OnShow?.Invoke();
    }

    public virtual void Hide()
    {
        m_animator.SetTrigger(hideTrigger);
        OnShow?.Invoke();
    }
}