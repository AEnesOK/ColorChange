using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler: MonoBehaviour
{
    AssetBundle myLoadAssetbundle;
    public string path;
    public string model;
    public Transform parent;
    public string assetBundleName;
    public string objectNameToLoad;
    
    public void AmIBoss()
    {
        StartCoroutine(LoadAsset(assetBundleName, objectNameToLoad));
    }
    IEnumerator LoadAsset(string assetBundleName, string objectNameToLoad)
    {
        string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "AssetBundles");
        filePath = System.IO.Path.Combine(filePath, assetBundleName);

      
        var assetBundleCreateRequest = AssetBundle.LoadFromFileAsync(filePath);
        yield return assetBundleCreateRequest;

        AssetBundle assetBundle = assetBundleCreateRequest.assetBundle;

        
        AssetBundleRequest asset = assetBundle.LoadAssetAsync<GameObject>(objectNameToLoad);
        yield return asset;

        
        GameObject loadedAsset = asset.asset as GameObject;
        GameObject newGO = GameObject.Instantiate(loadedAsset,parent) as GameObject;
       
    }
}