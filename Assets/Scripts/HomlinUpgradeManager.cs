using System;
using UnityEngine;

public class HomlinUpgradeManager : MonoBehaviour {
    public GameUI GameUI;

    [SerializeField]
    private GameManager _gameManager;

    [SerializeField]
    private HomlinUpgradesConfig _upgradesConfig;

    [SerializeField]
    private Homlin _homlin;

    private void Start() {
        GameUI.InitHomlinUpgrades(_upgradesConfig);
    }

    public void UpgradeStrength() {
        if (_gameManager.FruitsCount >= _upgradesConfig.StrengthIncreaseCost) {
            _gameManager.FruitsCount -= _upgradesConfig.StrengthIncreaseCost;

            _homlin.Strength += _upgradesConfig.StrengthIncrease;
            _gameManager.UpdateCount();
        }
    }

    public void UpgradeSpeed() {
        if (_gameManager.MineralsCount >= _upgradesConfig.SpeedIncreaseCost) {
            _gameManager.MineralsCount -= _upgradesConfig.SpeedIncreaseCost;

            _homlin.Speed += _upgradesConfig.SpeedIncrease;

            _gameManager.UpdateCount();
        }
    }

    public void BuyHat() {
        if (_gameManager.MineralsCount >= _upgradesConfig.HatCostMinerals && _gameManager.FruitsCount >= _upgradesConfig.HatCostFruits) {
            _gameManager.MineralsCount -= _upgradesConfig.HatCostMinerals;
            _gameManager.FruitsCount -= _upgradesConfig.HatCostFruits;

            _homlin.ActivateHat();
            _gameManager.IsHatBought = true;
            _gameManager.UpdateCount();
        }
    }
}