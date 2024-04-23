
function Zoom() {
    var img = document.getElementById('img_gc');
    img.style.transform = "scale(1.5)";
    img.style.transition = "transform 0.4s ease";
}
img = document.getElementById('img_gc');
function makeSmall() {
    img.style.transform = "scale(1)";
    img.style.transition = "transform 0.4s ease";
}


// RESPONSIVE MENU FOR SMALL SIZES

menu.onclick = function Menu_appear() {
    var x = document.getElementById("myTopnav");

    if (x.className === "topnav") {
        x.className += " responsive";
    } else {
        x.className = "topnav";
    }
};

// CHANGING THE SIZE OF FONT BY BUTTONS AND STORE IN THE LOCAL STORAGE

var cont = document.getElementById('myTopnav');
cont.style.fontSize = localStorage.getItem('size') + 'px';
function changeSizeByBtn(size) {
    cont.style.fontSize = size + 'px';
    localStorage.setItem("size", size);
};

// CHANGE THE STYLE OF WEBSITE BY LOCAL STORAGE



let a = localStorage.getItem("style_css");
let theme = document.getElementById("theme");


if (a == "/website implementation/main-dark.css") {
    theme.href = "/website implementation/main-dark.css";
} else if (a == "/website implementation/main-light.css") {
    theme.href = "/website implementation/main-light.css";
}


// CHANGE THE STYLE OF WEBSITE BY BUTTON

let switchMode = document.getElementById("SwitchMode");
switchMode.onclick = function () {
    let theme = document.getElementById("theme");
    if (theme.getAttribute("href") == "/website implementation/main-light.css") {
        theme.href = "/website implementation/main-dark.css";
        localStorage.setItem("style_css", "/website implementation/main-dark.css");
    } else if (theme.getAttribute("href") == "/website implementation/main-dark.css") {
        theme.href = "/website implementation/main-light.css";
        localStorage.setItem("style_css", "/website implementation/main-light.css");
    }
};


// VALIDATION FOR REGISTRATION PAGE

/* const form = document.getElementById('form');
const name1 = document.getElementById('name1');
const surname = document.getElementById('surname');
const phone = document.getElementById('phone');
const email = document.getElementById('email');
const password = document.getElementById('password');

form.addEventListener('submit', e => {
    e.preventDefault();
    validateInputs();
    document.getElementById('submit1').onclick = function () {
        alert('You submitted the form');
    }
});

const setError = (element, message) => {
    const inputControl = element.parentElement;
    const errorDisplay = inputControl.querySelector('.error');

    errorDisplay.innerText = message;
    inputControl.classList.add('error');
    inputControl.classList.add('success');
};

const setSuccess = element => {
    const inputControl = element.parentElement;
    const errorDisplay = inputControl.querySelector('.error');

    errorDisplay.innerText = '';
    inputControl.classList.add('success');
    inputControl.classList.remove('error');
};

const isValidEmail = email => {
    const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
};

const isValidPhone = phone => {
    const re = /^[+]*[(]{0,1}[0-9]{1,3}[)]{0,1}[-\s\./0-9]*$/;
    return re.test(String(phone));
};


const validateInputs = () => {
    const name1Value = name1.value.trim();
    const surnameValue = surname.value.trim();
    const phoneValue = phone.value.trim();
    const emailValue = email.value.trim();
    const passwordValue = password.value.trim();

    if (name1Value === '') {
        setError(name1, 'Name is required');
    } else {
        setSuccess(name1);
    };

    if (surnameValue === '') {
        setError(surname, 'Surname is required');
    } else {
        setSuccess(surname);
    }

    if (phoneValue === '') {
        setError(phone, 'Phone is required');
    } else if (!isValidPhone(phoneValue)) {
        setError(phone, 'Provide a valid phone number');
    } else {
        setSuccess(phone);
    };


    if (emailValue === '') {
        setError(email, 'Email is required');
    } else if (!isValidEmail(emailValue)) {
        setError(email, 'Provide a valid email address');
    } else {
        setSuccess(email);
    };


    if (passwordValue === '') {
        setError(password, 'Password is required');
    } else if (passwordValue.length < 8) {
        setError(password, 'Password must be at least 8 character.')
    } else {
        setSuccess(password);
    }

    if (document.querySelectorAll('.success').length === 4) {        
        form.submit();
    }
};*/


// VALIDATION FOR THE HOME PAGE ASK SECTION //

/* form.addEventListener('submit', e => {
    e.preventDefault();

    validateInputs2();
});

const validateInputs2 = () => {
    const emailValue = email.value.trim();
    const phoneValue = phone.value.trim();


    if (phoneValue === '') {
        setError(phone, 'Phone is required');
    } else if (!isValidPhone(phoneValue)) {
        setError(phone, 'Provide a valid phone number');
    } else {
        setSuccess(phone);
    };


    if (emailValue === '') {
        setError(email, 'Email is required');
    } else if (!isValidEmail(emailValue)) {
        setError(email, 'Provide a valid email address');
    } else {
        setSuccess(email);
    };
};
*/

function showAdminCode() {
    let role = document.getElementById("role").value;
    if (role === "Admin") {
        document.getElementById("adminCodeGroup").classList.remove("d-none");
    } else {
        document.getElementById("adminCodeGroup").classList.add("d-none");
    }
}


