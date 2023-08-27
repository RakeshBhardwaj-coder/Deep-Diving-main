using UnityEngine;
using UnityEngine.UI;
public class MovingImage : MonoBehaviour
{
    public Image uiImage;
    float speed;

    private RectTransform imageRectTransform;
    public float canvasWidth;

    private void Start()
    {
        imageRectTransform = uiImage.GetComponent<RectTransform>();
        canvasWidth = uiImage.canvas.pixelRect.width/1.5f;
    }

    private void Update()
    {
        MoveImage();
    }

    private void MoveImage()
    {
        speed = Random.Range(10f, 60f);
        Vector3 newPosition = imageRectTransform.anchoredPosition;
        newPosition.x += speed * Time.deltaTime;

        if (newPosition.x > canvasWidth)
        {
            newPosition.x = -canvasWidth; // Reset the position when image goes off screen
        }

        imageRectTransform.anchoredPosition = newPosition;
    }
}
