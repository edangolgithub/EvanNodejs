const http= require("http")
const fs= require("fs")
const readstream=fs.createReadStream("public/text.txt",'utf-8')
const writeStream=fs.createWriteStream("public/write.txt")

readstream.on('data',chunk=>{
    console.log(chunk);
    writeStream.write(chunk);
})