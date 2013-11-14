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
        arr.Add(content.ToLower());
        arr.Sort();

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

        //System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
        //byte[] s = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(str));
        //for (int i = 0; i < s.Length; i++)
        //{
        //    md5Str = md5Str + s[i].ToString("X");
        //}

        md5Str = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");

        return md5Str;
    }

    /// <summary>
    /// 返回SHA1
    /// </summary>
    public string GetSha1(string str)
    {
        string sha1Str = null;

        //System.Security.Cryptography.SHA1 sha1 = System.Security.Cryptography.SHA1CryptoServiceProvider.Create();
        //byte[] s = sha1.ComputeHash(System.Text.Encoding.UTF8.GetBytes(str));
        //sha1Str = BitConverter.ToString(s).Replace("-", string.Empty);

        sha1Str = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "SHA1");

        return sha1Str;
    }
}