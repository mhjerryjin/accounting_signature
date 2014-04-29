using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
///Signature 的摘要说明
/// </summary>
public class Signature
{
    public string GetSignature(string appkey, string appsecret,
        string timestamp, string nonce, string content)
    {
        System.Collections.Generic.List<string> arr = new System.Collections.Generic.List<string>();
        arr.Add(appkey.ToLower());
        arr.Add(appsecret.ToLower());
        arr.Sort();
        string appinfo = string.Join(string.Empty, arr.ToArray());

        appinfo = GetMd5(appinfo).ToLower();

        arr.Clear();
        arr.Add(appinfo);
        arr.Add(timestamp.ToLower());
        arr.Add(nonce.ToLower());
        arr.Sort();
        //将content内容插到最开始部分
        arr.Insert(0, content.ToLower());

        string signature = string.Join(string.Empty, arr.ToArray());
        signature = GetSha1(signature).ToLower();

        return signature;
    }

    /// <summary>
    /// 返回MD5
    /// </summary>
    public string GetMd5(string str)
    {
        string md5Str = null;
        md5Str = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");

        return md5Str;
    }

    /// <summary>
    /// 返回SHA1
    /// </summary>
    public string GetSha1(string str)
    {
        string sha1Str = null;

        sha1Str = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "SHA1");

        return sha1Str;
    }
}