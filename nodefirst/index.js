var fs = require("fs");


fs.readFile('input1.txt', function (err, data) {
   if (err) return console.error(err);
   console.log(data.toString());
});

console.log("Program Ended1");


var data = fs.readFileSync('input.txt');

console.log(data.toString());
console.log("Program Ended2");