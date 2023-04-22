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

    GameObject[] buttons = new GameObject[9];

    UpgradeStats[] upgradeStats = new UpgradeStats[5] { new UpgradeStats(),
                                                        new UpgradeStats(),
                                                        new UpgradeStats(),
                                                        new UpgradeStats(),
                                                        new UpgradeStats()
                                                      };

    // Start is called before the first frame update
    void Start()
    {
        gatherButtons();
    }

    // Update is called once per frame
    void Update()
    {
        updateMaxHPLabel();
        updateSpeedLabel();
        updatePowerLabel();
        updateFireRateLabel();
        updateHPPotionLabel();
        updateUpgradeButtons();
        updateDowngradeButtons();
    }

    void gatherButtons()
    {
        buttons = GameObject.FindGameObjectsWithTag("Button");
    }

    void updateUpgradeButtons()
    {
        //Max hp
        if (student.getCoins() >= upgradeStats[0].price)
        {
            buttons[0].SetActive(true);
        }
        else
        {
            buttons[0].SetActive(false);
        }
        //Speed
        if (student.getCoins() >= upgradeStats[1].price && upgradeStats[1].level != 5)
        {
            buttons[2].SetActive(true);
        }
        else
        {
            buttons[2].SetActive(false);
        }
        //Power
        if (student.getCoins() >= upgradeStats[2].price && upgradeStats[2].level != 5)
        {
            buttons[4].SetActive(true);
        }
        else
        {
            buttons[4].SetActive(false);
        }
        //Fire rate
        if (student.getCoins() >= upgradeStats[3].price && upgradeStats[3].level != 5)
        {
            buttons[6].SetActive(true);
        }
        else
        {
            buttons[6].SetActive(false);
        }
        //HP potion
        if (student.getCoins() >= upgradeStats[4].price && upgradeStats[4].price != 0)
        {
            buttons[8].SetActive(true);
        }
        else
        {
            buttons[8].SetActive(false);
        }
    }

    void updateDowngradeButtons()
    {
        if (upgradeStats[0].level == 1)
        {
            buttons[1].SetActive(false);
        }
        else
        {
            buttons[1].SetActive(true);
        }
        if (upgradeStats[1].level == 1)
        {
            buttons[3].SetActive(false);
        }
        else
        {
            buttons[3].SetActive(true);
        }
        if (upgradeStats[2].level == 1)
        {
            buttons[5].SetActive(false);
        }
        else
        {
            buttons[5].SetActive(true);
        }
        if (upgradeStats[3].level == 1)
        {
            buttons[7].SetActive(false);
        }
        else
        {
            buttons[7].SetActive(true);
        }
    }

    private void updateMaxHPLabel()
    {
        maxHP.text = "Max hp : " + student.getMaxHP();
        maxHPPrice.text = upgradeStats[0].price.ToString();
    }

    public void ugradeMaxHP()
    {
        student.updateMaxHP(10);
        student.payCoins(upgradeStats[0].price);
        upgradeStats[0].price += 10;
        upgradeStats[0].level++;
    }

    public void downgradeMaxHP()
    {
        student.updateMaxHP(-10);
        upgradeStats[0].price -= 10;
        student.addCoins(upgradeStats[0].price);
        upgradeStats[0].level--;
    }

    private void updateSpeedLabel()
    {
        if (upgradeStats[1].level == 5)
        {
            speed.text = "Speed : MAX";
            speedPrice.text = "X";
        }
        else
        {
            speed.text = "Speed : " + upgradeStats[1].level;
            speedPrice.text = upgradeStats[1].price.ToString();
        }
    }

    public void upgradeSpeed()
    {
        student.updateSpeed(1f);
        student.payCoins(upgradeStats[1].price);
        upgradeStats[1].price += 10;
        upgradeStats[1].level++;
    }

    public void downgradeSpeed()
    {
        student.updateSpeed(-1f);
        upgradeStats[1].price -= 10;
        student.addCoins(upgradeStats[1].price);
        upgradeStats[1].level--;
    }

    private void updatePowerLabel()
    {
        if (upgradeStats[2].level == 5)
        {
            power.text = "Power : MAX";
            powerPrice.text = "X";
        }
        else
        {
            power.text = "Power : " + upgradeStats[2].level;
            powerPrice.text = upgradeStats[2].price.ToString();
        }
    }

    public void upgradePower()
    {
        student.updatePower(5);
        student.payCoins(upgradeStats[2].price);
        upgradeStats[2].price += 10;
        upgradeStats[2].level++;
    }

    public void downgradePower()
    {
        student.updatePower(-5);
        upgradeStats[2].price -= 10;
        student.addCoins(upgradeStats[2].price);
        upgradeStats[2].level--;
    }

    private void updateFireRateLabel()
    {
        if (upgradeStats[3].level == 5)
        {
            fireRate.text = "Fire rate : MAX";
            fireRatePrice.text = "X";
        }
        else
        {
            fireRate.text = "Fire rate : " + upgradeStats[3].level.ToString();
            fireRatePrice.text = upgradeStats[3].price.ToString();
        }
    }

    public void upgradeFireRate()
    {
        student.updateFireRate(0.1);
        student.payCoins(upgradeStats[3].price);
        upgradeStats[3].price += 10;
        upgradeStats[3].level++;
    }

    public void downgradeFireRate()
    {
        student.updateFireRate(-0.1);
        upgradeStats[3].price -= 10;
        student.addCoins(upgradeStats[3].price);
        upgradeStats[3].level--;
    }

    private void updateHPPotionLabel()
    {
        var missingHP = student.getMissingHP();
        if (missingHP == 0)
        {
            hpPotion.text = "HP potion : MAX";
            hpPotionPrice.text = "X";
            upgradeStats[4].price = 0;
        }
        else
        {
            upgradeStats[4].price = missingHP / 2;
            hpPotion.text = "HP potion : " + missingHP;
            hpPotionPrice.text = upgradeStats[4].price.ToString();
        }
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