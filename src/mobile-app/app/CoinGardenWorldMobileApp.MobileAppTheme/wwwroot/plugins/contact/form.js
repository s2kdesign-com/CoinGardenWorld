/*!
 * Contact Form.js
 * Version: 2.0 - Vanilla JS build
 *
 * Copyright Enabled - https://themeforest.net/user/enabled
 * Released under the ThemeForest License. Usage prohibited otherwise.
 */
 
var contactForm = document.querySelectorAll('.contact-form');
if(contactForm.length){
	var form = document.getElementById('contactForm');
	form.onsubmit = function (e) {
		// Stop the regular form submission
		e.preventDefault();

		//Validate Fields
		var nameField = document.getElementById('contactNameField');
		var mailField = document.getElementById('contactEmailField');
		var textField = document.getElementById('contactMessageTextarea');
		var validateMail = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
		if(nameField.value === ''){
			form.setAttribute('data-form','invalid');
			nameField.classList.add('border-red-dark');
			document.getElementById('validator-name').classList.remove('disabled');
		} else {
			form.setAttribute('data-form','valid');
			document.getElementById('validator-name').classList.add('disabled');
			nameField.classList.remove('border-red-dark');
		}
		if(mailField.value === ''){
			form.setAttribute('data-form','invalid');
			mailField.classList.add('border-red-dark');
			document.getElementById('validator-mail1').classList.remove('disabled');
		} else {
			document.getElementById('validator-mail1').classList.add('disabled');
			if(!validateMail.test(mailField.value)){
				form.setAttribute('data-form','invalid');
				mailField.classList.add('border-red-dark');
				document.getElementById('validator-mail2').classList.remove('disabled');
			} else{
				form.setAttribute('data-form','valid');
				document.getElementById('validator-mail2').classList.add('disabled');
				mailField.classList.remove('border-red-dark');
			}
		}
		if(textField.value === ''){
			form.setAttribute('data-form','invalid');
			textField.classList.add('border-red-dark');
			document.getElementById('validator-text').classList.remove('disabled');
		} else{
			form.setAttribute('data-form','valid');
			document.getElementById('validator-text').classList.add('disabled');
			textField.classList.remove('border-red-dark')
		}

		if(form.getAttribute('data-form') === 'valid'){
			document.querySelectorAll('.form-sent')[0].classList.remove('disabled');
			document.querySelectorAll('.contact-form')[0].classList.add('disabled');
			// Collect the form data while iterating over the inputs
			var data = {};
			for (let i = 0, ii = form.length; i < ii; ++i) {
				let input = form[i];
				if (input.name) {
					data[input.name] = input.value;
				}
			}
			// Construct an HTTP request
			var xhr = new XMLHttpRequest();
			xhr.open(form.method, form.action, true);
			xhr.setRequestHeader('Accept', 'application/json; charset=utf-8');
			xhr.setRequestHeader('Content-Type', 'application/json; charset=UTF-8');
			// Send the collected data as JSON
			xhr.send(JSON.stringify(data));
			// Callback function
			xhr.onloadend = function (response) {if (response.target.status === 200) {console.log('Form Submitted')}};
		}
	};
}