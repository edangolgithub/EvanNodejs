var express = require('express');
//var app = express();
//var server = app.listen(3456, function () {
//    var host = server.address().address;
//    var port = server.address().port;
//    console.log('running at http://' + host + ':' + port)
//});



//const app = express();

//app.get('/', (req, res) => res.send('Hello World!'));

//app.listen(3000, () => console.log('Example app listening on port 3000!'));



var express = require("express");
var app = express();

/* serves main page */
app.get("/", function (req, res) {
    res.sendfile('index.htm')
});

app.post("/user/add", function (req, res) {
    /* some server side logic */
    res.send("OK");
});

/* serves all the static files */
app.get(/^(.+)$/, function (req, res) {
    console.log('static file request : ' + req.params);
    res.sendfile(__dirname + req.params[0]);
});

var port = process.env.PORT || 5000;
app.listen(port, function () {
    console.log("Listening on " + port);
});