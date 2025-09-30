using UnityEngine;
using TMPro;
public class Repository : MonoBehaviour
{
    [SerializeField] private TMP_Text coins;

    
    private void Update()
    {
        coins.text = DataConteiner.coinse.ToString();
    }
}
