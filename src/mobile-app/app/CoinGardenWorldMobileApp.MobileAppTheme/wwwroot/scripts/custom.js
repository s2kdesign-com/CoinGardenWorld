//Removing Preloader
//setTimeout(function(){
//    var preloader = document.getElementById('preloader')
//    if(preloader){preloader.classList.add('preloader-hide');}
//},150);
function removePreloader() {

    var preloader = document.getElementById('preloader')
    if (preloader) { preloader.classList.add('preloader-hide'); }
}
//document.addEventListener('DOMContentLoaded', () => {
//    'use strict'

    //Remove Display none from Page to improve CLS
    // document.querySelectorAll('#page')[0].style.display ='block';

    //Global Variables
    let isPWA = true;  // Enables or disables the service worker and PWA
    let isAJAX = true; // AJAX transitions. Requires local server or server
    var pwaName = "Duo"; //Local Storage Names for PWA
    var pwaRemind = 1; //Days to re-remind to add to home
    var pwaNoCache = false; //Requires server and HTTPS/SSL. Will clear cache with each visit

    //Setting Service Worker Locations scope = folder | location = service worker js location
    var pwaScope = "/";
    var pwaLocation = "/_service-worker.js";

    //Place all your custom Javascript functions and plugin calls below this line
    function init_template(){
        //Caching Global Variables
        var i, e, el, evt, event; //https://www.w3schools.com/js/js_performance.asp
		
        //Image Sliders
        var splide = document.getElementsByClassName('splide');
        if(splide.length){
            var singleSlider = document.querySelectorAll('.single-slider');
            if(singleSlider.length){
                singleSlider.forEach(function(e){
                    var single = new Splide( '#'+e.id, {
                        type:'loop',
                        autoplay:true,
                        interval:4000,
                        perPage: 1,
                    }).mount();
                    var sliderNext = document.querySelectorAll('.slider-next');
                    var sliderPrev = document.querySelectorAll('.slider-prev');
                    sliderNext.forEach(el => el.addEventListener('click', el => {single.go('>');}));
                    sliderPrev.forEach(el => el.addEventListener('click', el => {single.go('<');}));
                });
            }

            var doubleSlider = document.querySelectorAll('.double-slider');
            if(doubleSlider.length){
                doubleSlider.forEach(function(e){
                     var double = new Splide( '#'+e.id, {
                        type:'loop',
                        autoplay:true,
                        interval:4000,
                        arrows:false,
                        perPage: 2,
                    }).mount();
                });
            }

            var tripleSlider = document.querySelectorAll('.triple-slider');
            if(tripleSlider.length){
                tripleSlider.forEach(function(e){
                     var triple = new Splide( '#'+e.id, {
                        type:'loop',
                        autoplay:true,
                        interval:4000,
                        arrows:false,
                        perPage: 3,
                        perMove: 1,
                    }).mount();
                });
            }
        }

        //Don't jump on Empty Links
        const emptyHref = document.querySelectorAll('a[href="#"]')
        emptyHref.forEach(el => el.addEventListener('click', e => {
            e.preventDefault();
            return false;
        }));

		//Activate Selected Menu
		function activatePage(){
			var activeMenu = document.querySelectorAll('[data-menu-active]');
            if (activeMenu && activeMenu.length > 0){
				var activeData = activeMenu[0].getAttribute('data-menu-active');
				var activeID = document.querySelectorAll('#'+activeData)[0]
				activeID.classList.add('active-item')
			}
		}

		//Remove Overflow from Body on Load
		document.body.setAttribute('style','');

        //Back Button
        const backButton = document.querySelectorAll('[data-back-button]');
        if(backButton.length){
            backButton.forEach(el => el.addEventListener('click',e =>{
                e.stopPropagation;
                e.preventDefault;
                window.history.go(-1);
            }));
        }
        //Back to Top
        const backToTop = document.querySelectorAll('.back-to-top-icon, .back-to-top-badge, .back-to-top');
            if(backToTop.length){
                backToTop.forEach(el => el.addEventListener('click',e =>{
                window.scrollTo({ top: 0, behavior: `smooth` })
            }));
        }
        //Auto Activate OffCanvas
        var autoActivateMenu = document.querySelectorAll('[data-auto-activate]')[0];
        if(autoActivateMenu){
            setTimeout(function(){
                var autoActivate = new bootstrap.Offcanvas(autoActivateMenu)
                autoActivate.show();
            },600)
        }

        //Open Offcanvas and Hide Automatically
        var autoHide = document.querySelectorAll('[data-auto-hide-target]')
        autoHide.forEach(el => el.addEventListener('click',e =>{
            var offCanvasID = el.getAttribute('data-auto-hide-target');
            var offCanvasTime = el.getAttribute('data-auto-hide-time');
            var autoHideMenu = document.querySelectorAll(offCanvasID)[0];
            var canvasIdenter = new bootstrap.Offcanvas(autoHideMenu);
            canvasIdenter.show();
            setTimeout(function(){
                canvasIdenter.hide();
            },offCanvasTime)
        }));

        //Card Extender
        const cards = document.getElementsByClassName('card');
        function card_extender(){
            for (let i = 0; i < cards.length; i++) {
                if(cards[i].getAttribute('data-card-height') === "cover"){
                    if (window.matchMedia('(display-mode: fullscreen)').matches) {var windowHeight = window.outerHeight;}
                    if (!window.matchMedia('(display-mode: fullscreen)').matches) {var windowHeight = window.innerHeight;}
                    var coverHeight = windowHeight + 'px';
                }
                if(cards[i].hasAttribute('data-card-height')){
                    var getHeight = cards[i].getAttribute('data-card-height');
                    cards[i].style.height= getHeight +'px';
                    if(getHeight === "cover"){
                        var totalHeight = getHeight
                        cards[i].style.height =  coverHeight
                    }
                }
            }
        }
        if(cards.length){card_extender(); window.addEventListener("resize", card_extender);}

        //Dark Mode
		function darkMode(){
	        var toggleDark = document.querySelectorAll('[data-toggle-theme]');
	        function activateDarkMode(){
	            document.getElementById('theme-check').setAttribute('content','#1f1f1f')
	            document.body.classList.add('theme-dark');
	            document.body.classList.remove('theme-light', 'detect-theme');
	            for(let i = 0; i < toggleDark.length; i++){toggleDark[i].checked="checked"};
	            localStorage.setItem(pwaName+'-Theme', 'dark-mode');
	            // console.log('dark');
	        }
	        function activateLightMode(){
	            document.getElementById('theme-check').setAttribute('content','#FFFFFF')
	            document.body.classList.add('theme-light');
	            document.body.classList.remove('theme-dark','detect-theme');
	            for(let i = 0; i < toggleDark.length; i++){toggleDark[i].checked=false};
	            localStorage.setItem(pwaName+'-Theme', 'light-mode');
	            // console.log('light');
	        }

	        function setColorScheme() {
	            const isDarkMode = window.matchMedia("(prefers-color-scheme: dark)").matches
	            const isLightMode = window.matchMedia("(prefers-color-scheme: light)").matches
	            const isNoPreference = window.matchMedia("(prefers-color-scheme: no-preference)").matches
	            window.matchMedia("(prefers-color-scheme: dark)").addListener(e => e.matches && activateDarkMode())
	            window.matchMedia("(prefers-color-scheme: light)").addListener(e => e.matches && activateLightMode())
	            if(isDarkMode) activateDarkMode();
	            if(isLightMode) activateLightMode();
	        }

	        //Activating Dark Mode
	        var darkModeSwitch = document.querySelectorAll('[data-toggle-theme]')
	        darkModeSwitch.forEach(el => el.addEventListener('click',e =>{
	            if(document.body.className == "theme-light"){ removeTransitions(); activateDarkMode();}
	            else if(document.body.className == "theme-dark"){ removeTransitions(); activateLightMode();}
	            setTimeout(function(){addTransitions();},350);
	        }));

	        //Set Color Based on Remembered Preference.
	        if(localStorage.getItem(pwaName+'-Theme') == "dark-mode"){for(let i = 0; i < toggleDark.length; i++){toggleDark[i].checked="checked"};document.body.className = 'theme-dark';}
	        if(localStorage.getItem(pwaName+'-Theme') == "light-mode"){document.body.className = 'theme-light';} if(document.body.className == "detect-theme"){setColorScheme();}

	        //Detect Dark/Light Mode
	        const darkModeDetect = document.querySelectorAll('.detect-dark-mode');
	        darkModeDetect.forEach(el => el.addEventListener('click',e =>{
	            document.body.classList.remove('theme-light', 'theme-dark');
	            document.body.classList.add('detect-theme')
	            setTimeout(function(){setColorScheme();},50)
	        }))

	        function removeTransitions(){var falseTransitions = document.querySelectorAll('.btn, .header, #footer-bar, .menu-box, .menu-active'); for(let i = 0; i < falseTransitions.length; i++) {falseTransitions[i].style.transition = "all 0s ease";}}
	        function addTransitions(){var trueTransitions = document.querySelectorAll('.btn, .header, #footer-bar, .menu-box, .menu-active'); for(let i = 0; i < trueTransitions.length; i++) {trueTransitions[i].style.transition = "";}}
		}

		//OTP Boxes
		var otp = document.querySelectorAll('.otp');
		if(otp[0]){
			otp.forEach(el => {
				el.addEventListener('focus', (e) => {el.value = "";})
				el.addEventListener('input', (e) => {el.nextElementSibling ? el.nextElementSibling.focus() : el.blur();});
			});
		}

        //File Upload
        const inputArray = document.getElementsByClassName('upload-file');
        if(inputArray.length){
            inputArray[0].addEventListener('change',prepareUpload,false);
                function prepareUpload(event){
                    if (this.files && this.files[0]) {
                    var img = document.getElementById('image-data');
                    img.src = URL.createObjectURL(this.files[0]);
                    img.classList.add('mt-4', 'mb-3', 'mx-auto');
                }
                const files = event.target.files;
                const fileName = files[0].name;
                const fileSize = (files[0].size/1000).toFixed(2)+'kb';
                const textBefore = document.getElementsByClassName('upload-file-name')[0].getAttribute('data-text-before');
                const textAfter = document.getElementsByClassName('upload-file-name')[0].getAttribute('data-text-after');
                document.getElementsByClassName('upload-file-name')[0].innerHTML =  textBefore + ' ' +  fileName + ' - ' + fileSize + ' - ' + textAfter;
                document.getElementsByClassName('upload-file-name')[0].classList.add('pb-3');
            }

        }

        //Adding Local Storage for Visited Links
        var checkVisited = document.querySelectorAll('.check-visited');
            if(checkVisited.length){
            function check_visited_links(){
                var visited_links = JSON.parse(localStorage.getItem(pwaName+'_Visited_Links')) || [];
                var links = document.querySelectorAll('.check-visited a');
                for (let i = 0; i < links.length; i++) {
                    var that = links[i];
                    that.addEventListener('click',function(e){
                        var clicked_url = this.href;
                        if (visited_links.indexOf(clicked_url)==-1) {
                            visited_links.push(clicked_url);
                            localStorage.setItem(pwaName+'_Visited_Links', JSON.stringify(visited_links));
                        }
                    })
                    if (visited_links.indexOf(that.href)!== -1) {
                        that.className += ' visited-link';
                    }
                }
            }
            check_visited_links();
        }

        //Scrolling Header
        var scrollItems = document.querySelectorAll('.header-auto-show')
        var scrollHeader = document.querySelectorAll('.header-auto-show');
        window.addEventListener('scroll', function() {
            if (document.querySelectorAll('.scroll-ad, .header-auto-show, .header-bar, #footer-bar').length) {
                function showHeader(){scrollHeader[0].classList.add('header-active');}
                function hideHeader(){scrollHeader[0].classList.remove('header-active');}
                var window_height = window.outerWidth;
                var total_scroll_height = document.documentElement.scrollTop
                let inside_header = total_scroll_height <= 30;
                var passed_header = total_scroll_height >= 30;
                let inside_footer = (window_height - total_scroll_height + 1000) <= 150
                if(scrollHeader.length){
                    inside_header ? hideHeader() : null
                    passed_header ? showHeader() : null
                }
				if(passed_header){
					document.querySelectorAll('.header-bar')[0].classList.remove('header-bar-detached');
					document.querySelectorAll('#footer-bar')[0].classList.remove('footer-bar-detached');
				} else {
					document.querySelectorAll('.header-bar')[0].classList.add('header-bar-detached');
					document.querySelectorAll('#footer-bar')[0].classList.add('footer-bar-detached');
				}
            }
        });

        //Stepper
        var stepperAdd = document.querySelectorAll('.stepper-add');
        var stepperSub = document.querySelectorAll('.stepper-sub');
        if(stepperAdd.length){
            stepperAdd.forEach(el => el.addEventListener('click', event => {
                var currentValue = el.parentElement.querySelector('input').value
                el.parentElement.querySelector('input').value = +currentValue + 1
            }))

            stepperSub.forEach(el => el.addEventListener('click', event => {
                var currentValue = el.parentElement.querySelector('input').value
				if(currentValue >= 1){
	                el.parentElement.querySelector('input').value = +currentValue - 1
				}
            }))
        }

        //Link List Toggle
        var linkListToggle = document.querySelectorAll('[data-trigger-switch]:not([data-toggle-theme])');
        if(linkListToggle.length){
            linkListToggle.forEach(el => el.addEventListener('click', event => {
                var switchData = el.getAttribute('data-trigger-switch');
                el.classList.add('no-click');
                setTimeout(function(){el.classList.remove('no-click');},270)
                var getCheck = document.getElementById(switchData);
                getCheck.checked ? getCheck.checked = false : getCheck.checked = true;
            }))
        }


        //Toasts
        var toastTrigger = document.querySelectorAll('[data-toast]');
        if(toastTrigger.length){
            toastTrigger.forEach(el => el.addEventListener('click', event => {
                document.querySelectorAll('.toast, .snackbar, .notification-bar').forEach(el=>{el.classList.remove('show')})
                var toastData = el.getAttribute('data-toast')
                var notificationToast = document.getElementById(toastData);
                var notificationToast = new bootstrap.Toast(notificationToast);
                notificationToast.show();
            }));
        }

		var toastDismiss = document.querySelectorAll('[data-bs-dismiss="toast"]');
		toastDismiss.forEach(el => {
		  el.addEventListener('click', (e) => {
			  var notificationBar = document.querySelectorAll('.notification-bar');
			  notificationBar.forEach(el => {
				  el.classList.remove('show');
			  });

		  });
		});


        //Dropdown
        var dropdownElementList = [].slice.call(document.querySelectorAll('[data-bs-toggle="dropdown"]'))
        if(dropdownElementList.length){
            var dropdownList = dropdownElementList.map(function (dropdownToggleEl) {
            return new bootstrap.Dropdown(dropdownToggleEl);
            })
        }

        //Form Validation
        var bootstrapForms = document.querySelectorAll('.needs-validation')
          // Loop over them and prevent submission
        Array.prototype.slice.call(bootstrapForms).forEach(function(bootstrapForms) {
            bootstrapForms.addEventListener('submit', function(event) {
                if (!bootstrapForms.checkValidity()) {
                    event.preventDefault();
                    event.stopPropagation();
                } else{
                    //Remove the code below to allow form submission.
                   event.preventDefault();
                   event.stopPropagation();
                   qrFunction(event);
                }
                bootstrapForms.classList.add('was-validated')
            }, false)
        })

        //Form Label Activate on Write
        var formLabel = document.querySelectorAll('.form-label input, .form-label select, .form-label textarea');
        formLabel.forEach(el => el.addEventListener('input', event => {
            if(el.value == ''){el.parentElement.querySelectorAll('label')[0].classList.remove('form-label-active');}
            if(el.value !=='') {el.parentElement.querySelectorAll('label')[0].classList.add('form-label-active')}
        }));

        //Local Window Error
        if (window.location.protocol === "file:"){
            var linksLocal = document.querySelectorAll('a');
            linksLocal.forEach(el => el.addEventListener('mouseover', event => {
               console.log("You are seeing these errors because your file is on your local computer. For real life simulations please use a Live Server or a Local Server such as AMPPS or WAMPP or simulate a  Live Preview using a Code Editor like http://brackets.io (it's 100% free) - PWA functions and AJAX Page Transitions will only work in these scenarios.");
            }));
        }

        //Sharing
        function shareLinks(){
			var shareTitle = document.title;
			var shareText = document.title;
			var shareLink = window.location.href;
			if(document.querySelectorAll('.shareToFacebook, .shareToTwitter, .shareToLinkedIn')[0]){
				document.querySelectorAll('.shareToFacebook, .shareToTwitter, .shareToLinkedIn, .shareToWhatsApp, .shareToMail').forEach(x => {x.setAttribute('target','_blank');});
				document.querySelectorAll('.shareToFacebook').forEach( x=> x.setAttribute("href", "https://www.facebook.com/sharer/sharer.php?u="+shareLink));
				document.querySelectorAll('.shareToTwitter').forEach( x=> x.setAttribute("href", "http://twitter.com/share?text="+shareTitle+"%20"+shareLink));
				document.querySelectorAll('.shareToPinterest').forEach( x=> x.setAttribute("href", "https://pinterest.com/pin/create/button/?url=" + shareLink));
				document.querySelectorAll('.shareToWhatsApp').forEach( x=> x.setAttribute("href", "whatsapp://send?text=" + shareLink));
				document.querySelectorAll('.shareToMail').forEach( x=> x.setAttribute("href", "mailto:?body=" + shareLink));
				document.querySelectorAll('.shareToLinkedIn').forEach( x=> x.setAttribute("href", "https://www.linkedin.com/shareArticle?mini=true&url="+shareLink+"&title="+shareTitle+"&summary=&source="));
			}
			//Menu Share Web API
			if (navigator.canShare){
				const shareData = {title: shareTitle, text: shareText, url: shareLink}
				var shareMenu = document.querySelectorAll('[data-bs-target="#menu-share"], [data-show-share]');
					shareMenu.forEach(el => {
						el.addEventListener('click', async () => {
							document.querySelectorAll('#menu-share')[0].classList.remove('show')
							document.querySelectorAll('.offcanvas-backdrop')[0].classList.remove('show')
							document.body.setAttribute('style','');
							try {
								await navigator.share(shareData)
							} catch (err) {}
						});
					});
			}
		}
		shareLinks();

        //Copyright Year
        var copyrightYear = document.querySelectorAll('.copyright-year');
        if(copyrightYear){
            copyrightYear.forEach(function(e){
                var dteNow = new Date();
                const intYear = dteNow.getFullYear();
                e.textContent = intYear;
            });
        }

        //Creating Offline Alert Messages
        var addOfflineClasses = document.querySelectorAll('.offline-message');
        if(!addOfflineClasses.length){
            const offlineAlert = document.createElement('p');
            const onlineAlert = document.createElement('p');
            offlineAlert.className = 'offline-message bg-red-dark shadow-bg shadow-bg-s color-white';
            offlineAlert.innerHTML = '<i class="bi bi-wifi-off pe-2"></i> No internet connection detected';
            onlineAlert.className = 'online-message bg-green-dark shadow-bg shadow-bg-s color-white';
            onlineAlert.innerHTML = '<i class="bi bi-wifi pe-2"></i> You are back online.';
            document.querySelectorAll('#page')[0].appendChild(offlineAlert);
            document.querySelectorAll('#page')[0].appendChild(onlineAlert);
        }

        //Online / Offline Settings
        //Activating and Deactivating Links Based on Online / Offline State
        function offlinePage(){
            var anchorsDisabled = document.querySelectorAll('a');
            anchorsDisabled.forEach(function(e){
                var hrefs = e.getAttribute('href');
                if(hrefs.match(/.html/)){e.classList.add('show-offline'); e.setAttribute('data-link',hrefs); e.setAttribute('href','#');}
            });
            var showOffline = document.querySelectorAll('.show-offline');
            showOffline.forEach(el => el.addEventListener('click', event => {
                document.getElementsByClassName('offline-message')[0].classList.add('offline-message-active');
                setTimeout(function(){document.getElementsByClassName('offline-message')[0].classList.remove('offline-message-active');},1500)
            }));
        }
        function onlinePage(){
            var anchorsEnabled = document.querySelectorAll('[data-link]');
            anchorsEnabled.forEach(function (e) {
                var hrefs = e.getAttribute('data-link');
                if (hrefs.match(/.html/)) {e.setAttribute('href', hrefs); e.removeAttribute('data-link', '');}
            });
        }

        //Defining Offline/Online Variables
        var offlineMessage = document.getElementsByClassName('offline-message')[0];
        var onlineMessage = document.getElementsByClassName('online-message')[0];

        //Online / Offline Status
        function isOnline(){
            onlinePage();
            offlineMessage.classList.remove('offline-message-active');
            onlineMessage.classList.add('online-message-active');
            setTimeout(function(){onlineMessage.classList.remove('online-message-active'); },2000)
            console.info('Connection: Online');
        }

        function isOffline(){
            offlinePage();
            onlineMessage.classList.remove('online-message-active');
            offlineMessage.classList.add('offline-message-active');
            setTimeout(function(){offlineMessage.classList.remove('offline-message-active'); },2000)
            console.info('Connection: Offline');
        }

        var simulateOffline = document.querySelectorAll('.simulate-offline');
        var simulateOnline = document.querySelectorAll('.simulate-online');
        if(simulateOffline.length){
            simulateOffline[0].addEventListener('click',function(){isOffline()});
            simulateOnline[0].addEventListener('click',function(){isOnline()});
        }

        //Check if Online / Offline
        function updateOnlineStatus(event) {var condition = navigator.onLine ? "online" : "offline"; isOnline(); }
        function updateOfflineStatus(event) {isOffline();}
        window.addEventListener('online',  updateOnlineStatus);
        window.addEventListener('offline', updateOfflineStatus);

        //Detecting Mobile OS
        let isMobile = {
            Android: function() {return navigator.userAgent.match(/Android/i);},
            iOS: function() {return navigator.userAgent.match(/iPhone|iPad|iPod/i);},
            any: function() {return (isMobile.Android() || isMobile.iOS());}
        };
        function iOSversion() {if (/iP(hone|od|ad)/.test(navigator.platform)) {var v = (navigator.appVersion).match(/OS (\d+)_(\d+)_?(\d+)?/); return [parseInt(v[1], 10)];}}


        const androidDev = document.getElementsByClassName('show-android');
        const iOSDev = document.getElementsByClassName('show-ios');
        const noDev = document.getElementsByClassName('show-no-device');

        if(!isMobile.any()){
            for (let i = 0; i < iOSDev.length; i++) {iOSDev[i].classList.add('disabled');}
            for (let i = 0; i < androidDev.length; i++) {androidDev[i].classList.add('disabled');}
        }
        if(isMobile.iOS()){
            for (let i = 0; i < noDev.length; i++) {noDev[i].classList.add('disabled');}
            for (let i = 0; i < androidDev.length; i++) {androidDev[i].classList.add('disabled');}
            //Detect iOS 15 or Higher Version and Attach Classes
        }
        if(isMobile.Android()){
            for (let i = 0; i < iOSDev.length; i++) {iOSDev[i].classList.add('disabled');}
            for (let i = 0; i < noDev.length; i++) {noDev[i].classList.add('disabled');}
        }

        //PWA Settings
        if(isPWA === true){

            //Defining PWA Windows
            var iOS_PWA = document.querySelectorAll('#menu-install-pwa-ios')[0];
            if(iOS_PWA){var iOS_Window = new bootstrap.Offcanvas(iOS_PWA)}
            var Android_PWA = document.querySelectorAll('#menu-install-pwa-android')[0];
            if(Android_PWA){var Android_Window = new bootstrap.Offcanvas(Android_PWA)}

            var checkPWA = document.getElementsByTagName('html')[0];
            if(!checkPWA.classList.contains('isPWA')){
                if ('serviceWorker' in navigator) {
                  window.addEventListener('load', function() {
					  navigator.serviceWorker.register(pwaLocation, {scope: pwaScope}).then(function(registration){registration.update();})
					});
                }

                //Setting Timeout Before Prompt Shows Again if Dismissed
                var hours = pwaRemind * 24; // Reset when storage is more than 24hours
                var now = Date.now();
                var setupTime = localStorage.getItem(pwaName+'-PWA-Timeout-Value');
                if (setupTime == null) {
                    localStorage.setItem(pwaName+'-PWA-Timeout-Value', now);
                } else if (now - setupTime > hours*60*60*1000) {
                    localStorage.removeItem(pwaName+'-PWA-Prompt')
                    localStorage.setItem(pwaName+'-PWA-Timeout-Value', now);
                }


                const pwaClose = document.querySelectorAll('.pwa-dismiss');
                pwaClose.forEach(el => el.addEventListener('click',e =>{
                    const pwaWindows = document.querySelectorAll('#menu-install-pwa-android, #menu-install-pwa-ios');
                    for(let i=0; i < pwaWindows.length; i++){pwaWindows[i].classList.remove('menu-active');}
                    localStorage.setItem(pwaName+'-PWA-Timeout-Value', now);
                    localStorage.setItem(pwaName+'-PWA-Prompt', 'install-rejected');
                    console.log('PWA Install Rejected. Will Show Again in '+ (pwaRemind)+' Days')
                }));

                //Trigger Install Prompt for Android
                const pwaWindows = document.querySelectorAll('#menu-install-pwa-android, #menu-install-pwa-ios');
                if(pwaWindows.length){
                    if (isMobile.Android()) {
                        if (localStorage.getItem(pwaName+'-PWA-Prompt') != "install-rejected") {
                            function showInstallPrompt() {
                                setTimeout(function(){
                                    if (!window.matchMedia('(display-mode: fullscreen)').matches) {
                                        console.log('Triggering PWA Window for Android')
                                        Android_Window.show()
                                    }
                                },3500);
                            }
                            var deferredPrompt;
                            window.addEventListener('beforeinstallprompt', (e) => {
                                e.preventDefault();
                                deferredPrompt = e;
                                showInstallPrompt();
                            });
                        }
                        const pwaInstall = document.querySelectorAll('.pwa-install');
                        pwaInstall.forEach(el => el.addEventListener('click', e => {
                            deferredPrompt.prompt();
                            deferredPrompt.userChoice
                                .then((choiceResult) => {
                                    if (choiceResult.outcome === 'accepted') {
                                        console.log('Added');
                                    } else {
                                        localStorage.setItem(pwaName+'-PWA-Timeout-Value', now);
                                        localStorage.setItem(pwaName+'-PWA-Prompt', 'install-rejected');
                                        setTimeout(function(){
                                            if (!window.matchMedia('(display-mode: fullscreen)').matches) {
                                                Android_Window.show()
                                            }
                                        },50);
                                    }
                                    deferredPrompt = null;
                                });
                        }));
                        window.addEventListener('appinstalled', (evt) => {
                            Android_Window.hide()
                        });
                    }
                    //Trigger Install Guide iOS
                    if (isMobile.iOS()) {
                        if (localStorage.getItem(pwaName+'-PWA-Prompt') != "install-rejected") {
                            setTimeout(function(){
                                if (!window.matchMedia('(display-mode: fullscreen)').matches) {
                                    console.log('Triggering PWA Window for iOS');
                                    iOS_Window.show()
                                }
                            },3500);
                        }
                    }
                }
            }
            checkPWA.setAttribute('class','isPWA');
        }

        //Page Highlights
		function setHighlights(){
        var highlightData = document.querySelectorAll('[data-change-highlight]');
        highlightData.forEach(el => el.addEventListener('click', e =>{
            var highlight = el.getAttribute('data-change-highlight');
            var pageHighlight = document.querySelectorAll('.page-highlight');
            if(pageHighlight.length){pageHighlight.forEach(function(e){e.remove();});}
            var loadHighlight = document.createElement("link");
            loadHighlight.rel = "stylesheet";
            loadHighlight.className = "page-highlight";
            loadHighlight.type = "text/css";
            // Edited to suuport CoinGardenTheme
            loadHighlight.href = '../_content/CoinGardenWorldMobileApp.MobileAppTheme/styles/highlights/' + highlight +'.css';
            document.getElementsByTagName("head")[0].appendChild(loadHighlight);
            document.body.setAttribute('data-highlight', 'highlight-'+highlight)
            localStorage.setItem(pwaName+'-Highlight', highlight)
			highlightData.forEach(el => {
				el.querySelectorAll('i')[0].classList.remove('bi-check-circle-fill');
				el.querySelectorAll('i')[0].classList.add('bi-circle');
			});
			el.querySelectorAll('i')[0].classList.remove('bi-circle');
			el.querySelectorAll('i')[0].classList.add('bi-check-circle-fill');

        }))
        var rememberHighlight = localStorage.getItem(pwaName+'-Highlight');
	        if(rememberHighlight){
	            document.body.setAttribute('data-highlight', rememberHighlight);
	            var loadHighlight = document.createElement("link");
	            loadHighlight.rel = "stylesheet";
	            loadHighlight.className = "page-highlight";
                loadHighlight.type = "text/css";
            // Edited to suuport CoinGardenTheme
                loadHighlight.href = './_content/CoinGardenWorldMobileApp.MobileAppTheme/styles/highlights/' + rememberHighlight +'.css';
	            if(!document.querySelectorAll('.page-highlight').length){
	                document.getElementsByTagName("head")[0].appendChild(loadHighlight);
	                document.body.setAttribute('data-highlight', 'highlight-'+rememberHighlight)
	            }
				var highlightData = document.querySelectorAll('[data-change-highlight]');
				highlightData.forEach(el => {
					el.querySelectorAll('i')[0].classList.remove('bi-check-circle-fill');
					el.querySelectorAll('i')[0].classList.add('bi-circle');
				});
                var highlightSelect = document.querySelectorAll('[data-change-highlight="' + rememberHighlight + '"]')[0];
                if (highlightSelect) {

				    highlightSelect.querySelectorAll('i')[0].classList.remove('bi-circle');
                    highlightSelect.querySelectorAll('i')[0].classList.add('bi-check-circle-fill');
                }
	        }
		}
		
        //Lazy Loading
        var lazyLoad = new LazyLoad();

		//Calling Functions Required After External Menus are Loaded
		var dataMenuLoad = document.querySelectorAll('[data-menu-load]')
		if(dataMenuLoad[0]){
			dataMenuLoad.forEach(function(e){
				var menuLoad = e.getAttribute('data-menu-load')
				fetch(menuLoad)
				.then(data => data.text())
				.then(html => e.innerHTML = html)
				.then(data => {
					setTimeout(function(){
						if(dataMenuLoad[dataMenuLoad.length-1] === e){
							activatePage();
							darkMode();
							card_extender();
							setHighlights();
						}
					},100);
				}).catch(function() {
					e.innerHTML = "<h5 class='font-16 px-4 py-4 mb-0'>Please use a Local Server such as AMPPS or WAMP to see externally loaded menus or put "+pwaName+" files on your server. <br> To load menus from inside your HTML you must remove the data-menu-load=`your-menu.html` and copy what is inside your-menu.html in this div. <br>Using external menus, editing a single menu will show in all pages. <br><br> For more information please read the Documentation -> Menu Chapter.</h5>";
				});
			})
		} else {
			activatePage();
			darkMode();
			card_extender();
			setHighlights();
		}

        // Check Documentation folder for detailed explanations on
        // Externally loading Javascript files for better performance.

        var plugIdent, plugClass, plugMain, plugCall;

            // Edited to suuport CoinGardenTheme
        var plugLoc = "./_content/CoinGardenWorldMobileApp.MobileAppTheme/plugins/"

        let plugins = [
          {
            //Example of how to call an external script.
            id: 'uniqueID', // to detect if loaded and unload if no longer required.
            plug: 'pluginName/plugin.js', // the main plugin javascript file
            call: 'pluginName/pluginName-call.js', // the plugin call functions
            style: 'pluginName/pluginName-style.css', // the plugin stylesheet
            trigger: '.pluginTriggerClass' // the class inside the page that will activate plugin load
          },
          {
            id: 'gallery',
            plug: 'glightbox/glightbox.js',
            call: 'glightbox/glightbox-call.js',
            style: 'glightbox/glightbox.css',
            trigger: '[data-gallery]'
          },
          {
            id: 'gallery-views',
            call: 'galleryViews/gallery-views.js',
            trigger: '.gallery-view-controls'
          },
          {
            id: 'filter',
            plug: 'filterizr/filterizr.js',
            call: 'filterizr/filterizr-call.js',
            style: 'filterizr/filterizr.css',
            trigger: '.gallery-filter'
          },
          {
            id: 'apex-chart',
            plug: 'apex/apexcharts.js',
            call: 'apex/apex-call.js',
            trigger: '.chart'
          },
          {
            id: 'geo-location',
            call: 'geolocation/geo.js',
            trigger: '.get-location'
          },
          {
            id: 'qr-generator',
            call: 'qrgenerator/qr.js',
            trigger: '.generate-qr-auto'
          },
          {
            id: 'demo-functions', // can be deleted
            call: 'demo/demo.js', // can be deleted
            trigger: '.demo-boxed' // can be deleted
          },
		  {
			  id: 'count',
			  plug: 'countdown/countdown.js',
			  trigger: '.countdown'
		  },
          {
            id: 'contact-form',
            call: 'contact/form.js',
            style: 'contact/form.css',
            trigger: '.contact-form'
          }
        ];

        //External Script Loader
        for (let i = 0; i < plugins.length; i++) {
            //Remove Previous Calls
            if(document.querySelectorAll('.'+plugins[i].id+'-c').length){document.querySelectorAll('.'+plugins[i].id+'-c')[0].remove();                }

            //Load Plugins
            var plugTrigger = document.querySelectorAll(plugins[i].trigger)
            if(plugTrigger.length){
                var loadScript = document.getElementsByTagName('script')[1],
                    loadScriptJS = document.createElement('script');
                loadScriptJS.type = 'text/javascript'
                loadScriptJS.className = plugins[i].id+'-p'
                loadScriptJS.src = plugLoc + plugins[i].plug
                loadScriptJS.addEventListener('load',function(){
                    //Once plugin is loaded, load the call.
                    if(plugins[i].call !== undefined){
                        var callFn = document.getElementsByTagName('script')[2],
                            callJS = document.createElement('script');
                        callJS.type = 'text/javascript'
                        callJS.className = plugins[i].id+'-c'
                        callJS.src =  plugLoc + plugins[i].call
                        callFn.parentNode.insertBefore(callJS, callFn);
                    }
                });
                //If plugin doesn't exist, load it
                if(!document.querySelectorAll('.'+plugins[i].id+'-p').length && plugins[i].plug !== undefined){
                    loadScript.parentNode.insertBefore(loadScriptJS, loadScript);
                } else {
                    //If plugin doesn't exist, only load the call function
                    setTimeout(function(){
                    var loadScript = document.getElementsByTagName('script')[1],
                        loadScriptJS = document.createElement('script');
                    loadScriptJS.type = 'text/javascript'
                    loadScriptJS.className = plugins[i].id+'-c'
                    loadScriptJS.src = plugLoc + plugins[i].call;
                    loadScript.parentNode.insertBefore(loadScriptJS, loadScript);
                    },50);
                }
                //If Style doesn't exist in array, don't do anything
                if(plugins[i].style !== undefined){
                    //if style already exists, don't re-add to page.
                    if(!document.querySelectorAll('.'+plugins[i].id+'-s').length){
                        var loadCSS = document.createElement("link");
                        loadCSS.className = plugins[i].id+'-s';
                        loadCSS.rel = "stylesheet";
                        loadCSS.type = "text/css";
                        loadCSS.href = plugLoc + plugins[i].style;
                        document.getElementsByTagName("head")[0].appendChild(loadCSS);
                    }
                }
            }
        }
    }

    //Fix Scroll for AJAX pages.
    if ('scrollRestoration' in window.history) window.history.scrollRestoration = 'manual';

    //End of Init Template
    //if(isAJAX === true){
    //    if(window.location.protocol !== "file:"){
    //        const options = {
    //            containers: ["#page"],
    //            cache:false,
    //            animateHistoryBrowsing: false,
    //            plugins: [
    //                new SwupPreloadPlugin()
    //            ],
    //            linkSelector:'a:not(.external-link):not(.default-link):not([href^="https"]):not([href^="http"]):not([data-gallery])'
    //        };
    //        const swup = new Swup(options);
    //        document.addEventListener('swup:pageView',(e) => { init_template(); })
    //    }
    //}

    //init_template();
//});