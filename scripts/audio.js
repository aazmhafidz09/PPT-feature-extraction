function base64ToArrayBuffer(base64) {
    let binaryString = window.atob(base64);
    let binaryLen = binaryString.length;
    let bytes = new Uint8Array(binaryLen);
    for (let i = 0; i < binaryLen; i++) {
        let ascii = binaryString.charCodeAt(i);
        bytes[i] = ascii;
    }
    return bytes;
}

function loadAudio(data, containerId) {
    let bytes = base64ToArrayBuffer(data);
    let blob = new Blob([bytes], { type: 'audio/wav' });
    let url = window.URL.createObjectURL(blob);
    let audio = document.createElement('audio');
    audio.controls = true;
    audio.src = url;
    let audioContainer = document.getElementById(containerId);
    audioContainer.textContent = '';
    audioContainer.appendChild(audio);
}
