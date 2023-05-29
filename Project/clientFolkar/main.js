const api_url = "https://localhost:7212/WeatherForecast";
var floor;
var dep;
window.onload = function () {
    $('#myFloorsSelect').append($('<option>', {
        value: -1,
        text: "בחר קומה"
      } ));
    fetch(api_url)
        .then(response => response.json())
        .then(data => {
            $.each(data, function(index, value) {
  $('#myFloorsSelect').append($('<option>', {
                  value: index+1,
                  text: value.name
                } )); 
            });
            $('#myFloorsSelect').on('change', function() {
                var floorId = $(this).val();
                getDep(floorId);
                floor=floorId;
                $('#myDepSelect').removeData();
            }); 
            if (data != null) {
                //createTable(data);
            }
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

function getDep(floorId) {
    $('#myDepSelect').empty();
    $('#myDepSelect').append($('<option>', {
        value: -1,
        text: "בחר מחלקה"
      } ));
    fetch(`${api_url}/${floorId}`)
        .then(response => response.json())
        .then(data => {
            $.each(data, function(index, value) {
                $('#myDepSelect').append($('<option>', {
                  value: index+1,
                  text: value.department_desc
                } ));
            });
            $('#myFloorsSelect').on('change', function() {
                dep = $(this).val();
            });
            if (data != null) {
                //createTable(data);
            }
            console.log(data);
        })
        .catch(error => {
            // handle any errors here
            console.error(error);
        });
}
function showData() {
    fetch(`${api_url}/${floor}/${dep}`)
        .then(response => response.json())
        .then(data => {
            if (data != null) {
                //createTable(data);
            }
            console.log(data);
        })
        .catch(error => {
            console.error(error);
        });
}
function createTable(data) {

    $("#searchdiv")
        .append(`<div id="resultSearchdiv" style="box-shadow: -1px 1px 1px 1px rgb(0 0 0 / 30%)";"><br> 
<div class="FormFrameTitle">
<lable border="0" cellpadding="0" cellspacing="0" style="width: 97%" class="NoWrap">${getJsonValue('resultsSearch', 'search results:')}</lable></div>`);
    $("#resultSearchdiv")
        .append(`<div style="margin:2%"> 
<div class="FormFrameTitle">
<lable border="0" cellpadding="0" cellspacing="0" style="width: 97%" class="NoWrap">${getJsonValue('contenTtemplatesSearch', 'Content templates:')}</lable>
</div>
 <table id="tableSearchTem" border="0" cellpadding="1" cellspacing="1" class="List">
         <thead class="ListTitle">
           <tr>
              <th class="ListTitle"  style="white-space: nowrap; width: 25%;" valign="top">
             ${getJsonValue('contentTemplateName', 'Content template name')} 
              </th>
              <th class="ListTitle" valign="top" scope="col" >
                 ${getJsonValue('objectType', 'Level / Object type')}
              </th>
              <th class="ListTitle" style="width: 30%;" valign="top" scope="col">
               ${getJsonValue('defaultValue', 'Default value')}   
              </th>
              <th class="ListTitle"  style="white-space: nowrap" valign="top">
               ${getJsonValue('Language', 'Language')}  
              </th >
           </tr>  
         </thead>
  </table> 
</div><br>`);
    $("#resultSearchdiv")
        .append(`<div style="margin:2%"> 
     <div class="FormFrameTitle">
      <lable border="0" cellpadding="0" cellspacing="0" style="width: 97%" class="NoWrap">${getJsonValue('contenItemlatesSearch', 'Content item:')}</lable> 
     </div>
       <table id="tableSearchItem" border="0" cellpadding="1" cellspacing="1" class="List">
         <thead class="ListTitle">
           <tr>
              <th class="ListTitle"  style="white-space: nowrap; width: 25%;" valign="top">
                ${getJsonValue('contentItemName', 'Content item name')}
              </th>
              <th class="ListTitle"  style="white-space: nowrap; width: 25%;" valign="top">
                 ${getJsonValue('objectType', 'Level / Object type')} 
              </th>
               <th class="ListTitle"  style="white-space: nowrap; width: 25%;" valign="top">
                 ${getJsonValue('Object', 'Object')} 
              </th>
            <th class="ListTitle"  style="white-space: nowrap; width: 25%;" valign="top">
                 ${getJsonValue('defaultValue', 'Default value')}
              </th >
            <th class="ListTitle"  style="white-space: nowrap;" valign="top">
                 ${getJsonValue('Language', 'Language')}  
              </th >
           </tr>  
           </thead>
        </table> 
    </div><br>`);
    result.forEach(
        element => {
            if (!element.IsContentItem) {
                http = `${window.urlRelativePathBase}Design/ContentTemplates.aspx?id=${element.ContentTemplateId}`
                $('#tableSearchTem')
                    .append(`
    <tr class="ListRow" style="height: 48px">
       <td style="white-space: nowrap" valign="top">
          ${element.ParameterName} 
       </td>
       <td style="white-space: nowrap" valign="top">
          ${getJsonValue(`${element.ObjectType}ObjectType`, `${element.ObjectType}`)} 
       </td>
       <td  style="white-space: nowrap" valign="top" >
         <a href="${http}" target="_blank">
          ${element.Value} 
         </a>
       </td>
       <td style="white-space: nowrap" valign="top">
         ${element.LanguageCode}
       </td>        
    </tr>`)
            }
            else {
                http = `${window.urlRelativePathBase}Design/ContentManagement.aspx?obj=${element.ObjectType}&id=${element.ObjectId}&lang=${element.LanguageCode}&val=${element.ParameterName}`
                $('#tableSearchItem')
                    .append(`
    <tr class="ListRow" style="height: 48px">
       <td style="white-space: nowrap" valign="top">
          ${element.ParameterName} 
       </td>
      <td style="white-space: nowrap" valign="top">
           ${getJsonValue(`${element.ObjectType}ObjectType`, `${element.ObjectType}`)} 
       </td>
       <td style="white-space: nowrap" valign="top">
          ${element.ObjectName} 
       </td>
       <td style="white-space: nowrap" valign="top">
         <a href="${http}" target="_blank">
          ${element.Value} 
         </a>
       </td>
       <td style="white-space: nowrap" valign="top">
         ${element.LanguageCode}
       </td>        
    </tr>`)
            }
        });
    backgroundOdd();
};

// api url

// Function to hide the loader
function hideloader() {
    document.getElementById('loading').style.display = 'none';
}


