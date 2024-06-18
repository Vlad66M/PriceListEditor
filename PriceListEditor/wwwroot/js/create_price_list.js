
var btn = document.getElementById("btn-add-col");
var columnsContainer = document.getElementById("columns-container");
var columnsCount = columnsContainer.childElementCount;

btn.addEventListener("click", () => {
    columnsCount++;
    let column = document.createElement("div");
    column.classList.add("d-flex");
    column.classList.add("flex-row");

    column.innerHTML = `
        <div class="form-control">
            <span class="fw-bold cols-selector">Col ${columnsContainer.childElementCount + 1}</span>
        </div>
        <div class="form-control">
            <input type="text" name="Features[${columnsContainer.childElementCount}].Title" class="form-control features-name-selector" placeholder="Col Name">
        </div>
        <div class="form-control">
            <select name="Features[${columnsContainer.childElementCount}].Type" class="form-select features-type-selector" aria-label="Default select example">
                <option selected>--Type--</option>
                <option value="number">Number</option>
                <option value="line">Single Line</option>
                <option value="multiline">Multiline</option>
            </select>
        </div>
        <div class="form-control">
            <button type="button" id="btn-del-${columnsCount}" class="btn-danger">Delete</button>
        </div>
    `;
    columnsContainer.appendChild(column);

    console.log("btn-del-" + (columnsContainer.childElementCount - 1));
    document.getElementById("btn-del-" + (columnsCount)).addEventListener("click", (e) => {
        e.currentTarget.parentNode.parentNode.remove();
        renameElements();
    });
});

function renameElements() {
    console.log("enter rename");
    var allCols = document.querySelectorAll('.cols-selector');
    var colsArray = [...allCols]; 

    var allFeatureNameInputs = document.querySelectorAll('.features-name-selector');
    var featureNameInputsArray = [...allFeatureNameInputs]; 

    var allFeatureTypeInputs = document.querySelectorAll('.features-type-selector');
    var featureTypeInputsArray = [...allFeatureTypeInputs]; 

    let counter = 0;
    console.log("cols count: " + colsArray.length);

    colsArray.forEach(el => {
        console.log("rename" + counter);
        counter++;
        el.innerHTML = `Col ${counter}`;
    });

    counter = 0;
    featureNameInputsArray.forEach(el => {
        console.log("featureNameInputsArray" + counter);
        el.setAttribute("name", `Features[${counter}].Title`);
        counter++;
    });

    counter = 0;
    featureTypeInputsArray.forEach(el => {
        console.log("featureNameInputsArray" + counter);
        el.setAttribute("name", `Features[${counter}].Type`);
        counter++;
    });
}
