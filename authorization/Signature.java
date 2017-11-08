package com.mingdao;

import java.security.MessageDigest;


public class Signature {

    /**
     * 获得签名
     *
     * @param secret    SecretKey
     * @param timestamp UTC时间戳（精度为毫秒）
     * @return
     */
    public static String getSignature(String secret, long timestamp) {

        return Signature.SHA256(secret + timestamp);

    }

    /**
     * SHA256加密
     *
     * @param strText
     * @return
     */
    public static String SHA256(final String strText) {

        String strResult = null;

        if (strText != null && strText.length() > 0) {
            try {
                MessageDigest messageDigest = MessageDigest.getInstance("SHA-256");
                messageDigest.update(strText.getBytes("UTF-8"));
                byte byteBuffer[] = messageDigest.digest();

                StringBuffer strHexString = new StringBuffer();
                for (int i = 0; i < byteBuffer.length; i++) {
                    String hex = Integer.toHexString(0xff & byteBuffer[i]);
                    if (hex.length() == 1) {
                        strHexString.append('0');
                    }
                    strHexString.append(hex);
                }
                strResult = strHexString.toString();
            } catch (Exception e) {
                e.printStackTrace();
            }
        }

        return strResult;
    }

    public static void main(String[] args) {
        Signature.getSignature("dsfsdf",123123L);
    }

}