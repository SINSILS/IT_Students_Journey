using UnityEngine;

public class AchievementController : MonoBehaviour
{
    public RectTransform canvasRectTransform;
    public float flyInDuration = 3f;
    public float flyOutDuration = 3f;
    public float waitDuration = 3f;

    private Vector2 startPosition = new Vector2(900f, 220f);
    private Vector2 endPosition = new Vector2(440f, 220f);

    private void Start()
    {
    }

    private void Update()
    {
        ShowAchievement();
    }
    //For now achievement is showed when key "O" is pressed
    public void ShowAchievement()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            // Start flying in
            LeanTween.move(gameObject, canvasRectTransform.TransformPoint(endPosition), flyInDuration)
                .setOnComplete(() =>

                {
                    // Wait for specified duration
                    LeanTween.delayedCall(gameObject, waitDuration, () =>
                    {
                        // Start flying out
                        LeanTween.move(gameObject, canvasRectTransform.TransformPoint(startPosition), flyOutDuration);
                    });
                });
        }
    }
}