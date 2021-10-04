using System;
using UnityEngine;
using System.Collections;

public class DownloadAssetBundles: MonoBehaviour
{
    public string BundleURL;
    public string AssetName;
    public int version;
    string url = "https://rgbkod.com/AssetBundles/";
    string tempUrl;
    public Transform Parent;
    bool control = false;
    string tempAssetname;

    public void LoadSingleClick(string assetName)
    {
            if (Parent.childCount >= 1)
            Destroy(Parent.GetChild(0).gameObject);

        StartCoroutine(DownloadAndCache(assetName));
    }

    IEnumerator DownloadAndCache(string assetName)
    {

        if (control)
        {
            Debug.Log("YOU CLICKED THE BUTTON MULTIPLE TIMES!!!");
        }
        else
        {
            while (!Caching.ready)
                yield return null;

            AssetBundle bundle;


            tempUrl = url + assetName + ".unity3d";
            using (WWW www = WWW.LoadFromCacheOrDownload(tempUrl, version))
            {
                yield return www;
                if (www.error != null)
                    throw new Exception("WWW download had an error:" + www.error);
                bundle = www.assetBundle;

                Instantiate(bundle.LoadAsset(assetName), Parent, false);
            }
            bundle.Unload(false);
            }
    }



}