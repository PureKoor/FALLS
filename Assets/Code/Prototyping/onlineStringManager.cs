
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.SDK3.StringLoading;
using VRC.Udon.Common.Interfaces;
using System.Text;

public class onlineStringManager : UdonSharpBehaviour
{
    [SerializeField] private VRCUrl url;
    [SerializeField] private TMPro.TextMeshProUGUI board;

    void Start()
    {
        Debug.Log("------- onlineStringManager Started -------");
        VRCStringDownloader.LoadUrl(url, (IUdonEventReceiver)this);
    }

    public override void OnStringLoadSuccess(IVRCStringDownload result)
    {
        //Different Ways to access successful data
        string resultAsUTF8 = result.Result;
        byte[] resultAsBytes = result.ResultBytes;
        string resultAsASCII = Encoding.ASCII.GetString(resultAsBytes);
        Debug.Log($"UTF8: {resultAsUTF8}");
        Debug.Log($"ASCII: {resultAsASCII}");
        board.text = "--- Result of grab is --- \n" + result.Result;
    }

    public override void OnStringLoadError(IVRCStringDownload result)
    {
        Debug.LogError($"Error loading string: {result.ErrorCode} - {result.Error}");
        board.text = "Board Bad :c -- Error: onlineStringManager";
    }
}
