
var currentPage = 1;
var totalPages = 2;
let priceListId = document.getElementById("price-list-id").value;

var allBtns = document.querySelectorAll('.btn-price-list-pagination');
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
    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    let asc = urlParams.get('asc');
    let orderby = urlParams.get('orderby');
    $.ajax({

        url:
            '/get_products_list_json/' + priceListId + '?orderby=' + orderby + '&asc=' + asc,

        type: "GET",

        data: { page: page },

        success: function (data) {

            let x = JSON.stringify(data);
            const a = JSON.parse(x);
            fillTable(a);
        },

        error: function (error) {
            
        }
    });
}

function fillTable(data) {
    let list = JSON.parse(data);
    currentPage = list.Products.currentPage;
    totalPages = list.Products.totalPages;
    
    let tableHeadFeatures = ``;
    list.PriceList.Features.forEach(f => {
        tableHeadFeatures += `<th class="user-select-none" style="cursor: pointer;" onclick="submit_ordering(${f.Id})" scope="col">${f.Title}</th>`;
    });
    let tableContent = '';
    list.Products.data.forEach(el => {
        tableContent += `
            <tr>
                    <td>
                        <a class="link-offset-2 link-underline link-underline-opacity-0" href="/products/${el.Id}">${el.Name}</a>
                    </td>
                    <td>${el.Code}</td>`;
        el.ProductFeatures.forEach(f => {
            tableContent += `
                <td>${f.Value}</td>
            `;
        });

        tableContent += `</tr>`;
    });
    let content = `
        <table class="table table-striped">
        <thead>
            <tr>
                <th class="user-select-none" style="cursor: pointer;" onclick="submit_ordering(1)" scope="col">Название товара</th>
                <th class="user-select-none" style="cursor: pointer;" onclick="submit_ordering(2)" scope="col">Код товара</th>
                ${tableHeadFeatures}
            </tr>
        </thead>
        <tbody>
            ${tableContent}
        </tbody>
    </table>
    `;

    document.getElementById("products-container").innerHTML = content;

}
