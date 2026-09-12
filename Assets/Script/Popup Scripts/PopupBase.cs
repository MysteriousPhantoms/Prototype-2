using UnityEngine;

public class PopupBase : MonoBehaviour
{
    private PowerLoader loader;

    [SerializeField] private float penaltyAmount = 0.2f;
    [SerializeField] private float sabotageMultiplier = 1f;
    [SerializeField] private bool appliesSabotage = false;

    void Start()
    {
        // Auto-find GameManager in the scene
        if (loader == null)
            loader = FindObjectOfType<PowerLoader>();

        if (appliesSabotage && loader != null)
        {
            loader.ApplySabotage(sabotageMultiplier);
        }
    }

    public void OnClickOk()
    {
        Debug.Log("Ok button clicked!");
        if (loader != null)
        {
            loader.LoseProgress(penaltyAmount);
        }
        ClosePopup();
    }

    public void OnClickNo()
    {
        Debug.Log("No button clicked!");
        ClosePopup();
    }

    public void OnClickX()
    {
        Debug.Log("X button clicked!");
        ClosePopup();
    }

    private void ClosePopup()
    {
        if (appliesSabotage && loader != null)
        {
            loader.ClearSabotage();
        }
        Destroy(gameObject);
    }
}
