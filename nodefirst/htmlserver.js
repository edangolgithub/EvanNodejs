const http= require("http")
const fs= require("fs")

const writeStream=fs.createWriteStream("files/b.txt")

//readstream.pipe(writeStream);

const server=http.createServer((req,res)=>{
    const readstream=fs.createReadStream(__dirname+"/index.html",'utf-8')
    res.writeHead(200,{'Content-Type':'text/html'})
    readstream.pipe(res);
})
server.listen(3001,'127.0.0.1');