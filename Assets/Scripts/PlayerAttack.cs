using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject ArrowPrefab;
    [SerializeField] SpriteRenderer ArrowGFX;
    [SerializeField] Slider bowPowerSlider;
    [SerializeField] Transform Bow;

    [Range(0, 10)]
    [SerializeField] float bowPower;

    [Range(0, 3)]
    [SerializeField] float maxBowCharge;

    float bowCharge;
    bool canFire = true;

    // Start is called before the first frame update
    void Start()
    {
        bowPowerSlider.value = 0f;
        bowPowerSlider.maxValue = maxBowCharge;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && canFire)
        {
            ChargeBow();
        }
        else if (Input.GetMouseButtonUp(0) && canFire)
        {
            FireArrow();
        }
        else
        {
            if(bowCharge > 0f)
            {
                bowCharge -= 1f * Time.deltaTime;
            }
            else
            {
                bowCharge = 0f;
                canFire = true;
            }

            bowPowerSlider.value = bowCharge;
        }
    }

    void ChargeBow()
    {
        ArrowGFX.enabled = true;
        bowCharge += Time.deltaTime;

        bowPowerSlider.value = bowCharge;

        if(bowCharge > maxBowCharge)
        {
            bowPowerSlider.value = maxBowCharge;
        }
    }

    void FireArrow()
    {
        if (bowCharge > maxBowCharge)
        {
            bowCharge = maxBowCharge;
        }

        float arrowSpeed = bowCharge + bowPower;
        float arrowDamage = bowCharge * bowPower;

        float angle = Utility.AngleTowardsMouse(Bow.position);
        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));

        Arrow arrow = Instantiate(ArrowPrefab, Bow.position, rot).GetComponent<Arrow>();
        arrow.arrowVelocity = arrowSpeed;
        arrow.arrowDamage = arrowDamage;

        canFire = false;
        ArrowGFX.enabled = false;
    }
}
