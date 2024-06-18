
var currentPage = 1;
var totalPages = 2; 

var allBtns = document.querySelectorAll('.btn-price-lists-pagination');
var btnsArray = [...allBtns]; 

btnsArray.forEach(el => {
    el.addEventListener("click", () => {
        let page = el.innerHTML;
        console.log(page);
        if (isNaN(page)) {
            if (page == "←") {
                console.log("enter <-");
                currentPage--;
                if (currentPage <= 0) {
                    currentPage = 1;
                }
            }
            if (page == "→") {
                console.log("enter ->");
                console.log("totalPages:" + totalPages);
                currentPage++;
                if (currentPage > totalPages) {
                    currentPage = totalPages;
                }
                console.log("currentPage:" + currentPage);
            }
            page = currentPage;
        }
        ajaxCallGetPriceLists(page);
    });
});

function ajaxCallGetPriceLists(page) {
    $.ajax({

        url:
            '/get_pice_lists_json',

        type: "GET",

        data: { page: page },

        success: function (data) {

            let x = JSON.stringify(data);
            const a = JSON.parse(x);
            fillTable(a);
        },

        error: function (error) {
            console.log(`Error ${error}`);
        }
    });
}

function fillTable(data) {
    let list = JSON.parse(data);
    currentPage = list.currentPage;
    totalPages = list.totalPages;
    console.log(list);
    let tableContent = '';
    list.data.forEach(el => {
        tableContent += `
            <tr>
                    <td>${el.Id}</td>
                    <td>${el.Name}</td>
            </tr>
        `;
    });
    let content = `
        <table class="table table-striped">
        <thead>
            <tr>
                <th scope="col">№</th>
                <th scope="col">Название</th>
            </tr>
        </thead>
        <tbody>
            ${tableContent}
        </tbody>
    </table>
    `;

    document.getElementById("price-lists-container").innerHTML = content;
}
