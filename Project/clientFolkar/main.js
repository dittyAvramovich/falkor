//<html>
//    <head>
//        <title>dropdown menu using select tab</title>
//    </head>

//    <body onload = load()>

//        <form>
//            <b> Select floor</b>
//            <select id="myList" onchange="favTutorial()" >
//                <option> ---Choose floor--- </option>
//                <option> w3schools </option>
//                <option> Javatpoint </option>
//                <option> tutorialspoint </option>
//                <option> geeksforgeeks </option>
//            </select>

//            <b>Select department</b>
//            <select id="myList" onchange="favTutorial()" >
//                <option> ---Choose floor--- </option>
//                <option> w3schools </option>
//                <option> Javatpoint </option>
//                <option> tutorialspoint </option>
//                <option> geeksforgeeks </option>
//            </select>

//        </form>

//        <div class="d-flex justify-content-center">
//            <div class="spinner-border"
//                role="status" id="loading">
//                <span class="sr-only">Loading...</span>
//            </div>
//        </div>
//        <h1>Registered Employees</h1>

//        <table id="employees"></table>
//    </body>
//</html>
window.onload = function () {
    const api_url = "https://localhost:7212/WeatherForecast";
    fetch(api_url)
      .then(response => response.json())
      .then(data => {
        // handle the response data here
        console.log(data);
      })
      .catch(error => {
        // handle any errors here
        console.error(error);
      }); 
};

function favTutorial() {
    var mylist = document.getElementById("myList");
    document.getElementById("favourite").value = mylist.options[mylist.selectedIndex].text;
}
function table() {
    var x = document.getElementById("myTable");
    x.deleteRow(0);
}
// api url
function load() {
    alert("loadd");
  
        const api_url = "https://localhost:7212/GetWeatherForecast";
        fetch(api_url)
          .then(response => response.json())
          .then(data => {
            // handle the response data here
            console.log(data);
          })
          .catch(error => {
            // handle any errors here
            console.error(error);
          }); 
}
// Function to hide the loader
function hideloader() {
    document.getElementById('loading').style.display = 'none';
}
// Function to define innerHTML for HTML table
function show(data) {
    let tab =
        `<tr>
          <th>שעת זימון</th>
          <th>כירורוגיה</th>
          <th>מוס</th>
          <th>עיניים</th>
          <th>עפעפיים</th>
         </tr>`;

    // Loop to access all rows
    for (let r of data.list) {
        tab += `<tr>
    <td>${r.name} </td>
    <td>${r.office}</td>
    <td>${r.position}</td>
    <td>${r.salary}</td>         
</tr>`;
    }
    // Setting innerHTML as tab variable
    document.getElementById("employees").innerHTML = tab;
}