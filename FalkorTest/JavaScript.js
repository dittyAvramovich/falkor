
    window.onload = function () {
        alert("iiiiii");
        const api_url =
            "https://localhost:7051/getFloors";

        // Defining async function
        async function getapi(url) {

            // Storing response
            const response = await fetch(url);

            // Storing data in form of JSON
            var data = await response.json();
            console.log(data);
            if (response) {
                hideloader();
            }
            show(data);
        }
        // Calling that async function
        getapi(api_url);

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
    const api_url =
        "https://localhost:7051/api/getFloors";

    // Defining async function
    async function getapi(url) {

        // Storing response
        const response = await fetch(url);

        // Storing data in form of JSON
        var data = await response.json();
        console.log(data);
        if (response) {
            hideloader();
        }
        show(data);
    }
    // Calling that async function
    getapi(api_url);
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