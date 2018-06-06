var edge = require('edge-js');

var helloWorld = edge.func(`
    async (input) => { 
        return ".NET Welcomes " + input.ToString(); 
    }
`);
var helloWorld1 = edge.func(
    'async(input) => {' +
    'return "Hurray! Inline C# works with edge.js!!!";' +
    '}'
);
helloWorld1(10, function (error, result) {
    if (error) {
        console.log("error occured...");
        console.log(error);
        return;
    }
    console.log(result);
});
helloWorld('JavaScript', function (error, result) {
    if (error) throw error;
    console.log(result);
});

