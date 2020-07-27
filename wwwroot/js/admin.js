



function getAllUsers() {
    var xhr = new XMLHttpRequest();
    xhr.open("GET", "/Account/AdminGetAllUser")
    xhr.onload = function () {
        var users = JSON.parse(this.responseText);
    };
    xhr.send()
}