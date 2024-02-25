
window.attemptSignIn = async () => {
    //Get the form from the current page
    var form = document.querySelector("form");
    var formData = new FormData();
    //Load the form data
    for (var x = 0; x < form.length; x++) {
        //console.log(form[x].name);
        //console.log(form[x].value);
        formData.append(form[x].name,form[x].value)
    }
    //var data = Array.from(formData);
    //console.log(data);
    
    var xhr = new XMLHttpRequest();
    var response = await new Promise((resolve, reject) => {
        xhr.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                resolve(xhr.response);
            } else if (this.readyState == 4 && this.status != 200) {
                reject(new Error('Request failed'));
            }
        };
        xhr.open('POST', '/signin');
        xhr.send(formData);
    });
    return response;
};