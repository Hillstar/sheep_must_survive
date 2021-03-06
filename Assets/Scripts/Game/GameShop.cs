﻿using System;
using Game;
using Game.Character;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace Game
{
    public class GameShop : MonoBehaviour
    {
        public CharacterWeaponControl characterWeaponControl;
        public CharacterHealth characterHealth;
        public Animator canvasAnimator;
        public GameObject shotgunPrice;
        public GameObject riflePrice;
        public GameObject laserPrice;
        public GameObject restoreHpButton;
        
        private bool _shotgunBought = false;
        private bool _rifleBought = false;
        private bool _laserBought = false;

        private void Update()
        {
            if (GameManager.gameState != GameStates.WaveEnded) return;
            GameManager.gameState = GameStates.Break;
            canvasAnimator.SetTrigger("BreakStart");
            restoreHpButton.SetActive(characterHealth.curHealth < characterHealth.maxHealth);
        }
        
        public void RestoreHp()
        {
            if (characterHealth.curHealth < characterHealth.maxHealth && GameManager.money >= 300)
            {
                var newHp = characterHealth.curHealth + 10;
                if (newHp > 50)
                    characterHealth.curHealth = 50;
                else
                {
                    characterHealth.curHealth = newHp;
                }

                GameManager.money -= 300;
            }
        }
    
        public void SelectPistol()
        {
            characterWeaponControl.SelectWeapon(WeaponTypes.Pistol);
        }
    
        public void SelectShotgun()
        {
            if (!_shotgunBought && GameManager.money >= 700)
            {
                _shotgunBought = true;
                GameManager.money -= 700;
                shotgunPrice.gameObject.SetActive(false);
            }
            
            if(_shotgunBought)
                characterWeaponControl.SelectWeapon(WeaponTypes.Shotgun);
        }
        
        public void SelectRifle()
        {
            if (!_rifleBought && GameManager.money >= 2000)
            {
                _rifleBought = true;
                GameManager.money -= 2000;
                riflePrice.gameObject.SetActive(false);
            }
            
            if(_rifleBought)
                characterWeaponControl.SelectWeapon(WeaponTypes.Rifle);
        }
        
        public void SelectLaser()
        {
            if (!_laserBought && GameManager.money >= 3000)
            {
                _laserBought = true;
                GameManager.money -= 3000;
                laserPrice.gameObject.SetActive(false);
            }
            
            if(_laserBought)
                characterWeaponControl.SelectWeapon(WeaponTypes.Laser);
        }

        public void GoNextWave()
        {
            canvasAnimator.SetTrigger("BreakStop");
            GameManager.gameState = GameStates.BreakEnded;
        }
    }
}
