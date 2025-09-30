using UnityEngine;

public class TipsTriger : MonoBehaviour
{
    [Header("Тест Підсказки")]
    [TextArea(3, 10)]
    [SerializeField] private string masage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LopAnimation._displeiTipsEvent?.Invoke(masage);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LopAnimation._disabeTipIvent?.Invoke();
        }
    }
}
