using NUnit.Framework;
using UnityEngine;

public class UnitTests_enemy
{
    private GameObject _gameObject;
    private Enemy _Enemy;
    private BlueEnemy _BlueEnemy;
    private RedEnemy _RedEnemy;
    private GreenEnemy _GreenEnemy;

    [SetUp]
    public void Setup()
    {
        _gameObject = new GameObject();
        _Enemy = _gameObject.AddComponent<Enemy>();
        _BlueEnemy = _gameObject.AddComponent<BlueEnemy>();
        _BlueEnemy.title = null;
        _RedEnemy = _gameObject.AddComponent<RedEnemy>();
        _RedEnemy.title = null;
        _GreenEnemy = _gameObject.AddComponent<GreenEnemy>();
        _gameObject.AddComponent<Animator>();
        _gameObject.AddComponent<Rigidbody2D>();
    }

    //Enemy tests
    [Test]
    public void SetFirePositionTest()
    {
        _Enemy.canMove = true;
        _Enemy.setFirePosition();
        Assert.Less(-17f, _Enemy.firePosition);
        Assert.Less(_Enemy.firePosition, 21f);
    }

    [Test]
    public void BlueTakeDamageTest()
    {
        _BlueEnemy.setRandomStats(0, 1);
        _BlueEnemy.takeDamage(5);
        var expected = 5;
        Assert.AreEqual(expected, _BlueEnemy.hp);
    }

    [Test]
    public void BlueSetRandomStatsTest()
    {
        _BlueEnemy.setRandomStats(0, 8);
        Assert.AreNotEqual(0, _BlueEnemy.hp);
        Assert.AreNotEqual(0, _BlueEnemy.speed);
        Assert.AreNotEqual(0, _BlueEnemy.damage);
        Assert.AreNotEqual(0, _BlueEnemy.value);
    }

    [Test]
    public void RedTakeDamageTest()
    {
        _RedEnemy.setRandomStats(0, 1);
        _RedEnemy.takeDamage(5);
        var expected = 5;
        Assert.AreEqual(expected, _RedEnemy.hp);
    }

    [Test]
    public void RedSetRandomStatsTest()
    {
        _RedEnemy.setRandomStats(0, 8);
        Assert.AreNotEqual(0, _RedEnemy.hp);
        Assert.AreNotEqual(0, _RedEnemy.speed);
        Assert.AreNotEqual(0, _RedEnemy.damage);
        Assert.AreNotEqual(0, _RedEnemy.value);
    }

    [Test]
    public void GreenSetRandomStatsTest()
    {
        _GreenEnemy.setRandomStats(0, 8);
        Assert.AreNotEqual(0, _GreenEnemy.hp);
        Assert.AreNotEqual(0, _GreenEnemy.damage);
        Assert.AreNotEqual(0, _GreenEnemy.value);
    }
}