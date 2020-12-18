var fs = require('fs');

var lines = fs.readFileSync('input.txt', 'utf-8')
    .split('\n');

const countTrees = (xSlip, ySlip) => {
    let x = 0;
    let y = 0;
    let treeCounter = 0;

    let lineLength = lines[0].length;

    while (lines.length > y) {
        let index = x % lineLength;
        if (lines[y][index] === '#')
            treeCounter++;

        x += xSlip
        y += ySlip
    }
    return treeCounter;
}

let c1 = countTrees(1, 1)
let c2 = countTrees(3, 1)
let c3 = countTrees(5, 1)
let c4 = countTrees(7, 1)
let c5 = countTrees(1, 2)

console.log(`${c1} ${c2} ${c3}  ${c4} ${c5}`)
console.log(c1 * c2 * c3 * c4 * c5)