
//Chart 1
var optionsChart1 = {
	chart: {
		type: 'area',
		toolbar: {
			show: false
		},
		animations: {
			enabled: false,
		}
	},
	series: [{
		name: 'Mobile',
		data: [30, 40, 45, 50, 49, 60, 70],
	}, {
		name: 'PWA',
		data: [40, 50, 65, 70, 89, 90, 95],
	}],
	fill: {
		type: "gradient",
		gradient: {
			shadeIntensity: 1,
			opacityFrom: 0.7,
			opacityTo: 0.9,
			stops: [0, 90, 100]
		}
	},
	xaxis: {
			categories: [1991, 1992, 1993, 1994, 1995, 1996, 1997]
	}
}

var chartDemo1 = new ApexCharts(document.querySelectorAll("#charts-demo-1")[0], optionsChart1);
chartDemo1.render();


var optionsChart2 = {
	series: [{
		name: 'Desktop',
		data: [44, 55, 57, 56, 61, 58, 63, 60, 66]
	}, {
		name: 'Mobile',
		data: [76, 85, 101, 98, 87, 105, 91, 114, 94]
	}, {
		name: 'Tablet',
		data: [35, 41, 36, 26, 45, 48, 52, 53, 41]
	}],
	chart: {
		type: 'bar',
		height: 250,
		toolbar: {
			show: false
		},
		animations: {
			enabled: false,
		}
	},
	plotOptions: {
		bar: {
			horizontal: false,
			columnWidth: '55%',
			endingShape: 'rounded'
		},
	},
	dataLabels: {
		enabled: false
	},
	stroke: {
		show: true,
		width: 2,
		colors: ['transparent']
	},
	xaxis: {
		categories: ['Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct'],
	},
	fill: {
		opacity: 1
	},
	tooltip: {
		y: {
			formatter: function(val) {
				return "$ " + val + " thousands"
			}
		}
	}
};

var chartDemo2 = new ApexCharts(document.querySelectorAll("#charts-demo-2")[0], optionsChart2);
chartDemo2.render();


var optionsChart3 = {
	legend: {
	  position: 'bottom'
	},
	series: [64, 55, 35],
	chart: {
		width: '100%',
		type: 'pie',
		toolbar: {
			show: false
		},
		animations: {
			enabled: false,
		},

	},
	labels: ['Mobile', 'Desktop', 'Laptop'],
};

var chartDemo3 = new ApexCharts(document.querySelectorAll("#charts-demo-3")[0], optionsChart3);
chartDemo3.render();


