using _SlimeCatch.Enemy;
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
            await GetWeaponInfo();
        }
        
        [MenuItem("MData更新/武器情報")]
        private static async void WeaponUpdateWindow()
        {
            await GetEnemyInfo();
        }

        private static async UniTask<EnemyResponseClass> GetEnemyInfo()
        {
            var request = UnityWebRequest.Get($"{SlimeCatchDataApiUrl}?sheetName=敵情報");
            await request.SendWebRequest();
            if (request.isHttpError || request.isNetworkError)
            {
                Debug.LogError($"APIからの取得エラー->:{request.error}");
            }
            else
            {
                var json = request.downloadHandler.text;
                Debug.Log($"json:{json}");
                var data = JsonUtility.FromJson<EnemyResponseClass>(json);
                return data;
            }

            return null;
        }
        
        private static async UniTask<WeaponResponseClass> GetWeaponInfo()
        {
            var request = UnityWebRequest.Get($"{SlimeCatchDataApiUrl}?sheetName=武器詳細");
            await request.SendWebRequest();
            if (request.isHttpError || request.isNetworkError)
            {
                Debug.LogError($"APIからの取得エラー->:{request.error}");
            }
            else
            {
                var json = request.downloadHandler.text;
                Debug.Log($"json:{json}");
                var data = JsonUtility.FromJson<WeaponResponseClass>(json);
                return data;
            }

            return null;
        }
    }
}