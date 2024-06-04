using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (fileName = "New Item", menuName = "Item")]
public class Items : ScriptableObject
{
    public Sprite sprite;//arka plan kare(toplama) üçgen(çarpma) yuvarlak(çıkarma) ve beşgen(bölme)
    public Sprite icon;//içerisindeki pot image
    public int value;//kaçla işlem yaptığı
    public Type type;//işlemin tipini belirleyen
}
