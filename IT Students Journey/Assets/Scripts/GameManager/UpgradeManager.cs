using ClearSky;
using TMPro;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public StudentController student;
    public TMP_Text maxHP;
    public TMP_Text speed;
    public TMP_Text power;
    public TMP_Text fireRate;
    public TMP_Text hpPotion;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        updateLabels();
    }

    private void updateLabels()
    {
        maxHP.text = "Max hp : " + student.getMaxHP();
        updateSpeedLabel();
        updatePowerLabel();
        updateFireRateLabel();
        hpPotion.text = "HP potion : " + student.getHPPotion();
    }

    private void updateSpeedLabel()
    {
        var convertedSpeed = student.getSpeed() % 10f;
        if (convertedSpeed != 0)
        {
            convertedSpeed = convertedSpeed / 0.5f + 1;
        }
        else
        {
            convertedSpeed = 1;
        }
        speed.text = "Speed : " + convertedSpeed;
    }

    private void updatePowerLabel()
    {
        var convertedPower = student.getPower() / 5;
        power.text = "Power : " + convertedPower;
    }

    private void updateFireRateLabel()
    {
        var convertedFireRate = (1 - student.getFireRate()) * 10 + 1;
        fireRate.text = "Fire rate : " + convertedFireRate;
    }
}
