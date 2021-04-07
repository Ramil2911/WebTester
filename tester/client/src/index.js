import {edit} from "ace-builds";
import 'ace-builds/src-noconflict/mode-csharp'
import 'ace-builds/src-noconflict/theme-dracula'

let editor;

function SetupEditor()
{
    editor = edit("editor");
    editor.setTheme("ace/theme/dracula")
    editor.session.setMode("ace/mode/csharp");
    editor.setShowPrintMargin(false);
}

function Run() {return editor.getValue()}

function log(txt){
    var newLine = document.createElement("li");
    newLine.innerHTML = (typeof txt === 'string') ? txt : JSON.stringify(txt, null, 4);
    document.querySelector('#console').appendChild(newLine);
}

window.Run = Run;
window.SetupEditor = SetupEditor;
window.log = log;