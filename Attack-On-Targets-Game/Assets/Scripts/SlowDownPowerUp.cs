using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownPowerUp : MonoBehaviour
{
    public float slowDownAmount = 0.05f;
    public float slowDownLength = 2f;

    private void Update()
    {
        Time.timeScale += (1f / slowDownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    public void OnCollisionEnter(Collision collision)
    {
        Time.timeScale = slowDownAmount;
        Time.fixedDeltaTime = Time.timeScale * .02f;

        // transform.parent.gameObject.SetActive(false);
        // collision.gameObject.SetActive(false);
    }
}
