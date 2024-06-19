
const queryString = window.location.search;
const urlParams = new URLSearchParams(queryString);
let asc = urlParams.get('asc');
if (asc == null) {
    asc = true;
}
let currentFeatureId = urlParams.get('orderby');

let priceId = document.getElementById("price-list-id").value;



function submit_ordering(featureId) {
    
    if (featureId == currentFeatureId) {
        if (asc == "true") {
            asc = false;
        }
        else {
            asc = true;
        }
    }
    currentFeatureId = featureId;
    window.location.href = '/price_lists/' + priceId + '?orderby=' + featureId + '&asc=' + asc;
}