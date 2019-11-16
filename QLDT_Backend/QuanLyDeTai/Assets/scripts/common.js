$(document).ready(function () {
    $("#loading").removeClass("display");
    $(".main").addClass("opacity-bg");

    setInterval('window.location.reload()', 1000 * 60 * 20);

    $("#GiangVien").select2();

    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "positionClass": "toast-bottom-right",
        "preventDuplicates": true,
        "onclick": null,
        "showDuration": "100",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "show",
        "hideMethod": "hide"
    };


    $('.collapsed').on('click', function () {
        var id = $(this).attr("href").replace("#","");
        if ($(this).hasClass("active")) {
            $('#menu').removeClass("active");
            $('#menu2').removeClass("active");
            $('.collapse').removeClass("in");
            $("#"+id).removeClass("in");
            $('.collapsed').find("i.icon-submenu").removeClass("lnr-chevron-down")
            $('.collapsed').find("i.icon-submenu").addClass("lnr-chevron-left");
            $(this).attr("aria-expanded", false);
            $("#" + id).attr("aria-expanded", false);
            $(this).find("i.icon-submenu").removeClass("lnr-chevron-down")
            $(this).find("i.icon-submenu").addClass("lnr-chevron-left");
            
        }
        else {
            $('#menu').removeClass("active");
            $('#menu2').removeClass("active");
            $('.collapse').removeClass("in");
            $('.collapsed').find("i.icon-submenu").removeClass("lnr-chevron-down")
            $('.collapsed').find("i.icon-submenu").addClass("lnr-chevron-left");
            $(this).addClass('active');
            $("#" + id).addClass("in");
            $(this).attr("aria-expanded", true);
            $("#" + id).attr("aria-expanded", true);
            $(this).find("i.icon-submenu").removeClass("lnr-chevron-left")
            $(this).find("i.icon-submenu").addClass("lnr-chevron-down");
        }

    });

    

    $('.kichhoat').on('click', function () {
        var trangthai = $('#TrangThai').prop('checked');
        if (trangthai == true) {
            $('#trangthai').text("Kích hoạt");

        }
        else {
            $('#trangthai').text("Chưa kích hoạt");
        }
        var suatrangthai = $('#SuaTrangThai').prop('checked');
        if (suatrangthai == true) {
            $('#suatrangthai').text("Kích hoạt");

        }
        else {
            $('#suatrangthai').text("Chưa kích hoạt");
        }
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

    $(window).on('load', function () {

        if ($("a").hasClass("menu")) {
            $("#menu").addClass('active');
            $("#subPages").addClass("in");
            $("#menu").attr("aria-expanded", true);
            $("#subPages").attr("aria-expanded", true);
            $("#menu").find("i.icon-submenu").removeClass("lnr-chevron-left")
            $("#menu").find("i.icon-submenu").addClass("lnr-chevron-down");
        }
        if ($("a").hasClass("menu2")) {
            $("#menu2").addClass('active');
            $("#subPages2").addClass("in");
            $("#menu2").attr("aria-expanded", true);
            $("#subPages2").attr("aria-expanded", true);
            $("#menu2").find("i.icon-submenu").removeClass("lnr-chevron-left")
            $("#menu2").find("i.icon-submenu").addClass("lnr-chevron-down");
        }


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

        //$('#myTable').DataTable({
        //    "order": [[0, "asc"]],
        //    "paging": false,
        //    "info": false,
        //    "searching": false
        //});

        //$('#myTable1').DataTable({
        //    "order": [[0, "asc"]],
        //    "paging": false,
        //    "info": false,
        //    "searching": false
        //});

        //$('#TableField').DataTable({
        //    "order": [[0, "asc"]],
        //    "paging": false,
        //    "info": false,
        //    "searching": false
        //});

        //$('#TableStudent').DataTable({
        //    "order": [[0, "asc"]],
        //    "paging": false,
        //    "info": false,
        //    "searching": false
        //});
        //$('#TableTeacher').DataTable({
        //    "order": [[0, "asc"]],
        //    "paging": false,
        //    "info": false,
        //    "searching": false
        //});
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

function myFunction() {
    var x = document.getElementById("snackbar");
    x.className = "show";
    setTimeout(function () {
        x.className = x.className.replace("show", "");
    }, 3000);
}






