function myFunction() {
    var element = document.body;
    element.classList.toggle("dark-mode");
}


try {
    const uploadbtn = document.getElementById('inputGroupFile02');
    const file = document.getElementById('fileselect');
    var elements = document.querySelector('[disabled]');

    uploadbtn.addEventListener('change', function () {
        console.log('hello');
        if (this.files.length == 1) {
            file.textContent = this.files[0].name
            elements.removeAttribute('disabled');
        }
        else {
            file.textContent = this.files.length + "File Selected";
            elements.removeAttribute('disabled');
        }
        //file.textContent = this.files[0].name;
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



