using UnityEngine;

public class SvorldShVisyal : MonoBehaviour
{
    [SerializeField] private Svorld svorld;

    private const string ATACK1 = "Atack1";

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        svorld.OnSvorldSwing += Svorld_OnSvorldSwing;
    }
    private void Svorld_OnSvorldSwing(object sender, System.EventArgs e)
    {
        animator.SetTrigger("Atack1");
    }

   
}

