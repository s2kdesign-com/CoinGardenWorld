/*!
 * QR.js
 * Version: 1.0 - Vanilla JS build
 * Copyright Enabled - https://themeforest.net/user/enabled
 * Released under the ThemeForest License. Usage prohibited otherwise.
 */

function qrFunction(event){
	var qr_image = document.querySelectorAll('.qr-image');
	var get_qr_url = event.srcElement.querySelectorAll('#qr-generator-value')[0].value
	console.log(get_qr_url)
	var qr_api_address = 'https://api.qrserver.com/v1/create-qr-code/?size=250x250&data=';
	var qr_img = '<img class="mx-auto polaroid-effect shadow-l mt-4 delete-qr" src="'+qr_api_address+get_qr_url+'" alt="img"><p class="font-11 text-center mb-0">'+get_qr_url+'</p>'
	document.getElementsByClassName('generate-qr-result')[0].innerHTML = qr_img
}

//QR Generator
var qr_image = document.querySelectorAll('.generate-qr-auto');
if(qr_image.length){
	var qr_this = window.location.href;
	var qr_auto = document.getElementsByClassName('generate-qr-auto')[0];
	var qr_api_address = 'https://api.qrserver.com/v1/create-qr-code/?size=200x200&data=';
	if(qr_auto){qr_auto.setAttribute('src', qr_api_address+qr_this)        }
}