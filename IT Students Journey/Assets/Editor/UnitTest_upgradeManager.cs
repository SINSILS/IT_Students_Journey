using ClearSky;
using NUnit.Framework;
using UnityEngine;

public class UnitTest_upgradeManager : MonoBehaviour
{
    private GameObject _gameObject;
    private StudentController _studentController;
    private UpgradeManager _upgradeManager;

    [SetUp]
    public void Setup()
    {
        _gameObject = new GameObject();
        _studentController = _gameObject.AddComponent<StudentController>();
        _upgradeManager = _gameObject.AddComponent<UpgradeManager>();
        _gameObject.AddComponent<Animator>();
        _gameObject.AddComponent<Rigidbody2D>();
        _studentController.addCoins(1000);
        _upgradeManager.setStudent(_studentController);
    }

    //studentController tests
    [Test]
    public void SetSceneIndexTest()
    {
        int expectedSceneIndex = 3;
        _upgradeManager.setSceneIndex(expectedSceneIndex);
        Assert.AreEqual(expectedSceneIndex, _upgradeManager.getSceneIndex());
    }

    [Test]
    public void UpgradeMaxHPTest()
    {
        _upgradeManager.upgradeMaxHP();
        var expectedHP = 60;
        var expectedCoins = 990;
        Assert.AreEqual(expectedHP, _studentController.getMaxHP());
        Assert.AreEqual(expectedCoins, _studentController.getCoins());
    }

    [Test]
    public void DowngradeMaxHPTest()
    {
        _upgradeManager.downgradeMaxHP();
        var expectedHP = 40;
        var expectedCoins = 1000;
        Assert.AreEqual(expectedHP, _studentController.getMaxHP());
        Assert.AreEqual(expectedCoins, _studentController.getCoins());
    }

    [Test]
    public void UpgradeSpeedTest()
    {
        _upgradeManager.upgradeSpeed();
        var expectedSpeed = 11f;
        var expectedCoins = 990;
        Assert.AreEqual(expectedSpeed, _studentController.getSpeed());
        Assert.AreEqual(expectedCoins, _studentController.getCoins());
    }

    [Test]
    public void DowngradeSpeedTest()
    {
        _upgradeManager.downgradeSpeed();
        var expectedSpeed = 9f;
        var expectedCoins = 1000;
        Assert.AreEqual(expectedSpeed, _studentController.getSpeed());
        Assert.AreEqual(expectedCoins, _studentController.getCoins());
    }

    [Test]
    public void UpgradePowerTest()
    {
        _upgradeManager.upgradePower();
        var expectedPower = 10;
        var expectedCoins = 990;
        Assert.AreEqual(expectedPower, _studentController.getPower());
        Assert.AreEqual(expectedCoins, _studentController.getCoins());
    }

    [Test]
    public void DowngradePowerTest()
    {
        _upgradeManager.downgradePower();
        var expectedPower = 0;
        var expectedCoins = 1000;
        Assert.AreEqual(expectedPower, _studentController.getPower());
        Assert.AreEqual(expectedCoins, _studentController.getCoins());
    }

    [Test]
    public void UpgradeFireRateTest()
    {
        _upgradeManager.upgradeFireRate();
        var expectedFireRate = 0.9;
        var expectedCoins = 990;
        Assert.AreEqual(expectedFireRate, _studentController.getFireRate());
        Assert.AreEqual(expectedCoins, _studentController.getCoins());
    }

    [Test]
    public void DowngradeFireRateTest()
    {
        _upgradeManager.downgradeFireRate();
        var expectedFireRate = 1.1;
        var expectedCoins = 1000;
        Assert.AreEqual(expectedFireRate, _studentController.getFireRate());
        Assert.AreEqual(expectedCoins, _studentController.getCoins());
    }

    [Test]
    public void ResetHealthTest()
    {
        _studentController.takeDamage(20);
        _upgradeManager.resetHealth();
        var expectedCurrentHP = 50;
        var expectedCoins = 990;
        Assert.AreEqual(expectedCurrentHP, _studentController.getCurrentHP());
        Assert.AreEqual(expectedCoins, _studentController.getCoins());
    }
}
