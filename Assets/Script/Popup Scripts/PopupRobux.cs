using UnityEngine;

public class PopupRobux : MonoBehaviour
{
    [SerializeField] private PowerLoader loader;  // drag your PowerLoader here
    [SerializeField] private float penaltyAmount = 0.2f; // editable in Inspector

    public void OnClickOk()
    {
        if (loader != null)
        {
            loader.loadingFill.fillAmount -= penaltyAmount;
            loader.loadingFill.fillAmount = Mathf.Clamp01(loader.loadingFill.fillAmount);
        }
        Destroy(gameObject);
    }

    public void OnClickNo()
    {
        Destroy(gameObject);
    }

    public void OnClickX()
    {
        Destroy(gameObject);
    }
}
