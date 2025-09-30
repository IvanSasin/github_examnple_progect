using System;
using TMPro;
using UnityEngine;

public class LopAnimation : MonoBehaviour
{
    public static Action<string> _displeiTipsEvent;
    public static Action _disabeTipIvent;


    [SerializeField] private TMP_Text masage;

    private Animator animator;

    private int ActiveteTips;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _displeiTipsEvent += DispleiTips;
        _disabeTipIvent += DisableTips;
    }

    private void OnDisable()
    {
        _displeiTipsEvent -= DispleiTips;
        _disabeTipIvent -= DisableTips;
    }

    private void DispleiTips(string massage)
    {
        masage.text = massage;
        animator.SetInteger("state", ++ActiveteTips);
    }

    private void DisableTips()
    {
        animator.SetInteger("state", --ActiveteTips);
    }
}
