const http= require("http")




const server=http.createServer((req,res)=>{
  
    res.writeHead(200,{'Content-Type':'application/json'})

    const person={
        name:"alex",
        email:"alex@gmail.com"
    };
    res.end(JSON.stringify(person))
    
})
server.listen(3001,'127.0.0.1');