/*!
 * Countdown.js
 * Version: 2.0 - Vanilla JS build
 *
 * Copyright Enabled 
 * Released under the ThemeForest License. Usage prohibited otherwise.
 */
function countdownCall(){
	function countdown(dateEnd) {
		var timer, years, days, hours, minutes, seconds;
		dateEnd = new Date(dateEnd);
		dateEnd = dateEnd.getTime();
		if (isNaN(dateEnd)) {return;}
		timer = setInterval(calculate, 1);
		function calculate() {
			var dateStart = new Date();
			var dateStart = new Date(dateStart.getUTCFullYear(), dateStart.getUTCMonth(), dateStart.getUTCDate(), dateStart.getUTCHours(), dateStart.getUTCMinutes(), dateStart.getUTCSeconds());
			var timeRemaining = parseInt((dateEnd - dateStart.getTime()) / 1000)
			if (timeRemaining >= 0) {
				years = parseInt(timeRemaining / 31536000);
				timeRemaining = (timeRemaining % 31536000);
				days = parseInt(timeRemaining / 86400);
				timeRemaining = (timeRemaining % 86400);
				hours = parseInt(timeRemaining / 3600);
				timeRemaining = (timeRemaining % 3600);
				minutes = parseInt(timeRemaining / 60);
				timeRemaining = (timeRemaining % 60);
				seconds = parseInt(timeRemaining);
				if (document.querySelectorAll('.countdown').length) {
					document.getElementById('years').innerHTML = parseInt(years, 10);
					document.getElementById('days').innerHTML = parseInt(days, 10);
					document.getElementById('hours').innerHTML = ("0" + hours).slice(-2);
					document.getElementById('minutes').innerHTML = ("0" + minutes).slice(-2);
					document.getElementById('seconds').innerHTML = ("0" + seconds).slice(-2);
				}
			} else {return;}
		}

		function display(days, hours, minutes, seconds) {}
	}

	countdown('01/19/2030 03:14:07 AM');
}
countdownCall();