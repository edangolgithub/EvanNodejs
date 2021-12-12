const http= require("http")
const fs= require("fs")

const writeStream=fs.createWriteStream("files/b.txt")

//readstream.pipe(writeStream);

const server=http.createServer((req,res)=>{
    const readstream=fs.createReadStream(__dirname+"/files/a.txt",'utf-8')
    res.writeHead(200,{'Content-Type':'text/plain'})
    readstream.pipe(res);
})
server.listen(3001,'127.0.0.1');