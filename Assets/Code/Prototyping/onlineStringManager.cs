
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.SDK3.StringLoading;
using VRC.Udon.Common.Interfaces;
using System.Text;

public class onlineStringManager : UdonSharpBehaviour
{
    [SerializeField]
    private VRCUrl url;

    void Start()
    {
        VRCStringDownloader.LoadUrl(url, (IUdonEventReceiver)this);
    }

    public override void OnStringLoadSuccess(IVRCStringDownload result)
    {
        string resultAsUTF8 = result.Result;
        byte[] resultAsBytes = result.ResultBytes;
        string resultAsASCII = Encoding.ASCII.GetString(resultAsBytes);
        Debug.Log($"UTF8: {resultAsUTF8}");
        Debug.Log($"ASCII: {resultAsASCII}");
    }

    public override void OnStringLoadError(IVRCStringDownload result)
    {
        Debug.LogError($"Error loading string: {result.ErrorCode} - {result.Error}");
    }
}
