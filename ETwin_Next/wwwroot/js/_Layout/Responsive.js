$("#sidebarToggle, #sidebarToggleTop").on('click', function (e) {
    //debugger;
    if (window.matchMedia("(max-width: 450px)").matches) {

        var companyLogo = document.querySelector('.company_logo');
        var stiliCalcolati = window.getComputedStyle(companyLogo);
        var stile = stiliCalcolati.getPropertyValue('display');
        if (stile === 'none') {
            companyLogo.style.width = '100%';
            companyLogo.style.display = 'flex';
            $('.container-fluid').hide();

            var logo = document.getElementById('imgLogo');
            var divLogo = document.getElementById('toggleMobile');
            var divBack = document.getElementById('backDiv');
            divLogo.appendChild(logo);
            logo.style.width = '4rem';
            logo.style.height = '4rem';
            var btn = document.getElementById('sidebarToggle');
            var div = document.getElementById('togglebutton_container');
            div.style.alignItems = 'center';
            div.insertBefore(btn, div.firstChild);

            var container = document.getElementById('backToggle_container');
            container.style.padding = '15px';
            container.style.alignItems = 'center';

            div.style.width = '33%';
            div.style.justifyContent = 'right';

            divBack.style.width = '33%';
            divBack.style.justifyContent = 'left';

            divLogo.style.width = '33%';
            divLogo.style.justifyContent = 'center';
            //container.insertBefore(logo, container.firstChild);
            container.appendChild(divLogo);
            container.appendChild(div);
            var contentWrappers = document.querySelectorAll('#wrapper #content-wrapper');
            contentWrappers.forEach(function (contentWrapper) {
                contentWrapper.style.display = 'none';
                contentWrapper.style.width = '0%';
            });


            var navLinkSpans = document.querySelectorAll('.sidebar .nav-item .nav-link span');
            navLinkSpans.forEach(function (span) {
                span.style.fontSize = '1rem';
                span.style.display = 'inline-block';
            });
        }
        else {
            var element = document.getElementById("imgLogo");
            var toggle = document.getElementById("sidebarToggle");
            var myDiv = document.getElementById("menuNav");
            myDiv.insertBefore(toggle, myDiv.firstChild);
            myDiv.insertBefore(element, myDiv.firstChild);
            $('#menu').hide();
            companyLogo.style.width = '0%';
            companyLogo.style.display = 'none !important';
            $('.container-fluid').show();

            var contentWrappers = document.querySelectorAll('#wrapper #content-wrapper');
            contentWrappers.forEach(function (contentWrapper) {
                contentWrapper.style.display = 'flex !important';
                contentWrapper.style.width = '100%';
            });
        }
    }
    else {
        if (levelType === "LevelOne") {
            $('#sidebarToggleLeft').hide();
        }
        else {
            $('#sidebarToggleLeft').show();
        }
        $("body").toggleClass("sidebar-toggled");
        $(".sidebar").toggleClass("toggled");
        $('.company_logo div').css({ 'justify-content': 'space-between' });
        $('#togglebutton_container').css({ 'margin-right': '20px' });
        $('#sidebarToggle').css({ 'margin-right': '20px' });
        $('#backbtn').show();
        $('.searchbar').show();
        $('.hidePart').show();
        if ($(".sidebar").hasClass("toggled")) {
            $('#sidebarToggleLeft').hide();
            $('.company_logo div').css({ 'justify-content': 'center' });
            $('#togglebutton_container').css({ 'margin-right': '0px' });
            $('#sidebarToggle').css({ 'margin-right': '0px' });
            $('#col-6').removeClass('company_logo_dimension');
            $('.sidebar .collapse').collapse('hide');
            $('.hidePart').hide();
            $('.searchbar').hide();
            $('#backbtn').hide();
        };
    }
});