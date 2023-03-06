/*!
 * Charts - ICOCrypto v2.1.0 by Softnio.
**/
NioApp = (function (NioApp, $, window) {
    "use strict";
	var $chart = $('.chart-data'), $chart_s2 = $('.chart-data-s2'), $chart_s1 = $('.chart-data-s1');
    
	NioApp.Chart = {};
	
    var $win		= $(window);
    
	// ChartsJS @v1.0
    NioApp.Chart.ChartJs = function () {
        
        NioApp.Chart.ChartJs.Doughnut = function (_canvas, _titles, _colors, _amounts, _canvas_border, _canvas_cutout) {
            if ($('#'+_canvas).length) {
                var _canvas_el = document.getElementById(_canvas).getContext("2d");
                var doughnut_chart = new Chart(_canvas_el, {
                    type: 'doughnut',
                    data: {
                        labels: _titles,
                        datasets: [{
                            label: "949",
                            lineTension: 0,
                            backgroundColor: _colors,
                            borderColor: _canvas_border,
                            borderWidth:2,
                            hoverBorderColor:_canvas_border,
                            data: _amounts,
                        }]
                    },
                    options: {
                        legend: {
                            display: false,
                            labels: {
                                boxWidth:10,
                                fontColor: '#000'
                            }
                        },
                        rotation: -2,
                        cutoutPercentage:_canvas_cutout,
                        responsive: true,
                        maintainAspectRatio: false,
                        tooltips: {
                            callbacks: {
                                title: function(tooltipItem, data) {
                                    return data['labels'][tooltipItem[0]['index']];
                                },
                                label: function(tooltipItem, data) {
                                    return data['datasets'][0]['data'][tooltipItem['index']] + ' %';
                                }
                            },
                            backgroundColor: '#eff6ff',
                            titleFontSize: 13,
                            titleFontColor: '#6783b8',
                            titleMarginBottom:10,
                            bodyFontColor: '#9eaecf',
                            bodyFontSize: 14,
                            bodySpacing:4,
                            yPadding: 15,
                            xPadding: 15,
                            footerMarginTop: 5,
                            displayColors: false
                        }
                    }
                });
                // Resize Chart
                $win.on('resize', function(){
                    doughnut_chart.resize();
                });
            }
        }
        
        NioApp.Chart.ChartJs.Doughnut2 = function (_canvas, _titles, _colors, _amounts, _canvas_border, _canvas_cutout) {
            if ($('#'+_canvas).length) {
                var _canvas_el = document.getElementById(_canvas).getContext("2d");
                var doughnut_chart = new Chart(_canvas_el, {
                    type: 'doughnut',
                    data: {
                        labels: _titles,
                        datasets: [{
                            label: "949",
                            lineTension: 0,
                            backgroundColor: _colors,
                            borderColor: _canvas_border,
                            borderWidth: 3,
                            hoverBorderColor:_canvas_border,
                            data: _amounts,
                        }]
                    },
                    options: {
                        legend: {
                            display: false,
                            labels: {
                                boxWidth:10,
                                fontColor: '#000'
                            }
                        },
                        rotation: -2,
                        cutoutPercentage:_canvas_cutout,
                        responsive: true,
                        maintainAspectRatio: false,
                        tooltips: {
                            callbacks: {
                                title: function(tooltipItem, data) {
                                    return data['labels'][tooltipItem[0]['index']];
                                },
                                label: function(tooltipItem, data) {
                                    return data['datasets'][0]['data'][tooltipItem['index']] + ' %';
                                }
                            },
                            backgroundColor: '#eff6ff',
                            titleFontSize: 13,
                            titleFontColor: '#6783b8',
                            titleMarginBottom:10,
                            bodyFontColor: '#9eaecf',
                            bodyFontSize: 14,
                            bodySpacing:4,
                            yPadding: 15,
                            xPadding: 15,
                            footerMarginTop: 5,
                            displayColors: false
                        },
                        hover: {
                            onHover: function(e, i) {
                                if(i.length) {
                                    var _cur_idx = i[0]._index + 1, _self_can = i[0]._chart.canvas.id;
                                    $('[data-canvas="'+_self_can+'"] li').removeClass('active');
                                    $('[data-canvas="'+_self_can+'"] li:nth-child('+_cur_idx+')').addClass('active');
                                }else{
                                    $('[data-canvas="'+_self_can+'"] li').removeClass('active');
                                }
                            },
                        }
                    }
                });
                
                // Resize Chart
                $win.on('resize', function(){
                    doughnut_chart.resize();
                });
            }
        }
        
        // @since v1.6
        NioApp.Chart.ChartJs.Pie = function (_canvas, _label, _title, _colors, _colors_hover, _amounts, _canvas_border, _canvas_cutout) {
            if ($('#'+_canvas).length) {
                var _canvas_el = document.getElementById(_canvas).getContext("2d");
                
                var data_set = {
                    labels: _label,
                    titles: _title,
                    datasets: [{
                        label: "949",
                        lineTension: 0,
                        backgroundColor: _colors,
                        hoverBackgroundColor: _colors_hover,
                        borderColor: _canvas_border,
                        borderWidth:2,
                        hoverBorderColor:_canvas_border,
                        data: _amounts,
                        animationDuration: 400,
                    }]
                };
                var options_set = {
                    legend: false,
                    cutoutPercentage:0,
                    responsive: true,
                    maintainAspectRatio: false,
                    tooltips: {
                        callbacks: {
                            title: function(tooltipItem, data) {
                                return data['labels'][tooltipItem[0]['index']];
                            },
                            label: function(tooltipItem, data) {
                                return data['datasets'][0]['data'][tooltipItem['index']] + ' %';
                            }
                        },
                        backgroundColor: 'transparent',
                        titleFontSize: 11,
                        bodyFontColor: '#fff',
                        bodyFontSize: 14,
                        bodyFontStyle: 'bold',
                        bodySpacing:0,
                        yPadding: 0,
                        xPadding: 0,
                        yAlign: 'center',
                        xAlign: 'center',
                        footerMarginTop: 5,
                        displayColors: false
                    },
                    hover: {
                        onHover: function(e, i) {
                            if(i.length) {
                                var _cur_idx = i[0]._index + 1, _self_can = i[0]._chart.canvas.id;
                                $('[data-canvas="'+_self_can+'"] li').removeClass('active');
                                $('[data-canvas="'+_self_can+'"] li:nth-child('+_cur_idx+')').addClass('active');
                            }else{
                                $('[data-canvas="'+_self_can+'"] li').removeClass('active');
                            }
                        }
                    }
                };
                
                var pie_chart = new Chart(_canvas_el, {
                    type: 'pie',
                    data: data_set,
                    options: options_set
                });
                
                // Resize Chart
                $win.on('resize', function(){
                    pie_chart.resize();
                });
            }
        }
        
        if($chart.length > 0){
            $chart.each(function(){
                var $chart_data = $(this).children('li'), _canvas = $(this).data('canvas'), 
                    _canvas_border = $(this).data('border-color') ? $(this).data('border-color') : '#fff', 
                    _canvas_cutout = $(this).data('canvas-cutout') ? $(this).data('canvas-cutout') : '70', 
                    _canvas_type = $(this).data('canvas-type');
                _canvas_type = (typeof _canvas_type==='undefined' || _canvas_type==='') ? 'doughnut' : _canvas_type;
                if(typeof _canvas!=='undefined' && _canvas !=='') {
                    var item_label = [],  item_color = [], item_percent = [];
                    $chart_data.each(function(){
                        var l = $(this).data('title'), c = $(this).data('color'),  p = $(this).data('amount');
                        item_label.push(l); item_color.push(c); item_percent.push(p);
                        $(this).html('<span class="chart-c" style="background-color: ' + c + '"></span><span class="chart-l">' + l + '</span><span class="chart-p">' + p +'%</span>')
                    });
                    if (_canvas_type==='doughnut') {
                        NioApp.Chart.ChartJs.Doughnut(_canvas, item_label, item_color, item_percent,_canvas_border,_canvas_cutout);
                    } else if(_canvas_type==='pie') {
                        NioApp.Chart.ChartJs.Pie(_canvas, item_label, item_color, item_percent,_canvas_border);
                    } else if(_canvas_type==='linechart') {
                        NioApp.Chart.ChartJs.Doughnut(_canvas, item_label, item_color, item_percent,_canvas_border);
                    }
                } else {
                    console.log('Unable to draw canvas: '+_canvas);
                }
            });
        }
        
        // @since v1.6
        if($chart_s2.length > 0){
            $chart_s2.each(function(){
                var $chart_data = $(this).children('li'), _canvas = $(this).data('canvas'), 
                    _canvas_border = $(this).data('border-color') ? $(this).data('border-color') : '#fff',
                    _canvas_cutout = $(this).data('canvas-cutout') ? $(this).data('canvas-cutout') : '40',  
                    _canvas_type = $(this).data('canvas-type');
                _canvas_type = (typeof _canvas_type==='undefined' || _canvas_type==='') ? 'doughnut' : _canvas_type;
                if(typeof _canvas!=='undefined' && _canvas !=='') {
                    var item_label = [], item_title = [],  item_color = [],  item_color_hover = [],  item_percent = [];
                    $chart_data.each(function(){
                        var l = $(this).data('label'), t = $(this).data('title'), sl = $(this).data('subtitle'), c = $(this).data('color'), hc = $(this).data('color-hover'), p = $(this).data('amount');
                        item_label.push(l);item_title.push(t); item_color.push(c);  item_color_hover.push(hc); item_percent.push(p);
                        $(this).html('<div class="chart-data-item"><span class="chart-label">' + t + '</span><span class="chart-info"><span class="chart-percent">' + p +'% </span><span class="chart-sublabel">' + sl + '</span></span></div>')
                    });
                    if (_canvas_type==='doughnut') {
                        NioApp.Chart.ChartJs.Doughnut(_canvas, item_label, item_title, item_color, item_percent, _canvas_border,_canvas_cutout);
                    } else if(_canvas_type==='pie') {
                        NioApp.Chart.ChartJs.Pie(_canvas, item_label, item_title, item_color, item_color_hover, item_percent, _canvas_border);
                    } else if(_canvas_type==='linechart') {
                        NioApp.Chart.ChartJs.Doughnut(_canvas, item_label, item_title, item_color, item_percent, _canvas_border);
                    }
                } else {
                    console.log('Unable to draw canvas: '+_canvas);
                }
            });
        }
        
        if($chart_s1.length > 0){
            $chart_s1.each(function(){
                var $chart_data = $(this).children('li'), _canvas = $(this).data('canvas'), 
                    _canvas_border = $(this).data('border-color') ? $(this).data('border-color') : '#122272', 
                    _canvas_cutout = $(this).data('canvas-cutout') ? $(this).data('canvas-cutout') : '40', 
                    _canvas_type = $(this).data('canvas-type');
                _canvas_type = (typeof _canvas_type==='undefined' || _canvas_type==='') ? 'doughnut' : _canvas_type;
                if(typeof _canvas!=='undefined' && _canvas !=='') {
                    var item_label = [],  item_color = [],  item_color_hover = [],  item_percent = [];
                    $chart_data.each(function(){
                        var l = $(this).data('title'), sl = $(this).data('subtitle'), c = $(this).data('color'), hc = $(this).data('color-hover'), p = $(this).data('amount');
                        item_label.push(l); item_color.push(c);  item_color_hover.push(hc); item_percent.push(p);
                        $(this).html('<span class="chart-l">' + l + '</span><span class="chart-p" style="background-color: '+ c +'" ><span>' + p +'%</span></span>')
                    });
                    for(var i=0; i < $chart_data.length + 1; i++){
                        $chart_data.eq(i-1).addClass('chart-index-'+i);
                    }
                    if (_canvas_type==='doughnut') {
                        NioApp.Chart.ChartJs.Doughnut2(_canvas, item_label, item_color, item_percent, _canvas_border,_canvas_cutout);
                    } else if(_canvas_type==='pie') {
                        NioApp.Chart.ChartJs.Pie(_canvas, item_label, item_color, item_color_hover, item_percent, _canvas_border);
                    } else if(_canvas_type==='linechart') {
                        NioApp.Chart.ChartJs.Doughnut(_canvas, item_label, item_color, item_percent, _canvas_border);
                    }
                } else {
                    console.log('Unable to draw canvas: '+_canvas);
                }
            });
        } 
	};
    NioApp.components.docReady.push(NioApp.Chart.ChartJs);
	return NioApp;
})(NioApp, jQuery, window);