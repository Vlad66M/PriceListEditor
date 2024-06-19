
var currentPage = 1;
var totalPages = 2; 

var allBtns = document.querySelectorAll('.btn-price-lists-pagination');
var btnsArray = [...allBtns]; 

btnsArray.forEach(el => {
    el.addEventListener("click", () => {
        let page = el.innerHTML;
        
        if (isNaN(page)) {
            if (page == "←") {
                
                currentPage--;
                if (currentPage <= 0) {
                    currentPage = 1;
                }
            }
            if (page == "→") {
                
                currentPage++;
                if (currentPage > totalPages) {
                    currentPage = totalPages;
                }
                
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
    
    let tableContent = '';
    list.data.forEach(el => {
        tableContent += `
            <tr>
                    <td>${el.Id}</td>
                    <td><a class="link-offset-2 link-underline link-underline-opacity-0" href="price_lists/${el.Id}">${el.Name}</a></td>
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
