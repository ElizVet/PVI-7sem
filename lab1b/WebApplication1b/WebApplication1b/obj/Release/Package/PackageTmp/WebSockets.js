var ta;
var ws = null;
var bstart;
var bstop;

window.onload = function () {
    if (Modernizr.websockets) { // поддерживает ли браузер технологию вебсокет
        WriteMessage('support', 'yes');
        ta = document.getElementById('ta');
        bstart = document.getElementById('bstart');
        bstop = this.document.getElementById('bstop');
        bstart.disabled = false;
        bstop.disabled = true;
    }
}

function WriteMessage(idspan, txt) {
    document.getElementById(idspan).innerHTML = txt;
}

function exe_start() {
    if (ws == null) {
        try {
            ws = new WebSocket("ws://localhost:40001/websockets.websocket")
            ws.onopen = function () { ws.send('Connection'); }
            ws.onclose = function (s) { console.log('onclose', s); }
            ws.onmessage = function (evt) { ta.innerHTML += '\n' + evt.data; }
            bstart.disabled = true;
            bstop.disabled = false;
        } catch (error) {
            console.error(error);
        }

    }
}

function exe_stop() {
    try {
        ws.close(3001, 'stopapplication'); // польз-й код, текст-е соо
        ws = null;
        bstart.disabled = false;
        bstop.disabled = true;
    } catch (error) {
        console.error(error);
    }
}