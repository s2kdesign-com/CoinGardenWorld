/*!
 * Toastr - ICOCrypto v1.9.5 by Softnio.
**/
NioApp = (function (NioApp, $, window) {
    "use strict";
    
	var $toastr_top_center = $('.toastr-top-center'),
        $toastr_top_right = $('.toastr-top-right'),
        $toastr_top_left = $('.toastr-top-left'),
        $toastr_top_full = $('.toastr-top-full'),
        $toastr_bottom_center = $('.toastr-bottom-center'), 
        $toastr_bottom_right = $('.toastr-bottom-right'),
        $toastr_bottom_left = $('.toastr-bottom-left'),
        $toastr_bottom_full = $('.toastr-bottom-full'),
        $toastr_info = $('.toastr-info'),
        $toastr_success = $('.toastr-success'),
        $toastr_warning = $('.toastr-warning'),
        $toastr_error = $('.toastr-error');
    
	NioApp.Toastr = {};
	
	// ToastrJs @v1.0
    NioApp.Toastr.ToastrJs = function () {
        if ($toastr_top_center.exists()) {
			$toastr_top_center.each(function(){
				var $self = $(this);
				$self.on("click", function(e){
                    toastr.clear();
                    toastr.options = {
                        "closeButton": true,
                        "newestOnTop": false,
                        "preventDuplicates": true,
                        "positionClass": "toast-top-center",
                        "showDuration": "1000",
                        "hideDuration": "10000",
                        "timeOut": "2000",
                        "extendedTimeOut": "1000"
                    };
                    toastr.info('This is a note for Info message on Top Center');
                    e.preventDefault();
                });
			});
        }
        if ($toastr_top_right.exists()) {
			$toastr_top_right.each(function(){
				var $self = $(this);
				$self.on("click", function(e){
                    toastr.clear();
                    toastr.options = {
                        "closeButton": true,
                        "newestOnTop": false,
                        "preventDuplicates": true,
                        "positionClass": "toast-top-right",
                        "showDuration": "1000",
                        "hideDuration": "10000",
                        "timeOut": "2000",
                        "extendedTimeOut": "1000"
                    };
                    toastr.info('This is a note for Info message on Top Right');
                    e.preventDefault();
                });
			});
        }
        if ($toastr_top_left.exists()) {
			$toastr_top_left.each(function(){
				var $self = $(this);
				$self.on("click", function(e){
                    toastr.clear();
                    toastr.options = {
                        "closeButton": true,
                        "newestOnTop": false,
                        "preventDuplicates": true,
                        "positionClass": "toast-top-left",
                        "showDuration": "1000",
                        "hideDuration": "10000",
                        "timeOut": "2000",
                        "extendedTimeOut": "1000"
                    };
                    toastr.info('This is a note for Info message on Top Left');
                    e.preventDefault();
                });
			});
        }
        if ($toastr_top_full.exists()) {
			$toastr_top_full.each(function(){
				var $self = $(this);
				$self.on("click", function(e){
                    toastr.clear();
                    toastr.options = {
                        "closeButton": true,
                        "newestOnTop": false,
                        "preventDuplicates": true,
                        "positionClass": "toast-top-full-width",
                        "showDuration": "1000",
                        "hideDuration": "10000",
                        "timeOut": "2000",
                        "extendedTimeOut": "1000"
                    };
                    toastr.info('This is a note for Info message on Top Full');
                    e.preventDefault();
                });
			});
        }
        if ($toastr_bottom_center.exists()) {
			$toastr_bottom_center.each(function(){
				var $self = $(this);
				$self.on("click", function(e){
                    toastr.clear();
                    toastr.options = {
                        "closeButton": true,
                        "newestOnTop": false,
                        "preventDuplicates": true,
                        "positionClass": "toast-bottom-center",
                        "showDuration": "1000",
                        "hideDuration": "10000",
                        "timeOut": "2000",
                        "extendedTimeOut": "1000"
                    };
                    toastr.info('This is a note for Info message on Bottom Center');
                    e.preventDefault();
                });
			});
        }
        if ($toastr_bottom_right.exists()) {
			$toastr_bottom_right.each(function(){
				var $self = $(this);
				$self.on("click", function(e){
                    toastr.clear();
                    toastr.options = {
                        "closeButton": true,
                        "newestOnTop": false,
                        "preventDuplicates": true,
                        "positionClass": "toast-bottom-right",
                        "showDuration": "1000",
                        "hideDuration": "10000",
                        "timeOut": "2000",
                        "extendedTimeOut": "1000"
                    };
                    toastr.info('This is a note for Info message on Bottom Right');
                    e.preventDefault();
                });
			});
        }
        if ($toastr_bottom_left.exists()) {
			$toastr_bottom_left.each(function(){
				var $self = $(this);
				$self.on("click", function(e){
                    toastr.clear();
                    toastr.options = {
                        "closeButton": true,
                        "newestOnTop": false,
                        "preventDuplicates": true,
                        "positionClass": "toast-bottom-left",
                        "showDuration": "1000",
                        "hideDuration": "10000",
                        "timeOut": "2000",
                        "extendedTimeOut": "1000"
                    };
                    toastr.info('This is a note for Info message on Bottom Left');
                    e.preventDefault();
                });
			});
        }
        if ($toastr_bottom_full.exists()) {
			$toastr_bottom_full.each(function(){
				var $self = $(this);
				$self.on("click", function(e){
                    toastr.clear();
                    toastr.options = {
                        "closeButton": true,
                        "newestOnTop": false,
                        "preventDuplicates": true,
                        "positionClass": "toast-bottom-full-width",
                        "showDuration": "1000",
                        "hideDuration": "10000",
                        "timeOut": "2000",
                        "extendedTimeOut": "1000"
                    };
                    toastr.info('This is a note for Info message on Bottom Full');
                    e.preventDefault();
                });
			});
        }
        if ($toastr_info.exists()) {
			$toastr_info.each(function(){
				var $self = $(this);
				$self.on("click", function(e){
                    toastr.clear();
                    toastr.options = {
                        "closeButton": true,
                        "newestOnTop": false,
                        "preventDuplicates": true,
                        "positionClass": "toast-bottom-center",
                        "showDuration": "1000",
                        "hideDuration": "10000",
                        "timeOut": "2000",
                        "extendedTimeOut": "1000"
                    };
                    toastr.info('<em class="ti ti-filter toast-message-icon"></em> This is a note for Info message');
                    e.preventDefault();
                });
			});
        }
        if ($toastr_success.exists()) {
			$toastr_success.each(function(){
				var $self = $(this);
				$self.on("click", function(e){
                    toastr.clear();
                    toastr.options = {
                        "closeButton": true,
                        "newestOnTop": false,
                        "preventDuplicates": true,
                        "positionClass": "toast-bottom-center",
                        "showDuration": "1000",
                        "hideDuration": "10000",
                        "timeOut": "2000",
                        "extendedTimeOut": "1000"
                    };
                    toastr.success('<em class="ti ti-check toast-message-icon"></em> This is a note for Success message');
                    e.preventDefault();
                });
			});
        }
        if ($toastr_warning.exists()) {
			$toastr_warning.each(function(){
				var $self = $(this);
				$self.on("click", function(e){
                    toastr.clear();
                    toastr.options = {
                        "closeButton": true,
                        "newestOnTop": false,
                        "preventDuplicates": true,
                        "positionClass": "toast-bottom-center",
                        "showDuration": "1000",
                        "hideDuration": "10000",
                        "timeOut": "2000",
                        "extendedTimeOut": "1000"
                    };
                    toastr.warning('<em class="ti ti-alert toast-message-icon"></em> This is a note for Warning message');
                    e.preventDefault();
                });
			});
        }
        if ($toastr_error.exists()) {
			$toastr_error.each(function(){
				var $self = $(this);
				$self.on("click", function(e){
                    toastr.clear();
                    toastr.options = {
                        "closeButton": true,
                        "newestOnTop": false,
                        "preventDuplicates": true,
                        "positionClass": "toast-bottom-center",
                        "showDuration": "1000",
                        "hideDuration": "10000",
                        "timeOut": "2000",
                        "extendedTimeOut": "1000"
                    };
                    toastr.error('<em class="ti ti-na toast-message-icon"></em> This is a note for Error message');
                    e.preventDefault();
                });
			});
        }
	};
	
    NioApp.components.docReady.push(NioApp.Toastr.ToastrJs);
	return NioApp;
})(NioApp, jQuery, window);
    