function keepAliveFunc() {
    setTimeout("keepAlive()", 10000);
};

function keepAlive() {
    $.post("/Home/KeepAlive", null, function () { keepAliveFunc(); });
};