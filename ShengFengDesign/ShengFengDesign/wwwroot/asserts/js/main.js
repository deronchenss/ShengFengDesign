// Write your JavaScript code.

function openMobileNav() {
  let headerBtn = document.getElementById("header");
  headerBtn.classList.toggle("nav-collapse");
}

function translatePath(url, targetLanguage) {
    let regex = /\/([a-z]{2})(\/|$)/;
    let match = regex.exec(url);
    if (match && match[1]) {
        const oldLanguage = match[1];
        const newUrl = url.replace(oldLanguage, targetLanguage);
        return newUrl;
    }
    else {
        return url + targetLanguage;
    }
    return url;
}


function changeLangange(langange) {
    let currentUrl = window.location.href;
    window.location.href = translatePath(currentUrl, langange);
}

function userCollect(){
  let formElement = document.forms.UserCollect;
  let formData = new FormData(formElement);
  let contact = {
    UserName: formData.get('userName'),
    Email: formData.get('email'),
    UserRole: formData.get('userRole'),
    Message: formData.get('message'),
    MessengerType: formData.get('messengerType'),
    MessengerId: formData.get('messengerId')
  }

  fetch('ContactUs/SaveContact', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json; charset=utf-8',
    },
    body: JSON.stringify(contact),
  })
  .then(
      (response) => response.json())
      .then((data) => {
          alert("Save Success!");
    console.log("Success",data);
  })
  .catch((error) => {
    console.error('Error:', error);
  });
}