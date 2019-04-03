using UnityEngine;
using UnityEngine.UI;

public class HealthBar_Controller : MonoBehaviour {

	    float currentHealth;
        float maxHealth;
        public CreepControls creepStats;
        public GameObject healthbar;
    
  
        // Print the canvas to the camera.
        void LateUpdate()
        {
            SlideHealthBar(creepStats.getHealthPercentage());
            transform.LookAt(GameObject.FindWithTag("MainCamera").transform);
        }

        void SlideHealthBar(float healthpercent)
        {
            Image health=healthbar.GetComponent<Image>();
            health.fillAmount=healthpercent;
        }
}
