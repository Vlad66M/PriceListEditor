
var btn = document.getElementById("btn-add-col");
var columnsContainer = document.getElementById("columns-container");
var columnsCount = columnsContainer.childElementCount;

btn.addEventListener("click", () => {
    columnsCount++;
    let column = document.createElement("div");
    column.classList.add("d-flex");
    column.classList.add("flex-row");

    column.innerHTML = `
        <div class="form-control width-300">
            <span class="fw-bold cols-selector">Колонка ${columnsContainer.childElementCount + 1}</span>
        </div>
        <div class="form-control">
            <input name="Features[${columnsContainer.childElementCount}].FeatureId" type="number" hidden value="@f.Id" />
            <input type="text" name="Features[${columnsContainer.childElementCount}].Title" class="form-control features-name-selector" placeholder="название колонки">
        </div>
        <div class="form-control">
            <select name="Features[${columnsContainer.childElementCount}].Type" class="form-select features-type-selector" aria-label="Default select example">
                <option selected>--тип колонки--</option>
                <option value="number">Число</option>
                <option value="line">Однострочный текст</option>
                <option value="multiline">Многострочный текст</option>
            </select>
        </div>
        <div class="form-control width-100">
            <button type="button" id="btn-del-${columnsCount}" class="btn-danger">Удалить</button>
        </div>
    `;
    columnsContainer.appendChild(column);

    document.getElementById("btn-del-" + (columnsCount)).addEventListener("click", (e) => {
        e.currentTarget.parentNode.parentNode.remove();
        renameElements();
    });
});

function renameElements() {
    
    var allCols = document.querySelectorAll('.cols-selector');
    var colsArray = [...allCols]; 

    var allFeatureNameInputs = document.querySelectorAll('.features-name-selector');
    var featureNameInputsArray = [...allFeatureNameInputs]; 

    var allFeatureTypeInputs = document.querySelectorAll('.features-type-selector');
    var featureTypeInputsArray = [...allFeatureTypeInputs]; 

    var allFeatureIdsInputs = document.querySelectorAll('.features-id-selector');
    var featureIdsInputsArray = [...allFeatureIdsInputs];

    let counter = 0;
    

    colsArray.forEach(el => {
        
        counter++;
        el.innerHTML = `Колонка ${counter}`;
    });

    counter = 0;
    featureNameInputsArray.forEach(el => {
        
        el.setAttribute("name", `Features[${counter}].Title`);
        counter++;
    });

    counter = 0;
    featureTypeInputsArray.forEach(el => {
        
        el.setAttribute("name", `Features[${counter}].Type`);
        counter++;
    });

    counter = 0;
    featureIdsInputsArray.forEach(el => {

        el.setAttribute("name", `Features[${counter}].FeatureId`);
        counter++;
    });
}
