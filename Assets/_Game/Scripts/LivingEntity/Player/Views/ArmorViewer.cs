using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class ArmorViewer : MonoBehaviour
{
    [SerializeField] Player player;
    // [SerializeField] TextMeshProUGUI armorTMPro;
    [SerializeField] GameObject armorParentGo;
    [SerializeField] Image armorImage;

    CompositeDisposable disposables = new CompositeDisposable();

    private void Start()
    {
        player.PlayerDataScriptable.ArmorRP.Subscribe(OnArmorChange).AddTo(disposables);
        player.ArmorFeatureScriptable.IsOpenRP.Subscribe(OnArmorFeatureChanged).AddTo(disposables);
    }

    private void OnDestroy()
    {
        disposables.Dispose();
    }

    public void OnArmorFeatureChanged(bool isOpen)
    {
        armorParentGo.SetActive(isOpen);
    }

    void OnArmorChange(float armor)
    {
        // armorTMPro.text = armor.ToString();
        armorImage.fillAmount = armor / player.PlayerDataScriptable.MaxArmor;
    }
}