const form = document.getElementById("delete-form");
function deleteProduct(id) {
    let confirmed = confirm("Удалить товар?");
    if (confirmed) {
        form.submit();
    }
}