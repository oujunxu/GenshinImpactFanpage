setTimeout(function () {
    $('.loader_bg').fadeToggle();
}, 1500);

function deleteOnClick(name) {
    document.getElementsByClassName("name-to-delete").value = name;
}