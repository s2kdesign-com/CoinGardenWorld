export function getBrowserLanguage () {
    "use strict";
        return (navigator.languages && navigator.languages.length) ? navigator.languages[0] : navigator.userLanguage || navigator.language || navigator.browserLanguage || 'en';
    
};

export function  fullyRendered (state) {
    window.prerenderReady = state;
}