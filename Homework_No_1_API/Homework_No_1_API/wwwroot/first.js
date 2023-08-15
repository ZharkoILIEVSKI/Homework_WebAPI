let request = document.getElementById("request");


let url = "https://localhost:7238/api/Users/Get";
     let getAllData = async () => {

         let response = await fetch(url);
         let data = await response.json();

         console.log(data)
         document.body.innerHTML = data[0] + " " + data[1] + " " + data[2]
       
     };

request.addEventListener("click", getAllData);