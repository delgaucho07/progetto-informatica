//  LOGIN
function login() {
    let user = document.getElementById("username").value;
    let pass = document.getElementById("password").value;

    if (user === "admin" && pass === "1234") {
        window.location.href = "admin.html";
    } else {
        alert("Credenziali errate");
    }
}

// CALENDARIO
if (document.getElementById("data")) {
    flatpickr("#data", {
        minDate: "today",
        dateFormat: "Y-m-d",
        disable: ["2026-04-20", "2026-04-25"]
    });
}

//  VALIDAZIONE DEL FORM
function validaForm() {
    let nome = document.getElementById("nome").value;

    if (nome === "") {
        alert("Inserisci il nome!");
        return false;
    }

    return true;
}

// ORARI DINAMICI
if (document.getElementById("data")) {
    document.getElementById("data").addEventListener("change", aggiornaOrari); 
        {let orari = document.getElementById("orario");
        orari.innerHTML = "";

        if (this.value == "2026-04-10") {
            orari.innerHTML += "<option>09:00</option>";
            orari.innerHTML += "<option>10:00</option>";
            orari.innerHTML += "<option>11:00</option>";
            orari.innerHTML += "<option>12:00</option>";
            orari.innerHTML += "<option>13:00</option>";
          
        } 
        else {
            orari.innerHTML += "<option>15:30</option>";
            orari.innerHTML += "<option>17:00</option>";
            orari.innerHTML += "<option>18:30</option>";
        }
        
    }
}
// registrazione
function validaRegistrazione() {

    let nome = document.getElementById("nome").value;
    let email = document.getElementById("email").value;
    let pass = document.getElementById("password").value;
    let conferma = document.getElementById("confermaPassword").value;

    if(nome === "" || email === "" || pass === "") {
        alert("Compila tutti i campi!");
        return false;
    }

    if(pass !== conferma){
        alert("Le password non coincidono!");
        return false;
    }

    alert("Registrazione completata!");
    return true;
}


// CONTROLLO DELLE DISPONIBILITÀ (SIMULATO)
function controllaDisponibilita() {

    let cavallo = document.getElementById("cavallo").value;
    let orario = document.getElementById("orario").value;

    let risultato = document.getElementById("risultato");

    if (cavallo === "1" && orario === "10:00") {
        risultato.innerText = " Cavallo non disponibile";
        risultato.style.color = "red";
    } else {
        risultato.innerText = "Cavallo Disponibile";
        risultato.style.color = "green";
    }
}

//  RIEPILOGO DELLE PRENOTAZIONE
if (document.getElementById("riepilogo")) {
    let params = new URLSearchParams(window.location.search);

    document.getElementById("riepilogo").innerHTML =
        "Nome: " + params.get("nome") + "<br>" +
        "Data: " + params.get("data") + "<br>" +
        "Orario: " + params.get("orario") + "<br>" +
        "Cavallo: " + params.get("cavallo");
}

//  ADMIN - AGGIUNGI CAVALLO
function aggiungiCavallo() {

    let nome = document.getElementById("nomeCavallo").value;
    let lista = document.getElementById("listaCavalli");

    lista.innerHTML += "<li>" + nome + "</li>";
}

// ORARI IN BASE AL TIPO DI ATTIVITÀ                                                                                            
function aggiornaOrari() {

    console.log("Aggiornamento orari in corso...");

    let tipo = document.getElementById("tipo").value;
    let orari = document.getElementById("orario");

    orari.innerHTML = "";

    if (tipo === "lezione") {
        orari.innerHTML += "<option>09:00</option>";
        orari.innerHTML += "<option>10:00</option>";
        orari.innerHTML += "<option>11:00</option>";
        orari.innerHTML += "<option>12:00</option>";
        orari.innerHTML += "<option>13:00</option>";
    } else {
        orari.innerHTML += "<option>15:30</option>";
        orari.innerHTML += "<option>17:00</option>";
        orari.innerHTML += "<option>18:30</option>";
        
    }
}