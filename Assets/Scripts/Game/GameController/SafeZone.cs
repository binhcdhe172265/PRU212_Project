using System.Collections;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    public float duration = 10f;  // Thời gian tồn tại của vùng an toàn
    public Color safeZoneColor = new Color(0f, 0f, 1f, 0.2f);  // Màu sắc vùng an toàn (có thể điều chỉnh)

    private SpriteRenderer _spriteRenderer;  // SpriteRenderer để thay đổi kích thước vùng an toàn

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();  // Lấy SpriteRenderer của vùng an toàn
        _spriteRenderer.color = safeZoneColor;  // Thiết lập màu sắc cho vùng an toàn
        StartCoroutine(DestroySafeZoneAfterDuration());  // Bắt đầu thời gian tồn tại
    }

    // Coroutine để xóa vùng an toàn sau thời gian
    private IEnumerator DestroySafeZoneAfterDuration()
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);  // Xóa vùng an toàn sau khi hết thời gian
    }

    // Thay đổi scale của vùng an toàn (thực hiện thay đổi scale của sprite)
    public void SetScale(float size)
    {
        // Chỉ thay đổi scale thay vì bán kính Collider
        transform.localScale = new Vector3(size, size, 1f);  // Điều chỉnh scale của sprite
    }
}
