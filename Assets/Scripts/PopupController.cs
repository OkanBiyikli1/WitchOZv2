using UnityEngine;
using DG.Tweening;

public class PopupController : MonoBehaviour
{
    // Paneli açan fonksiyon
    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        panel.transform.localScale = Vector3.zero; // Başlangıçta küçük
        panel.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack); // Pop-up açılma animasyonu
    }

    // Paneli kapatan fonksiyon
    public void ClosePanel(GameObject panel)
    {
        panel.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBack).OnComplete(() => panel.SetActive(false)); // Pop-up kapanma animasyonu
    }
}
