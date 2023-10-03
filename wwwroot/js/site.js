function validarContraseña() {
    var pass1 = document.getElementById("pass1").value;
    var pass2 = document.getElementById("pass2").value;
    var pass3 = document.getElementById("pass3").value;
    var patron = /^(?=.*[A-Z])(?=.*[!@#$%^&*]).{8,}$/;
    let devolver= true

    if (pass1 != pass2){
        document.getElementById("password-error1").innerHTML = "Las contraseñas no coinciden.";
        document.getElementById("password-error1").classList.remove("d-none");
        devolver= false;
    } 
    else{
        document.getElementById("password-error1").classList.add("d-none");
    }
    if (!patron.test(pass1)){
        document.getElementById("password-error").innerHTML = "La contraseña debe contener al menos una letra en mayúscula, un carácter especial y tener al menos 8 caracteres de longitud.";
        document.getElementById("password-error").classList.remove("d-none");
        devolver= false;
    }
    else {
        document.getElementById("password-error").classList.add("d-none");
    }
    console.log(pass3.length);
    if(pass3.length != 8){
        document.getElementById("dni-error").innerHTML = "El DNI debe tener 8 dígitos";
        document.getElementById("dni-error").classList.remove("d-none");
        devolver= false;
    }
    else{
        document.getElementById("dni-error").classList.add("d-none");
    }
    return devolver;
}