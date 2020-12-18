var fs = require('fs');

var lines = fs.readFileSync('input.txt', 'utf-8')
    .split('\n');

let x = 0;
let y = 0;
let treeCounter = 0;

let lineLength = lines[0].length;

while (lines.length > y) {
    let index = x % lineLength;
    if (lines[y][index] === '#')
        treeCounter++;

    y += 1
    x += 3

}

console.log(treeCounter);