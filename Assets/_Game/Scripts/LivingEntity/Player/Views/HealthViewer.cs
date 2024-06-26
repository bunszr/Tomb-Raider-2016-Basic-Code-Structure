using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class HealthViewer : MonoBehaviour
{
    [SerializeField] Player player;
    // [SerializeField] TextMeshProUGUI healthTMPro;
    [SerializeField] Image healthImage;

    CompositeDisposable disposables = new CompositeDisposable();

    private void Start()
    {
        player.PlayerDataScriptable.HealthRP.Subscribe(OnHealthChanged).AddTo(disposables);
    }

    private void OnDestroy()
    {
        disposables.Dispose();
    }

    void OnHealthChanged(float health)
    {
        // healthTMPro.text = health + "|";
        healthImage.fillAmount = health / player.PlayerDataScriptable.MaxHealth;
    }
}