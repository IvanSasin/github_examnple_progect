using UnityEngine;

public class DestroiPlantsVisual : MonoBehaviour
{
    [SerializeField] private DestroiPlants _destroiPlantsVisual;
    [SerializeField] private GameObject BrushDestroyVFXPrefab;

    private void Start()
    {
        _destroiPlantsVisual.OnDestructibleTakeDamage += DestroiPlantsVisual_OnDestructibleTakeDamage;
    }

    private void DestroiPlantsVisual_OnDestructibleTakeDamage(object sender, System.EventArgs e)
    {
        ShovDeathVFX();
    }
    private void ShovDeathVFX()
    {
        Instantiate(BrushDestroyVFXPrefab, _destroiPlantsVisual.transform.position, Quaternion.identity);
    }
    private void OnDestroy()
    {
        _destroiPlantsVisual.OnDestructibleTakeDamage -= DestroiPlantsVisual_OnDestructibleTakeDamage;
    }
}
