using UnityEngine;

public class SvorldVisyal : MonoBehaviour
{
    [SerializeField] public Svorld svorld;
    private Animator animator;
    private const string ATACK1 = "Atack1";

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
    public void trigerEndAtack()
    {
        svorld.AtackColiderTirnOff();
    }


}
