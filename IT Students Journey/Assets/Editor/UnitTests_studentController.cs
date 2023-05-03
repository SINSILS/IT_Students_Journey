using ClearSky;
using NUnit.Framework;
using UnityEngine;

public class UnitTests_studentController
{
    private GameObject _gameObject;
    private StudentController _studentController;
    private Enemy _Enemy;

    [SetUp]
    public void Setup()
    {
        _gameObject = new GameObject();
        _studentController = _gameObject.AddComponent<StudentController>();
        _gameObject.AddComponent<Animator>();
        _gameObject.AddComponent<Rigidbody2D>();
    }

    //studentController tests
    [Test]
    public void TakeDamage()
    {
        int hp = 50;
        int damage = 10;
        _studentController.takeDamage(damage);
        Assert.AreEqual(hp - damage, _studentController.getCurrentHP());
    }

    [Test]
    public void SetSceneIndexTest()
    {
        int expectedSceneIndex = 3;
        _studentController.setSceneIndex(expectedSceneIndex);
        Assert.AreEqual(expectedSceneIndex, _studentController.getSceneIndex());
    }

    [Test]
    public void GetSceneIndexTest()
    {
        _studentController.setSceneIndex(1);
        Assert.AreEqual(1, _studentController.getSceneIndex());
    }

    [Test]
    public void DieTest()
    {
        _studentController.takeDamage(55);
        Assert.IsFalse(_studentController.isAlive());
    }

    [Test]
    public void GetMaxHPTest()
    {
        int expected = 50;
        Assert.AreEqual(expected, _studentController.getMaxHP());
    }

    [Test]
    public void GetSpeedTest()
    {
        float expected = 10f;
        Assert.AreEqual(expected, _studentController.getSpeed());
    }

    [Test]
    public void GetPowerTest()
    {
        int expected = 5;
        Assert.AreEqual(expected, _studentController.getPower());
    }

    [Test]
    public void GetFireRateTest()
    {
        double expected = 1.0;
        Assert.AreEqual(expected, _studentController.getFireRate());
    }

    [Test]
    public void GetMissingHPTest()
    {
        _studentController.takeDamage(10);
        int expected = 10;
        Assert.AreEqual(expected, _studentController.getMissingHP());
    }

    [Test]
    public void GetCurrentHPTest()
    {
        _studentController.takeDamage(10);
        int expected = 40;
        Assert.AreEqual(expected, _studentController.getCurrentHP());
    }

    [Test]
    public void GetCoinsTest()
    {
        _studentController.addCoins(10);
        Assert.AreNotEqual(0, _studentController.getCoins());
    }

    [Test]
    public void AddCoinsTest()
    {
        _studentController.addCoins(10);
        int expected = 10;
        Assert.AreEqual(expected, _studentController.getCoins());
    }

    [Test]
    public void PayCoinsTest()
    {
        _studentController.addCoins(30);
        _studentController.payCoins(10);
        int expected = 20;
        Assert.AreEqual(expected, _studentController.getCoins());
    }

    [Test]
    public void UpdateMaxHPTest()
    {
        _studentController.updateMaxHP(10);
        int expected = 60;
        Assert.AreEqual(expected, _studentController.getMaxHP());
    }

    [Test]
    public void UpdateSpeedTest()
    {
        _studentController.updateSpeed(5f);
        float expected = 15f;
        Assert.AreEqual(expected, _studentController.getSpeed());
    }

    [Test]
    public void UpdatePowerTest()
    {
        _studentController.updatePower(25);
        int expected = 30;
        Assert.AreEqual(expected, _studentController.getPower());
    }

    [Test]
    public void UpdateFireRateTest()
    {
        _studentController.updateFireRate(0.2);
        double expected = 0.8;
        Assert.AreEqual(expected, _studentController.getFireRate());
    }

    [Test]
    public void ResetHealthTest()
    {
        _studentController.takeDamage(25);
        _studentController.resetHealth();
        int expected = 50;
        Assert.AreEqual(expected, _studentController.getCurrentHP());
    }

    [Test]
    public void IsAliveTest()
    {
        _studentController.takeDamage(50);
        Assert.False(_studentController.isAlive());
    }
}