using System;
using _SlimeCatch.Enemy;
using _SlimeCatch.Wave;
using _SlimeCatch.Weapon;
using Cysharp.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

namespace _SlimeCatch.Editor
{
    public class GetMasterData : EditorWindow
    {
        private const string SlimeCatchDataApiUrl = "https://script.google.com/macros/s/AKfycbxpW4e9iRKK1i8Jyy-stqgAo72jOrIByOZP1VDOckCFC-NgnY_82eId_s_xzzj5vOI7/exec";
        [MenuItem("MData更新/敵情報")]
        private static async void EnemyUpdateWindow()
        {
            var response = await GetData<EnemyResponseClass>("敵情報");
            CreateEnemyObject(response);
        }
        
        
        [MenuItem("MData更新/武器情報")]
        private static async void WeaponUpdateWindow()
        {
            var response = await GetData<WeaponResponseClass>("武器情報");
            CreateWeaponObject(response);
        }
        
        [MenuItem("MData更新/Wave情報")]
        private static async void WaveUpdateWindow()
        {
            var response = await GetData<WaveResponseClass>("Wave情報");
            CreateWaveObject(response);
        }
        
        private static async UniTask<T> GetData<T>(string sheetName)
        {
            var request = UnityWebRequest.Get($"{SlimeCatchDataApiUrl}?sheetName={sheetName}");
            await request.SendWebRequest();
            if (request.isHttpError || request.isNetworkError)
            {
                Debug.LogError($"APIからの取得エラー->:{request.error}");
            }
            else
            {
                var json = request.downloadHandler.text;
                var data = JsonUtility.FromJson<T>(json);
                return data;
            }

            return default;
        }

        private static void CreateEnemyObject(EnemyResponseClass enemyResponseClass)
        {
            foreach (var info in enemyResponseClass.slimeCatchInfoList)
            {
                var instance = CreateInstance<EnemyObject>();
                instance.BaseWeapon = (WeaponEnum)Enum.Parse(typeof(WeaponEnum),info.BaseWeapon);
                instance.SpecialWeapon = (WeaponEnum)Enum.Parse(typeof(WeaponEnum),info.SpecialWeapon);
                instance.EnemyName = info.Name;
                instance.EnemySize = info.EnemySize;
                
                AssetDatabase.CreateAsset(instance,$"Assets/_SlimeCatch/Resources/Enemy/{info.Name}.asset");
                AssetDatabase.Refresh();
            }
        }

        private static void CreateWeaponObject(WeaponResponseClass weaponResponseClass)
        {
            foreach (var info in weaponResponseClass.slimeCatchInfoList)
            {
                var instance = CreateInstance<WeaponObject>();
                instance.WeaponName = (WeaponEnum)Enum.Parse(typeof(WeaponEnum),info.Name);
                instance.WeaponOrbit = (WeaponOrbitEnum)Enum.Parse(typeof(WeaponOrbitEnum),info.Orbit);
                
                AssetDatabase.CreateAsset(instance,$"Assets/_SlimeCatch/Resources/Weapon/{info.Name}.asset");
                AssetDatabase.Refresh();
            }
        }

        private static void CreateWaveObject(WaveResponseClass waveResponseClass)
        {
            foreach (var info in waveResponseClass.slimeCatchInfoList)
            {
                var instance = CreateInstance<WaveObject>();
                instance.StageName = (WaveEnum)Enum.Parse(typeof(WaveEnum),info.StageName);
                instance.SlimeCount = info.SlimeCount;
                instance.WaveCount = info.WaveCount;
                
                AssetDatabase.CreateAsset(instance,$"Assets/_SlimeCatch/Resources/Wave/{info.StageName}.asset");
                AssetDatabase.Refresh();
            }
        }
    }
}
