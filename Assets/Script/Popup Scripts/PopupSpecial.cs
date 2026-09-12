using UnityEngine;
public class PopupSpecial : MonoBehaviour
{
    private PowerLoader loader;

    [SerializeField] private float penaltyChoice1 = 0.1f;
    [SerializeField] private float penaltyChoice2 = 0.2f;
    [SerializeField] private float penaltyChoice3 = 0f;

    void Start()
    {
        loader = FindObjectOfType<PowerLoader>();
    }

    public void OnClickChoice1()
    {
        if (loader != null) loader.LoseProgress(penaltyChoice1);
        ClosePopup();
    }

    public void OnClickChoice2()
    {
        if (loader != null) loader.LoseProgress(penaltyChoice2);
        ClosePopup();
    }

    public void OnClickChoice3()
    {
        if (loader != null) loader.LoseProgress(penaltyChoice3);
        ClosePopup();
    }

    private void ClosePopup()
    {
        Destroy(gameObject);
    }
}
