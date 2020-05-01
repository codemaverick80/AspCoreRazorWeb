


$(document).ready(function () {

    // GetArtistsUsingXMLHttp();

   // GetArtistsUsingFethApi();

   GetArtistsUsingFethApiAsync();

});

//======== V1 Callback with XMLHttpRequest =======

function GetArtistsUsingXMLHttp() {

    const http = new storeXMLHttpRequest(); 

    http.get('/api/artist', callback);   

}

function callback(error, response) {
    if (error) {
        console.log(error);
        document.querySelector('#dataTable').innerHTML =
            ` <div class="alert alert-danger" role="alert">
                    ${error}
                </div>
          `;

    } else {
        let json = JSON.parse(response);
        generateDataTable(json.data);
    }
} 




//======== V2 Fetch api (without callback) =======

function GetArtistsUsingFethApi() {
    const http = new storeFetchApi();
    http.get('/api/artist')
        .then(data => generateDataTable(data.data))
        .catch(err => showError(err));
}


//======== V3 Fetch api Async =======

function GetArtistsUsingFethApiAsync() {
    const http = new storeFetchAsync();
    http.get('/api/artist')
        .then(data => generateDataTable(data.data))
        .catch(err => showError(err));
}
    



//======== Populate table ============

function generateDataTable(data) {
    const datatable = document.querySelector('#dataTable');


    let table = `
        <table class="table">
        <thead>
            <tr>
                <th>Artist Name</th>
                <th>YearActive</th>
                <th>Actions</th>
            </tr>
        </thead>
        <tbody>`;

  
    data.forEach(function (artist) {
        table += `
                <tr>
                    <td>${artist.name}</td>
                    <td>${artist.yearActive}</td>
                    <td>
                    <a href="artist/index" data-id="${artist.id}">Edit</a> |
                    <a href="artist/Details" data-id="${artist.id}">Details</a> |
                    <a href="artist/Delete" data-id="${artist.id}">Delete</a>
                    </td>
                </tr> `;
    });
                          

    table +=`</tbody></table>`;

    datatable.innerHTML = table;  
}

function showError(err) {

    document.querySelector('#dataTable').innerHTML =
        ` <div class="alert alert-danger" role="alert">
                    ${err}
                </div>
          `;
}







