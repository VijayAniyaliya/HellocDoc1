function myFunction() {
    var element = document.body;
    element.classList.toggle("dark-mode");
}


try {
    const uploadbtn = document.getElementById('inputGroupFile02');
    const file = document.getElementById('fileselect');

    uploadbtn.addEventListener('change', function () {
        file.textContent = this.files[0].name;
        file.style.fontSize = "large";
    })

}
catch (err) {
}


try {



    document.getElementById('editButton').addEventListener('click', function () {
        var elements = document.querySelectorAll('[disabled]');
        elements.forEach(function (element) {
            element.removeAttribute('disabled');
        });
        savebtn.style.display = 'block';
        document.getElementById('editButton').style.display = 'none';
    });
    

}
catch (err) {

}



