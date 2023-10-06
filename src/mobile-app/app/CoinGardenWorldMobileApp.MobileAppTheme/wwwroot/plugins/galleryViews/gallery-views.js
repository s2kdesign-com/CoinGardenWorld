/*!
 * Gallery Views.js
 * Version: 2.0 - Vanilla JS build
 *
 * Copyright Enabled - https://themeforest.net/user/enabled
 * Released under the ThemeForest License. Usage prohibited otherwise.
 */

//Define Global Variables
function galleryViews(){
    var galleryColorClass, galleryViews, galleryColorClass, galleryActiveString, galleryActiveValue;
    //Set your gallery default color for selected buttons.
    var galleryColorClass = 'color-highlight'
    var galleryViews = document.querySelectorAll('.gallery-views');
    var galleryViewControls = document.querySelectorAll('.gallery-view-controls a');

    function removeSelected(el){
        galleryViewControls[0].classList.add(galleryColorClass);
        for (var i = 0; i < galleryViewControls.length; i++){galleryViewControls[i].classList.remove(galleryColorClass)}
        for (var i = 0; i < galleryViews.length; i++){galleryViews[i].removeAttribute("class"); galleryViews[i].setAttribute('class','gallery-views');}
    }   
    galleryViewControls.forEach(el => el.addEventListener('click', e => {
        removeSelected(el);
        var galleryActiveString = el.getAttribute('class');
        var galleryActiveValue = galleryActiveString.split("gallery-view-");
        galleryViews[0].classList.add('gallery-view-'+galleryActiveValue[1]);
        el.classList.add(galleryColorClass);
    }));
}
galleryViews();