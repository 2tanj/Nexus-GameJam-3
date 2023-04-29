using UnityEngine;
using UnityEngine.UI;

public class XPBarController : MonoBehaviour
{
    public AgentXp playerController;
    public Image xpBarFill;

    private void Update()
    {
        xpBarFill.fillAmount = (float)playerController.xp / playerController.xpToLevelUp;
    }
}
