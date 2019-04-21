$(document).ready(function() {

	var table = '.mytable'
	$(window).on('load', function() {
		$('.pagination').html('')
		var trnum = 0
		var maxRows = 5
		var totalRows = $(table+' tbody tr').length
		$(table+' tr:gt(0)').each(function(){
			trnum++
			if(trnum > maxRows){
				$(this).hide()
			}
			if(trnum <= maxRows){
				$(this).show()
			}
		})
		if(totalRows > maxRows){
			var pagenum = Math.ceil(totalRows/maxRows)
			
			$('.pagination').append('<li class="page-item previous-all"><a class="page-link" href="#" aria-label="Previous"><span aria-hidden="true"<i class="fa fa-angle-double-left"></i></span><span class="sr-only">Previous</span></a></li><li class="page-item previous"><a class="page-link" href="#" aria-label="Previous"><span aria-hidden="true"<i class="fa fa-angle-left"></i></span><span class="sr-only">Previous</span></a></li>').show();
			for(var i=1;i<=pagenum;){
				
					$('.pagination').append('<li class="page-item page  page-number-'+i+'" data-page="'+i+'">\<span>'+ i++ +'<span class="sr-only">(current)</span></span>\</li>').show()

			}
			var num=--i;
			$('.pagination').append('<li class="page-item next"><a class="page-link" href="#" aria-label="Previous"><span aria-hidden="true"<i class="fa fa-angle-right"></i></span><span class="sr-only">Previous</span></a></li><li class="page-item next-all"><a class="page-link" href="#" aria-label="Previous"><span aria-hidden="true"<i class="fa fa-angle-double-right"></i></span><span class="sr-only">Previous</span></a></li>').show();
		}
		$('.page-number-1').addClass('active')
		$('.page-number-1').addClass('abc')
		$('.previous-all').on('click',function(){
			var pageNum = 1;
			var trIndex = 0;
			$('.pagination li').removeClass('active')
			$('.pagination li').removeClass('abc')
			$('.page-number-1').addClass('active')
			$('.page-number-1').addClass('abc')
			$(table+' tr:gt(0)').each(function(){
				trIndex++
				if(trIndex > (maxRows*pageNum) || trIndex <= ((maxRows*pageNum)-maxRows)){
					$(this).hide()
				} else{
					$(this).show()
				}
			})
		})
		$('.previous').on('click',function(){	
				var pageNum = $('.abc').attr('data-page')
				
				if(pageNum==1){
				}
				else{
				pageNum=Number(pageNum)
				pageNum=pageNum-1;
				
				var trIndex = 0;
				$('.pagination li').removeClass('active')
				$('.pagination li').removeClass('abc')
				$('.page-number-'+pageNum).addClass('active')
				$('.page-number-'+pageNum).addClass('abc')
				$(table+' tr:gt(0)').each(function(){
					trIndex++
					if(trIndex > (maxRows*pageNum) || trIndex <= ((maxRows*pageNum)-maxRows)){
						$(this).hide()
					} else{
						$(this).show()
					}
				})
			}
		})
		$('.next').on('click',function(){	
				pageNum = $('.abc').attr('data-page')
				
				if(pageNum==num){
				}
				else{
				pageNum=Number(pageNum)
				pageNum=pageNum+1;
				
				var trIndex = 0;
				$('.pagination li').removeClass('active')
				$('.pagination li').removeClass('abc')
				$('.page-number-'+pageNum).addClass('active')
				$('.page-number-'+pageNum).addClass('abc')
				$(table+' tr:gt(0)').each(function(){
					trIndex++
					if(trIndex > (maxRows*pageNum) || trIndex <= ((maxRows*pageNum)-maxRows)){
						$(this).hide()
					} else{
						$(this).show()
					}
				})
			}
		})
		$('.next-all').on('click',function(){
			var pageNum = num;
			var trIndex = 0;
			$('.pagination li').removeClass('active')
			$('.pagination li').removeClass('abc')
			$('.page-number-'+pageNum).addClass('active')
			$('.page-number-'+pageNum).addClass('abc')
			$(table+' tr:gt(0)').each(function(){
				trIndex++
				if(trIndex > (maxRows*pageNum) || trIndex <= ((maxRows*pageNum)-maxRows)){
					$(this).hide()
				} else{
					$(this).show()
				}
			})
		})
		$('.page').on('click',function(){
			var pageNum = $(this).attr('data-page')
			var trIndex = 0;
			$('.pagination li').removeClass('active')
			$('.pagination li').removeClass('abc')
			$('.page-number-'+pageNum).addClass('active')
			$('.page-number-'+pageNum).addClass('abc')
			$(table+' tr:gt(0)').each(function(){
				trIndex++
				if(trIndex > (maxRows*pageNum) || trIndex <= ((maxRows*pageNum)-maxRows)){
					$(this).hide()
				} else{
					$(this).show()
				}
			})
		})
	});
	
	$('#maxRows').on('change', function(){
		$('.pagination').html('')
		var trnum = 0
		var maxRows = parseInt($(this).val())
		var totalRows = $(table+' tbody tr').length
		$(table+' tr:gt(0)').each(function(){
			trnum++
			if(trnum > maxRows){
				$(this).hide()
			}
			if(trnum <= maxRows){
				$(this).show()
			}
		})
		if(totalRows > maxRows){
			var pagenum = Math.ceil(totalRows/maxRows)
			
			$('.pagination').append('<li class="page-item previous-all"><a class="page-link" href="#" aria-label="Previous"><span aria-hidden="true"<i class="fa fa-angle-double-left"></i></span><span class="sr-only">Previous</span></a></li><li class="page-item previous"><a class="page-link" href="#" aria-label="Previous"><span aria-hidden="true"<i class="fa fa-angle-left"></i></span><span class="sr-only">Previous</span></a></li>').show();
			for(var i=1;i<=pagenum;){
				
					$('.pagination').append('<li class="page-item page  page-number-'+i+'" data-page="'+i+'">\<span>'+ i +'<span class="sr-only">(current)</span></span>\</li>').show()
					i++
			}
			var num=--i;
			$('.pagination').append('<li class="page-item next"><a class="page-link" href="#" aria-label="Previous"><span aria-hidden="true"<i class="fa fa-angle-right"></i></span><span class="sr-only">Previous</span></a></li><li class="page-item next-all"><a class="page-link" href="#" aria-label="Previous"><span aria-hidden="true"<i class="fa fa-angle-double-right"></i></span><span class="sr-only">Previous</span></a></li>').show();
		}
		$('.page-number-1').addClass('active')
		$('.page-number-1').addClass('abc')
		$('.previous-all').on('click',function(){
			var pageNum = 1;
			var trIndex = 0;
			$('.pagination li').removeClass('active')
			$('.pagination li').removeClass('abc')
			$('.page-number-1').addClass('active')
			$('.page-number-1').addClass('abc')
			$(table+' tr:gt(0)').each(function(){
				trIndex++
				if(trIndex > (maxRows*pageNum) || trIndex <= ((maxRows*pageNum)-maxRows)){
					$(this).hide()
				} else{
					$(this).show()
				}
			})
		})
		$('.previous').on('click',function(){	
				var pageNum = $('.abc').attr('data-page')
				
				if(pageNum==1){
				}
				else{
				pageNum=Number(pageNum)
				pageNum=pageNum-1;
				
				var trIndex = 0;
				$('.pagination li').removeClass('active')
				$('.pagination li').removeClass('abc')
				$('.page-number-'+pageNum).addClass('active')
				$('.page-number-'+pageNum).addClass('abc')
				$(table+' tr:gt(0)').each(function(){
					trIndex++
					if(trIndex > (maxRows*pageNum) || trIndex <= ((maxRows*pageNum)-maxRows)){
						$(this).hide()
					} else{
						$(this).show()
					}
				})
			}
		})
		$('.next').on('click',function(){	
				pageNum = $('.abc').attr('data-page')
				
				if(pageNum==num){
				}
				else{
				pageNum=Number(pageNum)
				pageNum=pageNum+1;
				
				var trIndex = 0;
				$('.pagination li').removeClass('active')
				$('.pagination li').removeClass('abc')
				$('.page-number-'+pageNum).addClass('active')
				$('.page-number-'+pageNum).addClass('abc')
				$(table+' tr:gt(0)').each(function(){
					trIndex++
					if(trIndex > (maxRows*pageNum) || trIndex <= ((maxRows*pageNum)-maxRows)){
						$(this).hide()
					} else{
						$(this).show()
					}
				})
			}
		})
		$('.next-all').on('click',function(){
			var pageNum = num;
			var trIndex = 0;
			$('.pagination li').removeClass('active')
			$('.pagination li').removeClass('abc')
			$('.page-number-'+pageNum).addClass('active')
			$('.page-number-'+pageNum).addClass('abc')
			$(table+' tr:gt(0)').each(function(){
				trIndex++
				if(trIndex > (maxRows*pageNum) || trIndex <= ((maxRows*pageNum)-maxRows)){
					$(this).hide()
				} else{
					$(this).show()
				}
			})
		})
		$('.page').on('click',function(){
			var pageNum = $(this).attr('data-page')
			var trIndex = 0;
			$('.pagination li').removeClass('active')
			$('.pagination li').removeClass('abc')
			$('.page-number-'+pageNum).addClass('active')
			$('.page-number-'+pageNum).addClass('abc')
			$(table+' tr:gt(0)').each(function(){
				trIndex++
				if(trIndex > (maxRows*pageNum) || trIndex <= ((maxRows*pageNum)-maxRows)){
					$(this).hide()
				} else{
					$(this).show()
				}
			})
		})
	});
	
			
	/*-----------------------------------/
	/*	TOP NAVIGATION AND LAYOUT
	/*----------------------------------*/

	$('.btn-toggle-fullwidth').on('click', function() {
		if(!$('body').hasClass('layout-fullwidth')) {
			$('body').addClass('layout-fullwidth');

		} else {
			$('body').removeClass('layout-fullwidth');
			$('body').removeClass('layout-default'); // also remove default behaviour if set
		}

		$(this).find('.lnr').toggleClass('lnr-arrow-left-circle lnr-arrow-right-circle');

		if($(window).innerWidth() < 1025) {
			if(!$('body').hasClass('offcanvas-active')) {
				$('body').addClass('offcanvas-active');
			} else {
				$('body').removeClass('offcanvas-active');
			}
		}
	});

	$(window).on('load', function() {
		if($(window).innerWidth() < 1025) {
			$('.btn-toggle-fullwidth').find('.icon-arrows')
			.removeClass('icon-arrows-move-left')
			.addClass('icon-arrows-move-right');
		}

		// adjust right sidebar top position
		$('.right-sidebar').css('top', $('.navbar').innerHeight());

		// if page has content-menu, set top padding of main-content
		if($('.has-content-menu').length > 0) {
			$('.navbar + .main-content').css('padding-top', $('.navbar').innerHeight());
		}

		// for shorter main content
		if($('.main').height() < $('#sidebar-nav').height()) {
			$('.main').css('min-height', $('#sidebar-nav').height());
		}
	});


	/*-----------------------------------/
	/*	SIDEBAR NAVIGATION
	/*----------------------------------*/

	$('.sidebar a[data-toggle="collapse"]').on('click', function() {
		if($(this).hasClass('collapsed')) {
			$(this).addClass('active');
		} else {
			$(this).removeClass('active');
		}
	});

	if( $('.sidebar-scroll').length > 0 ) {
		$('.sidebar-scroll').slimScroll({
			height: '95%',
			wheelStep: 2,
		});
	}


	/*-----------------------------------/
	/*	PANEL FUNCTIONS
	/*----------------------------------*/

	// panel remove
	$('.panel .btn-remove').click(function(e){

		e.preventDefault();
		$(this).parents('.panel').fadeOut(300, function(){
			$(this).remove();
		});
	});

	// panel collapse/expand
	var affectedElement = $('.panel-body');

	$('.panel .btn-toggle-collapse').clickToggle(
		function(e) {
			e.preventDefault();

			// if has scroll
			if( $(this).parents('.panel').find('.slimScrollDiv').length > 0 ) {
				affectedElement = $('.slimScrollDiv');
			}

			$(this).parents('.panel').find(affectedElement).slideUp(300);
			$(this).find('i.lnr-chevron-up').toggleClass('lnr-chevron-down');
		},
		function(e) {
			e.preventDefault();

			// if has scroll
			if( $(this).parents('.panel').find('.slimScrollDiv').length > 0 ) {
				affectedElement = $('.slimScrollDiv');
			}

			$(this).parents('.panel').find(affectedElement).slideDown(300);
			$(this).find('i.lnr-chevron-up').toggleClass('lnr-chevron-down');
		}
	);


	/*-----------------------------------/
	/*	PANEL SCROLLING
	/*----------------------------------*/

	if( $('.panel-scrolling').length > 0) {
		$('.panel-scrolling .panel-body').slimScroll({
			height: '430px',
			wheelStep: 2,
		});
	}

	if( $('#panel-scrolling-demo').length > 0) {
		$('#panel-scrolling-demo .panel-body').slimScroll({
			height: '175px',
			wheelStep: 2,
		});
	}

	/*-----------------------------------/
	/*	TODO LIST
	/*----------------------------------*/

	$('.todo-list input').change( function() {
		if( $(this).prop('checked') ) {
			$(this).parents('li').addClass('completed');
		}else {
			$(this).parents('li').removeClass('completed');
		}
	});


	/*-----------------------------------/
	/* TOASTR NOTIFICATION
	/*----------------------------------*/

	if($('#toastr-demo').length > 0) {
		toastr.options.timeOut = "false";
		toastr.options.closeButton = true;
		toastr['info']('Hi there, this is notification demo with HTML support. So, you can add HTML elements like <a href="#">this link</a>');

		$('.btn-toastr').on('click', function() {
			$context = $(this).data('context');
			$message = $(this).data('message');
			$position = $(this).data('position');

			if($context == '') {
				$context = 'info';
			}

			if($position == '') {
				$positionClass = 'toast-left-top';
			} else {
				$positionClass = 'toast-' + $position;
			}

			toastr.remove();
			toastr[$context]($message, '' , { positionClass: $positionClass });
		});

		$('#toastr-callback1').on('click', function() {
			$message = $(this).data('message');

			toastr.options = {
				"timeOut": "300",
				"onShown": function() { alert('onShown callback'); },
				"onHidden": function() { alert('onHidden callback'); }
			}

			toastr['info']($message);
		});

		$('#toastr-callback2').on('click', function() {
			$message = $(this).data('message');

			toastr.options = {
				"timeOut": "10000",
				"onclick": function() { alert('onclick callback'); },
			}

			toastr['info']($message);

		});

		$('#toastr-callback3').on('click', function() {
			$message = $(this).data('message');

			toastr.options = {
				"timeOut": "10000",
				"closeButton": true,
				"onCloseClick": function() { alert('onCloseClick callback'); }
			}

			toastr['info']($message);
		});
	}
});

// toggle function
$.fn.clickToggle = function( f1, f2 ) {
	return this.each( function() {
		var clicked = false;
		$(this).bind('click', function() {
			if(clicked) {
				clicked = false;
				return f2.apply(this, arguments);
			}

			clicked = true;
			return f1.apply(this, arguments);
		});
	});

}





