var net = require('net');

var server = net.createServer(function (socket) { //Create the server and pass it the function which will write our data
    socket.write("Hello\n");
    socket.write("World!\n");
    socket.end("End of communications.");
});

server.listen(3000);
//This is the port number we're listening to
console.log('running at port 3000');