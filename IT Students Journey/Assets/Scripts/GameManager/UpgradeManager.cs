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

    public TMP_Text maxHPPrice;
    public TMP_Text speedPrice;
    public TMP_Text powerPrice;
    public TMP_Text fireRatePrice;
    public TMP_Text hpPotionPrice;

    UpgradeStats[] upgradeStats = new UpgradeStats[5] { new UpgradeStats(),
                                                        new UpgradeStats(),
                                                        new UpgradeStats(),
                                                        new UpgradeStats(),
                                                        new UpgradeStats()
                                                      };

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        updateMaxHPLabel();
        updateSpeedLabel();
        updatePowerLabel();
        updateFireRateLabel();
        updateHPPotionLabel();
    }

    private void updateMaxHPLabel()
    {
        maxHP.text = "Max hp : " + student.getMaxHP();
        maxHPPrice.text = upgradeStats[0].price.ToString();
    }

    public void ugradeMaxHP()
    {
        if (student.getCoins() >= upgradeStats[0].price)
        {
            student.updateMaxHP(10);
            student.payCoins(upgradeStats[0].price);
            upgradeStats[0].price += 10;
            upgradeStats[0].level++;
        }
    }

    public void downgradeMaxHP()
    {
        if (upgradeStats[0].level > 1 && student.getCurrentHP() > 10)
        {
            student.updateMaxHP(-10);
            upgradeStats[0].price -= 10;
            student.addCoins(upgradeStats[0].price);
            upgradeStats[0].level--;
        }
    }

    private void updateSpeedLabel()
    {
        speed.text = "Speed : " + upgradeStats[1].level;
        speedPrice.text = upgradeStats[1].price.ToString();
    }

    public void upgradeSpeed()
    {
        if (student.getCoins() >= upgradeStats[1].price && upgradeStats[1].level < 5)
        {
            student.updateSpeed(1f);
            student.payCoins(upgradeStats[1].price);
            upgradeStats[1].price += 10;
            upgradeStats[1].level++;
        }
    }

    public void downgradeSpeed()
    {
        if (upgradeStats[1].level > 1)
        {
            student.updateSpeed(-1f);
            upgradeStats[1].price -= 10;
            student.addCoins(upgradeStats[1].price);
            upgradeStats[1].level--;
        }
    }

    private void updatePowerLabel()
    {
        power.text = "Power : " + upgradeStats[2].level;
        powerPrice.text = upgradeStats[2].price.ToString();
    }

    public void upgradePower()
    {
        if (student.getCoins() >= upgradeStats[2].price && upgradeStats[2].level < 5)
        {
            student.updatePower(5);
            student.payCoins(upgradeStats[2].price);
            upgradeStats[2].price += 10;
            upgradeStats[2].level++;
        }
    }

    public void downgradePower()
    {
        if (upgradeStats[2].level > 1)
        {
            student.updatePower(-5);
            upgradeStats[2].price -= 10;
            student.addCoins(upgradeStats[2].price);
            upgradeStats[2].level--;
        }
    }

    private void updateFireRateLabel()
    {
        fireRate.text = "Fire rate : " + upgradeStats[3].level.ToString();
        fireRatePrice.text = upgradeStats[3].price.ToString();
    }

    public void upgradeFireRate()
    {
        if (student.getCoins() >= upgradeStats[3].price && upgradeStats[3].level < 5)
        {
            student.updateFireRate(0.1);
            student.payCoins(upgradeStats[3].price);
            upgradeStats[3].price += 10;
            upgradeStats[3].level++;
        }
    }

    public void downgradeFireRate()
    {
        if (upgradeStats[3].level > 1)
        {
            student.updateFireRate(-0.1);
            upgradeStats[3].price -= 10;
            student.addCoins(upgradeStats[3].price);
            upgradeStats[3].level--;
        }
    }

    private void updateHPPotionLabel()
    {
        upgradeStats[4].price = student.getMissingHP() / 2;
        hpPotion.text = "HP potion : " + student.getMissingHP();
        hpPotionPrice.text = upgradeStats[4].price.ToString();
    }

    public void resetHealth()
    {
        if (student.getCoins() >= upgradeStats[4].price)
        {
            student.payCoins(upgradeStats[4].price);
            student.resetHealth();
        }
    }
}

class UpgradeStats
{
    public int level = 1;
    public int price = 10;
}