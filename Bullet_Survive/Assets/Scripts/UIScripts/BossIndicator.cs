using UnityEngine;
using UnityEngine.UI;

public class BossIndicator : MonoBehaviour
{
    public Transform player;
    public Transform boss;
    public Image arrowImage;
    public Camera mainCamera;
    public float margin = 10f;

    private void Update()
    {
        if (boss == null)
            return;

        // Check if the boss is visible on screen
        Vector3 screenPoint = mainCamera.WorldToViewportPoint(boss.position);
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

        if (onScreen)
        {
            // Hide the arrow if the boss is on screen
            arrowImage.enabled = false;
        }
        else
        {
            // Show and position the arrow pointing towards the boss if it is off-screen
            arrowImage.enabled = true;
            Vector3 direction = (boss.position - player.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            arrowImage.rectTransform.rotation = Quaternion.Euler(0, 0, angle - 90);

            Vector3 screenPosition = mainCamera.WorldToScreenPoint(boss.position);
            screenPosition.x = Mathf.Clamp(screenPosition.x, margin, Screen.width - margin);
            screenPosition.y = Mathf.Clamp(screenPosition.y, margin, Screen.height - margin);
            arrowImage.rectTransform.position = screenPosition;
        }
    }
    public void FindBoss()
    {
        GameObject bossObject = GameObject.FindGameObjectWithTag("Boss");
        if (bossObject != null)
        {
            boss = bossObject.transform;
        }
    }
}