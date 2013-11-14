var crypto = require("crypto");

function getsignature(appid, appkey, timestamp, nonce, content) {
    var arr = new Array(appid.toLowerCase(), appkey.toLowerCase());
    arr.sort();
    var appinfo = arr.join('');
    appinfo = crypto.createHash('md5').update(appinfo, 'utf8').digest('hex').toLowerCase();

    var sigArr = new Array(appinfo, timestamp.toLowerCase(), nonce.toLowerCase(), content.toLowerCase());
    sigArr.sort();
    var signature = sigArr.join('');
    signature = crypto.createHash('sha1').update(signature, 'utf8').digest('hex').toLowerCase();

    return signature;
};

exports.signature = getsignature;