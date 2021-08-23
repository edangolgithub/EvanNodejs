var buf = new Buffer.from([10, 20, 30, 40, 50,5,11],"ascii");

console.log(buf.length);
var json = buf.toJSON(buf);

console.log(json);