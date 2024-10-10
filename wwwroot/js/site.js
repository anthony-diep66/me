// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const THRESHOLD_WIDTH = 1200


const sideColumn = document.querySelector(".side-column");
const sideColumnBoxes = Array.from(document.querySelectorAll(".sbox"));


window.onresize = window.onload = function () {
    if (this.innerWidth <= THRESHOLD_WIDTH) {
        sideColumnBoxes.forEach(box => {
            box.classList.replace('sbox', 'mbox')
            console.log(box.className)
        })
        sideColumn.className = "main-column"
    }
    else {
        sideColumnBoxes.forEach(box => {
            box.classList.replace('mbox', 'sbox')
        })
        sideColumn.className = "side-column"
    }
}
s