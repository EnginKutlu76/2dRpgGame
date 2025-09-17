using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;
using System;

public class AddressablesManager : MonoBehaviour
{
    [SerializeField] private AssetReference _assetReference;
    [SerializeField] private Button _loadAssetBtn;
    [SerializeField] private Button _releaseAssetBtn;

    private GameObject _spawnedEnvironment;
    private AsyncOperationHandle<GameObject>? _handle;

    private void Awake()
    {
        _loadAssetBtn.onClick.AddListener(LoadAsset);
        _releaseAssetBtn.onClick.AddListener(ReleaseAsset);
    }

    private void LoadAsset()
    {
        if (_spawnedEnvironment != null)
        {
            Debug.LogWarning("Asset zaten spawn edilmiþ!");
            return;
        }

        // Async instantiate
        _handle = _assetReference.InstantiateAsync();
        _handle.Value.Completed += handle =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                _spawnedEnvironment = handle.Result;
            }
            else
            {
                Debug.LogError("Asset yüklenemedi!");
            }
        };
    }

    private void ReleaseAsset()
    {
        if (_spawnedEnvironment != null && _handle.HasValue)
        {
            _assetReference.ReleaseInstance(_spawnedEnvironment);
            _spawnedEnvironment = null;
            _handle = null;
        }
        else
        {
            Debug.LogWarning("Release edilecek asset yok!");
        }
    }
}
