// Toast alert
function toast(e) {
    var x = document.getElementById("snackbar");
    switch (e) {
        case "success":
            x.style.color = "#3c763d";
            x.style.backgroundColor = "#dff0d8";
            x.style.borderColor = "#d6e9c6";
            break;
        case "info":
            x.style.color = "#31708f";
            x.style.backgroundColor = "#d9edf7";
            x.style.borderColor = "#bce8f1";
            break;
        case "warning":
            x.style.color = "#8a6d3b";
            x.style.backgroundColor = "#fcf8e3";
            x.style.borderColor = "#faebcc";
            break;
        case "danger":
            x.style.color = "#a94442";
            x.style.backgroundColor = "#f2dede";
            x.style.borderColor = "#ebccd1";
            break;
    }
    x.className = "show";
    setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
}


$(function () {

    $(document).on("click", function (e) {
        var $item = $(".rad-dropmenu-item");
        if ($item.hasClass("active")) {
            $item.removeClass("active");
        }
    });


    $(".rad-dropdown >.rad-menu-item").on('click', function (e) {
        e.stopPropagation();
        $(".rad-dropmenu-item").removeClass("active");
        $(this).next(".rad-dropmenu-item").toggleClass("active");
    });

    $(document).on("click", function (e) {
        var $item = $(".rad-dropmenu-user");
        if ($item.hasClass("active")) {
            $item.removeClass("active");
        }
    });


    $(".rad-dropdown >.rad-menu-item").on('click', function (e) {
        e.stopPropagation();
        $(".rad-dropmenu-user").removeClass("active");
        $(this).next(".rad-dropmenu-user").toggleClass("active");
    });
});

function drdDeleteNotif() {
    {
        document.getElementById("myDropdown").classList.toggle("show");
    }

    // Close the dropdown if the user clicks outside of it
    window.onclick = function (event) {
        if (!event.target.matches('.dropbtn')) {

            var dropdowns = document.getElementsByClassName("dropdown-content");
            var i;
            for (i = 0; i < dropdowns.length; i++) {
                var openDropdown = dropdowns[i];
                if (openDropdown.classList.contains('show')) {
                    openDropdown.classList.remove('show');
                }
            }
        }
    }
}




