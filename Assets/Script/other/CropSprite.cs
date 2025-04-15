using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CropUIHead : MonoBehaviour
{
    public Sprite originalSprite; // Drag & Drop sprite karakter di Inspector
    [Range(0f, 1f)] public float cropPercentage = 0.4f; // Seberapa besar bagian kepala yang ingin ditampilkan

    private Image imageComponent;

    void Start()
    {
        imageComponent = GetComponent<Image>();

        if (originalSprite != null)
        {
            imageComponent.sprite = CropHead(originalSprite);
        }
    }
    //test update

    Sprite CropHead(Sprite sprite)
    {
        if (sprite == null) return null;

        // Ambil ukuran asli sprite
        Rect originalRect = sprite.rect;

        // Hitung tinggi kepala berdasarkan persentase
        float headHeight = originalRect.height * cropPercentage;
        Rect headRect = new Rect(originalRect.x, originalRect.y + originalRect.height - headHeight, originalRect.width, headHeight);

        // Buat sprite baru dari bagian yang dicrop
        return Sprite.Create(sprite.texture, headRect, new Vector2(0.5f, 1f));
    }
}