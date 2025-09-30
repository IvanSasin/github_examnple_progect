using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] private Player _player; 
    [SerializeField] private Image LinerBar; 
     

    
    private void Update()
    {
        
        float targetFill = _player._currentHp / _player._maxHp;

        
        LinerBar.fillAmount = Mathf.Lerp(LinerBar.fillAmount, targetFill, Time.deltaTime );
    }
}
